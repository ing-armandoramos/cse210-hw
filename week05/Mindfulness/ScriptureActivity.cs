using System;
using System.Threading;
using System.Collections.Generic;

class ScriptureActivity : Activity
{
    private List<string> _scriptures = new List<string>
    {
        "John 3:16 - For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.",
        "Proverbs 3:5-6 - Trust in the LORD with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.",
        "Philippians 4:13 - I can do all this through him who gives me strength.",
        "Jeremiah 29:11 - For I know the plans I have for you, declares the LORD, plans to prosper you and not to harm you, plans to give you hope and a future.",
        "Romans 8:28 - And we know that in all things God works for the good of those who love him, who have been called according to his purpose.",
        "Matthew 11:28 - Come to me, all you who are weary and burdened, and I will give you rest.",
        "Psalm 23:1 - The LORD is my shepherd, I lack nothing.",
        "Isaiah 40:31 - But those who hope in the LORD will renew their strength. They will soar on wings like eagles; they will run and not grow weary, they will walk and not be faint.",
        "Joshua 1:9 - Have I not commanded you? Be strong and courageous. Do not be afraid; do not be discouraged, for the LORD your God will be with you wherever you go.",
        "Romans 12:2 - Do not conform to the pattern of this world, but be transformed by the renewing of your mind.",
        "2 Timothy 1:7 - For God has not given us a spirit of fear, but of power and of love and of a sound mind.",
        "Matthew 6:33 - But seek first his kingdom and his righteousness, and all these things will be given to you as well.",
        "Psalm 46:10 - Be still, and know that I am God.",
        "1 Corinthians 16:14 - Do everything in love.",
        "Galatians 5:22-23 - But the fruit of the Spirit is love, joy, peace, forbearance, kindness, goodness, faithfulness, gentleness and self-control.",
        "Ephesians 2:8 - For it is by grace you have been saved, through faith—and this is not from yourselves, it is the gift of God.",
        "1 John 4:19 - We love because he first loved us.",
        "Psalm 118:24 - This is the day that the LORD has made; let us rejoice and be glad in it.",
        "Colossians 3:23 - Whatever you do, work at it with all your heart, as working for the Lord, not for human masters.",
        "Hebrews 11:1 - Now faith is confidence in what we hope for and assurance about what we do not see.",
        "James 1:2-3 - Consider it pure joy, my brothers and sisters, whenever you face trials of many kinds, because you know that the testing of your faith produces perseverance.",
        "Micah 6:8 - He has shown you, O mortal, what is good. And what does the LORD require of you? To act justly and to love mercy and to walk humbly with your God.",
        "Matthew 28:19 - Therefore go and make disciples of all nations, baptizing them in the name of the Father and of the Son and of the Holy Spirit.",
        "Psalm 119:105 - Your word is a lamp for my feet, a light on my path.",
        "Romans 15:13 - May the God of hope fill you with all joy and peace as you trust in him, so that you may overflow with hope by the power of the Holy Spirit."
    };

    public ScriptureActivity()
    {
        _name = "Scripture Typing Activity";
        _description = "This activity will help you type scriptures by showing you random verses and challenging you to type 5 of them correctly.";
    }

    protected override void ExecuteActivity()
    {
        // Select 3 random unique scriptures
        Random random = new Random();
        List<string> selectedScriptures = new List<string>();
        List<int> usedIndices = new List<int>();

        while (selectedScriptures.Count < 3)
        {
            int index = random.Next(_scriptures.Count);
            if (!usedIndices.Contains(index))
            {
                selectedScriptures.Add(_scriptures[index]);
                usedIndices.Add(index);
            }
        }

        // Scriptures to type
        Console.WriteLine("\nMemorize these scriptures:\n");
        foreach (string scripture in selectedScriptures)
        {
            Console.WriteLine(scripture);
            Thread.Sleep(5000); //Time for reading
        }

        Console.WriteLine("\nTime to test your memory! Type 5 of these scriptures (or type 'exit' to finish):\n");
        ShowCountdown(5);

        // Get user input
        int correctCount = 0;
        int attempts = 0;
        List<string> enteredScriptures = new List<string>();

        while (attempts < 5)
        {
            Console.Write($"Scripture {attempts + 1}: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                break;
            }

            enteredScriptures.Add(input);
            attempts++;

            // Check matches in selected scriptures
            foreach (string scripture in selectedScriptures)
            {
                if (scripture.Contains(input, StringComparison.OrdinalIgnoreCase))
                {
                    correctCount++;
                    Console.WriteLine("Correct!");
                    break;
                }
            }
        }

        // Show results
        Console.WriteLine($"\nYou got {correctCount} out of {attempts} correct!");
        Console.WriteLine("\nHere are the scriptures you were trying to memorize:");
        foreach (string scripture in selectedScriptures)
        {
            Console.WriteLine($"- {scripture}");
        }

        Console.WriteLine("\nHere's what you entered:");
        foreach (string entered in enteredScriptures)
        {
            Console.WriteLine($"- {entered}");
        }

        Thread.Sleep(5000);
    }
}