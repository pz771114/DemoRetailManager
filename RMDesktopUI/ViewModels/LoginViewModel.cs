using Caliburn.Micro;
using RMDesktopUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDesktopUI.ViewModels
{
    public class LoginViewModel:Screen
    {
        private string _userName;
        private string _password;
        private IAPIHelper _apiHelper;
        public LoginViewModel(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
            }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value;
                NotifyOfPropertyChange(() => Password); 
            }
        }

        public bool CanLogIn(string userName, string password)
        {
            bool output = false;
            if(userName.Length>0 && password.Length>0)
            {
                output = true;
            }
            return output;
        }

        public async Task LogIn()
        {
            try
            {
                var result = await _apiHelper.Authenticate(UserName, Password);
            }
            catch (Exception ex)
            {

                //throw some errors
                Console.WriteLine(ex.Message);
            }
        }
    }
}
