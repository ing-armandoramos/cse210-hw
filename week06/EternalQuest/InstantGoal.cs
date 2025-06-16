//This is the exceeding requirements requirement

using System;
using System.Threading;
public class InstantGoal : Goal
{
    private int timeLimit;

    public InstantGoal(string name, string description, int points, int timeLimit)
        : base(name, description, points)
    {
        this.timeLimit = timeLimit;
    }
    public override string GetStatus()
    {
        return "+" + GetName() + " (" + GetDescription() + $") - Time limit: {timeLimit} seconds";
    }
    public override int RecordEvent()
    {
        Console.Clear();
        Console.WriteLine($"\n Starting Instant Goal: {GetName()}");
        Console.WriteLine($"Description: {GetDescription()}");
        Console.WriteLine($"You have {timeLimit} seconds to complete it.");
        Console.WriteLine("Type 'done' (lowercase) when finished before time runs out.\n");
        Console.WriteLine("Start typing below:");
        string userInput = "";
        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < timeLimit)
        {
            Console.Title = $" {(timeLimit - (int)(DateTime.Now - startTime).TotalSeconds)} seconds remaining...";

            // Read when a key is pressed
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    if (userInput.Trim().ToLower() == "done")
                    {
                        ShowSuccessAnimation();
                        Console.WriteLine("\n Well done! You completed the Instant Goal!");
                        Thread.Sleep(10000);
                        return GetPoints();
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Keep trying...");
                        userInput = "";
                    }
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (userInput.Length > 0)
                    {
                        userInput = userInput.Substring(0, userInput.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    userInput += key.KeyChar;
                    Console.Write(key.KeyChar);
                }
            }

            Thread.Sleep(100);
        }

        Console.Title = "Time's up!";
        Console.Clear();
        ShowFailAnimation();
        Console.WriteLine("\n Time's up! Try again next time.");
        Thread.Sleep(10000);
        return 0;
    }

    public override string SaveData()
    {
        return $"InstantGoal|{GetName()}|{GetDescription()}|{GetPoints()}|{timeLimit}";
    }

    private void ShowSuccessAnimation()
    {
        string[] frames = { "(•‿•)", "(^‿^)", "(≧◡≦)", "(✿◠‿◠)", "(｡♥‿♥｡)" };
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"\r🎉 Great Job! {frames[i % frames.Length]}    ");
            Thread.Sleep(500);
        }
        Console.WriteLine();
    }

    private void ShowFailAnimation()
    {
        string[] frames = { "(╯︵╰,)", "(ಥ﹏ಥ)", "(T⌓T)", "(｡•́︿•̀｡)" };
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"\r Don't give up! {frames[i % frames.Length]}    ");
            Thread.Sleep(500);
        }
        Console.WriteLine();
    }
}
