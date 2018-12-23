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
	public partial class SearchTheImagePage : ContentPage
	{
        #region Constructor
        public SearchTheImagePage ()
		{
			InitializeComponent ();
        }
        #endregion

        #region Overrides
	    protected override void OnAppearing()
	    {
	        MixGrids();
	        MessagingCenter.Subscribe(this, Constants.Constants.MixImageGrids, async (SearchTheImageViewModel vm) =>
	        {
	            await Task.Delay(0);
	            MixGrids();
	        });
	    }

	    protected override void OnDisappearing()
	    {
	        MessagingCenter.Unsubscribe<SearchTheImageViewModel>(this, Constants.Constants.MixImageGrids);
	    }
        #endregion

        #region Methods
	    private void MixGrids()
	    {
	        var rnd = new Random();
	        List<int> unSortedList = new List<int> { 0, 1, 2 };
	        var result = unSortedList.OrderBy(item => rnd.Next()).ToList();
	        Image1.SetValue(Grid.ColumnProperty, result[0]);
	        Image2.SetValue(Grid.ColumnProperty, result[1]);
	        Image3.SetValue(Grid.ColumnProperty, result[2]);
	    }
        #endregion

        #region Events
	    private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
	    {
	        var answer = ((Image)sender).AutomationId;
	        BindingContext = ((Image)sender).BindingContext;
	        if (BindingContext == null) return;
	        SearchTheImageViewModel vm = BindingContext as SearchTheImageViewModel;
	        vm?.ValidateSelectionCommand.Execute(answer);
	        MixGrids();
	    }
        #endregion

    }
}