using System;

class Program
{
    static void Main(string[] args)
    {
        //ask firstname
        Console.Write("What is your first name? ");
        string firstname = Console.ReadLine();
        //ask lastname
        Console.Write("What is your last name? ");
        string lastname = Console.ReadLine();

        Console.WriteLine($"Your name is {lastname}, {firstname} {lastname}.");
    }
}