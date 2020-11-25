using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace MyToDoList
{
    class ActionsNotes
    {

        public void ShowNotes(string[] notes)
        {
            foreach (string note in notes)
            {
                Console.WriteLine(note);
            }
        }
        public string AddNote(string sourceFile)
        {
            string notes = "";
            using (StreamReader reader = new StreamReader(sourceFile))
                notes = reader.ReadLine();
            return notes;
        }
        public string[] EditNote(string[] notes, string sourceFile)
        {
            Console.WriteLine("Choose the numer of note you whant to change");
            var numberNote = Console.ReadLine();
            //using (StreamReader reader = new StreamReader(sourceFile))
            for (int i = 0; i < notes.Length; i++)
            {
                if (notes[i] == numberNote)
                {
                    notes[i] = Console.ReadLine();
                }
            }
            return notes;
        }
        public string[] DeliteNote(string[] notes)
        {
            List<string> tmp = new List<string>(notes);
            Console.WriteLine($"Please enter the number of the note you whant to delete");
            var numIdx = Int32.Parse(Console.ReadLine());
            tmp.RemoveAt(numIdx);
            return notes;

        }
    }
}
