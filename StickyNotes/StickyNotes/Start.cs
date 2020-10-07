using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StickyNotes
{
    class Start: IStart
    {
        IFileWork _fileName;
        IFunctionalytyOfTheNotes _functionNote;
        IApplication _application;
        public Start(IFileWork fileName, IFunctionalytyOfTheNotes functionNote, IApplication application)
        {
            _fileName = fileName;
            _functionNote = functionNote;
            _application = application;
        }

        public void ReadCommand()
        {
            //Read user input - Then execute correct method..
            Console.Write(Directory.GetDirectoryRoot(_fileName.NoteDirectory()));
            string Command = Console.ReadLine();

            switch (Command.ToLower())
            {
                case "new":
                    _functionNote.NewNote();
                    _application.Run();
                    break;
                case "edit":
                    _functionNote.EditNote();
                    _application.Run();
                    break;
                case "read":
                    _functionNote.ReadNote();
                    _application.Run();
                    break;
                case "delete":
                    _functionNote.DeleteNote();
                    _application.Run();
                    break;
                case "shownotes":
                    _functionNote.ShowNotes();
                    _application.Run();
                    break;
                case "dir":
                    _fileName.NotesDirectory();
                    _application.Run();
                    break;
                case "cls":
                    Console.Clear();
                    _application.Run();
                    break;
                case "exit":
                    _functionNote.Exit();
                    break;
                default:
                    CommandsAvailable();
                    _application.Run();
                    break;
            }
        }
        public void CommandsAvailable()
        {
            Console.WriteLine(" New - Create a new note\n Edit - Edit a note\n Read -  Read a note\n ShowNotes - List all notes\n Exit - Exit the application\n Dir - Opens note directory\n Help - Shows this help message\n Delete - Deletes the notes");
        }
    }
}
