using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EverNote.Annotations;
using EverNote.Models;
using EverNote.ViewModels.Commands;
using SQLite;

namespace EverNote.ViewModels
{
    public class LoginViewModel 
    {
        private User _user;

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
            }
        }

        public RegisterCommand RegisterCommand { get; set; }
        public LoginCommand LoginCommand { get; set; }

        public event EventHandler HasLoggedIn;
        public LoginViewModel()
        {
            RegisterCommand = new RegisterCommand(this);
            LoginCommand = new LoginCommand(this);
            CommandManager.InvalidateRequerySuggested();
        }

        public void Login()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DataBaseHelper.dbFile))
            {
                connection.CreateTable<User>();
                var user = connection.Table<User>().Where(x => x.UserName == User.UserName).FirstOrDefault();
                if (user.Password == User.Password)
                {
                    App.UserId = user.Id.ToString();
                    HasLoggedIn?.Invoke(this,new EventArgs());
                }
            }
        }

        public void Register()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DataBaseHelper.dbFile))
            {
                connection.CreateTable<User>();
                var result =DataBaseHelper.Insert(User);
                if (result)
                {
                    App.UserId = User.Id.ToString();
                    HasLoggedIn?.Invoke(this, new EventArgs());
                }
            }
        }

       
    }
}
