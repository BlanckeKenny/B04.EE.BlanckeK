using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Speech.Tts;
using Android.Support.V4.App;

namespace B04.EE.BlanckeK.Droid
{
    [Activity(Label = "Leren Lezen", Theme = "@style/MainTheme")]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        internal static MainActivity Instance { get; private set; }

        readonly string[] PermissionsLocation =
        {
            Manifest.Permission.WriteExternalStorage,
            Manifest.Permission.ReadExternalStorage
        };

        const int RequestLocationId = 0;

       


        protected override async void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);
            Instance = this;
            await GetLocationPermissionAsync();
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

        }

        protected override void OnActivityResult(int req, Result res, Intent data)
        {
            
        }

        async Task GetLocationPermissionAsync()
        {
            //Check to see if any permission in our group is available, if one, then all are

/*            var installTts = new Intent();
            installTts.SetAction(TextToSpeech.Engine.ActionCheckTtsData);
            StartActivity(installTts);

            var installTTS = new Intent();
            installTTS.SetAction(TextToSpeech.Engine.ActionInstallTtsData);
            StartActivity(installTTS);*/

            const string permission = Manifest.Permission.WriteExternalStorage;
            if (CheckSelfPermission(permission) == (int)Permission.Granted)
            {
                return;
            }



            //Finally request permissions with the list of permissions and Id
            RequestPermissions(PermissionsLocation, RequestLocationId);
        }
    }
}