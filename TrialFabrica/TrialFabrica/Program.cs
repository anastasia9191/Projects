using System;

namespace TrialFabrica
{
    class Program
    {
        static void Main(string[] args)
        {
            Developer dev = new PanelDeveloper("ООО КирпичСтрой");
            House house2 = dev.Create();

            dev = new WoodDeveloper("Частный застройщик");
            House house = dev.Create();

            Console.ReadLine();
        }
    }
    // абстрактный класс строительной компании
    abstract class Developer
    {
        public string Name { get; set; }

        public Developer(string n)
        {
            Name = n;
        }
        // фабричный метод
        abstract public House Create();
    }
    // строит панельные дома
    class PanelDeveloper : Developer
    {
        public PanelDeveloper(string n) : base(n)
        { }

        public override House Create()
        {
            return new PanelHouse();
        }
    }
    // строит деревянные дома
    class WoodDeveloper : Developer
    {
        public WoodDeveloper(string n) : base(n)
        { }

        public override House Create()
        {
            return new WoodHouse();
        }
    }

    abstract class House
    { }

    class PanelHouse : House
    {
        public PanelHouse()
        {
            Console.WriteLine("Панельный дом построен");
        }
    }
    class WoodHouse : House
    {
        public WoodHouse()
        {
            Console.WriteLine("Деревянный дом построен");
        }
    }
    public void AddNote()
    {
        Console.WriteLine("Add title");
        var title = Console.ReadLine();
        Console.WriteLine("Add content");
        var content = Console.ReadLine();

        XElement rootElement = new XElement("RootElement");
        rootElement.Add(new XElement("Tilte", title));
        rootElement.Add(new XElement("Content", content));

        rootElement.Save("C:\\Users\\asvarciuc\\source\\repos\\AnotherNotesApp\\Notes.xml");
    }

    public void DeleteNote()
    {
        throw new NotImplementedException();
    }

    public void GetByIdNote()
    {
        throw new NotImplementedException();
    }

    public void GetNotes()
    {
        Stream xmlFromFile = File.Open("Notes.xml", FileMode.Open);
        StreamReader reader = new StreamReader(xmlFromFile);
        string xmlData = reader.ReadToEnd();
        Console.WriteLine(xmlData);
    }

    public void UpdateNote()
    {
        Console.WriteLine("Write the title of the note you whant to change");
        var title = Console.ReadLine();
        Stream xmlFromFile = File.Open("C:\\Users\\asvarciuc\\source\\repos\\AnotherNotesApp\\Notes.xml", FileMode.Open);
        StreamReader reader = new StreamReader(xmlFromFile);
        string xmlData = reader.ReadToEnd();
        XDocument document = new XDocument();
        document = XDocument.Parse(xmlData);
        var readNote = (from p in document.Descendants()
                        where p.Element("Title").Value == title
                        select p.Element("Content")).FirstOrDefault();
        Console.WriteLine("Write new content");
        var replaced = Console.ReadLine();
        readNote.ReplaceWith(replaced);
        Console.WriteLine("Note is updated");
        document.Save("Notes.xml");
    }
}
