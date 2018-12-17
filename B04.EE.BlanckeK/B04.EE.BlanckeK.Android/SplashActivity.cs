using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace B04.EE.BlanckeK.Droid
{
    [Activity(Label = "Leren lezen", Icon = "@drawable/icon", 
              Theme = "@style/MainTheme.Splash", MainLauncher = true,
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashActivity : Android.Support.V7.App.AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Task.Delay(1000).Wait();
            StartActivity(new Intent(this, typeof(MainActivity)));
            // Create your application here
        }
    }
}