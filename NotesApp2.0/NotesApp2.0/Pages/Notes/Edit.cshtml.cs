using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesApp2._0.Core;
using NotesApp2._0.Data;

namespace NotesApp2._0.Pages.Notes
{
    public class EditModel : PageModel
    {
        private readonly INotesData notesData;
        public EditModel(INotesData notesData)
        {
            this.notesData = notesData;
        }
        [BindProperty] // priveazca, mojno ispolizovati srazu v tele metoda
        public Note Note { get; set; }
        public void OnGet(int? noteId)
        {
            Note = notesData.GetById(noteId.Value);
        }
        public IActionResult OnPost()
        {

            notesData.Update(Note);
            return RedirectToPage("./List");
        }

    }
}
