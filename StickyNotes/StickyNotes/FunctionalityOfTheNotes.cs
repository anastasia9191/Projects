using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Diagnostics;

namespace StickyNotes
{
    class FunctionalityOfTheNotes : IFunctionalytyOfTheNotes
    {
        IFileWork _fileName;
        IApplication _application;
        public FunctionalityOfTheNotes(IFileWork fileName)
        {
            _fileName = fileName;
           
        }

        public void NewNote()
        {

            Console.WriteLine("Please Enter Note:\n");
            string input = Console.ReadLine();//Read user input

            XmlWriterSettings NoteSettings = new XmlWriterSettings();//Add XML settings, change as you wish..

            NoteSettings.CheckCharacters = false;
            NoteSettings.ConformanceLevel = ConformanceLevel.Auto;
            NoteSettings.Indent = true;

            string FileName = DateTime.Now.ToString("dd-MM-yy") + ".xml";//The file name I chose date format..

            //write the file..
            using (XmlWriter NewNote = XmlWriter.Create(_fileName.NoteDirectory() + FileName, NoteSettings))
            {
                NewNote.WriteStartDocument();
                NewNote.WriteStartElement("Note");
                NewNote.WriteElementString("body", input);
                NewNote.WriteEndElement();

                NewNote.Flush();
                NewNote.Close();
            }
        }

        public void EditNote()
        {
            Console.WriteLine("Please enter file name.\n");
            string FileName = Console.ReadLine().ToLower();//Read user input

            if (File.Exists(_fileName.NoteDirectory() + FileName))
            {

                XmlDocument doc = new XmlDocument();

                //Load the document
                try
                {
                    doc.Load(_fileName.NoteDirectory() + FileName);

                    Console.Write(doc.SelectSingleNode("//body").InnerText);//get the note stored..

                    string ReadInput = Console.ReadLine();

                   
                        string newText = doc.SelectSingleNode("//body").InnerText = ReadInput;
                        doc.Save(_fileName.NoteDirectory() + FileName);
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could not edit note following error occurred: " + ex.Message);
                }


            }
            else
            {
                Console.WriteLine("File not found\n");
            }

        }

        public  void ReadNote()
        {
            Console.WriteLine("Please enter file name.\n");
            string FileName = Console.ReadLine().ToLower();

            if (File.Exists(_fileName.NoteDirectory() + FileName))
            {
                XmlDocument Doc = new XmlDocument();
                Doc.Load(_fileName.NoteDirectory() + FileName);

                Console.WriteLine(Doc.SelectSingleNode("//body").InnerText);
            }
            else
            {
                Console.WriteLine("File not found");
            }



        }

        public  void DeleteNote()
        {
            Console.WriteLine("Please enter file name\n");
            string FileName = Console.ReadLine();

            if (File.Exists(_fileName.NoteDirectory() + FileName))
            {
                Console.WriteLine(Environment.NewLine + "Are you sure you wish to delete this file? Y/N\n");
                string Confirmation = Console.ReadLine().ToLower();

                if (Confirmation == "y")
                {
                    try
                    {
                        File.Delete(_fileName.NoteDirectory() + FileName);
                        Console.WriteLine("File has been deleted\n");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("File not deleted following error occured: " + ex.Message);
                    }
                }
                else if (Confirmation == "n")
                {
                    _application.Run();
                }
                else
                {
                    Console.WriteLine("Invalid command\n");
                    DeleteNote();
                }
            }
            else
            {
                Console.WriteLine("File does not exist\n");
                DeleteNote();
            }
        }

        public  void ShowNotes()
        {
            string NoteLocation = _fileName.NoteDirectory();

            DirectoryInfo Dir = new DirectoryInfo(NoteLocation);

            if (Directory.Exists(NoteLocation))
            {
                FileInfo[] NoteFiles = Dir.GetFiles("*.xml");

                if (NoteFiles.Count() != 0)
                {

                    Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop + 2);
                    Console.WriteLine("+------------+");
                    foreach (var item in NoteFiles)
                    {
                        Console.WriteLine("  " + item.Name);
                    }



                    Console.WriteLine(Environment.NewLine);
                }
                else
                {
                    Console.WriteLine("No notes found.\n");
                }

            }
            else
            {
                Console.WriteLine(" Directory does not exist.....creating directory\n");
                Directory.CreateDirectory(NoteLocation);
                Console.WriteLine(" Directory: " + NoteLocation + " created successfully.\n");
            }
        }

        public void Exit()
        {
            Environment.Exit(0);
        }

       

      
       

    }
}
