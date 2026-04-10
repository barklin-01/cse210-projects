public class ActiveBreaks : Activity
{
    public ActiveBreaks()
        : base("Active Breaks", "Esta actividad te guiará con estiramientos para relajar el cuerpo.")
    {
    }

    public void Run()
    {
        Start();

        Console.WriteLine("Levanta los brazos y estírate...");
        Thread.Sleep(3000);

        Console.WriteLine("Gira suavemente el cuello...");
        Thread.Sleep(3000);

        Console.WriteLine("Estira las piernas...");
        Thread.Sleep(3000);

        End();
    }
}



