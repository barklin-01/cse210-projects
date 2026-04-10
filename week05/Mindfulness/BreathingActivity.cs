public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity", "This activity will help you relax by guiding you through slow breathing.")
    {
    }

    public void Run()
    {
        Start();

        int elapsed = 0;

        while (elapsed < _duration)
        {
            CountdownInline("Breathe in...", 4);
            CountdownInline("Breathe out...", 4);
            Console.WriteLine(); 

            elapsed += 8;
        }
        End();
    }
}