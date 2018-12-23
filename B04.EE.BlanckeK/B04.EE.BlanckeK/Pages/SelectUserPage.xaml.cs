using B04.EE.BlanckeK.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace B04.EE.BlanckeK.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectUserPage : ContentPage
	{
		public SelectUserPage ()
		{
			InitializeComponent ();
		}

	    private async void SwipeGestureRecognizer_OnSwiped(object sender, SwipedEventArgs e)
	    {
	        bool answer = await DisplayAlert("Bent u zeker?", "Bent u zeker dat u deze speler wilt verwijderen", "Ja", "Nee");
	        if (answer == false) return;
            SelectUserViewModel vm = BindingContext as SelectUserViewModel;
	        vm?.DeletePlayerCommand.Execute(null);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SelectUserViewModel vm = BindingContext as SelectUserViewModel;
            vm?.UpdateUserListCommand.Execute(null);
            
        }
    }
}