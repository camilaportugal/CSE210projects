public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    protected int _bonus; 

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0; 
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (_amountCompleted < _target) 
        {
            _amountCompleted++;
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted == _target; 
    }

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} -- Currently Completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_bonus},{_target},{_amountCompleted}";
    }

    public static ChecklistGoal CreateFromString(string data)
    {
        string[] parts = data.Split(',');
        string name = parts[0];
        string description = parts[1];
        int points = int.Parse(parts[2]);
        int bonus = int.Parse(parts[3]);
        int target = int.Parse(parts[4]);
        int amountCompleted = int.Parse(parts[5]);

        ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);
        goal._amountCompleted = amountCompleted;

        return goal;
    }


    public int GetBonus()
    {
        return _bonus;
    }
}