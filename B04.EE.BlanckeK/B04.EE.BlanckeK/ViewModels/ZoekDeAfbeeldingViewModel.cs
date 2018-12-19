using System;
using System.Collections.Generic;
using System.Linq;
using B04.EE.BlanckeK.Interfaces;
using B04.EE.BlanckeK.Models;
using FreshMvvm;

namespace B04.EE.BlanckeK.ViewModels
{
    public class ZoekDeAfbeeldingViewModel : FreshBasePageModel
    {
        private Gebruiker _huidigeGebruiker;
        private ZoekAfbeeldingSpel huidigSpel;
        private IGameService _gameService;
        private List<ZoekAfbeeldingSpel> _spelLijst = new List<ZoekAfbeeldingSpel>();
        private int _teller;
        private int _spelScore;

        public ZoekDeAfbeeldingViewModel(IGameService gameService)
        {
            _gameService = gameService;
            StartNieuwSpel();
        }

        private async void StartNieuwSpel()
        {
            _spelLijst = await _gameService.ZoekAfbeeldingSpelLijst();
            _teller = _spelLijst.Count - 1;
            _spelScore = 0;
            StartRonde();
        }

        private void StartRonde()
        {
            JuisteAfbeelding = _spelLijst[_teller].JuisteAfbeelding;
            VerkeerdeAfbeelding1 = _spelLijst[_teller].VerkeerdeAfbeelding1;
            VerkeerdeAfbeelding2 = _spelLijst[_teller].VerkeerdeAfbeelding2;
            Woord = _spelLijst[_teller].Woord;
        }

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


        private string _gebruikersNaam;
        public string GebruikersNaam
        {
            get => _gebruikersNaam;
            set
            {
                _gebruikersNaam = value;
                _huidigeGebruiker.Naam = _gebruikersNaam;
                RaisePropertyChanged(nameof(GebruikersNaam));
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
                _huidigeGebruiker.Score = _score;
                RaisePropertyChanged(nameof(Score));
                RaisePropertyChanged(HuidigeScore);
            }
        }

        private int _level;
        public int Level
        {
            get => _level;
            set
            {
                _level = value;
                _huidigeGebruiker.Level = _level;
                RaisePropertyChanged(nameof(Level));
                RaisePropertyChanged(HuidigLevel);
            }
        }


        public string HuidigeScore => $"Score : {Score}";
        public string HuidigLevel => $"Level : {Level}";


        public override void Init(object initData)
        {
            Gebruiker gebruiker = initData as Gebruiker;
            _huidigeGebruiker = gebruiker;
            base.Init(initData);
            _gebruikersNaam = _huidigeGebruiker.Naam;
            _score = _huidigeGebruiker.Score;

        }
    }
}
