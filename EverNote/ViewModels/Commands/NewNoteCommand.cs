using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EverNote.Models;

namespace EverNote.ViewModels.Commands
{
    public class NewNoteCommand : ICommand
    {
        public NotesViewModel NotesViewModel { get; set; }

        public NewNoteCommand(NotesViewModel notesViewModel)
        {
            this.NotesViewModel = notesViewModel;
        }

        public bool CanExecute(object parameter)
        {
           Notebook selectedNotebook = parameter as Notebook;
           return selectedNotebook != null;
        }

        public void Execute(object parameter)
        {
            Notebook selectedNotebook = parameter as Notebook;

            NotesViewModel.CreateNote(selectedNotebook.Id);
            NotesViewModel.ReadNotes();
        }

        public event EventHandler CanExecuteChanged;
    }
}
