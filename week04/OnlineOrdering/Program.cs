using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1 (USA)
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("Juan Benavidez", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Kitchen", "P001", 1200, 1));
        order1.AddProduct(new Product("Microwave", "P002", 250, 2));
        order1.AddProduct(new Product("Blender", "P003", 150, 1));

        // Order 2 (International)
        Address address2 = new Address("Av Quito", "Otavalo", "Imbabura", "Ecuador");
        Customer customer2 = new Customer("Noe Gonzalez", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Phone", "P004", 700, 3));
        order2.AddProduct(new Product("Earphones", "P005", 75, 4));
        order2.AddProduct(new Product("Laptop", "P006", 850, 1));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total: ${order1.GetTotalPrice()}");

        Console.WriteLine("\n-------------------\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total: ${order2.GetTotalPrice()}");
    }
}