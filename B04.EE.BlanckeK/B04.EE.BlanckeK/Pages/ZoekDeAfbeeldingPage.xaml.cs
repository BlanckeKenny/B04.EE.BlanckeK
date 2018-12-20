using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B04.EE.BlanckeK.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace B04.EE.BlanckeK.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ZoekDeAfbeeldingPage : ContentPage
	{
        #region Constructor
        public ZoekDeAfbeeldingPage ()
		{
			InitializeComponent ();
        }
        #endregion

        #region Overrides
	    protected override void OnAppearing()
	    {
	        MixGrids();
	        MessagingCenter.Subscribe(this, Constants.Constants.MixAfbeeldingGrids, async (ZoekDeAfbeeldingViewModel vm) =>
	        {
	            await Task.Delay(0);
	            MixGrids();
	        });
	    }

	    protected override void OnDisappearing()
	    {
	        MessagingCenter.Unsubscribe<ZoekDeAfbeeldingViewModel>(this, Constants.Constants.MixAfbeeldingGrids);
	    }
        #endregion

        #region Methods
	    private void MixGrids()
	    {
	        var rnd = new Random();
	        List<int> nietGesorteerdeLijst = new List<int> { 0, 1, 2 };
	        var result = nietGesorteerdeLijst.OrderBy(item => rnd.Next()).ToList();
	        Image1.SetValue(Grid.ColumnProperty, result[0]);
	        Image2.SetValue(Grid.ColumnProperty, result[1]);
	        Image3.SetValue(Grid.ColumnProperty, result[2]);
	    }
        #endregion

        #region Events
	    private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
	    {
	        var antwoord = ((Image)sender).AutomationId;
	        BindingContext = ((Image)sender).BindingContext;
	        if (BindingContext == null) return;
	        ZoekDeAfbeeldingViewModel vm = BindingContext as ZoekDeAfbeeldingViewModel;
	        vm?.ControleerCommand.Execute(antwoord);
	        MixGrids();
	    }
        #endregion

    }
}