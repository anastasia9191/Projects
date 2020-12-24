using AnotherNotesApp.Data;
using System;
using System.Collections.Generic;
using System.Text;
namespace AnotherNotesApp.Core
{
    public class RunApp: IRunApp
    {
        private readonly IDataRepo dataRepo;
        public RunApp(IDataRepo dataRepo)
        {
            this.dataRepo = dataRepo;
        }
        public void Start()
        {
            Console.WriteLine("Choose the operation you whant to use");
            Console.WriteLine("a - write new note, b- delete note,  c- updatr notes , d- show all notes, e- get note by Id");
            var answer = Console.ReadLine();
            switch(answer)
            {
                case "a":
                     dataRepo.AddNote();
                    break;
                case "b":
                    dataRepo.DeleteNote();
                    break;
                case "c":
                    dataRepo.UpdateNote();
                    break;
                case "d":
                    dataRepo.GetNotes();
                    break;
                case "e":
                    dataRepo.GetByIdNote();
                    break;
            }
                
        }
       
    }
}
