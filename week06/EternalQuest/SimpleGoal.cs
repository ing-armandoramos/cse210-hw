using System;
public class SimpleGoal : Goal
{
    private bool isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        this.isComplete = isComplete;
    }
    public override string GetStatus()
    {
        return (isComplete ? "[X]" : "[ ]") + " " + GetName() + " (" + GetDescription() + ")";
    }
    public override int RecordEvent()
    {
        if (!isComplete)
        {
            isComplete = true;
            return GetPoints();
        }
        else
        {
            return 0;
        }
    }

    // Save data as a string
    public override string SaveData()
    {
        return $"SimpleGoal|{GetName()}|{GetDescription()}|{GetPoints()}|{isComplete}";
    }
}
