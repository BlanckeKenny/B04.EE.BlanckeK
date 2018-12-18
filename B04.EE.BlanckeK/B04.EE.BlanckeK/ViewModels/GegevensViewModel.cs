using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using B04.EE.BlanckeK.Models;
using FreshMvvm;

namespace B04.EE.BlanckeK.ViewModels
{
    public class GegevensViewModel : FreshBasePageModel
    {
        Gebruiker gebruiker = new Gebruiker();

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
    }
}
