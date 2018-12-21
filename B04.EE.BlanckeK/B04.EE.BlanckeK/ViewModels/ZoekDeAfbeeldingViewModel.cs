using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using B04.EE.BlanckeK.Interfaces;
using B04.EE.BlanckeK.Models;
using FreshMvvm;
using Xamarin.Forms;

namespace B04.EE.BlanckeK.ViewModels
{
    public class ZoekDeAfbeeldingViewModel : FreshBasePageModel
    {
        #region Variabelen
        private Gebruiker _huidigeGebruiker;
        public IGameService GameService;
        private ITextToSpeech _speak;
        private List<ZoekAfbeeldingSpel> _spelLijst = new List<ZoekAfbeeldingSpel>();
        private int _teller;
        private int _totaalScore;
        #endregion

        #region Constructor
        public ZoekDeAfbeeldingViewModel(IGameService gameService, ITextToSpeech speak)
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
            _spelLijst = await GameService.ZoekAfbeeldingSpelLijst();
            NieuweAfbeeldingenEnWoord();
        }

        private void NieuweAfbeeldingenEnWoord()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    JuisteAfbeelding = _spelLijst[_teller].JuisteAfbeelding;
                    VerkeerdeAfbeelding1 = _spelLijst[_teller].VerkeerdeAfbeelding1;
                    VerkeerdeAfbeelding2 = _spelLijst[_teller].VerkeerdeAfbeelding2;
                    break;
                default:
                    JuisteAfbeelding = $"Assets/dieren/{_spelLijst[_teller].JuisteAfbeelding}";
                    VerkeerdeAfbeelding1 = $"Assets/dieren/{_spelLijst[_teller].VerkeerdeAfbeelding1}";
                    VerkeerdeAfbeelding2 = $"Assets/dieren/{_spelLijst[_teller].VerkeerdeAfbeelding2}";
                    break;
            }
            Woord = _spelLijst[_teller].Woord;
            MessagingCenter.Send(this, Constants.Constants.MixAfbeeldingGrids);
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

        #region properties
        public string HuidigeScore { get; private set; }
        public string HuidigLevel => $"Level: {Level}";

        private string _woord;
        public string Woord
        {
            get => _woord;
            set
            {
                _woord = value;
                RaisePropertyChanged(nameof(Woord));
            }
        }

        private string _verkeerdeAfbeelding2;
        public string VerkeerdeAfbeelding2
        {
            get => _verkeerdeAfbeelding2;
            set
            {
                _verkeerdeAfbeelding2 = value;
                RaisePropertyChanged(nameof(VerkeerdeAfbeelding2));
            }
        }

        private string _verkeerdeAfbeelding1;
        public string VerkeerdeAfbeelding1
        {
            get => _verkeerdeAfbeelding1;
            set
            {
                _verkeerdeAfbeelding1 = value;
                RaisePropertyChanged(nameof(VerkeerdeAfbeelding1));
            }
        }

        public string GebruikersNaam { get; set; }

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

        #region Commands
        public ICommand ControleerCommand => new Command(async (antwoord) =>
        {
            await Task.Delay(0);
            Controleer(antwoord.ToString());
            if (_teller < _spelLijst.Count) NieuweAfbeeldingenEnWoord();
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
                _huidigeGebruiker.Score =  _totaalScore;
                _huidigeGebruiker.Level = Level;
            }
        });
        #endregion
    }
}
