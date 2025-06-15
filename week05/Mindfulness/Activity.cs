using System;
using System.Threading;
abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    public void Run()
    {
        DisplayStartingMessage();
        PrepareToBegin();
        ExecuteActivity();
        DisplayEndingMessage();
    }
    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"This activity will start: {_name}");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
    }
    protected void PrepareToBegin()
    {
        Console.Clear();
        Console.WriteLine("Be ready in...");
        ShowSpinner(3);
    }
    protected void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Excellent job!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed the {_name} for {_duration} seconds.");
        ShowSpinner(3);
    }
    protected abstract void ExecuteActivity();
    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("|");
            Thread.Sleep(500);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(500);
            Console.Write("\b \b");
            Console.Write("-");
            Thread.Sleep(500);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(500);
            Console.Write("\b \b");
        }
    }
    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}