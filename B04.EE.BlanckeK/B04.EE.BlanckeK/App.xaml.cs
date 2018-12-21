using B04.EE.BlanckeK.Interfaces;
using B04.EE.BlanckeK.Interfaces.Mock;
using B04.EE.BlanckeK.ViewModels;
using FreshMvvm;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace B04.EE.BlanckeK
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            FreshIOC.Container.Register<IGameService, SpelInMemoryService>();
            FreshIOC.Container.Register(DependencyService.Get<ITextToSpeech>());
            MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<StartViewModel>());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
