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
    public class ListModel : PageModel
    {
        private readonly INotesData notesData;
        public ListModel(INotesData notesData)
        {
            this.notesData = notesData;
        }
        public IEnumerable<Note> Notes { get; set; }
        public void OnGet()
        {
            Notes = notesData.GetNotes();
        }
    }
}
