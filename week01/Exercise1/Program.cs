using System;

class Program
{
    static void Main(string[] args)
    {
        //ask firstname
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();
        //ask lastname
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}