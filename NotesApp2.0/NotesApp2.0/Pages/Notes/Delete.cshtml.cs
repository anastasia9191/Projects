using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesApp2._0.Core;
using NotesApp2._0.Data;

namespace NotesApp2._0.Pages.Notes
{
    public class DeleteModel : PageModel
    {
        private readonly INotesData notesData;
       
        public DeleteModel(INotesData notesData)
        {
            this.notesData = notesData;
        }
        public Note Note { get; set; }

        public IActionResult OnGet(int noteId)
        {
            Note = notesData.GetById(noteId);
            if (Note == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost(int noteId)
        {
            var note = notesData.Delete(noteId);
            if (note == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"{note.Title} deleted";
            return RedirectToPage("./List");
        }

    }
}
