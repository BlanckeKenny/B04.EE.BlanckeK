using System;
using System.Threading.Tasks;
using B04.EE.BlanckeK.Interfaces;
using B04.EE.BlanckeK.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using B04.EE.BlanckeK.Extensions;

namespace B04.EE.BlanckeK.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GegevensPage : ContentPage
	{
	    private string _entryToCheck;
	    private bool _isGeldigeNaam;
	    private bool _isGeldigeLeeftijd;


        public GegevensPage ()
		{
		    InitializeComponent();
            NiveauPicker.Items.Add(Niveau.Makkelijk.ToString());
            NiveauPicker.Items.Add(Niveau.Normaal.ToString());
            NiveauPicker.Items.Add(Niveau.Moeilijk.ToString());
            NiveauPicker.Items.Add(Niveau.Gevorderd.ToString());
		    NiveauPicker.TextColor = Color.Accent;
            NiveauPicker.SelectedIndex = 0;

		}

	    private void NiveauPicker_OnSelectedIndexChanged(object sender, EventArgs e)
	    {

	    }

	    private void Entry_OnTextChanged(object sender, TextChangedEventArgs e)
	    {
	        _entryToCheck = ((Entry)sender).StyleId;
	        ValidateEntry(_entryToCheck);
        }

        private void ValidateEntry(string entryToValidate)
        {
            switch (entryToValidate)
            {
                case "Voornaam":
                    _isGeldigeVoornaam = Voornaam.Text.IsValidName();
                    FirstNameValidation.Text = _isGeldigeVoornaam ? "" : "Ongeldige voornaam";
                    break;
                case "Telefoonnummer":
                    _isGeldigeTelefoon = Telefoonnummer.Text.IsValidPhoneNumber();
                    PhoneValidation.Text = _isGeldigeTelefoon ? "" : "Ongeldig telefoonnummer";
                    break;
            }
        }
}