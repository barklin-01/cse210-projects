using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Magic Number Game!");
        string gameagain;

        do
        {
            Random random = new Random();
            int magicnumber = random.Next(1, 101);

            int adivinanza = -1;
            while (adivinanza != magicnumber)
            {
                Console.Write("Guess the magic number (between 1 and 100):What is your guess? ");
                adivinanza = int.Parse(Console.ReadLine());

                if (adivinanza < magicnumber)
                {
                    Console.WriteLine("Too low! Try again.");
                }
                else if (adivinanza > magicnumber)
                {
                    Console.WriteLine("Too high! Try again.");
                }
                else
                {
                    Console.WriteLine("Congratulations! You've guessed the magic number!");
                }
            }
            Console.Write("Do you want to play again? (yes/no): ");
            gameagain = Console.ReadLine().ToLower();
        } while (gameagain == "yes");
        Console.WriteLine("Thanks for playing! Goodbye!");
    }
}