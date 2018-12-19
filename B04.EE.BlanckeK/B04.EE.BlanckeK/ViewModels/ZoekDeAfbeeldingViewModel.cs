using System.Collections.Generic;
using B04.EE.BlanckeK.Interfaces;
using B04.EE.BlanckeK.Models;
using FreshMvvm;

namespace B04.EE.BlanckeK.ViewModels
{
    public class ZoekDeAfbeeldingViewModel : FreshBasePageModel
    {
        private Gebruiker _huidigeGebruiker;
        private IGameService _gameService;
        private IEnumerable<ZoekAfbeeldingSpel> _spelLijst = new List<ZoekAfbeeldingSpel>();

        public ZoekDeAfbeeldingViewModel(IGameService gameService)
        {
            _gameService = gameService;
            StartNieuwSpel();
        }

        private async void StartNieuwSpel()
        {
            _spelLijst = await _gameService.ZoekAfbeeldingSpelLijst();
        }

        public override void Init(object initData)
        {
            Gebruiker gebruiker = initData as Gebruiker;
            _huidigeGebruiker = gebruiker;
            base.Init(initData);
            _gebruikersNaam = _huidigeGebruiker.Naam;
            _score = _huidigeGebruiker.Score;

        }

        public string HuidigeScore => $"Score : {Score}";
        public string HuidigLevel => $"Level : {Level}";

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
    }
}
