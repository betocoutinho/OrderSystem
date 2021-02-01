using System;
using OrderSystem.Entities;
using OrderSystem.Entities.Enum;
using System.Globalization;

namespace OrderSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Cliente Data: ");
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Birth date (DD/MM/YYYY): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Client c1 = new Client(name, email, date);

            Console.WriteLine("Enter order data: ");
            Console.WriteLine("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Order o1 = new Order(status, c1);

            Console.WriteLine("How many items to this order? ");
            int cont = int.Parse(Console.ReadLine());

            for (int i = 1; i <= cont; i++)
            {
                Console.WriteLine($"Enter #{i} item data: ");
                Console.WriteLine("Product name: ");
                string productName = Console.ReadLine();
                Console.WriteLine("Product price: ");
                double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.WriteLine("Quantity: ");
                int productQuantity = int.Parse(Console.ReadLine());

                Product p = new Product(productName, productPrice);
                OrderItem order = new OrderItem(productQuantity, p);
                o1.AddItem(order);
            }

            Console.WriteLine(o1.ToString());
        }
    }
}
