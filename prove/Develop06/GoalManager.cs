public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _userOption = 0; 

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0; 
    }

    public void Start()
    {

        while (_userOption != 6)
        {
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

            if (_userOption > 6)
            {
                Console.WriteLine("Please enter a number from the menu: ");
                Console.WriteLine(); 
            }
        }
    }

    public void DisplayPlayerInfo()
    {

    }

    public void ListGoalNames()
    {

    }

    public void ListGoalDetails()
    {

    }

    public void CreateGoal()
    {

    }

    public void RecordEvent()
    {

    }

    public void SaveGoals()
    {

    }

    public void LoadGoals()
    {

    }
}