using System;

public class Order
{
    public int Id { get; set; }
    public Customer Customer { get; set; }
    public string Date { get; set; }
    public bool IsPaid { get; private set; }
    public List<OrderLine> Lines { get; } = new List<OrderLine>();
    public Order(int id, Customer customer, string date) 
    { 
        Id = id;
        Customer = customer;
        Date = date;
        IsPaid = false;
    }
    public bool AddLine(Product product, int quantity) 
    { 
        if (IsPaid) 
        { 
            Console.WriteLine("ERROR: cannot change a paid order.");
            return false; 
        } 
        if (Lines.Count >= 20) 
        { 
            Console.WriteLine("ERROR: order has too many lines.");
            return false; 
        }
        if (quantity <= 0) 
        { 
            Console.WriteLine("ERROR: quantity must be positive."); 
            return false; 
        } 
        if (!product.HasEnoughStock(quantity))
        { 
            Console.WriteLine($"ERROR: not enough stock for product #{product.Id}.");
            return false;
        } 
        product.ReduceStock(quantity);
        Lines.Add(new OrderLine(product, quantity));
        return true; 
    }
    public double CalculateTotal()
    { 
        double total = 0.0; 
        foreach (OrderLine line in Lines)
        { 
            total += line.CalculateTotal(); 
        } 
        if (Customer.IsVip)
        { 
            total *= 0.90; 
        } 
        return total; 
    }
    public bool MarkAsPaid() 
    { 
        if (Lines.Count == 0) 
        { Console.WriteLine("ERROR: cannot pay an empty order.");
            return false;
        } 
        IsPaid = true;
        return true; 
    }
}
