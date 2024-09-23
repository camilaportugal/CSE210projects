using System;

class Program
{
    static void Main(string[] args)
    {

        string keepPlaying = "yes";

        while (keepPlaying == "yes")
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = 0; 
            int guesses = 0;

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guesses += 1;

                if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }

                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }

                else 
                {
                    Console.WriteLine("Congratulations, you did it!");
                }
            }
            Console.WriteLine($"It took you {guesses} guesses");

            Console.Write("Would you like to play again? ");
            keepPlaying = Console.ReadLine();
        }
    }
}