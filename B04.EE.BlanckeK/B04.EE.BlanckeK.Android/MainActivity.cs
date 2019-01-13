using System.Linq;
using System.Threading.Tasks;
using Android.Speech.Tts;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;

namespace B04.EE.BlanckeK.Droid
{
    [Activity(Label = "Leren Lezen", Theme = "@style/MainTheme")]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        internal static MainActivity Instance { get; private set; }
        private const int RequestStorageId = 0;
        private const int RequestSpeechId = 1;

        private readonly string[] _permissions =
        {
            Manifest.Permission.WriteExternalStorage,
            Manifest.Permission.ReadExternalStorage
        };

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);
            Instance = this;
            await RequestPermission();
            Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        private void InstallVoicesIfNecresssary()
        {
            // Als ik deze method gebruik in de onCreate() werkt deze zoals het moet (enkel de eerste keer) 
            // en gaat hij naar het menu om een taal/stem te installeren. Maar doet hij dat ook als er al een taal/stem
            // geinstalleerd is. Ik vind (na uren zoeken) geen enkele manier hoe ik kan aftesten of er al een taal geinstalleerd is of niet.
            var checkTtsIntent = new Intent();
            checkTtsIntent.SetAction(TextToSpeech.Engine.ActionCheckTtsData);
            StartActivityForResult(checkTtsIntent, RequestSpeechId);
        }

        protected override void OnActivityResult(int req, Result res, Intent data)
        {
            if (req == RequestSpeechId)
            {
                var ttsLoadIntent = new Intent();

                if (res == Result.FirstUser)
                {
                    ttsLoadIntent.SetAction(TextToSpeech.Engine.ActionInstallTtsData);
                    StartActivity(ttsLoadIntent);
                }
            }
            base.OnActivityResult(req, res, data);
        }

        private async Task RequestPermission()
        {
            const string permission = Manifest.Permission.WriteExternalStorage;

            if (CheckSelfPermission(permission) != (int) Permission.Granted)
            {
                await Task.Delay(0);
                RequestPermissions(_permissions, RequestStorageId);
            }
        }
    }
}
