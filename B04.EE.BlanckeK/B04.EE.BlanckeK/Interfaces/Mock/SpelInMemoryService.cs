using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B04.EE.BlanckeK.Models;

namespace B04.EE.BlanckeK.Interfaces.Mock
{
    public class SpelInMemoryService : IGameService
    {
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
                    VerkeerdeAfbeelding1 = "vogel.jpg",
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

        public Task<List<ZoekWoordSpel>> ZoekWoordSpelLijst()
        {
            throw new NotImplementedException();
        }

        public Task<List<VulWoordAanSpel>> VulWoordAanSpelLijst()
        {
            throw new NotImplementedException();
        }
    }
}
