using System;

class Program
{
    static void Main(string[] args)
    {
        // First Order
        Address address1 = new Address("123 Carrot St", "New York", "NY", "USA");
        Customer customer1 = new Customer("Liam Johnson", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Fish Eyes", "P001", 1.99, 1));
        order1.AddProduct(new Product("Sword from swordfish", "P002", 15.99, 2));
        order1.AddProduct(new Product("Trident", "P003", 575.00, 1));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}\n");

        // Second Order
        Address address2 = new Address("456 Pinecone Av", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Olivia Jones", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Toaster", "P004", 99.99, 2));
        order2.AddProduct(new Product("Bathtub", "P005", 1500.00, 3));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}");

        // Third Order
        Address address3 = new Address("789 Aguacate St", "Puebla", "Pue", "Mexico");
        Customer customer3 = new Customer("Maria Antonieta de las Nieves", address3);
        Order order3 = new Order(customer3);

        order3.AddProduct(new Product("Avocados", "P004", 500.00, 2));
        order3.AddProduct(new Product("Tomatoes", "P005", 50.00, 3));
        order3.AddProduct(new Product("Onions", "P005", 550.00, 3));
        order3.AddProduct(new Product("Tortilla chips", "P005", 55.55, 3));

        Console.WriteLine(order3.GetPackingLabel());
        Console.WriteLine(order3.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order3.GetTotalCost():F2}");
    }
}
