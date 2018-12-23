using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using B04.EE.BlanckeK.Interfaces;
using B04.EE.BlanckeK.Models;
using FreshMvvm;
using Xamarin.Forms;

namespace B04.EE.BlanckeK.ViewModels
{
    public class SearchTheImageViewModel : FreshBasePageModel
    {
        #region Variabelen
        private User _currentUser;
        public IGameService GameService;
        private readonly ITextToSpeech _speak;
        private readonly IUserService _userService;
        private List<SearchImageGame> _gameList = new List<SearchImageGame>();
        private int _counter;
        private int _totalScore;
        #endregion

        #region properties
        public string CurrentScore { get; private set; }
        public string CurrentLevel => $"Level: {Level}";
        public string UserName { get; set; }

        private string _word;
        public string Word
        {
            get => _word;
            set
            {
                _word = value;
                RaisePropertyChanged(nameof(Word));
            }
        }

        private string _wrongImage1;
        public string WrongImage1
        {
            get => _wrongImage1;
            set
            {
                _wrongImage1 = value;
                RaisePropertyChanged(nameof(WrongImage1));
            }
        }

        private string _wrongImage2;
        public string WrongImage2
        {
            get => _wrongImage2;
            set
            {
                _wrongImage2 = value;
                RaisePropertyChanged(nameof(WrongImage2));
            }
        }

        private string _correctImage;
        public string CorrectImage
        {
            get => _correctImage;
            set
            {
                _correctImage = value;
                RaisePropertyChanged(nameof(CorrectImage));
            }
        }

        private int _level;
        public int Level
        {
            get => _level;
            set
            {
                _level = value;
                RaisePropertyChanged(nameof(Level));
                RaisePropertyChanged(nameof(CurrentLevel));
            }
        }

        private int _score;
        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                RaisePropertyChanged(nameof(Score));
            }
        }
        #endregion

        #region Constructor
        public SearchTheImageViewModel(IGameService gameService, ITextToSpeech speak, IUserService userService)
        {
            GameService = gameService;
            _speak = speak;
            _userService = userService;
            StartNewGame();
        }
        #endregion

        #region Methods
        private async void StartNewGame()
        {
            _counter = 0;
            _score = 0;
            _gameList = await GameService.GetSearchImageList();
            GetNewImageAndWord();
        }

        private void GetNewImageAndWord()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    CorrectImage = _gameList[_counter].CorrectImage;
                    WrongImage1 = _gameList[_counter].WrongImage1;
                    WrongImage2 = _gameList[_counter].WrongImage2;
                    break;
                default:
                    CorrectImage = $"Assets/dieren/{_gameList[_counter].CorrectImage}";
                    WrongImage1 = $"Assets/dieren/{_gameList[_counter].WrongImage1}";
                    WrongImage2 = $"Assets/dieren/{_gameList[_counter].WrongImage2}";
                    break;
            }
            Word = _gameList[_counter].WordToRead;
            MessagingCenter.Send(this, Constants.Constants.MixImageGrids);
        }

        private void Validate(string answer)
        {
            _counter++;
            if (answer == Constants.Constants.Correct) Score = Score + 1;
            CurrentScore = $"Score: {Score}/{_counter}";
            RaisePropertyChanged(nameof(CurrentScore));
            _speak.SpeakOut(answer);
        }
        #endregion

        #region Override's
        public override void Init(object initData)
        {
            User user = initData as User;
            _currentUser = user;
            base.Init(initData);
            UserName = _currentUser.Name;
            _level = _currentUser.Level;
            CurrentScore = $"Score: {Score}/{_counter}";
        }
        #endregion

        #region Commands
        public ICommand ValidateSelectionCommand => new Command(async (answer) =>
        {
            await Task.Delay(0);
            Validate(answer.ToString());
            if (_counter < _gameList.Count) GetNewImageAndWord();

            // Als het spel alle afbeeldingen getoond heeft
            else
            {
                if (Score > _counter / 2 + 1)
                    await CoreMethods.DisplayAlert($"Goed zo u heeft {Score} op {_counter}", "", "Ok");
                else
                    await CoreMethods.DisplayAlert($"Nog even oefenen u score was {Score} op {_counter}", "", "Ok");

                await CoreMethods.PopPageModel();
                _totalScore = _currentUser.Score + Score;
                if (_totalScore >= Level * 30)
                {
                    Level++;
                    _totalScore = 0;
                    RaisePropertyChanged(nameof(Level));
                    RaisePropertyChanged(nameof(CurrentLevel));
                }
                _currentUser.Score =  _totalScore;
                _currentUser.Level = Level;
                await _userService.SaveUser(_currentUser);
            }
        });
        #endregion
    }
}
