using System;
using System.Collections.Generic;
using System.Threading;

class ListingActivity : Activity
{
    private string[] _prompts = {
        "Who are people that you appreciate?",
        "Things that the Church provides for you?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "People that is not longer alive that you would like to make proud of you",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
        "Things that you have achieved that you dreamed as a kid",
        "Things that you want your descendants to have from you"
    };

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can according to the question.";
    }

    protected override void ExecuteActivity()
    {
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Length)];
        
        Console.WriteLine();
        Console.WriteLine("List as many things as you remember according to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();

        List<string> items = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                items.Add(item);
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} items, congratulations!");
    }
}