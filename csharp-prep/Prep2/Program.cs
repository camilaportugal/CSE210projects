using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string inputUser = Console.ReadLine();
        int grade = int.Parse(inputUser);

        string letter = "";

        if (grade >= 90)
        {
            letter = "A";
        }

        else if (grade >= 80)
        {
            letter = "B";
        }

        else if (grade >= 70)
        {
            letter = "C";
        }

        else if (grade >= 60)
        {
            letter = "D";
        }

        else
        {
            letter = "F";
        }

        int lastDigit = grade % 10;
        string sign = "";

        if (lastDigit >= 7)
        {
            sign = "+";
        }

        else if (lastDigit < 3)
        {
            sign = "-";
        }

        else 
        {
            sign = " ";
        }

        if (grade > 93 || letter == "F")
        {
            sign = " ";
        }

        Console.WriteLine($"Your grade percentage is {letter}{sign}");

        if (grade >= 70)                
        {
            Console.WriteLine("Congratulations, you passed!");
        }

        else 
        {
            Console.WriteLine("Better luck next time!");
        }
    }

}