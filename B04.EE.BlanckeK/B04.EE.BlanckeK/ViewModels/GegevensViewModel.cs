using System;
using System.Windows.Input;
using B04.EE.BlanckeK.Models;
using B04.EE.BlanckeK.Validators;
using FluentValidation;
using FreshMvvm;
using Xamarin.Forms;

namespace B04.EE.BlanckeK.ViewModels
{
    public class GegevensViewModel : FreshBasePageModel
    {
        private readonly IValidator _gebruikerValidator;
        private Gebruiker _huidigeGebruiker;

        #region Constructor
        public GegevensViewModel()
        {
            _gebruikerValidator = new GebruikerValidator();
        }
        #endregion


        #region Properties
        private string _gebruikersInvoerError;
        public string GebruikersInvoerError
        {
            get => _gebruikersInvoerError;
            set
            {
                _gebruikersInvoerError = value;
                RaisePropertyChanged(nameof(GebruikersInvoerError));
            }
        }

        private string _naam;
        public string Naam
        {
            get => _naam;
            set
            {
                _naam = value;
                RaisePropertyChanged(nameof(Naam));
            }
        }

        private int _leeftijd;
        public int Leeftijd
        {
            get => _leeftijd;
            set
            {
                _leeftijd = value;
                RaisePropertyChanged(nameof(Leeftijd));

            }
        }
        #endregion

        #region Methods
        private bool Valideer(Gebruiker gebruiker)
        {
            gebruiker.Leeftijd = Leeftijd;
            gebruiker.Naam = Naam;

            var validatieResultaat = _gebruikerValidator.Validate(gebruiker);

            foreach (var error in validatieResultaat.Errors)
            {
                switch (error.PropertyName)
                {
                    case nameof(gebruiker.Naam):
                        GebruikersInvoerError = error.ErrorMessage;
                        break;
                    case nameof(gebruiker.Leeftijd):
                        GebruikersInvoerError = error.ErrorMessage;
                        break;
                }
            }

            return validatieResultaat.IsValid;
        }
        #endregion

        #region Overrride's
        public override void Init(object initData)
        {
            base.Init(initData);

            Gebruiker gebruiker = initData as Gebruiker;
            if (gebruiker != null)
              _huidigeGebruiker = gebruiker;
            else 
                _huidigeGebruiker = new Gebruiker
                {
                    Niveau = Niveau.Makkelijk,
                    Naam = Naam,
                    Leeftijd = Leeftijd, 
                    GebruikersId = Guid.NewGuid(),
                    Level = 0, 
                    Score = 0,
                };
        }
        #endregion


        #region Commands
        public ICommand StartNewGameCommand => new Command(async () =>
        {
            GebruikersInvoerError = "";
            if (Valideer(_huidigeGebruiker) == false) await CoreMethods.DisplayAlert(GebruikersInvoerError, "", "ok");
            else await CoreMethods.PushPageModel<SpelSelectieViewModel>(_huidigeGebruiker);
        });
        #endregion
    }

}
