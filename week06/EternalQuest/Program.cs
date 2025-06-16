//Exceeds the core requirements by setting an InstantGoal, this addition will help the user to setup an instant activity with a timer (thus eliminating procrastination) added fun animations as well

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();

        while (true)
        {
            Console.WriteLine("\n--- Goal Tracker ---");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Select Goal Type:");
                Console.WriteLine("1. Simple Goal");
                Console.WriteLine("2. Eternal Goal");
                Console.WriteLine("3. Checklist Goal");
                Console.WriteLine("4. Instant Goal");
                Console.Write("Your choice: ");
                string type = Console.ReadLine();

                Console.Write("Enter goal name: ");
                string name = Console.ReadLine();
                Console.Write("Enter description: ");
                string description = Console.ReadLine();
                Console.Write("Enter points: ");
                int points = int.Parse(Console.ReadLine());

                if (type == "1")
                {
                    manager.AddGoal(new SimpleGoal(name, description, points));
                }
                else if (type == "2")
                {
                    manager.AddGoal(new EternalGoal(name, description, points));
                }
                else if (type == "3")
                {
                    Console.Write("How many times to complete: ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("Bonus points for completing: ");
                    int bonus = int.Parse(Console.ReadLine());
                    manager.AddGoal(new ChecklistGoal(name, description, points, target, bonus));
                }
                else if (type == "4")
                {
                    Console.Write("How many seconds to complete the instant goal: ");
                    int timeLimit = int.Parse(Console.ReadLine());
                    manager.AddGoal(new InstantGoal(name, description, points, timeLimit));
                }
            }
            else if (choice == "2")
            {
                manager.DisplayGoals();
            }
            else if (choice == "3")
            {
                manager.DisplayGoals();
                Console.Write("Select goal number to record: ");
                int index = int.Parse(Console.ReadLine()) - 1;
                manager.RecordEvent(index);
            }
            else if (choice == "4")
            {
                manager.DisplayScore();
            }
            else if (choice == "5")
            {
                Console.Write("Enter filename to save: ");
                string filename = Console.ReadLine();
                manager.SaveToFile(filename);
            }
            else if (choice == "6")
            {
                Console.Write("Enter filename to load: ");
                string filename = Console.ReadLine();
                manager.LoadFromFile(filename);
            }
            else if (choice == "7")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }
}
