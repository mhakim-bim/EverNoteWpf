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
using EverNote.Models;

namespace EverNote.Views.UserControl
{
    /// <summary>
    /// Interaction logic for NotesControl.xaml
    /// </summary>
    public partial class NotesControl : System.Windows.Controls.UserControl
    {
        public Note Note        
        {
            get { return (Note)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("Note", typeof(Note), typeof(NotesControl), new PropertyMetadata(null,SetValues));

        private static void SetValues(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NotesControl notesControl = d as NotesControl;
            if (notesControl != null)
            {
                notesControl.TitleTextBlock.Text = (e.NewValue as Note).Title;
                notesControl.EditedTextBlock.Text = (e.NewValue as Note).UpdatedTime.ToShortDateString();
                notesControl.contentTextBlock.Text = (e.NewValue as Note).Title;

            }
        }


        public NotesControl()
        {
            InitializeComponent();
        }
    }
}
