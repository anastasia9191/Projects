using NotesApp2._0.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesApp2._0.Data
{
    public interface INotesData
    {
        Note Add(Note note);
        IEnumerable<Note> GetNotes();
        Note Delete(int id);
        Note GetById(int id);
        Note Update(Note updatedNote);
    }
}
