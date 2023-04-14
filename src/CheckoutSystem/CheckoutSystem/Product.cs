namespace CheckoutSystem;

public class Product
{
    public string Name { get; set; }
    public string Sku { get; set; }
    public double Price { get; set; }
    
    public Product(string sku, string name, double price)
    {
        Sku = sku;
        Name = name;
        Price = price;
    }
}

public static class ProductPrice
{
    public static double ipdPrice = 549.99;
    public static double discountedIpdPrice = 499.99;

    public static double mbpPrice = 1399.99;
    public static double atvPrice = 109.50;
    public static double vgaPrice = 30.00;
}
