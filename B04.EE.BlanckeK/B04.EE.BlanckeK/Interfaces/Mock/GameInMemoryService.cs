using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B04.EE.BlanckeK.Models;

namespace B04.EE.BlanckeK.Interfaces.Mock
{
    public class GameInMemoryService : IGameService
    {
        #region SearchImageGame
        private static List<SearchImageGame> _searchImageGameList;
        public static List<SearchImageGame> SearchImageGameList
        {
            get
            {
                if (_searchImageGameList == null)
                    _searchImageGameList = CreateSeachImageGameList();
                return _searchImageGameList;
            }
        }

        // Maak een nieuwe lijst met 3 Afbeeldingen 1 woord
        private static List<SearchImageGame> CreateSeachImageGameList()
        {
            var imageGameList = new List<SearchImageGame>
            {
                new SearchImageGame
                {
                    CorrectImage = "aap.jpg",
                    WrongImage1 = "muis.jpg",
                    WrongImage2 = "kat.jpg",
                    WordToRead = "aap",
                },
                new SearchImageGame
                {
                    CorrectImage = "muis.jpg",
                    WrongImage1 = "ezel.jpg",
                    WrongImage2 = "konijn.jpg",
                    WordToRead = "muis",
                },
                new SearchImageGame
                {
                    CorrectImage = "hond.jpg",
                    WrongImage1 = "eend.jpg",
                    WrongImage2 = "koe.jpg",
                    WordToRead = "hond",
                },
                new SearchImageGame
                {
                    CorrectImage = "kip.jpg",
                    WrongImage1 = "bij.jpg",
                    WrongImage2 = "kikker.jpg",
                    WordToRead = "kip",
                },
                new SearchImageGame
                {
                    CorrectImage = "vos.jpg",
                    WrongImage1 = "mug.jpg",
                    WrongImage2 = "paard.jpg",
                    WordToRead = "vos",
                },
                new SearchImageGame
                {
                    CorrectImage = "uil.jpg",
                    WrongImage1 = "slak.jpg",
                    WrongImage2 = "vis.jpg",
                    WordToRead = "uil",
                },
                new SearchImageGame
                {
                    CorrectImage = "vis.jpg",
                    WrongImage1 = "panda.jpg",
                    WrongImage2 = "geit.jpg",
                    WordToRead = "vis",
                },
                new SearchImageGame
                {
                    CorrectImage = "paard.jpg",
                    WrongImage1 = "muis.jpg",
                    WrongImage2 = "aap.jpg",
                    WordToRead = "paard",
                },
                new SearchImageGame
                {
                    CorrectImage = "kat.jpg",
                    WrongImage1 = "konijn.jpg",
                    WrongImage2 = "hond.jpg",
                    WordToRead = "kat",
                },
                new SearchImageGame
                {
                    CorrectImage = "leeuw.jpg",
                    WrongImage1 = "vogel.png",
                    WrongImage2 = "geit.jpg",
                    WordToRead = "leeuw",
                },
            };
            return imageGameList;
        }

        public async Task<List<SearchImageGame>> GetSearchImageList()
        {
            await Task.Delay(0);
            var rnd = new Random();
            List<SearchImageGame> unSortedList = SearchImageGameList;
            var result = unSortedList.OrderBy(item => rnd.Next());
            return result.ToList();
        }
        #endregion
        
        #region SearchWordGame
        private static List<SearchWordGame> _searchWordList;
        public static List<SearchWordGame> SearchWordList
        {
            get
            {
                if (_searchWordList == null)
                    _searchWordList = CreateNewSearchWordList();
                return _searchWordList;
            }
        }

        // Maak een nieuwe lijst met 3 woorden en 1 afbeelding
        private static List<SearchWordGame> CreateNewSearchWordList()
        {
            var wordList = new List<SearchWordGame>
            {
                new SearchWordGame
                {
                    ImageToSearch = "muis.jpg",
                    CorrectWord = "muis",
                    WrongWord1 = "aap",
                    WrongWord2 = "egel"
                },
                new SearchWordGame
                {
                    ImageToSearch = "vis.jpg",
                    CorrectWord = "vis",
                    WrongWord1 = "vogel",
                    WrongWord2 = "mug"
                },
                new SearchWordGame
                {
                    ImageToSearch = "paard.jpg",
                    CorrectWord = "paard",
                    WrongWord1 = "kikker",
                    WrongWord2 = "vos"
                },
                new SearchWordGame
                {
                    ImageToSearch = "geit.jpg",
                    CorrectWord = "geit",
                    WrongWord1 = "uil",
                    WrongWord2 = "muis"
                },
                new SearchWordGame
                {
                    ImageToSearch = "slak.jpg",
                    CorrectWord = "slak",
                    WrongWord1 = "konijn",
                    WrongWord2 = "bij"
                },
                new SearchWordGame
                {
                    ImageToSearch = "panda.jpg",
                    CorrectWord = "panda",
                    WrongWord1 = "koe",
                    WrongWord2 = "paard"
                },
                new SearchWordGame
                {
                    ImageToSearch = "kip.jpg",
                    CorrectWord = "kip",
                    WrongWord1 = "vos",
                    WrongWord2 = "slak"
                },
                new SearchWordGame
                {
                    ImageToSearch = "eend.jpg",
                    CorrectWord = "eend",
                    WrongWord1 = "ezel",
                    WrongWord2 = "konijn"
                },
                new SearchWordGame
                {
                    ImageToSearch = "koe.jpg",
                    CorrectWord = "koe",
                    WrongWord1 = "vis",
                    WrongWord2 = "leeuw"
                },
                new SearchWordGame
                {
                    ImageToSearch = "leeuw.jpg",
                    CorrectWord = "leeuw",
                    WrongWord1 = "slak",
                    WrongWord2 = "egel"
                }
            };
            return wordList;
        }

        public async Task<List<SearchWordGame>> GetSearchWordList()
        {
            await Task.Delay(0);
            var rnd = new Random();
            List<SearchWordGame> unSortedList = SearchWordList;
            var result = unSortedList.OrderBy(item => rnd.Next());
            return result.ToList();
        }
        #endregion
    }
}
