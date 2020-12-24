using AnotherNotesApp.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AnotherNotesApp.Data
{
    public class JsonData : IDataRepo
    {
        public void AddNote()
        {
            // Read existing json data
            var jsonData = File.ReadAllText("C:\\Users\\asvarciuc\\source\\repos\\AnotherNotesApp\\AnotherNotesApp.Data\\jsonFile.json");
            // De-serialize to object or create new list
            var noteList = JsonConvert.DeserializeObject<List<ListNotesModel>>(jsonData) ?? new List<ListNotesModel>();
            Console.WriteLine("Enter Notes Title : ");
            var notesTitle = Console.ReadLine();
            Console.WriteLine("\nEnter the Content of The Note : ");
            var contentNote = Console.ReadLine();
            Console.WriteLine("\nEnter the ID of The Note : ");
            var id = Console.ReadLine();
            noteList.Add(new ListNotesModel
            {
                Notes = 
                    new Note
                {
                    Title = notesTitle,
                    Content = contentNote,
                    Id = Convert.ToInt32(id)
                
                }

            });
            jsonData = JsonConvert.SerializeObject(noteList);
            File.WriteAllText("C:\\Users\\asvarciuc\\source\\repos\\AnotherNotesApp\\AnotherNotesApp.Data\\jsonFile.json", jsonData);
        }

        public void DeleteNote()
        {
            var jsonData = File.ReadAllText("C:\\Users\\asvarciuc\\source\\repos\\AnotherNotesApp\\AnotherNotesApp.Data\\jsonFile.json");
            // De-serialize to object or create new list
            var noteList = JsonConvert.DeserializeObject<List<ListNotesModel>>(jsonData);
            Console.WriteLine("Enter the id of the note");
            var id = Console.ReadLine();
            var noteToDelete = noteList.FirstOrDefault(c => c.Notes.Id == Convert.ToInt32(id));
            
            noteList.Remove(noteToDelete);
            jsonData = JsonConvert.SerializeObject(noteList);
            File.WriteAllText("C:\\Users\\asvarciuc\\source\\repos\\AnotherNotesApp\\AnotherNotesApp.Data\\jsonFile.json", jsonData);
        }

        public void GetByIdNote()
        {
            var jsonData = File.ReadAllText("C:\\Users\\asvarciuc\\source\\repos\\AnotherNotesApp\\AnotherNotesApp.Data\\jsonFile.json");
            // De-serialize to object or create new list
            var noteList = JsonConvert.DeserializeObject<List<ListNotesModel>>(jsonData);
            Console.WriteLine("Enter the id of the note");
            var id = Console.ReadLine();
            var noteToShow = noteList.FirstOrDefault(c => c.Notes.Id == Convert.ToInt32(id));
            Console.WriteLine(noteToShow);
        }

        public void GetNotes()
        {
            var jsonData = File.ReadAllText("C:\\Users\\asvarciuc\\source\\repos\\AnotherNotesApp\\AnotherNotesApp.Data\\jsonFile.json");
            // De-serialize to object or create new list
            var noteList = JsonConvert.DeserializeObject<List<ListNotesModel>>(jsonData);
            foreach(var note in noteList)
            {
                Console.WriteLine(note);
            }
        }

        public void UpdateNote()
        {
            var jsonData = File.ReadAllText("C:\\Users\\asvarciuc\\source\\repos\\AnotherNotesApp\\AnotherNotesApp.Data\\jsonFile.json");
            // De-serialize to object or create new list
            var noteList = JsonConvert.DeserializeObject<List<ListNotesModel>>(jsonData);
            Console.WriteLine("Enter the id of the note");
            var id = Console.ReadLine();
            Console.WriteLine("Enter new id of the note");
            var idNew = Console.ReadLine();
            Console.WriteLine("Enter new title for the note");
            var title = Console.ReadLine();
            Console.WriteLine("Enter new title for the note");
            var content = Console.ReadLine();
            var noteToUpdate = noteList.FirstOrDefault(c => c.Notes.Id == Convert.ToInt32(id));
            noteToUpdate.Notes.Id = Convert.ToInt32(idNew);
            noteToUpdate.Notes.Title = title;
            noteToUpdate.Notes.Content = content;
            jsonData = JsonConvert.SerializeObject(noteList);
            File.WriteAllText("C:\\Users\\asvarciuc\\source\\repos\\AnotherNotesApp\\AnotherNotesApp.Data\\jsonFile.json", jsonData);
        }
    }
}
