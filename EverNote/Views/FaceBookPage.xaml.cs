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
using CefSharp;

namespace EverNote.Views
{
    /// <summary>
    /// Interaction logic for FaceBookPage.xaml
    /// </summary>
    public partial class FaceBookPage : Window
    {
        public FaceBookPage()
        {
            InitializeComponent();
        }


        void ExecuteScript(string script)
        {
            Browser.ExecuteScriptAsync(script);

            this.FindElementText.Text = Browser.Title;
        }

        private void ClickOnPage_OnClick(object sender, RoutedEventArgs e)
        {
           
            //Adding Email to Email Text
            string emailEntry = $"document.getElementById('email').value ='melhakim2016@gamil.com';";
            ExecuteScript(emailEntry);

            //Adding password to pass Text
            string passEntry = $"document.getElementById('pass').value ='hakim555';";
            ExecuteScript(passEntry);

            //Click login button
            string loginButton = $"document.getElementsByName('login')[0].click();";
            ExecuteScript(loginButton);
        }

        private void ShowDevTools_OnClick(object sender, RoutedEventArgs e)
        {
            Browser.ShowDevTools();
        }

        
    }
}
