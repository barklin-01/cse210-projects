using System;

class Program
{
    static void Main(string[] args)
    {
        ScriptureLibrary library = new ScriptureLibrary();
        ScriptureSource source = AskUserForSource();

        Scripture currentScripture = library.GetRandomScripture(source);

        string input = "";

        while (input != "quit" && !currentScripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(currentScripture.GetDisplay());

            Console.WriteLine("\nPress ENTER to hide more words, or type 'quit' to exit:");
            input = Console.ReadLine();

            if (input != "quit")
            {
                currentScripture.HideRandomWords();

                if (currentScripture.AllWordsHidden())
                {
                    Console.Clear();
                    Console.WriteLine(currentScripture.GetDisplay());
                    Console.WriteLine("\nAll words are hidden! Getting a new scripture...\n");
                    Console.ReadKey();

                    currentScripture = library.GetRandomScripture(source);
                }
            }
        }

        Console.WriteLine("Thanks for practicing! Press any key to exit.");
        Console.ReadKey();
    }

    // This function asks the user which scripture source they want to practice: Bible or Book of Mormon
    // Depending on the choice, the program will load scriptures from the selected source
    static ScriptureSource AskUserForSource()
    {
        while (true)
        {
            Console.WriteLine("Choose scripture source:");
            Console.WriteLine("1 - Bible");
            Console.WriteLine("2 - Book of Mormon");
            Console.Write("Enter 1 or 2: ");
            string input = Console.ReadLine();

            if (input == "1")
                return ScriptureSource.Bible;
            else if (input == "2")
                return ScriptureSource.BookOfMormon;
            else
                Console.WriteLine("Invalid input. Please enter 1 or 2.");
        }
    }
}