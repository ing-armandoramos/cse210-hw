using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;

        while (running)
        {
            Console.WriteLine("Please choose one of the following options:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Entry entry = new Entry
                    {
                        _date = DateTime.Now.ToShortDateString()
                    };

                    HashSet<string> usedPrompts = new HashSet<string>();
                    int promptsToAsk = 3;

                    while (entry._promptResponses.Count < promptsToAsk)
                    {
                        string prompt = promptGenerator.GetRandomPrompt();

                        if (!usedPrompts.Contains(prompt))
                        {
                            usedPrompts.Add(prompt);
                            Console.WriteLine($"Prompt: {prompt}");
                            Console.Write("Your response: ");
                            string response = Console.ReadLine();
                            entry._promptResponses.Add((prompt, response));
                        }
                    }

                    journal.AddEntry(entry);
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    Console.WriteLine("Journal saved.");
                    break;

                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    Console.WriteLine("Journal loaded.");
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine(); // Add space between menu loops
        }
    }
}
