// I added a new activity called Active Breaks that provides users with a series of simple exercises to do during short breaks.
//I put the new activity in yhe menu options.

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflection activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Start active breaks");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option between 1 and 5: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity b = new BreathingActivity();
                b.Run();
            }
            else if (choice == "2")
            {
                ReflectionActivity r = new ReflectionActivity();
                r.Run();
            }
            else if (choice == "3")
            {
                ListingActivity l = new ListingActivity();
                l.Run();
            }
            else if (choice == "4")
            {
                ActiveBreaks a = new ActiveBreaks();
                a.Run();
            }
            else if (choice == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("Opción inválida...");
                Thread.Sleep(1500);
            }
        }
    }
}