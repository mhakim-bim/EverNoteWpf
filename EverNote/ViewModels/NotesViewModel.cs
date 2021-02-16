using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EverNote.Models;
using EverNote.ViewModels.Commands;
using SQLite;

namespace EverNote.ViewModels
{
    public class NotesViewModel
    {
        public ObservableCollection<Notebook> Notebooks { get; set; }

        private Notebook _selectedNotebook;

        public Notebook SelectedNotebook
        {
            get { return _selectedNotebook; }
            set
            {
                _selectedNotebook = value; 
                //ToDO:Get notes
            }
        }

        public ObservableCollection<Note> Notes { get; set; }

        public NewNoteBookCommand NewNoteBookCommand { get; set; }
        public NewNoteCommand NewNoteCommand { get; set; }

        public NotesViewModel()
        {
            NewNoteBookCommand = new NewNoteBookCommand(this);
            NewNoteCommand =  new NewNoteCommand(this);
            Notebooks =new ObservableCollection<Notebook>();
            Notes = new ObservableCollection<Note>();
            
            ReadNotebooks();
        }

        public void CreateNotebook()
        {
            Notebook notebook = new Notebook()
            {
                Name = "New Notebook",UserId = int.Parse(App.UserId)
            };
            DataBaseHelper.Insert(notebook);
            ReadNotebooks();
        }

        public void CreateNote(int notebookId)
        {
            Note newNote = new Note()
            {
                NotebookId = notebookId,
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now,
                Title = "New Note"
            };

            DataBaseHelper.Insert(newNote);
            ReadNotes();
        }

        public void ReadNotebooks()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DataBaseHelper.dbFile))
            {
                var notebooks = connection.Table<Notebook>().ToList();
                Notebooks.Clear();
                notebooks.ForEach(x=>Notebooks.Add(x));
            }
        }

        public void ReadNotes()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DataBaseHelper.dbFile))
            {
                var notes = connection.Table<Note>().Where(n => n.NotebookId == SelectedNotebook.Id).ToList();
                Notes.Clear();
                notes.ForEach(x => Notes.Add(x));
            }
        }
    }
}
