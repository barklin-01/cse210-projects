using System;
using System.Collections.Generic;

public class QuestionGenerator
{
    private List<string> questions = new List<string>()
    {
        "What was the best part of your day?",
        "What did you learn today?",
        "What made you happy today?",
        "Who was important in your day?",
        "What would you do differently today?",
        "What places did you visit today?",
        "What was your favorite meal of the day?",
        "What was the most challenging part of your day?",
    };

    private Random rand = new Random();

    public string GetRandomQuestion()
    {
        int index = rand.Next(questions.Count);
        return questions[index];
    }
}
