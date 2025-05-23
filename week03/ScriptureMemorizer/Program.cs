//Exceeding the requirements
//I did change the Program.cs to instead to call a "Hardcoded" reference to call a "ScriptureLibrary" class, that way instead of having jus one scripture the user can have acces to as many scriptures as needed

using System;

class Program
{
    static void Main(string[] args)
    {
        ScriptureLibrary library = new ScriptureLibrary();

        // Get a random scripture from the ScriptureLibrary class
        var (referenceText, scriptureText) = library.GetRandomScripture();

        // Parse
        Reference reference = ParseReference(referenceText);

        // Create
        Scripture scripture = new Scripture(reference, scriptureText);

        // Main loop
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3); // hiddes 3 words

            if (scripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden. Program will now end.");
                break;
            }
        }
    }

    static Reference ParseReference(string referenceText)
    {
        // Example: "Proverbs 3:5–6" or "1 Nephi 3:7"
        string[] parts = referenceText.Split(' ');

        string book = string.Join(' ', parts[..^1]);
        string chapterAndVerse = parts[^1];

        string[] chapterVerseParts = chapterAndVerse.Split(':');
        int chapter = int.Parse(chapterVerseParts[0]);

        string versePart = chapterVerseParts[1];
        if (versePart.Contains('–') || versePart.Contains('-'))
        {
            var range = versePart.Split(new char[] { '–', '-' });
            int startVerse = int.Parse(range[0]);
            int endVerse = int.Parse(range[1]);
            return new Reference(book, chapter, startVerse, endVerse);
        }
        else if (versePart.Contains(','))
        {
            var split = versePart.Split(',');
            return new Reference(book, chapter, int.Parse(split[0]), int.Parse(split[0]));
        }
        else
        {
            int verse = int.Parse(versePart);
            return new Reference(book, chapter, verse);
        }
    }
}
