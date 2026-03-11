using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What ir you grade porcentaje");
        string grade = Console.ReadLine();
        int gradeInt = int.Parse(grade);

        string letter = "";

        if (gradeInt >= 90)
        {
            letter = "A";
        }
        else if (gradeInt >= 80)
        {
            letter = "B";
        }
        else if (gradeInt >= 70)
        {
            letter = "C";
        }
        else if (gradeInt >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is {letter}");
        if (gradeInt >= 70)
        {
            Console.WriteLine("Congratulations, you passed!");
        }
        else
        {
            Console.WriteLine("Don’t get discouraged. Failing is part of learning. You’ll do better next time.");
        }
    }
}