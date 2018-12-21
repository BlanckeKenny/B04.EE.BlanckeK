using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using B04.EE.BlanckeK.Interfaces;
using B04.EE.BlanckeK.Models;
using FreshMvvm;
using Xamarin.Forms;

namespace B04.EE.BlanckeK.ViewModels
{
    public class ZoekHetWoordViewModel : FreshBasePageModel
    {
        #region Variabelen
        private Gebruiker _huidigeGebruiker;
        public IGameService GameService;
        private List<ZoekWoordSpel> _spelLijst = new List<ZoekWoordSpel>();
        private int _teller;
        private int _totaalScore;
        private readonly ITextToSpeech _speak;
        #endregion

        #region Constructor
        public ZoekHetWoordViewModel(IGameService gameService, ITextToSpeech speak)
        {
            GameService = gameService;
            _speak = speak;
            StartNieuwSpel();
        }
        #endregion

        #region Methods
        private async void StartNieuwSpel()
        {
            _teller = 0;
            _score = 0;
            _spelLijst = await GameService.ZoekWoordSpelLijst();
            NieuweAfbeeldingEnWoorden();
        }

        private void NieuweAfbeeldingEnWoorden()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    JuisteAfbeelding = _spelLijst[_teller].Afbeelding;
                    break;
                default:
                    JuisteAfbeelding = $"Assets/dieren/{_spelLijst[_teller].Afbeelding}";
                    
                    break;
            }
            JuisteWoord = _spelLijst[_teller].JuisteWoord;
            VerkeerdeWoord1 = _spelLijst[_teller].VerkeerdWoord1;
            VerkeerdeWoord2 = _spelLijst[_teller].VerkeerdWoord2;
            MessagingCenter.Send(this, Constants.Constants.MixWoordGrids);
        }

        private void Controleer(string antwoord)
        {
            _teller++;
            if (antwoord == "Juist") Score = Score + 1;
            HuidigeScore = $"Score: {Score}/{_teller}";
            RaisePropertyChanged(nameof(HuidigeScore));
            _speak.Speak(antwoord);
        }
        #endregion

        #region Properties
        public string HuidigLevel => $"Level: {Level}";
        public string HuidigeScore { get; private set; }
        public string GebruikersNaam { get; set; }

        private string _verkeerdeWoord2;
        public string VerkeerdeWoord2
        {
            get => _verkeerdeWoord2;
            set
            {
                _verkeerdeWoord2 = value;
                RaisePropertyChanged(nameof(VerkeerdeWoord2));
            }
        }

        private string _verkeerdeWoord1;
        public string VerkeerdeWoord1
        {
            get => _verkeerdeWoord1;
            set
            {
                _verkeerdeWoord1 = value;
                RaisePropertyChanged(nameof(VerkeerdeWoord1));
            }
        }

        private string _juisteWoord;
        public string JuisteWoord
        {
            get => _juisteWoord;
            set
            {
                _juisteWoord = value;
                RaisePropertyChanged(nameof(JuisteWoord));
            }
        }

        private string _juisteAfbeelding;
        public string JuisteAfbeelding
        {
            get => _juisteAfbeelding;
            set
            {
                _juisteAfbeelding = value;
                RaisePropertyChanged(nameof(JuisteAfbeelding));
            }
        }

        private int _score;
        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                RaisePropertyChanged(nameof(Score));
            }
        }

        private int _level;
        public int Level
        {
            get => _level;
            set
            {
                _level = value;
                RaisePropertyChanged(nameof(Level));
                RaisePropertyChanged(nameof(HuidigLevel));
            }
        }
        #endregion

        #region Commands
        public ICommand ControleerCommand => new Command(async (antwoord) =>
        {
            await Task.Delay(0);
            Controleer(antwoord.ToString());
            if (_teller < _spelLijst.Count) NieuweAfbeeldingEnWoorden();
            else
            {
                if (Score > _teller / 2 + 1)
                    await CoreMethods.DisplayAlert($"Goed zo u heeft {Score} op {_teller}", "", "Ok");
                else
                    await CoreMethods.DisplayAlert($"Nog even oefenen u score was {Score} op {_teller}", "", "Ok");
                await CoreMethods.PopPageModel();
                _totaalScore = _huidigeGebruiker.Score + Score;
                if (_totaalScore >= 30)
                {
                    Level++;
                    _totaalScore = 0;
                    RaisePropertyChanged(nameof(Level));
                    RaisePropertyChanged(nameof(HuidigLevel));
                }
                _huidigeGebruiker.Score = _totaalScore;
                _huidigeGebruiker.Level = Level;
            }
        });

        #endregion

        #region Override's
        public override void Init(object initData)
        {
            Gebruiker gebruiker = initData as Gebruiker;
            _huidigeGebruiker = gebruiker;
            base.Init(initData);
            GebruikersNaam = _huidigeGebruiker.Naam;
            _level = _huidigeGebruiker.Level;
            HuidigeScore = $"Score: {Score}/{_teller}";
        }
        #endregion
    }
}
