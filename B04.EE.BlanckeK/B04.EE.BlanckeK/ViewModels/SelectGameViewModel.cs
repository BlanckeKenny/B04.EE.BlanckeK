using System.Windows.Input;
using B04.EE.BlanckeK.Interfaces;
using B04.EE.BlanckeK.Models;
using FreshMvvm;
using Xamarin.Forms;

namespace B04.EE.BlanckeK.ViewModels
{
    public class SelectGameViewModel : FreshBasePageModel
    {
        #region variabelen
        private User _currentUser;
        private readonly ITextToSpeech _speak;
        #endregion

        #region Constructor
        public SelectGameViewModel(ITextToSpeech speak)
        {
            _speak = speak;
            _speak.SpeakOut("Kies u spel");
        }
        #endregion

        #region Overrides
        public override void Init(object initData)
        {
            var user = initData as User;
            _currentUser = user;
            base.Init(initData);
        }
        #endregion

        #region Commands
        public ICommand SearchImageCommand => new Command(async () =>
        {
            await CoreMethods.PushPageModel<SearchTheImageViewModel>(_currentUser);
            _speak.SpeakOut("Zoek de afbeelding die bij het woord past.");
        });

        public ICommand SearchTheWordCommand => new Command(async () =>
        {
            await CoreMethods.PushPageModel<SearchTheWordViewModel>(_currentUser);
            _speak.SpeakOut("Zoek het woord die bij de afbeelding past.");
        });

        #endregion
    }
}