using System.Windows.Input;
using B04.EE.BlanckeK.Interfaces;
using B04.EE.BlanckeK.Models;
using FreshMvvm;
using Xamarin.Forms;

namespace B04.EE.BlanckeK.ViewModels
{
    public class SpelSelectieViewModel : FreshBasePageModel
    {
        #region variabelen
        private Gebruiker _huidigeGebruiker;
        #endregion

        #region Constructor
        public SpelSelectieViewModel()
        {
            DependencyService.Get<ITextToSpeech>().Speak("Kies u speltype");
        }
        #endregion

        #region Commands
        public ICommand ZoekDeAfBeeldingCommand => new Command(async () =>
        {
            await CoreMethods.PushPageModel<ZoekDeAfbeeldingViewModel>(_huidigeGebruiker);
            DependencyService.Get<ITextToSpeech>().Speak("Zoek de afbeelding die bij het woord past.");
        });

        public ICommand ZoekHetWoordSpelCommand => new Command(async () =>
        {
            await CoreMethods.PushPageModel<ZoekHetWoordViewModel>(_huidigeGebruiker);
            DependencyService.Get<ITextToSpeech>().Speak("Zoek het woord die bij de afbeelding past.");
        });

        public ICommand VulHetWoordAanSpelCommand => new Command(async () =>
        {
            await CoreMethods.PushPageModel<VulHetWoordAanViewModel>(_huidigeGebruiker);
            DependencyService.Get<ITextToSpeech>().Speak("Kijk naar de afbeelding en vul het woord aan.");
        });
        #endregion

        #region Overrides
        public override void Init(object initData)
        {
            Gebruiker gebruiker = initData as Gebruiker;
            _huidigeGebruiker = gebruiker;
            base.Init(initData);
        }
        #endregion
    }
}
