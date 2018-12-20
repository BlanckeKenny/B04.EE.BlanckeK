using System;

namespace B04.EE.BlanckeK.Models
{
    public class Gebruiker
    {
        public Guid GebruikersId { get; set; }
        public int Score { get; set; }
        public int Level { get; set; }
        public string Naam { get; set; }
        public int Leeftijd { get; set; }
    }
}
