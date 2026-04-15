using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStatus()
    {
        return "[ ]";
    }

    public override string GetStringRepresentation()
    {
        return $"Eternal|{GetName()}|{GetPoints()}";
    }

    public override string GetDisplayString()
    {
        return $"{GetStatus()} {GetName()} ({GetDescription()})";
    }
}