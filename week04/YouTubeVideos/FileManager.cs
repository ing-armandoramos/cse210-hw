using System;
using System.Collections.Generic;
using System.IO;

public static class FileManager
{
    public static void SaveVideosToFile(List<Video> videos, string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var video in videos)
            {
                writer.WriteLine($"Video: {video.Title}|{video.Author}|{video.Length}");
                foreach (var comment in video.GetComments())
                {
                    writer.WriteLine($"Comment: {comment.CommenterName}|{comment.CommentText}");
                }
                writer.WriteLine("END");
            }
        }
    }
}
