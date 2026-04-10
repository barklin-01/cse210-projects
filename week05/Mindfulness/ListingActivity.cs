public class ListingActivity : Activity
{
    private List<string> _questions = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
      : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public void Run()
    {
        Start();

        // Pregunta aleatoria
        Random random = new Random();
        string question = _questions[random.Next(_questions.Count)];

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"--- {question} ---");
        Console.WriteLine();

        // Tiempo para pensar
        Console.WriteLine("You may begin in:");
        CountdownInline("", 5);

        List<string> items = new List<string>();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                items.Add(input);
            }
        }

        Console.WriteLine($"You listed {items.Count} items!");

        End();
    }
}