public class PromptGenerator 
{
    public List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
    };

    public string GetRandomPrompt()
    {
        Random randomGenerator = new Random(); // Aquí cree una instancia para el Random Class 
        int index = randomGenerator.Next(_prompts.Count); // aquí la variable index, será la instancia y el '.Next(_prompts.Count)' significa que tendrá el siguiente int u oración en este caso en el rango de Longitud de la lista _prompts, '_prompts.Count'
        return _prompts[index]; //devuelve la pregunta
    }
}