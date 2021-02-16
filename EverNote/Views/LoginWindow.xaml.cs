using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EverNote.ViewModels;

namespace EverNote.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            LoginViewModel loginViewModel = new LoginViewModel();
            ContainerGrid.DataContext = loginViewModel;

            loginViewModel.HasLoggedIn  += LoginViewModelOnHasLoggedIn; 
        }

        private void LoginViewModelOnHasLoggedIn(object sender, EventArgs e)
        {
            this.Close();
        }


        private void HaveAccountButton_OnClick(object sender, RoutedEventArgs e)
        {
            registerStackPanel.Visibility = Visibility.Collapsed;
            loginStackPanel.Visibility = Visibility.Visible;
        }

        private void NoAccountButton_OnClick(object sender, RoutedEventArgs e)
        {
            loginStackPanel.Visibility = Visibility.Collapsed;
            registerStackPanel.Visibility = Visibility.Visible;
        }

        
    }
}
