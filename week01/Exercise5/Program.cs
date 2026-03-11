using System;

class Program
{
    static void Main(string[] args)
    {
        message();
        string name = askname();
        int number = asknumber();
        int square = squarenumber(number);
        displayresult(name, square);

    }
    //Mensaje de bienvenida
    static void message()
    {
        Console.WriteLine("Wlcome to the program");
    }
    // Pedir nombre al usuario
    static string askname()
    {
        Console.Write("What is your name? ");
        string name = Console.ReadLine();

        return name;
    }
    //Numero favorito
    static int asknumber()
    {
        Console.Write("What is your favorite number? ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }
    static int squarenumber(int number)
    {
        int square = number * number;
        return square;
    }
    static void displayresult(string name,int square)
    {
        Console.WriteLine($"{name}, the square of your favorite number is {square}");
    }
}