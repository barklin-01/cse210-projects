using System;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = 0;
    }

    public override int RecordEvent()
    {
        if (_currentCount >= _targetCount)
        {
            return 0;
        }

        _currentCount++;

        int earned = _points;

        // bonus SOLO cuando se completa todo
        if (_currentCount == _targetCount)
        {
            earned += _bonus;
        }

        return earned;
    }

    public override bool IsComplete()
    {
        return _currentCount >= _targetCount;
    }

    public override string GetStatus()
    {
        return IsComplete() ? "[X]" : "[ ]";
    }

    public override string GetStringRepresentation()
    {
        return $"Checklist|{GetName()}|{_currentCount}|{_targetCount}|{_bonus}|{GetPoints()}";
    }

    public override string GetDisplayString()
    {
        return $"{GetStatus()} {GetName()} ({GetDescription()}) -- Currently completed: {_currentCount}/{_targetCount}";
    }
}