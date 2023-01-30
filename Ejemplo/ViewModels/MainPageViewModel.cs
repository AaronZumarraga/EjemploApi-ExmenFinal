using IntelliJ.Lang.Annotations;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejemplo.Models;

namespace Ejemplo.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        public MainPageViewModel()
        {
            GetUserCommand = new AsyncRelayCommand(GetUser);
        }
        /// <summary>
        /// Command to get user details
        /// </summary>
        public IAsyncRelayCommand GetUserCommand { get; }
        /// <summary>
        /// User Object
        /// </summary>
        [ObservableProperty]
        User user;
        /// <summary>
        /// Message property to show API call result
        /// </summary>
        [ObservableProperty]
        string message;
        /// <summary>
        /// Is busy property to show loader on screen
        /// </summary>
        [ObservableProperty]
        bool isBusy;

        /// <summary>
        /// Gets the user data from API
        /// </summary>
        private async Task GetUser()
        {
            IsBusy = true;
            await RestServiceCall<User>.Get("users/7", UserDataLoaded, UserDataLoadFailed);
            IsBusy = false;
        }

        /// <summary>
        /// User details loaded successfully
        /// </summary>
        /// <param name="userObj">User</param>
        private void UserDataLoaded(User userObj)
        {
            if (userObj != null)
            {
                User = userObj;
            }
            Message = "El usuario que se muestra es:";
        }
        /// <summary>
        /// Failed to load user data
        /// </summary>
        /// <param name="exception">Exception</param>
        private void UserDataLoadFailed(Exception exception)
        {
            Message = exception?.Message;
        }
    }
}
