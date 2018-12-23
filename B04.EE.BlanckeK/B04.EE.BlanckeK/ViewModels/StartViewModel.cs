using System;
using System.Windows.Input;
using B04.EE.BlanckeK.Interfaces;
using FreshMvvm;
using Xamarin.Forms;

namespace B04.EE.BlanckeK.ViewModels
{
    public class StartViewModel : FreshBasePageModel
    {
        #region variables
        private readonly int _time = DateTime.Now.Hour;
        private readonly ITextToSpeech _speak;
        #endregion

        #region Constructor
        public StartViewModel(ITextToSpeech speak)
        {
            _speak = speak;
        }
        #endregion

        #region Commands
        public ICommand GoToNewUserPageCommand => new Command(async () =>
        {
            _speak.SpeakOut("Gelieve u naam en leeftijd in te vullen");
            await CoreMethods.PushPageModel<NewUserViewModel>();
        });

        public ICommand SelectUserCommand => new Command(async () =>
        {
            _speak.SpeakOut("Klik op u naam om verder te gaan");
            await CoreMethods.PushPageModel<SelectUserViewModel>();
        });
        #endregion

        #region Overrides
        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            SayHallo();
        }
        #endregion

        #region Methods
        private void SayHallo()
        {
            if (_time > 5 && _time <= 10)
                _speak.SpeakOut("Goeiemorgen");
            else if (_time > 10 && _time <= 17)
                _speak.SpeakOut("Goeiemiddag");
            else
                _speak.SpeakOut("Goeie avond");
        }
        #endregion
    }
}