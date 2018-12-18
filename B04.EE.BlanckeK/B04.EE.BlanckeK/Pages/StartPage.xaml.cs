using B04.EE.BlanckeK.Interfaces;
using Xamarin.Forms;

namespace B04.EE.BlanckeK.Pages
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
            DependencyService.Get<ITextToSpeech>().Speak("test");
        }
    }
}
