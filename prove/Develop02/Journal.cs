using System.IO;
public class Journal 
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
        }

        else
        {
            foreach (Entry entry in _entries)
            {
                entry.Display();
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date} - Prompt: {entry._promptText}");
                outputFile.WriteLine($"> {entry._entryText}");
            }
        }
    }

    public void LoadFromFile(string file)
    {
        if (File.Exists(file))
        {
            string[] lines = System.IO.File.ReadAllLines(file);

            for (int i = 0; i < lines.Length; i += 2)
            {
           
                if (i + 1 < lines.Length)
                {
                    string[] parts = lines[i].Split(" - Prompt: ");

                    if (parts.Length == 2)
                    {
                        Entry entry = new Entry()
                        {
                            _date = parts[0],
                            _promptText = parts[1],
                            _entryText = lines[i + 1].Substring(2) 
                        };

                        _entries.Add(entry);
                    }
                }

                else 
                {
                    Console.WriteLine("File not found.");
                }
            }
        } 
    }

    public int CountEntriesFile(string file)
    {

        string[] lines = System.IO.File.ReadAllLines(file);
        int entryCount = 0;

        for (int i = 0; i < lines.Length; i += 2)
        {
            if (i + 1 < lines.Length)
            {
                entryCount++;
            }
        }

        return entryCount;
    }
}
   