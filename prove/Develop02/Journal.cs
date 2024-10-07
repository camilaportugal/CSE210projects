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
        if (_entries.Count == 0) // si la lista _entries está vacia, dice que no se encontraron files
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
        if (File.Exists(file)) //verifica si el archivo existe 
        {
            string[] lines = System.IO.File.ReadAllLines(file); //Si el archivo existe, se lee línea por línea usando File.ReadAllLines(file), lo cual devuelve un arreglo de strings llamado lines que contiene todas las líneas del archivo.

            for (int i = 0; i < lines.Length; i += 2) // La función recorre las líneas en un bucle for, incrementando i de dos en dos (i += 2). Esto sugiere que cada entrada ocupa dos líneas consecutivas en el archivo.
            {                                         //La condición i < lines.Length asegura que el bucle continúe ejecutándose mientras i sea menor que el número de líneas disponibles en el archivo.
           
                if (i + 1 < lines.Length)
                {                                                      // En cada iteración, se verifica que la siguiente línea (i + 1) exista, y luego se intenta dividir la línea actual (lines[i]) usando " - Prompt: " como delimitador.
                    string[] parts = lines[i].Split(" - Prompt: ");

                    if (parts.Length == 2) //Si la línea tiene dos partes después de dividir (parts.Length == 2), se crea un objeto de la clase Entry
                    {
                        Entry entry = new Entry()
                        {
                            _date = parts[0], // _date asignado a la primera parte (parts[0]).
                            _promptText = parts[1],  //_promptText asignado a la segunda parte (parts[1]).
                            _entryText = lines[i + 1].Substring(2) //_entryText asignado a la línea siguiente (lines[i + 1]), comenzando desde el tercer carácter (Substring(2)), lo cual sugiere que las dos primeras posiciones no son relevantes para el contenido.
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
   