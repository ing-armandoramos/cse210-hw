using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 3, 6), 30, 5.0),
            new Cycling(new DateTime(2023, 4, 7), 45, 20.0),
            new Swimming(new DateTime(2024, 5, 8), 40, 30)
        };
        //Iterate through this list and call the GetSummary method on each item and display the results.
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}