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
        private readonly ITextToSpeech _speak;
        #endregion

        #region Constructor
        public SpelSelectieViewModel(ITextToSpeech speak)
        {
            _speak = speak;
            _speak.Speak("Kies u spel");
        }
        #endregion

        #region Commands
        public ICommand ZoekDeAfBeeldingCommand => new Command(async () =>
        {
            await CoreMethods.PushPageModel<ZoekDeAfbeeldingViewModel>(_huidigeGebruiker);
            _speak.Speak("Zoek de afbeelding die bij het woord past.");
        });

        public ICommand ZoekHetWoordSpelCommand => new Command(async () =>
        {
            await CoreMethods.PushPageModel<ZoekHetWoordViewModel>(_huidigeGebruiker);
            _speak.Speak("Zoek het woord die bij de afbeelding past.");
        });

        public ICommand VulHetWoordAanSpelCommand => new Command(async () =>
        {
            await CoreMethods.PushPageModel<VulHetWoordAanViewModel>(_huidigeGebruiker);
            _speak.Speak("Kijk naar de afbeelding en vul het woord aan.");
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
