using AnotherNotesApp.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnotherNotesApp.Data
{
    public interface IDataRepo
    {
        public void GetNotes();
        public  void AddNote();
        public void DeleteNote();
        public void UpdateNote();
        public void GetByIdNote();

    }
}
