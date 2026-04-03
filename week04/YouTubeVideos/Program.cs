using System;
using System.Collections.Generic;

// Class for Comment
public class Comment
{
    public string Name;
    public string Text;
}

// Class for Video
public class Video
{
    public string Title;
    public string Author;
    public int Length; // in seconds

    public List<Comment> Comments = new List<Comment>();

    // Method to get the number of comments
    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // List to hold all videos
        List<Video> videos = new List<Video>();

        // VIDEO 1
        Video video1 = new Video();
        video1.Title = "Photograph"; 
        video1.Author = "Ed Sheeran";   
        video1.Length = 260;             

        // Adding comments to Video 1
        video1.Comments.Add(new Comment { Name = "Carlos", Text = "Great music!" });   
        video1.Comments.Add(new Comment { Name = "Juan", Text = "I miss my girlfreind" });
        video1.Comments.Add(new Comment { Name = "Sofia", Text = "Excelent song for dance with my boyfriend" });

        videos.Add(video1);

        // VIDEO 2 
        Video video2 = new Video();
        video2.Title = "Ideas in five minutes";
        video2.Author = "Carlos Gonzalez";
        video2.Length = 300;

        video2.Comments.Add(new Comment { Name = "David", Text = "Excellent ideas for camping" });
        video2.Comments.Add(new Comment { Name = "Eva", Text = "The four idea is the best!" });
        video2.Comments.Add(new Comment { Name = "Frank", Text = "I use many of those ideas in my life" });
        video2.Comments.Add(new Comment { Name = "David", Text = "Great video!" });

        videos.Add(video2);

        //  VIDEO 3 
        Video video3 = new Video();
        video3.Title = "Travel to Ecuador!";
        video3.Author = "Luisito Comunica";
        video3.Length = 800;

        video3.Comments.Add(new Comment { Name = "Laura", Text = "I want to travel Ecuador" });
        video3.Comments.Add(new Comment { Name = "Sofia", Text = "Ecuador is a great place to visit this year" });
        video3.Comments.Add(new Comment { Name = "Pedro", Text = "Perfect explanation!" });
        video3.Comments.Add(new Comment { Name = "Santiago", Text = "Luisito you are the best " });
        video3.Comments.Add(new Comment { Name = "Jose", Text = "Recently I was in Ecuador, It is a beautiful place to visit" });
        video3.Comments.Add(new Comment { Name = "Carlos", Text = "Great job" });

        videos.Add(video3);

        // DISPLAY ALL VIDEOS
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }

            Console.WriteLine(); 
        }
    }
}