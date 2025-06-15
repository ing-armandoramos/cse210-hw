using System;
class Program
{
    static void Main(string[] args)
    {
        Assignment a1 = new Assignment("Ariel Garcia", "Geometry");
        Console.WriteLine(a1.GetSummary());

        MathAssignment a2 = new MathAssignment("Mary Poppins", "Line representations", "8.5", "25-32");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Leobardo Camacho", "Mexican Literature", "Octavio Paz a poet turned politician");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());

        WritingAssignment a4 = new WritingAssignment("Bill Jones", "Spanish Literature", "Don Quijote parallelisms");
        Console.WriteLine(a4.GetSummary());
        Console.WriteLine(a4.GetWritingInformation());
    }
}