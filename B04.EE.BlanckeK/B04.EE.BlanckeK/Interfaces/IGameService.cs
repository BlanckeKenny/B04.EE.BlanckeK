using System.Collections.Generic;
using System.Threading.Tasks;
using B04.EE.BlanckeK.Models;

namespace B04.EE.BlanckeK.Interfaces
{
    public interface IGameService
    {
        Task<List<SearchImageGame>> GetSearchImageList();
        Task<List<SearchWordGame>> GetSearchWordList();
    }
}
