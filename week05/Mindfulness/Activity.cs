public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }
    //mensaje de bienvenida, descripción, duración y listo  para cada actividad
    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"=== Welcome to {_name} ===");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.Clear();

        Console.Write("Get ready");
        Dots(3);
        Console.WriteLine();
    }
    //mensaje de despedida, resumen de la actividad
    public void End()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        Spinner("", 3);

        Console.WriteLine($"You have completed {_duration} seconds of the {_name}.");
        Spinner("", 3);
    }
//animacion de los ...
    public void Dots(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Thread.Sleep(500);
            Console.Write(".");
        }
        Console.WriteLine();
    }
    // animacion de cuenta regresiva
    public void CountdownInline(string message, int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{message} {i} ");
            Thread.Sleep(1000);
        }
        Console.Write($"\r{message}   ");
    }
    // animacion de spinner
    public static void Spinner(string text, int seconds)
    {
        string[] frames = { "|", "/", "-", "\\" };

        for (int i = 0; i < seconds * 4; i++)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                Console.Write($"\r{frames[i % frames.Length]}");
            }
            else
            {
                Console.Write($"\r{text} {frames[i % frames.Length]}");
            }

            Thread.Sleep(250);
        }

        // limpiar línea
        Console.Write("\r   ");
    }

}