using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        int score = 0;

        while (true)
        {
            Console.WriteLine("=================================");
            Console.WriteLine($"🏆 Your score is: {score}");
            Console.WriteLine("=================================");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("\n1. Create Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. List Goals");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Exit");

            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            // ---------------------------
            // 1. CREATE GOAL
            // ---------------------------
            if (option == "1")
            {
                Console.Clear();
                Console.WriteLine("1. Simple Goal");
                Console.WriteLine("2. Eternal Goal");
                Console.WriteLine("3. Checklist Goal");
                Console.Write("What type of goal would you like to create? ");
                string type = Console.ReadLine();

                Console.Write("Enter name: ");
                string name = Console.ReadLine();

                Console.Write("Enter description: ");
                string description = Console.ReadLine();

                int points;
                Console.Write("Enter points: ");
                while (!int.TryParse(Console.ReadLine(), out points))
                {
                    Console.Write("Invalid input. Enter a number for points: ");
                }

                if (type == "1")
                {
                    goals.Add(new SimpleGoal(name, description, points));
                }
                else if (type == "2")
                {
                    goals.Add(new EternalGoal(name, description, points));
                }
                else if (type == "3")
                {
                    int target;
                    Console.Write("How many times to complete? ");
                    while (!int.TryParse(Console.ReadLine(), out target))
                    {
                        Console.Write("Invalid input: ");
                    }

                    int bonus;
                    Console.Write("Bonus points: ");
                    while (!int.TryParse(Console.ReadLine(), out bonus))
                    {
                        Console.Write("Invalid input: ");
                    }

                    goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                }

                Console.Clear();
            }

            // ---------------------------
            // 2. RECORD EVENT
            // ---------------------------
            else if (option == "2")
            {
                Console.Clear();
                if (goals.Count == 0)
                {
                    Console.WriteLine("No goals available.");
                    continue;
                }

                for (int i = 0; i < goals.Count; i++)
                {
                    Console.WriteLine($"{i}. {goals[i].GetStatus()} {goals[i].GetName()}");
                }

                Console.Write("Select a goal: ");

                int index;
                while (!int.TryParse(Console.ReadLine(), out index) || index < 0 || index >= goals.Count)
                {
                    Console.Write("Invalid selection. Try again: ");
                }

                int earned = goals[index].RecordEvent();
                score += earned;

                Console.WriteLine($"Event recorded! You earned {earned} points.");
                Console.WriteLine($"Your current score now is: {score}");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }

            // ---------------------------
            // 3. LIST GOALS
            // ---------------------------
            else if (option == "3")
            {
                foreach (var goal in goals)
                {
                    Console.WriteLine(goal.GetDisplayString());
                }

                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }

            // ---------------------------
            // 4. SAVE
            // ---------------------------
            else if (option == "4")
            {
                Console.Write("What is the filename for the goal file? ");
                string filename = Console.ReadLine();

                SaveGoals(goals, score, filename);

                Console.WriteLine("Saved successfully!");
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }

            // ---------------------------
            // 5. LOAD (FIXED)
            // ---------------------------
            else if (option == "5")
            {
                Console.Write("Filename to load: ");
                string filename = Console.ReadLine();

                var data = LoadGoals(filename);
                goals = data.Item1;
                score = data.Item2;

                Console.WriteLine("Loaded successfully!");
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue...");    
                Console.ReadLine();
            }

            // ---------------------------
            // 6. EXIT
            // ---------------------------
            else if (option == "6")
            {
                break;
            }
        }
    }

    // ---------------------------
    // SAVE
    // ---------------------------
    static void SaveGoals(List<Goal> goals, int score, string filename)
    {
        List<string> lines = new List<string>();
        lines.Add(score.ToString());

        foreach (var goal in goals)
        {
            lines.Add(goal.GetStringRepresentation());
        }

        File.WriteAllLines(filename, lines);
    }

    // ---------------------------
    // LOAD (SAFE)
    // ---------------------------
    static (List<Goal>, int) LoadGoals(string filename)
    {
        List<Goal> goals = new List<Goal>();
        int score = 0;

        if (!File.Exists(filename))
        {
            return (goals, 0);
        }

        string[] lines = File.ReadAllLines(filename);

        if (lines.Length == 0)
        {
            return (goals, 0);
        }

        int.TryParse(lines[0], out score);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");

            if (parts[0] == "Simple")
            {
                bool isComplete = bool.Parse(parts[2]);
                int points = int.Parse(parts[3]);

                var goal = new SimpleGoal(parts[1], "", points);

                if (isComplete)
                {
                    goal.RecordEvent();
                }

                goals.Add(goal);
            }
            else if (parts[0] == "Eternal")
            {
                goals.Add(new EternalGoal(parts[1], "", int.Parse(parts[2])));
            }
            else if (parts[0] == "Checklist")
            {
                var goal = new ChecklistGoal(
                    parts[1],
                    "",
                    int.Parse(parts[5]),
                    int.Parse(parts[3]),
                    int.Parse(parts[4])
                );

                int count = int.Parse(parts[2]);

                for (int j = 0; j < count; j++)
                {
                    goal.RecordEvent();
                }

                goals.Add(goal);
            }
        }

        return (goals, score);
    }
}