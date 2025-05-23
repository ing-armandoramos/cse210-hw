using System;
using System.Collections.Generic;

public class ScriptureLibrary
{
    // Here the user can add more scriptures
    private Dictionary<string, string> _scriptures = new Dictionary<string, string>()
    {
        { "Moses 1:39", "For behold, this is my work and my glory—to bring to pass the immortality and eternal life of man." },
        { "Matthew 5:14–16", "Ye are the light of the world. A city that is set on an hill cannot be hid. Let your light so shine before men..." },
        { "1 Nephi 3:7", "I will go and do the things which the Lord hath commanded..." },
        { "Proverbs 3:5–6", "Trust in the Lord with all thine heart; and lean not unto thine own understanding..." },
        // Here the user can add more scriptures
    };

    private Random _random = new Random();

    public (string reference, string text) GetRandomScripture()
    {
        var keys = new List<string>(_scriptures.Keys);
        int index = _random.Next(keys.Count);
        string reference = keys[index];
        return (reference, _scriptures[reference]);
    }
}
