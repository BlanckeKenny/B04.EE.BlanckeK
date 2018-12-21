using System;
using System.Windows.Input;
using B04.EE.BlanckeK.Interfaces;
using FreshMvvm;
using Xamarin.Forms;


namespace B04.EE.BlanckeK.ViewModels
{
    public class StartViewModel : FreshBasePageModel
    {
        #region variabelen
        readonly int _time = DateTime.Now.Hour;
        private readonly ITextToSpeech _speak;

        public StartViewModel(ITextToSpeech speak)
        {
            _speak = speak;
        }

        #endregion

        #region Overrides
        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            Begroet();
        }
        #endregion

        #region Commands
        public ICommand StartSpelCommand => new Command(async () =>
        {
            _speak.Speak("Gelieve u naam en leeftijd in te vullen");
            await CoreMethods.PushPageModel<GegevensViewModel>();
        });
        #endregion

        #region Methods
        private void Begroet()
        {

            if (_time > 5 && _time <= 10)
            {
                _speak.Speak("Goeiemorgen");
            }
            else if (_time > 10 && _time <= 17)
            {
                _speak.Speak("Goeiemiddag");
            }
            else
            {
                _speak.Speak("Goeie avond");
            }
        }
        #endregion
    }
}
