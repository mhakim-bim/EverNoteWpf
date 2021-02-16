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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EverNote.Views.UserControl
{
    /// <summary>
    /// Interaction logic for Notebook.xaml
    /// </summary>
    public partial class Notebook : System.Windows.Controls.UserControl
    {
        public Models.Notebook DisplayNotebook
        {
            get { return (Models.Notebook)GetValue(DisplayNotebookProperty); }
            set { SetValue(DisplayNotebookProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DisplayNotebook.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisplayNotebookProperty =
            DependencyProperty.Register("DisplayNotebook", typeof(Models.Notebook), typeof(Notebook), new PropertyMetadata(null,SetValues));

        private static void SetValues(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Notebook notebook = d as Notebook;
            if (notebook != null)
            {
                notebook.NotebookName.Text = (e.NewValue as Models.Notebook).Name;
            }
        }


        public Notebook()
        {
            InitializeComponent();
        }
    }
}
