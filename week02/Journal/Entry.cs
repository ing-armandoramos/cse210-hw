using System;
using System.Collections.Generic;

public class Entry
{
    public string _date;
    public List<(string Prompt, string Response)> _promptResponses = new List<(string, string)>();

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        foreach (var pair in _promptResponses)
        {
            Console.WriteLine($"Prompt: {pair.Prompt}");
            Console.WriteLine($"Response: {pair.Response}");
            Console.WriteLine();
        }
    }
}
