using B04.EE.BlanckeK.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace B04.EE.BlanckeK.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GegevensPage : ContentPage
    {
        #region Constructor
        public GegevensPage()
        {
            InitializeComponent();
/*            VulNiveauLijst();*/
        }
        #endregion

/*        #region Methods
        public void VulNiveauLijst()
        {
            NiveauPicker.Items.Add(Niveau.Makkelijk.ToString());
            NiveauPicker.Items.Add(Niveau.Normaal.ToString());
            NiveauPicker.Items.Add(Niveau.Moeilijk.ToString());
            NiveauPicker.Items.Add(Niveau.Gevorderd.ToString());
            NiveauPicker.TextColor = Color.Accent;
            NiveauPicker.SelectedIndex = 0;
        }
        #endregion*/

    }
}