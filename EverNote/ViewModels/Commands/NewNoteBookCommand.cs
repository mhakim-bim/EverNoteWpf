using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EverNote.ViewModels.Commands
{
    public class NewNoteBookCommand :ICommand
    {
        public NotesViewModel NotesViewModel { get; set; }

        public NewNoteBookCommand(NotesViewModel notesViewModel)
        {
            this.NotesViewModel = notesViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            NotesViewModel.CreateNotebook();
        }

        public event EventHandler CanExecuteChanged;
    }
}
