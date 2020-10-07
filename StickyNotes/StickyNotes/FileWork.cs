using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace StickyNotes
{

    public class FileWork : IFileWork
    {
        public string NoteDirectory()
        {
            string NoteDirectory = @"C:\Users\asvarciuc\Documents\Notes\";
            return NoteDirectory;
        }
        public void NotesDirectory()
        {   
        
        Process.Start("explorer.exe", NoteDirectory());
        }
    }
}
