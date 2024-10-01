using System;

// I added a new method to count the entries in a file.
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        Console.WriteLine("Welcome to the Journal Program");

        int userChoice = 0 ;
        while (userChoice != 5)
        {
            Console.WriteLine("Please select one of the following choices");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.WriteLine("6. Entry Count");
            Console.Write("What would you like to do? ");
            userChoice = int.Parse(Console.ReadLine());

            if (userChoice == 1)
            {
                DateTime theCurrentTime = DateTime.Now;

                Entry newEntry = new Entry(); 
                newEntry._date = theCurrentTime.ToShortDateString();

                PromptGenerator promptGenerator = new PromptGenerator();
                newEntry._promptText = promptGenerator.GetRandomPrompt();

                newEntry.Display();
                string textUser = Console.ReadLine();
                newEntry._entryText = textUser;

                journal.AddEntry(newEntry);
            }

            else if (userChoice == 2)
            {
                
                journal.DisplayAll();
            }

            else if (userChoice == 3)
            {
                Console.Write("What is the file name? ");
                string loadFile = Console.ReadLine();               
                journal.LoadFromFile(loadFile);
            }

            else if (userChoice == 4)
            {
                Console.Write("What is the file name? ");
                string saveFile = Console.ReadLine();
                journal.SaveToFile(saveFile);
            }

            else if (userChoice == 5)
            {
                Console.WriteLine("Goodbye!");
            }

            else if (userChoice == 6)
            {
                Console.WriteLine("What is the file name? ");
                string filename = Console.ReadLine();
                int count = journal.CountEntriesFile(filename); 

                Console.WriteLine($"The number of entries in the file '{filename}' is {count}");
            }
        }
        
    }
        
}
