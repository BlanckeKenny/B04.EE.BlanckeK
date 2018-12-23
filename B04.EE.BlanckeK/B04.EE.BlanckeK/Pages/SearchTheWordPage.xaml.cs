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
	public partial class SearchTheWordPage : ContentPage
	{
        #region Constructor
	    public SearchTheWordPage()
	    {
	        InitializeComponent();
	    }
        #endregion

	    #region Overrides
	    protected override void OnAppearing()
	    {
	        MixGrids();
	        MessagingCenter.Subscribe(this, Constants.Constants.MixWordGrids, async (SearchTheWordViewModel vm) =>
	        {
	            await Task.Delay(0);
	            MixGrids();
	        });
	    }

	    protected override void OnDisappearing()
	    {
	        MessagingCenter.Unsubscribe<SearchTheWordViewModel>(this, Constants.Constants.MixWordGrids);
	    }
        #endregion

	    #region Methods
	    private void MixGrids()
	    {
	        var rnd = new Random();
	        List<int> unSortedList = new List<int> { 0, 1, 2 };
	        var result = unSortedList.OrderBy(item => rnd.Next()).ToList();
	        CorrectWord.SetValue(Grid.ColumnProperty, result[0]);
	        WrongWord1.SetValue(Grid.ColumnProperty, result[1]);
	        WrongWord2.SetValue(Grid.ColumnProperty, result[2]);
	    }
        #endregion

	    #region Events
	    private void CorrectWord_OnClicked(object sender, EventArgs e)
	    {
	        var answer = ((Button)sender).AutomationId;
	        BindingContext = ((Button)sender).BindingContext;
	        if (BindingContext == null) return;
	        SearchTheWordViewModel vm = BindingContext as SearchTheWordViewModel;
	        vm?.ValidateCommand.Execute(answer);
	        MixGrids();
        }
        #endregion
    }
}