using System;
using System.Diagnostics;
using System.Windows.Input;
using B04.EE.BlanckeK.Interfaces;
using B04.EE.BlanckeK.Models;
using B04.EE.BlanckeK.Validators;
using FluentValidation;
using FreshMvvm;
using Xamarin.Forms;

namespace B04.EE.BlanckeK.ViewModels
{
    public class NewUserViewModel : FreshBasePageModel
    {
        #region Variables
        private readonly IValidator _userValidator;
        private readonly IUserService _userService;
        private User _currentUser;
        #endregion

        #region Properties
        private string _userInputError;
        public string UserInputError
        {
            get => _userInputError;
            set
            {
                _userInputError = value;
                RaisePropertyChanged(nameof(UserInputError));
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        private int _age;
        public int Age
        {
            get => _age;
            set
            {
                _age = value;
                RaisePropertyChanged(nameof(Age));

            }
        }
        #endregion

        #region Constructor
        public NewUserViewModel(IUserService userService)
        {
            _userService = userService;
            _userValidator = new UserValidator();
        }
        #endregion

        #region Methods
        private bool Validate(User user)
        {
            user.Age = Age;
            user.Name = Name;

            var validationResult = _userValidator.Validate(user);

            foreach (var error in validationResult.Errors)
            {
                switch (error.PropertyName)
                {
                    case nameof(user.Name):
                        UserInputError = error.ErrorMessage;
                        break;
                    case nameof(user.Age):
                        UserInputError = error.ErrorMessage;
                        break;
                }
            }
            return validationResult.IsValid;
        }
        #endregion

        #region Commands
        public ICommand StartNewGameCommand => new Command(async () =>
        {
            _currentUser = new User
            {
                Name = Name,
                Age = Age,
                UserId = Guid.NewGuid(),
                Level = 1,
                Score = 0,
            };

            UserInputError = "";
            if (Validate(_currentUser) == false) await CoreMethods.DisplayAlert(UserInputError, "", "ok");
            else
            {
                await _userService.SaveUser(_currentUser);
                await CoreMethods.PushPageModel<SelectGameViewModel>(_currentUser);
                CoreMethods.RemoveFromNavigation<NewUserViewModel>();
            }
        });
        #endregion
    }

}
