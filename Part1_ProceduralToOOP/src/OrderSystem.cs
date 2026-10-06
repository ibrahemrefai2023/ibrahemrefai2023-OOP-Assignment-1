using System;

public class OrderSystem
{
    private const int MaxCustomers = 50;
    private const int MaxProducts = 50;
    private const int MaxOrders = 100; 
    private readonly List<Customer> customers = new(); 
    private readonly List<Product> products = new();
    private readonly List<Order> orders = new();

    // Customer Operations //
    public void AddCustomer( int id, string name, string email, string city, bool isVip) 
    { 
        if (customers.Count >= MaxCustomers)
        { 
            Console.WriteLine("ERROR: customer list is full.");
            return; 
        } 
        if (FindCustomerById(id) != null) 
        { 
            Console.WriteLine( $"ERROR: customer id {id} already exists." );
            return;
        } 
        Customer customer = new Customer( id, name, email, city, isVip ); 
        customers.Add(customer); 
    } public void PrintCustomers() 
    { Console.WriteLine( $"\n=== CUSTOMERS ({customers.Count}) ===" );
        foreach (Customer customer in customers) 
        { 
            Console.WriteLine( $"#{customer.Id} " + $"{customer.Name} " + $"<{customer.Email}> " + $"{customer.City} " + $"vip={(customer.IsVip ? "yes" : "no")}" );
        } 
    } 
    private Customer? FindCustomerById(int id)
    {
        return customers.FirstOrDefault(c => c.Id == id); }
    // Product Operations //
    public void AddProduct( int id, string name, double price, int stock)
    { 
        if (products.Count >= MaxProducts) 
        { 
            Console.WriteLine("ERROR: product list is full.");
            return;
        } 
        if (FindProductById(id) != null) 
        { 
            Console.WriteLine( $"ERROR: product id {id} already exists." );
            return;
        } 
        Product product = new Product( id, name, price, stock );
        products.Add(product);
    } 
    public void PrintProducts() 
    {
        Console.WriteLine( $"\n=== PRODUCTS ({products.Count}) ===" );
        foreach (Product product in products) 
        { Console.WriteLine( $"#{product.Id} " + $"{product.Name} " + $"price={product.Price:F2} " + $"stock={product.Stock}" );
        } 
    }
    private Product? FindProductById(int id) 
    { 
        return products.FirstOrDefault(p => p.Id == id); 
    }
    // Order Operations //
    public bool CreateOrder( int orderId, int customerId, string date) 
    {
        if (orders.Count >= MaxOrders) 
        { 
            Console.WriteLine("ERROR: order list is full.");
            return false; } if (FindOrderById(orderId) != null) 
        { 
            Console.WriteLine( $"ERROR: order id {orderId} already exists." );
            return false; 
        }
        Customer? customer = FindCustomerById(customerId); 
        if (customer == null) 
        { 
            Console.WriteLine( $"ERROR: customer id {customerId} not found." );
            return false;
        } 
        Order order = new Order( orderId, customer, date ); 
        orders.Add(order); 
        return true; 
    }
    public void AddLineToOrder( int orderId, int productId, int quantity) 
    { 
        Order? order = FindOrderById(orderId);
        if (order == null) 
        { 
            Console.WriteLine( $"ERROR: order id {orderId} not found." );
            return; 
        } 
        Product? product = FindProductById(productId); 
        if (product == null) 
        {
            Console.WriteLine( $"ERROR: product id {productId} not found." ); 
            return;
        } 
        order.AddLine(product, quantity);
    } 
    public void MarkOrderPaid(int orderId)
    {
        Order? order = FindOrderById(orderId); 
        if (order == null) 
        { 
            Console.WriteLine( $"ERROR: order id {orderId} not found." ); 
            return;
        } 
        order.MarkAsPaid();
    }
    private Order? FindOrderById(int id)
    { 
        return orders.FirstOrDefault(o => o.Id == id); 
    } //  Printing Orders //
     public void PrintOrder(int orderId)
     { 
        Order? order = FindOrderById(orderId);
        if (order == null) 
        { 
            Console.WriteLine( $"ERROR: order id {orderId} not found." );
            return;
        }
        Console.WriteLine( $"\n=== ORDER #{order.Id} ===" );
        Console.WriteLine( $"Date: {order.Date}" );
        Console.WriteLine( $"Customer: {order.Customer.Name} " + $"(#{order.Customer.Id})" );
        Console.WriteLine( $"Paid: {(order.IsPaid ? "yes" : "no")}" ); 
        Console.WriteLine("Lines:");
        foreach (OrderLine line in order.Lines)
        { 
            double lineTotal = line.CalculateTotal();
            Console.WriteLine( $" - {line.Product.Name} " + $"x{line.Quantity} " + $"@{line.Product.Price:F2} " + $"= {lineTotal:F2}" ); 
        }
        Console.WriteLine( $"TOTAL: {order.CalculateTotal():F2}" ); 
     } 
     public void PrintAllOrders() 
     { 
        Console.WriteLine( $"\n=== ALL ORDERS ({orders.Count}) ===" ); 
        foreach (Order order in orders) 
        { 
            PrintOrder(order.Id);
        } 
     } 
    // Sales //
      public double CalculatePaidSalesTotal()
      { 
        double total = 0.0; 
        foreach (Order order in orders)
        {
            if (order.IsPaid)
            {
                total += order.CalculateTotal();
            }
        } return total; 
      } 
    // Sample Data //
      public void SeedSampleData()
    { 
        AddCustomer( 1, "Mona Ali", "mona@example.com", "Cairo", true );
        AddCustomer( 2, "Omar Hassan", "omar@example.com", "Alexandria", false );
        AddCustomer( 3, "Sara Nabil", "sara@example.com", "Giza", false );
        AddProduct( 101, "USB Cable", 50.0, 100 );
        AddProduct( 102, "Wireless Mouse", 250.0, 40 );
        AddProduct( 103, "Mechanical Keyboard", 1200.0, 15 );
        AddProduct( 104, "Laptop Stand", 400.0, 25 );
    }
    //  Demo //
      public void RunDemoScenario() 
      { 
        CreateOrder( 1001, 1, "2026-09-15" );
        AddLineToOrder( 1001, 101, 2 );
        AddLineToOrder( 1001, 102, 1 );
        MarkOrderPaid(1001);
        CreateOrder( 1002, 2, "2026-09-15" );
        AddLineToOrder( 1002, 103, 1 ); 
        AddLineToOrder( 1002, 104, 1 );
        CreateOrder( 1003, 3, "2026-09-16" ); 
        AddLineToOrder( 1003, 101, 5 );
        MarkOrderPaid(1003); 
      }
}
