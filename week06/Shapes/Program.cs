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
            // CREATE GOAL
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
            // RECORD EVENT
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
                Console.ReadLine();
                Console.Clear();
            }

            // ---------------------------
            // LIST GOALS
            // ---------------------------
            else if (option == "3")
            {
                foreach (var goal in goals)
                {
                    Console.WriteLine(goal.GetDisplayString());
                }

                Console.ReadLine();
                Console.Clear();
            }

            // ---------------------------
            // SAVE
            // ---------------------------
            else if (option == "4")
            {
                Console.Write("Filename: ");
                string filename = Console.ReadLine();

                SaveGoals(goals, score, filename);

                Console.WriteLine("Saved!");
                Console.ReadLine();
                Console.Clear();
            }

            // ---------------------------
            // LOAD
            // ---------------------------
            else if (option == "5")
            {
                Console.Write("Filename: ");
                string filename = Console.ReadLine();

                var data = LoadGoals(filename);
                goals = data.Item1;
                score = data.Item2;

                Console.WriteLine("Loaded!");
                Console.ReadLine();
                Console.Clear();
            }

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
    // LOAD (FIXED)
    // ---------------------------
    static (List<Goal>, int) LoadGoals(string filename)
    {
        List<Goal> goals = new List<Goal>();
        int score = 0;

        if (!File.Exists(filename))
            return (goals, 0);

        string[] lines = File.ReadAllLines(filename);

        if (lines.Length == 0)
            return (goals, 0);

        int.TryParse(lines[0], out score);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];

            if (string.IsNullOrWhiteSpace(line))
                continue;

            string[] parts = line.Split('|');

            // ---------------- SIMPLE GOAL ----------------
            if (parts[0] == "Simple")
            {
                if (parts.Length < 5)
                    continue;

                string name = parts[1];
                string desc = parts[2];

                bool complete = false;
                bool.TryParse(parts[3], out complete);

                int points;
                int.TryParse(parts[4], out points);

                var g = new SimpleGoal(name, desc, points);

                if (complete)
                    g.RecordEvent();

                goals.Add(g);
            }

            // ---------------- ETERNAL GOAL ----------------
            else if (parts[0] == "Eternal")
            {
                if (parts.Length < 4)
                    continue;

                string name = parts[1];
                string desc = parts[2];

                int points;
                int.TryParse(parts[3], out points);

                goals.Add(new EternalGoal(name, desc, points));
            }

            // ---------------- CHECKLIST GOAL ----------------
            else if (parts[0] == "Checklist")
            {
                if (parts.Length < 7)
                    continue;

                string name = parts[1];
                string desc = parts[2];

                int current;
                int target;
                int bonus;
                int points;

                int.TryParse(parts[3], out current);
                int.TryParse(parts[4], out target);
                int.TryParse(parts[5], out bonus);
                int.TryParse(parts[6], out points);

                var g = new ChecklistGoal(name, desc, points, target, bonus);

                for (int j = 0; j < current; j++)
                    g.RecordEvent();

                goals.Add(g);
            }
        }

        return (goals, score);
    }
}