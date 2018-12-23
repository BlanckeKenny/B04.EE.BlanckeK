using System.Collections.ObjectModel;
using System.Windows.Input;
using B04.EE.BlanckeK.Interfaces;
using B04.EE.BlanckeK.Models;
using FreshMvvm;
using Xamarin.Forms;

namespace B04.EE.BlanckeK.ViewModels
{
    public class SelectUserViewModel :FreshBasePageModel
    {
        #region Variables
        private readonly IUserService _userService;
        public User SelectedUser;
        #endregion

        #region Properties
        private ObservableCollection<User> _allUsersList;
        public ObservableCollection<User> AllUsersList
        {
            get => _allUsersList;
            set
            {
                _allUsersList = value;
                RaisePropertyChanged(nameof(AllUsersList));
            }
        }

        private string _userName;
        public string Name
        {
            get => _userName;
            set
            {
                _userName = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        private string _currentScore;
        public string CurrentScore
        {
            get => _currentScore;
            set
            {
                _currentScore = value;
                RaisePropertyChanged(nameof(CurrentScore));
            }
        }

        private string _currentLevel;
        public string CurrentLevel
        {
            get => _currentLevel;
            set
            {
                _currentLevel = value;
                RaisePropertyChanged(nameof(CurrentLevel));
            }
        }

       

        private bool _playerSelected;
        public bool PlayerSelected
        {
            get => _playerSelected;
            set
            {
                _playerSelected = value;
                RaisePropertyChanged(nameof(PlayerSelected));
            }
        }
        #endregion

        #region Constructor
        public SelectUserViewModel(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region Overrides
        public override async void Init(object initData)
        {
            AllUsersList = new ObservableCollection<User>(await _userService.GetAllUsers());
            RaisePropertyChanged(nameof(AllUsersList));
            base.Init(initData);
            PlayerSelected = false;
        }
        #endregion

        #region Commands
        public ICommand UpdateUserListCommand => new Command(async () =>
        {
            AllUsersList = new ObservableCollection<User>(await _userService.GetAllUsers());
        });

        public ICommand ShowUserDetails => new Command((user) =>
        {
            SelectedUser = (User)user;
            Name = SelectedUser == null ? "" : $"Naam: {SelectedUser.Name}";
            CurrentScore = SelectedUser == null ? "" : $"huidige score: {SelectedUser.Score}";
            CurrentLevel = SelectedUser == null ? "" : $"Level: {SelectedUser.Level}";
            PlayerSelected = SelectedUser != null;
        });

        public ICommand GoToGameScreenCommand => new Command(async () =>
        {
            await CoreMethods.PushPageModel<SelectGameViewModel>(SelectedUser);
        });

        public ICommand GoToNewUserScreenCommand => new Command(async () =>
        {
            await CoreMethods.PushPageModel<NewUserViewModel>();
        });

        public ICommand DeletePlayerCommand => new Command(async () =>
        {
            await _userService.DeleteUser(SelectedUser);
            AllUsersList = new ObservableCollection<User>(await _userService.GetAllUsers());
            ShowUserDetails.Execute(null);
        });

        #endregion
    }
}
