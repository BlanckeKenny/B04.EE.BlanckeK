using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B04.EE.BlanckeK.Models;

namespace B04.EE.BlanckeK.Interfaces.Mock
{
    public class SpelInMemoryService : IGameService
    {
        #region ZoekAfbeeldingSpel
        private static List<ZoekAfbeeldingSpel> _zoekAfbeeldingSpelLijst;
        public static List<ZoekAfbeeldingSpel> ZoekAfbeeldingSpelLijst
        {
            get
            {
                if (_zoekAfbeeldingSpelLijst == null)
                    _zoekAfbeeldingSpelLijst = MaakNieuwZoekAfbeeldingSpel();
                return _zoekAfbeeldingSpelLijst;
            }
        }

        // Maak een nieuwe lijst met 3 Afbeeldingen 1 woord
        private static List<ZoekAfbeeldingSpel> MaakNieuwZoekAfbeeldingSpel()
        {
            var zoekspelLijst = new List<ZoekAfbeeldingSpel>
            {
                new ZoekAfbeeldingSpel
                {
                    JuisteAfbeelding = "aap.jpg",
                    VerkeerdeAfbeelding1 = "muis.jpg",
                    VerkeerdeAfbeelding2 = "kat.jpg",
                    Woord = "aap",
                },
                new ZoekAfbeeldingSpel
                {
                    JuisteAfbeelding = "muis.jpg",
                    VerkeerdeAfbeelding1 = "ezel.jpg",
                    VerkeerdeAfbeelding2 = "konijn.jpg",
                    Woord = "muis",
                },
                new ZoekAfbeeldingSpel
                {
                    JuisteAfbeelding = "hond.jpg",
                    VerkeerdeAfbeelding1 = "eend.jpg",
                    VerkeerdeAfbeelding2 = "koe.jpg",
                    Woord = "hond",
                },
                new ZoekAfbeeldingSpel
                {
                    JuisteAfbeelding = "kip.jpg",
                    VerkeerdeAfbeelding1 = "bij.jpg",
                    VerkeerdeAfbeelding2 = "kikker.jpg",
                    Woord = "kip",
                },
                new ZoekAfbeeldingSpel
                {
                    JuisteAfbeelding = "vos.jpg",
                    VerkeerdeAfbeelding1 = "mug.jpg",
                    VerkeerdeAfbeelding2 = "paard.jpg",
                    Woord = "vos",
                },
                new ZoekAfbeeldingSpel
                {
                    JuisteAfbeelding = "uil.jpg",
                    VerkeerdeAfbeelding1 = "slak.jpg",
                    VerkeerdeAfbeelding2 = "vis.jpg",
                    Woord = "uil",
                },
                new ZoekAfbeeldingSpel
                {
                    JuisteAfbeelding = "vis.jpg",
                    VerkeerdeAfbeelding1 = "panda.jpg",
                    VerkeerdeAfbeelding2 = "geit.jpg",
                    Woord = "vis",
                },
                new ZoekAfbeeldingSpel
                {
                    JuisteAfbeelding = "paard.jpg",
                    VerkeerdeAfbeelding1 = "muis.jpg",
                    VerkeerdeAfbeelding2 = "aap.jpg",
                    Woord = "paard",
                },
                new ZoekAfbeeldingSpel
                {
                    JuisteAfbeelding = "kat.jpg",
                    VerkeerdeAfbeelding1 = "konijn.jpg",
                    VerkeerdeAfbeelding2 = "hond.jpg",
                    Woord = "kat",
                },
                new ZoekAfbeeldingSpel
                {
                    JuisteAfbeelding = "leeuw.jpg",
                    VerkeerdeAfbeelding1 = "vogel.png",
                    VerkeerdeAfbeelding2 = "geit.jpg",
                    Woord = "leeuw",
                },
            };
            return zoekspelLijst;
        }

