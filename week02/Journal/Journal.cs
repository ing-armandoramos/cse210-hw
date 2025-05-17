using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"Date:{entry._date}");
                foreach (var pair in entry._promptResponses)
                {
                    outputFile.WriteLine($"Prompt:{pair.Prompt}");
                    outputFile.WriteLine($"Response:{pair.Response}");
                }
                outputFile.WriteLine("---"); // Separator between entries
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        Entry currentEntry = null;
        string currentPrompt = "";

        foreach (var line in File.ReadLines(filename))
        {
            if (line.StartsWith("Date:"))
            {
                currentEntry = new Entry
                {
                    _date = line.Substring(5).Trim()
                };
            }
            else if (line.StartsWith("Prompt:"))
            {
                currentPrompt = line.Substring(7).Trim();
            }
            else if (line.StartsWith("Response:"))
            {
                string response = line.Substring(9).Trim();
                currentEntry._promptResponses.Add((currentPrompt, response));
            }
            else if (line == "---")
            {
                if (currentEntry != null)
                {
                    _entries.Add(currentEntry);
                    currentEntry = null;
                }
            }
        }
    }
}
