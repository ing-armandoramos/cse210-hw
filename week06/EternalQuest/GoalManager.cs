using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    private int score = 0;

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }
    public void DisplayGoals()
    {
        Console.WriteLine("\nYour Goals:");
        int i = 1;
        foreach (Goal goal in goals)
        {
            Console.WriteLine($"{i}. {goal.GetStatus()}");
            i++;
        }
    }
    public void DisplayScore()
    {
        Console.WriteLine($"\nYour current score is: {score}");
    }
    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            int earnedPoints = goals[goalIndex].RecordEvent();
            score += earnedPoints;
            Console.WriteLine($"\nYou earned {earnedPoints} points!");
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(score);
            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.SaveData());
            }
        }
    }
    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            goals.Clear();
            string[] lines = File.ReadAllLines(filename);
            score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split("|");

                if (parts[0] == "SimpleGoal")
                {
                    var goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
                    goals.Add(goal);
                }
                else if (parts[0] == "EternalGoal")
                {
                    var goal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                    goals.Add(goal);
                }
                else if (parts[0] == "ChecklistGoal")
                {
                    var goal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]));
                    goals.Add(goal);
                }
                else if (parts[0] == "InstantGoal")
                {
                    var goal = new InstantGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]));
                    goals.Add(goal);
                }
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
    public int GetGoalCount()
    {
        return goals.Count;
    }
}
