using System;
using System.Windows.Input;
using B04.EE.BlanckeK.Interfaces;
using FreshMvvm;
using Xamarin.Forms;


namespace B04.EE.BlanckeK.ViewModels
{
    public class StartViewModel : FreshBasePageModel
    {

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            DependencyService.Get<ITextToSpeech>().Speak("Welkom bij leren lezen!");
        }

        public ICommand StartSpelCommand => new Command(
            () =>
            {
                DependencyService.Get<ITextToSpeech>().Speak("Gelieve u leeftijd en niveau in te vullen");
                CoreMethods.PushPageModel<GegevensViewModel>();
            });
    }
}
