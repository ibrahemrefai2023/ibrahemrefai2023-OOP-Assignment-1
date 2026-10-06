using System;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Stock { get; private set; }
    public Product(int id, string name, double price, int stock) 
    {
        Id = id; 
        Name = name;
        Price = price;
        Stock = stock; 
    }
    public bool HasEnoughStock(int quantity) { return Stock >= quantity; }
    public void ReduceStock(int quantity) { Stock -= quantity; }
}
