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
	public partial class ZoekHetWoordPage : ContentPage
	{
        #region Constructor
	    public ZoekHetWoordPage()
	    {
	        InitializeComponent();
	    }
        #endregion

	    #region Overrides
	    protected override void OnAppearing()
	    {
	        MixGrids();
	        MessagingCenter.Subscribe(this, Constants.Constants.MixWoordGrids, async (ZoekHetWoordViewModel vm) =>
	        {
	            await Task.Delay(0);
	            MixGrids();
	        });
	    }

	    protected override void OnDisappearing()
	    {
	        MessagingCenter.Unsubscribe<ZoekHetWoordViewModel>(this, Constants.Constants.MixWoordGrids);
	    }
        #endregion

	    #region Methods
	    private void MixGrids()
	    {
	        var rnd = new Random();
	        List<int> nietGesorteerdeLijst = new List<int> { 0, 1, 2 };
	        var result = nietGesorteerdeLijst.OrderBy(item => rnd.Next()).ToList();
	        JuisteWoord.SetValue(Grid.ColumnProperty, result[0]);
	        Woord1.SetValue(Grid.ColumnProperty, result[1]);
	        Woord2.SetValue(Grid.ColumnProperty, result[2]);
	    }
        #endregion

	    #region Events
	    private void JuisteWoord_OnClicked(object sender, EventArgs e)
	    {
	        var antwoord = ((Button)sender).AutomationId;
	        BindingContext = ((Button)sender).BindingContext;
	        if (BindingContext == null) return;
	        ZoekHetWoordViewModel vm = BindingContext as ZoekHetWoordViewModel;
	        vm?.ControleerCommand.Execute(antwoord);
	        MixGrids();
        }
        #endregion
    }
}