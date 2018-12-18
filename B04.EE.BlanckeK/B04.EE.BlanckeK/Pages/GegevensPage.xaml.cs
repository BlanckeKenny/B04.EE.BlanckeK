using System.Threading.Tasks;
using B04.EE.BlanckeK.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace B04.EE.BlanckeK.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GegevensPage : ContentPage
	{
		public GegevensPage ()
		{
			InitializeComponent ();
		    DependencyService.Get<ITextToSpeech>().Speak("Welkom bij Leren lezen");
        }
	}
}