using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class ActiveBreaks : Activity
{
    private List<string> _instructions = new List<string>
    {
        "Raise your arms and stretch up high.",
        "Gently roll your neck in circles.",
        "Tilt your head from side to side.",
        "Stretch your legs forward.",
        "Rotate your shoulders forward and backward.",
        "Take a deep breath in and slowly exhale.",
        "Twist your torso side to side.",
        "Shake out your hands and wrists.",
        "Open and close your hands repeatedly.",
        "Stand up and touch your toes.",
        "March in place.",
        "Lift your knees one at a time.",
        "Stretch one arm across your chest.",
        "Switch arms and stretch the other side.",
        "Roll your ankles in circles.",
        "Stand on your tiptoes and hold.",
        "Do a gentle back stretch.",
        "Clasp your hands and push them forward.",
        "Reach one arm overhead and lean to the side.",
        "Switch sides and repeat the stretch.",
        "Take a deep breath and hold for a few seconds.",
        "Relax your shoulders and drop tension.",
        "Gently shake your whole body.",
        "Smile and relax your face muscles."
    };

    private Random _random = new Random();

    public ActiveBreaks()
        : base("Active Breaks", "This activity encourages you to take short breaks to stretch and move, helping to refresh your mind and body.")
    {
    }

    public void Run()
    {
        Start();

        int numberOfExercises = 8; 

        var shuffled = _instructions.OrderBy(x => _random.Next()).ToList();

        foreach (var instruction in shuffled.Take(numberOfExercises))
        {
            CountdownInline(instruction, 5);
            Console.WriteLine();
        }

        End();
    }
}