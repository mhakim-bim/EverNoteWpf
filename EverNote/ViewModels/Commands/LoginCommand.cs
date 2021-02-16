using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EverNote.Models;

namespace EverNote.ViewModels.Commands
{
     public class LoginCommand :ICommand
    {
        public LoginViewModel LoginViewModel { get; set; }

        public LoginCommand(LoginViewModel loginViewModel)
        {
            this.LoginViewModel = loginViewModel;
        }

        public bool CanExecute(object parameter)
        {
            var user = parameter as User;
            //if (user != null && (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password)))
            //{
            //    return false;
            //}
           
            return true;
        }

        public void Execute(object parameter)
        {
          LoginViewModel.Login();
        }

        public event EventHandler CanExecuteChanged;
    }
}
