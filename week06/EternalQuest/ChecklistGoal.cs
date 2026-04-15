using System;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;
    private bool _bonusGiven;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = 0;
        _bonusGiven = false;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0; // ya está completo
        }

        _currentCount++;

        int total = GetPoints();

        if (_currentCount == _targetCount && !_bonusGiven)
        {
            total += _bonus;
            _bonusGiven = true;
        }

        return total;
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
        return $"Checklist|{GetName()}|{GetDescription()}|{GetPoints()}|{_currentCount}|{_targetCount}|{_bonus}|{_bonusGiven}";
    }

    public override string GetDisplayString()
    {
        return $"{GetStatus()} {GetName()} ({GetDescription()}) -- {_currentCount}/{_targetCount}";
    }
}