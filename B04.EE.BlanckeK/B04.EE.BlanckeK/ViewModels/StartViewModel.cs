using System;
using System.Windows.Input;
using B04.EE.BlanckeK.Interfaces;
using FreshMvvm;
using Xamarin.Forms;


namespace B04.EE.BlanckeK.ViewModels
{
    public class StartViewModel : FreshBasePageModel
    {
        int _time = DateTime.Now.Hour;

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            Begroet();
        }


        public ICommand StartSpelCommand => new Command(async () =>
        {
            DependencyService.Get<ITextToSpeech>().Speak("Gelieve u naam en leeftijd in te vullen");
            await CoreMethods.PushPageModel<GegevensViewModel>();
        });

        public void Begroet()
        {

            if (_time > 5 && _time <= 10)
            {
                DependencyService.Get<ITextToSpeech>().Speak("Goeiemorgen");
            }
            else if (_time > 10 && _time <= 17)
            {
                DependencyService.Get<ITextToSpeech>().Speak("Goeiemiddag");
            }
            else
            {
                DependencyService.Get<ITextToSpeech>().Speak("Goeie avond");
            }
        }

    }
}