        async Task<List<ZoekAfbeeldingSpel>> IGameService.ZoekAfbeeldingSpelLijst()
        {
            await Task.Delay(0);
            var rnd = new Random();
            List<ZoekAfbeeldingSpel> nietGesorteerdeLijst = ZoekAfbeeldingSpelLijst;
            var result = nietGesorteerdeLijst.OrderBy(item => rnd.Next());
            return result.ToList();
        }
        #endregion
        
        #region ZoekWoordSpel
        // ZoekWoordSpel
        private static List<ZoekWoordSpel> _zoekWoordSpelLijst;
        public static List<ZoekWoordSpel> ZoekWoordSpelLijst
        {
            get
            {
                if (_zoekWoordSpelLijst == null)
                    _zoekWoordSpelLijst = MaakNieuwZoekWoordSpel();
                return _zoekWoordSpelLijst;
            }
        }

        // Maak een nieuwe lijst met 3 woorden en 1 afbeelding
        private static List<ZoekWoordSpel> MaakNieuwZoekWoordSpel()
        {
            var zoekWoordLijst = new List<ZoekWoordSpel>
            {
                new ZoekWoordSpel
                {
                    Afbeelding = "muis.jpg",
                    JuisteWoord = "muis",
                    VerkeerdWoord1 = "aap",
                    VerkeerdWoord2 = "egel"
                },
                new ZoekWoordSpel
                {
                    Afbeelding = "vis.jpg",
                    JuisteWoord = "vis",
                    VerkeerdWoord1 = "vogel",
                    VerkeerdWoord2 = "mug"
                },
                new ZoekWoordSpel
                {
                    Afbeelding = "paard.jpg",
                    JuisteWoord = "paard",
                    VerkeerdWoord1 = "kikker",
                    VerkeerdWoord2 = "vos"
                },
                new ZoekWoordSpel
                {
                    Afbeelding = "geit.jpg",
                    JuisteWoord = "geit",
                    VerkeerdWoord1 = "uil",
                    VerkeerdWoord2 = "muis"
                },
                new ZoekWoordSpel
                {
                    Afbeelding = "slak.jpg",
                    JuisteWoord = "slak",
                    VerkeerdWoord1 = "konijn",
                    VerkeerdWoord2 = "bij"
                },
                new ZoekWoordSpel
                {
                    Afbeelding = "panda.jpg",
                    JuisteWoord = "panda",
                    VerkeerdWoord1 = "koe",
                    VerkeerdWoord2 = "paard"
                },
                new ZoekWoordSpel
                {
                    Afbeelding = "kip.jpg",
                    JuisteWoord = "kip",
                    VerkeerdWoord1 = "vos",
                    VerkeerdWoord2 = "slak"
                },
                new ZoekWoordSpel
                {
                    Afbeelding = "eend.jpg",
                    JuisteWoord = "eend",
                    VerkeerdWoord1 = "ezel",
                    VerkeerdWoord2 = "konijn"
                },
                new ZoekWoordSpel
                {
                    Afbeelding = "koe.jpg",
                    JuisteWoord = "koe",
                    VerkeerdWoord1 = "vis",
                    VerkeerdWoord2 = "leeuw"
                },
                new ZoekWoordSpel
                {
                    Afbeelding = "leeuw.jpg",
                    JuisteWoord = "leeuw",
                    VerkeerdWoord1 = "slak",
                    VerkeerdWoord2 = "egel"
                }
            };
            return zoekWoordLijst;
        }

        async Task<List<ZoekWoordSpel>> IGameService.ZoekWoordSpelLijst()
        {
            await Task.Delay(0);
            var rnd = new Random();
            List<ZoekWoordSpel> nietGesorteerdeLijst = ZoekWoordSpelLijst;
            var result = nietGesorteerdeLijst.OrderBy(item => rnd.Next());
            return result.ToList();
        }
        #endregion

        #region VulWoordAanSpel
        public Task<List<VulWoordAanSpel>> VulWoordAanSpelLijst()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
