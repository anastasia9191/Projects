using Microsoft.EntityFrameworkCore;
using NotesApp2._0.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotesApp2._0.Data
{
    public class SqlDataNotes : INotesData
    {
        private readonly NotesAppDbContext db;
        public SqlDataNotes(NotesAppDbContext db)
        {
            this.db = db;
            //if(!db.Notes.Any())
            //{
            //    db.Notes.Add(new Note
            //    {
            //        Title = "List for the new year"
            //    ,
            //        Content = "There is a lot of things to do"
            //    }
            //    );
            //    db.SaveChanges();
            //}
        }

        public Note Add(Note note)
        {
            db.Add(note);
            db.SaveChanges();
            return note;
        }

        public Note Delete(int id)
        {
            var note = db.Notes.FirstOrDefault(c=>c.Id==id);
            if (note != null)
            {
                db.Notes.Remove(note);
                db.SaveChanges();
            }
            return note;

        }
        public IEnumerable<Note> GetNotes()
        {
            return db.Notes.ToList();
        }
        public Note GetById(int id)
        {
            return db.Notes.Find(id);
        }
        public Note Update(Note updatedNote)
        {
            var entity = db.Notes.Attach(updatedNote);
            entity.State = EntityState.Modified;
            db.SaveChanges();
            return updatedNote;
        }
    }
}
