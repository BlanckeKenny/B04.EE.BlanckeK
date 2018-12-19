﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B04.EE.BlanckeK.Models;

namespace B04.EE.BlanckeK.Interfaces.Mock
{
    public class GerbruikerInMemoryService : IGebruikersInterface
    {
        private static List<Gebruiker> gebruikers = new List<Gebruiker>
        {
            new Gebruiker{GebruikersId = Guid.NewGuid(), Leeftijd = 30, Niveau = Niveau.Makkelijk, Naam = "Kenny", Level = 0, Score = 0}
        };

        public async Task<Gebruiker> ZoekGebruikerMetId(Guid id)
        {
            await Task.Delay(0);
            return gebruikers.FirstOrDefault(gebruiker => gebruiker.GebruikersId == id);
        }

        public async Task GebruikerOpslaan(Gebruiker gebruiker)
        {
            //todo
            await Task.Delay(0);
        }
    }
}