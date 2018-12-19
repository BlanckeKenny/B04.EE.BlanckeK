using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using B04.EE.BlanckeK.Models;

namespace B04.EE.BlanckeK.Interfaces
{
    public interface IGebruikersInterface
    {
        Task<Gebruiker> ZoekGebruikerMetId(Guid id);
        Task GebruikerOpslaan(Gebruiker gebruiker);
    }
}
