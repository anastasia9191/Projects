using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesApp2._0.Core;
using NotesApp2._0.Data;

namespace NotesApp2._0.Pages.Notes
{
    public class AddNoteModel : PageModel
    {
        private readonly INotesData notesData;
        public AddNoteModel(INotesData notesData)
        {
            this.notesData = notesData;
        }
        public Note Note { get; set; }
        public void OnGet()
        {
            
        }
        public void OnPost(Note note)
        {
            Note = notesData.Add(note);
        }
     
    }
}
