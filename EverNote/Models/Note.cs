using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EverNote.Annotations;
using SQLite;

namespace EverNote.Models
{
    public class Note :INotifyPropertyChanged
    {

        private int _id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value; 
                OnPropertyChanged();
            }
        }

        private int _notebookId;
        [Indexed]
        public int NotebookId
        {
            get { return _notebookId; }
            set
            {
                _notebookId = value;
                OnPropertyChanged();
            }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value; 
                OnPropertyChanged();
            }
        }
        private DateTime _createdTime;

        public DateTime CreatedTime
        {
            get { return _createdTime; }
            set
            {
                _createdTime = value;
                OnPropertyChanged();
            }
        }



        private DateTime _updatedTime;

        public DateTime UpdatedTime
        {
            get { return _updatedTime; }
            set
            {
                _updatedTime = value; 
                OnPropertyChanged();
            }
        }

        private string _fileLocation;

        public string FileLocation
        {
            get { return _fileLocation; }
            set
            {
                _fileLocation = value; 
                OnPropertyChanged();
            }
        }

        #region Property Changed Methods
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}
