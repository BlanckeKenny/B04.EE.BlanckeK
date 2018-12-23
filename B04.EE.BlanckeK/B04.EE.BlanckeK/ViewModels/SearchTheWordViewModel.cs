using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using B04.EE.BlanckeK.Interfaces;
using B04.EE.BlanckeK.Models;
using FreshMvvm;
using Xamarin.Forms;

namespace B04.EE.BlanckeK.ViewModels
{
    public class SearchTheWordViewModel : FreshBasePageModel
    {
        #region Variables
        private User _currentUser;
        public IGameService GameService;
        private List<SearchWordGame> _gameList = new List<SearchWordGame>();
        private int _counter;
        private int _totalScore;
        private readonly ITextToSpeech _speak;
        private readonly IUserService _userService;
        #endregion

        #region Properties
        public string CurrentLevel => $"Level: {Level}";
        public string CurrentScore { get; private set; }
        public string UserName { get; set; }

        private string _correctWord;

        public string CorrectWord
        {
            get => _correctWord;
            set
            {
                _correctWord = value;
                RaisePropertyChanged(nameof(CorrectWord));
            }
        }

        private string _wrongWord1;

        public string WrongWord1
        {
            get => _wrongWord1;
            set
            {
                _wrongWord1 = value;
                RaisePropertyChanged(nameof(WrongWord1));
            }
        }

        private string _wrongWord2;

        public string WrongWord2
        {
            get => _wrongWord2;
            set
            {
                _wrongWord2 = value;
                RaisePropertyChanged(nameof(WrongWord2));
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
        #endregion

        #region Constructor
        public SearchTheWordViewModel(IGameService gameService, ITextToSpeech speak, IUserService userService)
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
            _gameList = await GameService.GetSearchWordList();
            GetNewImageAndWords();
        }

        private void GetNewImageAndWords()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    CorrectImage = _gameList[_counter].ImageToSearch;
                    break;
                default:
                    CorrectImage = $"Assets/dieren/{_gameList[_counter].ImageToSearch}";

                    break;
            }

            CorrectWord = _gameList[_counter].CorrectWord;
            WrongWord1 = _gameList[_counter].WrongWord1;
            WrongWord2 = _gameList[_counter].WrongWord2;
            MessagingCenter.Send(this, Constants.Constants.MixWordGrids);
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

        #region Commands
        public ICommand ValidateCommand => new Command(async answer =>
        {
            await Task.Delay(0);
            Validate(answer.ToString());
            if (_counter < _gameList.Count)
            {
                GetNewImageAndWords();
            }
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
                _currentUser.Score = _totalScore;
                _currentUser.Level = Level;
                await _userService.SaveUser(_currentUser);
            }
        });
        #endregion

        #region Override's
        public override void Init(object initData)
        {
            var user = initData as User;
            _currentUser = user;
            base.Init(initData);
            UserName = _currentUser.Name;
            _level = _currentUser.Level;
            CurrentScore = $"Score: {Score}/{_counter}";
        }
        #endregion

    }
}