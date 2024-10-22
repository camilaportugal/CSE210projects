using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a1 = new Assignment("Samuel Bennet", "Multiplication");
        Console.WriteLine(a1.GetSumamry());

        Console.WriteLine();

        MathAssignment a2 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(a2.GetSumamry());
        Console.WriteLine(a2.GetHomeworkList());

        Console.WriteLine();

        WritingAssignment a3 = new WritingAssignment("Mary Water", "European History", "The Causes of World War II");
        Console.WriteLine(a3.GetSumamry());
        Console.WriteLine(a3.GetWritingInformation());
    }
}