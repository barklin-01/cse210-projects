using System;

class Program
{
    static void Main(string[] args)
    {
        //Create a list
        List<int> numbers = new List<int>();

        int number = -1;
        //Keep asking the user for numbers until they enter 0
        while (number != 0)
        {
            Console.Write("Enter a number (0 to quit): ");
            string answer = Console.ReadLine();
            number = int.Parse(answer);

            if (number != 0)
            {
                numbers.Add(number);
            }
        }
        //Calculate the sum of the numbers
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        Console.WriteLine($"The sum of the numbers you entered is: {sum}");

        //Calculate the average of the numbers
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average of the numbers you entered is: {average}");

        //Find the largest number
        int largest = numbers[0];
        foreach (int num in numbers)
        {
            if (num > largest)
            {
                largest = num;
            }
        }
        Console.WriteLine($"The largest number you entered is: {largest}");
    }
}