using System;

public class Entry
{
    public string Date { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }

    public void Display()
    {
        Console.WriteLine($"{Date} - {Question}");
        Console.WriteLine(Answer);
        Console.WriteLine();
    }

    public string ToFileFormat()
    {
        // Usando "|~|" como separador
        return $"{Date}|~|{Question}|~|{Answer}";
    }

    public void LoadFromFile(string line)
    {
        string[] parts = line.Split("|~|", StringSplitOptions.None);
        if (parts.Length == 3)
        {
            Date = parts[0];
            Question = parts[1];
            Answer = parts[2];
        }
    }
}