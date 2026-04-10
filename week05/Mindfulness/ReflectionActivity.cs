using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    private Random _random = new Random();

    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
        : base("Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public void Run()
    {
        Start();

        Console.WriteLine("Think about the following prompt:");

        //  Prompt random
        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine($"--- {prompt} ---");

        Console.WriteLine();
        Console.WriteLine("Press ENTER when you are ready.");
        Console.ReadLine();
        Console.WriteLine("In your mind, answer the following questions...");
        CountdownInline("Get ready", 3);
        Console.Clear();

        int elapsed = 0;

        // Loop de preguntas
        while (elapsed < _duration)
        {
            string question = _questions[_random.Next(_questions.Count)];

            Console.WriteLine("> " + question);
            Spinner("",5);

            elapsed += 5;
        }

        End();
    }
}