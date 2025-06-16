using System;

// Base class
public abstract class Goal
{
    // Name, description, and points for each goal
    private string name;
    private string description;
    private int points;

    // Create a new goal
    public Goal(string name, string description, int points)
    {
        this.name = name;
        this.description = description;
        this.points = points;
    }

    // Getter to get the name
    public string GetName() => name;

    // Getter to get the description
    public string GetDescription() => description;

    // Getter to get the base points
    public int GetPoints() => points;

    // Each goal will display its own info
    public abstract string GetStatus();

    // When user records progress, it returns how many points earned
    public abstract int RecordEvent();

    // Will be used to save to file
    public abstract string SaveData();
}
