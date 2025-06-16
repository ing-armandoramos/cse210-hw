using System;
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override string GetStatus()
    {
        return "[∞] " + GetName() + " (" + GetDescription() + ")";//The goal is eternal, it would never have a [X] status
    }

    public override int RecordEvent()
    {
        // Always gives points
        return GetPoints();
    }

    public override string SaveData()
    {
        return $"EternalGoal|{GetName()}|{GetDescription()}|{GetPoints()}";
    }
}
