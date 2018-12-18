using Android.App;
using Android.Content;
using Android.OS;
using Android.Speech.Tts;

namespace B04.EE.BlanckeK.Droid
{
    [Activity(Label = "Leren Lezen", Theme = "@style/MainTheme")]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        internal static MainActivity Instance { get; private set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            Instance = this;
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

        }

        protected override void OnActivityResult(int req, Result res, Intent data)
        {
            var installTts = new Intent();
            installTts.SetAction(TextToSpeech.Engine.ActionCheckTtsData);
            StartActivity(installTts);

            if (req == 103)
            {
                // we need a new language installed
                var installTTS = new Intent();
                installTTS.SetAction(TextToSpeech.Engine.ActionInstallTtsData);
                StartActivity(installTTS);
            }
        }
    }
}