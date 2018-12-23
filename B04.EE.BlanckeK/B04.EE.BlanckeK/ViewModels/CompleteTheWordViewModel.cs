using B04.EE.BlanckeK.Models;
using FreshMvvm;

namespace B04.EE.BlanckeK.ViewModels
{
    public class CompleteTheWordViewModel : FreshBasePageModel
    {
        #region variables

        private User _currentUser;

        #endregion

        #region Overrides

        public override void Init(object initData)
        {
            var user = initData as User;
            _currentUser = user;
            base.Init(initData);
            _userName = _currentUser.Name;
            _score = _currentUser.Score;
        }

        #endregion

        #region Properties

        public string CurrentScore => $"Score : {Score}";
        public string CurrentLevel => $"Level : {Level}";

        private string _userName;

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                _currentUser.Name = _userName;
                RaisePropertyChanged(nameof(UserName));
            }
        }

        private int _score;

        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                _currentUser.Score = _score;
                RaisePropertyChanged(nameof(Score));
                RaisePropertyChanged(CurrentScore);
            }
        }

        private int _level;

        public int Level
        {
            get => _level;
            set
            {
                _level = value;
                _currentUser.Level = _level;
                RaisePropertyChanged(nameof(Level));
                RaisePropertyChanged(CurrentLevel);
            }
        }

        #endregion
    }
}