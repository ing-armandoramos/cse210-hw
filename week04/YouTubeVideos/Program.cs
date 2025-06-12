using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Create 3-4 videos
        Video video1 = new Video("C# Tutorial", "Armando Ramos", 690);
        video1.AddComment(new Comment("Berthold", "The sound is terrible! But the host is amazing!"));
        video1.AddComment(new Comment("Annie", "I have seen better"));
        video1.AddComment(new Comment("Charlie from the chocolate factory", "Excellent explanation, bad accent!"));

        Video video2 = new Video("Cooking Pasta", "Armando Ramos", 1900);
        video2.AddComment(new Comment("Mario", "Italy cries tonight"));
        video2.AddComment(new Comment("Luigi", "If you had more views Italy would join the axis again"));
        video2.AddComment(new Comment("Donkey  Kong", ""));

        Video video3 = new Video("Travel Vlog: Culiacan Sinaloa", "Armando Ramos", 1000);
        video3.AddComment(new Comment("Pablo Escobar", "Helps me remember my own country"));
        video3.AddComment(new Comment("Joaquin Guzman Loera", "I made that"));
        video3.AddComment(new Comment(" Ismael El Mayo Zambada", "I will destroy that"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Display videos and comments
        foreach (var video in videos)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(video);
            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment}");
            }
        }

        // Save to file
        FileManager.SaveVideosToFile(videos, "videos.txt");
        Console.WriteLine("\nVideos saved to 'videos.txt'");
    }
}
