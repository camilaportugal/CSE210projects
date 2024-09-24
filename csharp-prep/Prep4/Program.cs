using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List <int> listNumber = new List<int>();

        int numberUser = -1;

        Console.WriteLine(" Enter a list of numbers, type 0 when finished. ");

        while (numberUser != 0)
        {
            Console.Write("Enter a number: ");
            string answer = Console.ReadLine();
            numberUser = int.Parse(answer);

            if (numberUser != 0)
            {
                listNumber.Add(numberUser);
            }
        }

        int sum = 0;

        foreach (int number in listNumber)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / listNumber.Count;
        Console.WriteLine($"The average is: {average}");


        int largest = listNumber[0];
        int smallestPositive = listNumber[0];
        List <int> sortedList = new List<int>();

        foreach (int number in listNumber)
        {
            if (number > largest)
            {
                largest = number;
            }

            if (number > 0 && number < largest)
            {
                smallestPositive = number;
            }

            if (number < 0)
            {
                sortedList.Add(number);
            }
        }

        Console.WriteLine($"The largets number is: {largest}");
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        Console.WriteLine("The sorted list is:");
        foreach (int sortedNumber in sortedList)
        {
            Console.WriteLine(sortedNumber);
        }
    }
}