using System;

public class ChecklistGoal : Goal
{
    private int targetCount;
    private int currentCount;
    private int bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus, int currentCount = 0)
        : base(name, description, points)
    {
        this.targetCount = targetCount;
        this.bonus = bonus;
        this.currentCount = currentCount;
    }

    public override string GetStatus()
    {
        string check = (currentCount >= targetCount) ? "[X]" : "[ ]";
        return $"{check} {GetName()} ({GetDescription()}) -- Completed {currentCount}/{targetCount}";
    }

    public override int RecordEvent()
    {
        if (currentCount < targetCount)
        {
            currentCount++;
            if (currentCount == targetCount)
            {
                // Give normal points plus bonus
                return GetPoints() + bonus;
            }
            else
            {
                // Otherwise, just give normal points
                return GetPoints();
            }
        }
        else
        {
            return 0;
        }
    }

    public override string SaveData()
    {
        return $"ChecklistGoal|{GetName()}|{GetDescription()}|{GetPoints()}|{targetCount}|{bonus}|{currentCount}";
    }
}
