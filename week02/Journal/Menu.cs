using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Menu
{
    private List<Entry> journal = new List<Entry>();
    private QuestionGenerator questionGen = new QuestionGenerator();

    public void ShowMenu()
    {
        int option = 0;

        while (option != 5)
        {
            Console.WriteLine("\nWelcome to your journal!");
            Console.WriteLine("1. Write your day");
            Console.WriteLine("2. Show journal");
            Console.WriteLine("3. Save journale");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. Exit");
            //I added this option to allow users to write freely without a prompt, as some may prefer that.
            Console.WriteLine("6. Write a free entry (no prompt)");
            Console.Write("What would you like to do? ");

            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 6)
            {
                Console.Write("What would you like to do? Please enter a number between 1 and 6: ");
            }

            switch (option)
            {
                case 1:
                    WriteEntry();
                    break;
                case 2:
                    ShowJournal();
                    break;
                case 3:
                    SaveJournal();
                    break;
                case 4:
                    LoadJournal();
                    break;
                case 6:
                    WriteFreeEntry();
                    break;
            }
        }
    }

    private void WriteEntry()
    {
        string question = questionGen.GetRandomQuestion();
        Console.WriteLine($"\n{question}");
        Console.Write("> ");
        string answer = Console.ReadLine();

        Entry newEntry = new Entry()
        {
            Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
            Question = question,
            Answer = answer
        };

        journal.Add(newEntry);
    }

    private void WriteFreeEntry()
    {
        Console.WriteLine("\nWrite your thoughts for today:");
        Console.Write("> ");
        string answer = Console.ReadLine();

        Entry newEntry = new Entry()
        {
            Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
            Question = "Free Entry",
            Answer = answer
        };

        journal.Add(newEntry);
    }

    private void ShowJournal()
    {
        if (journal.Count == 0)
        {
            Console.WriteLine("\nYour journal is empty.");
            return;
        }

        Console.WriteLine("\n--- Your Journal ---\n");
        foreach (var entry in journal)
        {
            entry.Display();
        }
    }

    private void SaveJournal()
    {
        Console.Write("File name: ");
        string fileName = Console.ReadLine();

        using (StreamWriter sw = new StreamWriter(fileName))
        {
            foreach (var entry in journal)
            {
                sw.WriteLine(entry.ToFileFormat());
            }
        }

        Console.WriteLine("Journal saved successfully!");
    }

    private void LoadJournal()
    {
        Console.Write("File name: ");
        string fileName = Console.ReadLine();

        if (File.Exists(fileName))
        {
            journal.Clear();
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                Entry entry = new Entry();
                entry.LoadFromFile(line);
                journal.Add(entry);
            }

            Console.WriteLine("Journal loaded successfully!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    // I added these methods to allow users to save and load their journal in JSON format, which is more structured and easier to read than plain text.
    public void SaveJournalJson(string fileName)
    {
        string json = JsonSerializer.Serialize(journal, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(fileName, json);
        Console.WriteLine("Journal saved in JSON format!");
    }

    public void LoadJournalJson(string fileName)
    {
        if (File.Exists(fileName))
        {
            string json = File.ReadAllText(fileName);
            journal = JsonSerializer.Deserialize<List<Entry>>(json) ?? new List<Entry>();
            Console.WriteLine("Journal loaded from JSON successfully!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}