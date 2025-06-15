using System;
using System.Threading;

class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking your through breathing in and out. Clear your mind and focus on your breathing.";
    }

    protected override void ExecuteActivity()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in... ");
            ShowCountdown(5);
            
            Console.WriteLine();
            Console.Write("Now breathe out... ");
            ShowCountdown(5);
            Console.WriteLine();
        }
    }
}