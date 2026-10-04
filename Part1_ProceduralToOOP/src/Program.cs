namespace Part1_ProceduralToOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OrderSystem system = new OrderSystem();
            Console.WriteLine("OOP Order System");
            Console.WriteLine("Seed sample data show a demo then open the menu."); 
            system.SeedSampleData(); 
            system.RunDemoScenario(); 
            system.PrintCustomers(); 
            system.PrintProducts(); 
            system.PrintAllOrders();
            Console.WriteLine($"\nPaid sales total after demo: " + $"{system.CalculatePaidSalesTotal():F2}");
            RunInteractiveMenu(system);
        }
        private static void RunInteractiveMenu(OrderSystem system) 
        { 
            int choice = -1; 
            while (choice != 0) 
            { 
                PrintMenu(); 
                if (!int.TryParse(Console.ReadLine(), out choice))
                { 
                    Console.WriteLine("Unknown choice.");
                    continue; 
                } 
                if (choice == 1)
                { 
                    system.PrintCustomers(); 
                } 
                else if (choice == 2) 
                { 
                    system.PrintProducts(); 
                }
                else if (choice == 3)
                { 
                    system.PrintAllOrders(); 
                } 
                else if (choice == 4) 
                { 
                    Console.Write("Order id: ");
                    int orderId = int.Parse(Console.ReadLine()!);
                    system.PrintOrder(orderId); }
                else if (choice == 5)
                { 
                    Console.Write("Order id: ");
                    int orderId = int.Parse(Console.ReadLine()!);
                    Console.Write("Customer id: ");
                    int customerId = int.Parse(Console.ReadLine()!);
                    Console.Write("Date (YYYY-MM-DD): "); 
                    string date = Console.ReadLine()!;
                    system.CreateOrder(orderId, customerId, date);
                } 
                else if (choice == 6) 
                {
                    Console.Write("Order id: ");
                    int orderId = int.Parse(Console.ReadLine()!);
                    Console.Write("Product id: ");
                    int productId = int.Parse(Console.ReadLine()!);
                    Console.Write("Quantity: "); 
                    int quantity = int.Parse(Console.ReadLine()!);
                    system.AddLineToOrder(orderId, productId, quantity); 
                } 
                else if (choice == 7) 
                { 
                    Console.Write("Order id: ");
                    int orderId = int.Parse(Console.ReadLine()!);
                    system.MarkOrderPaid(orderId); } else if (choice == 8)
                { 
                    Console.WriteLine($"Paid sales total: " + $"{system.CalculatePaidSalesTotal():F2}"); 
                } 
                else if (choice == 0) { Console.WriteLine("Bye."); } else { Console.WriteLine("Unknown choice.");
                } 
            } 
        }
        private static void PrintMenu()
        { 
            Console.WriteLine("\n------- MENU -------");
            Console.WriteLine("1) Print customers");
            Console.WriteLine("2) Print products");
            Console.WriteLine("3) Print all orders");
            Console.WriteLine("4) Print one order by id");
            Console.WriteLine("5) Create order");
            Console.WriteLine("6) Add line to order");
            Console.WriteLine("7) Mark order paid");
            Console.WriteLine("8) Show paid sales total");
            Console.WriteLine("0) Exit");
            Console.Write("Choice: "); 
        }
    }

}
