using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EverNote.Models;

namespace EverNote.ViewModels.Commands
{
    public class RegisterCommand :ICommand
    {
        public LoginViewModel LoginViewModel { get; set; }

        public RegisterCommand(LoginViewModel loginViewModel)
        {
           this.LoginViewModel = loginViewModel;
        }

        public bool CanExecute(object parameter)
        {
            var user = parameter as User;
            //if (user != null && (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password)
            //                                                         || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Name)
            //                                                         || string.IsNullOrEmpty(user.LastName)))
            //{
            //    return false;
            //}
            return true;
        }

        public void Execute(object parameter)
        {
          LoginViewModel.Register();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
