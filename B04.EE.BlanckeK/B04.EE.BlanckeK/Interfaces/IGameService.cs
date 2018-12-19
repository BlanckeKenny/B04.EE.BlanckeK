using System.Collections.Generic;
using System.Threading.Tasks;
using B04.EE.BlanckeK.Models;

namespace B04.EE.BlanckeK.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<ZoekAfbeeldingSpel>> ZoekAfbeeldingSpelLijst();
        Task<IEnumerable<ZoekWoordSpel>> ZoekWoordSpelLijst();
        Task<IEnumerable<VulWoordAanSpel>> VulWoordAanSpelLijst();
    }
}
