public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _userOption = 0; 
    private int _userGoal = 0; 

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0; 
    }

    public void Start()
    {
        while (_userOption != 6)
        {
            DisplayPlayerInfo(); 
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");
            _userOption = int.Parse(Console.ReadLine());
            Console.WriteLine();

            if (_userOption == 1)
            {
                ListGoalNames();
                CreateGoal(); 
                Console.WriteLine();
            }

            else if (_userOption == 2)
            {
                ListGoalDetails();
                Console.WriteLine(); 
            }

            else if (_userOption == 3)
            {
                Console.Write("What is the filename for the goal file? ");
                string file = Console.ReadLine();
                SaveGoals(file);
                Console.WriteLine();
            }

            else if (_userOption == 4)
            {
                Console.Write("What is the filename for the goal file? ");
                string file = Console.ReadLine();
                LoadGoals(file);
                Console.WriteLine();
            }

            else if (_userOption == 5)
            {
                RecordEvent(); 
                Console.WriteLine();
            }

            else if (_userOption == 6)
            {
                Console.WriteLine("Thank You!");
                Console.WriteLine();
            }

            else
            {
                Console.WriteLine("Please Enter a choice from the menu.");
                Console.WriteLine();
            }
            
        }
        
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine();
    }

    public void ListGoalNames()
    {
        if (_userOption == 1)
        {
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("1. Simple Goal"); 
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Which type of goal would you like to create?: ");
            _userGoal = int.Parse(Console.ReadLine()); 
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are: ");
        for(int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}"); 
        }
    }
    

    public void CreateGoal()
    {
        if(_userGoal == 1)
        {
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine(); 
            Console.Write("What is the amount of goals associated with this goal? ");
            int points = int.Parse(Console.ReadLine());

            SimpleGoal goal= new SimpleGoal(name, description, points);
            _goals.Add(goal);
        }

        else if(_userGoal == 2)
        {
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine(); 
            Console.Write("What is the amount of goals associated with this goal? ");
            int points = int.Parse(Console.ReadLine());
            Console.WriteLine();

            EternalGoal goal= new EternalGoal(name, description, points);
            _goals.Add(goal);
        }

        else if (_userGoal == 3)
        {
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine(); 
            Console.Write("What is the amount of goals associated with this goal? ");
            int points = int.Parse(Console.ReadLine());
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing in that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            Console.WriteLine();

            ChecklistGoal goal= new ChecklistGoal(name, description, points, target, bonus);
            _goals.Add(goal);
        }
    }

    public void RecordEvent()
    {
        ListGoalDetails(); 
        Console.Write("Whice goal did you accomplish? ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1; 

        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            Goal selectedGoal = _goals[goalIndex];
            int initialScore = _score; 

            selectedGoal.RecordEvent();

           
            if (selectedGoal is ChecklistGoal checklistGoal)
            {
                _score += checklistGoal.GetPoints(); 

                if (checklistGoal.IsComplete())
                {
                    _score += checklistGoal.GetBonus(); 
                }
            }
            else
            {
                _score += selectedGoal.GetPoints();
            }


            DisplayPlayerInfo();
        }

    }

    public void SaveGoals(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals(string file)
    {
        if (File.Exists(file))
        {
            using (StreamReader reader = new StreamReader(file))
            {

                string scoreLine = reader.ReadLine();
                if (scoreLine != null)
                {
                    _score = int.Parse(scoreLine); 
                }

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length > 0)
                    {
                        if (parts[0] == "SimpleGoal")
                        {
                            _goals.Add(SimpleGoal.CreateFromString(line));
                        }
                        else if (parts[0] == "EternalGoal")
                        {
                            _goals.Add(EternalGoal.CreateFromString(line));
                        }
                        else if (parts[0] == "ChecklistGoal")
                        {
                            _goals.Add(ChecklistGoal.CreateFromString(line));
                        }
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("This file not exist.");
        }
    }
}