using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace EverNote.ViewModels
{
    public class DataBaseHelper
    {
        public static string dbFile = Path.Combine(Environment.CurrentDirectory,"NoteDb.db3");

        public static bool Insert<T>(T item)
        {
            bool result = false;

            using (SQLiteConnection sqLiteConnection = new SQLiteConnection(dbFile))
            {
                sqLiteConnection.CreateTable<T>();
                var numberOfRows =sqLiteConnection.Insert(item);
                result = numberOfRows>0;
            }

            return result;
        }

        public static bool Update<T>(T item)
        {
            bool result = false;

            using (SQLiteConnection sqLiteConnection = new SQLiteConnection(dbFile))
            {
                sqLiteConnection.CreateTable<T>();
                var numberOfRows = sqLiteConnection.Update(item);
                result = numberOfRows > 0;
            }

            return result;
        }

        public static bool Delete<T>(T item)
        {
            bool result = false;

            using (SQLiteConnection sqLiteConnection = new SQLiteConnection(dbFile))
            {
                sqLiteConnection.CreateTable<T>();
                var numberOfRows = sqLiteConnection.Delete(item);
                result = numberOfRows > 0;
            }

            return result;
        }
    }
}
