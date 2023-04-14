namespace CheckoutSystem;

class Program
{
    static void Main(string[] args)
    {
        List<Product> catalogue = new List<Product>()
        {
            new Product("ipd","Super iPad",  ProductPrice.ipdPrice),
            new Product("mbp","MacBook Pro", ProductPrice.mbpPrice),
            new Product("atv", "Apple TV", ProductPrice.atvPrice),
            new Product("vga","VGA adapter",  ProductPrice.vgaPrice),
        };

        Scan scan = new Scan();
        while (true)
        {
            Console.WriteLine("Please enter a SKU to add to your scan:");

            for (int i = 0; i < catalogue.Count; i++)
            {
                Console.WriteLine($"{catalogue[i].Sku} - {catalogue[i].Name} (${catalogue[i].Price})");
            }
            Console.WriteLine("0 - Checkout");

            string selection = Console.ReadLine();

            if (selection == "0")
            {
                break;
            }

            Product selectedProduct = catalogue.Find(product => product.Sku == selection);

            if (selectedProduct != null)
            {
                scan.AddItem(selectedProduct);
            }
            else
            {
                Console.WriteLine("Invalid SKU.");
            }
        }

        Console.WriteLine(scan.ToString());
    }
}

