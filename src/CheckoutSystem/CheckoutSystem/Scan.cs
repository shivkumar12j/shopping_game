using CheckoutSystem;

public class Scan
{
    private Dictionary<Product, int> items = new Dictionary<Product, int>();

    public void AddItem(Product item)
    {
        if (items.ContainsKey(item))
        {
            items[item]++;
        }
        else
        {
            items[item] = 1;
        }
    }

    public double CalculateTotal()
    {
        double total = 0.0;
        double discountedItemPrice = 0.0;

        foreach (KeyValuePair<Product, int> item in items)
        {
            if (item.Key.Name.Equals("Apple TV", StringComparison.OrdinalIgnoreCase) && item.Value >= 3)
            {
                discountedItemPrice = ((item.Value / 3) * 2 * item.Key.Price) + ((item.Value % 3) * item.Key.Price);
            }
            else if (item.Key.Name.Equals("Super iPad", StringComparison.OrdinalIgnoreCase) && item.Value > 4)
            {
                discountedItemPrice = ProductPrice.discountedIpdPrice * item.Value;
            }
            else
            {
                discountedItemPrice = item.Value * item.Key.Price;

            }
            total += discountedItemPrice;

            //Console.WriteLine($"{item.Key.Name} - ${item.Key.Price} x {item.Value} - ## Discounted Price - {discountedItemPrice}");
        }

        if (items.Any(i => i.Key.Name.Equals("MacBook Pro", StringComparison.OrdinalIgnoreCase)))
        {

            var macBookCount = items.Where(i => i.Key.Name.Equals("MacBook Pro", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Value;
            total = total - macBookCount * ProductPrice.vgaPrice;
        }

        return total;
    }

    public override string ToString()
    {
        if (items.Any(i => i.Key.Name.Equals("MacBook Pro", StringComparison.OrdinalIgnoreCase)))
        {
            var macBookCount = items.Where(i => i.Key.Name.Equals("MacBook Pro", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Value;
            int vgaAdapterCount = items.Where(i => i.Key.Name.Equals("VGA adapter", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Value;

            Product vgaItem = new Product("vga", "VGA adapter", ProductPrice.vgaPrice);
            if (vgaAdapterCount < macBookCount)
            {
                for (int i = 0; i < macBookCount - vgaAdapterCount; i++)
                {
                    if (items.ContainsKey(vgaItem))
                    {
                        items[vgaItem]++;
                    }
                    else
                    {
                        items[vgaItem] = 1;
                    }
                }
            }
        }

        string output = "";
        //var skuScanned = items.Keys.Select(p => p.Sku).ToArray();
        //output += $"SKUs Scanned: {String.Join(", ", skuScanned)}\n";

        output += $"SKUs Scanned: ";
        foreach (KeyValuePair<Product, int> item in items)
        {
            for (int i = 0; i < item.Value; i++)
            {
                output += $"{item.Key.Sku}, ";
            }
        }
        output = output.Substring(0, output.Length - 2) + "\n";

        output += $"Total expected: ${CalculateTotal()}";

        return output;
    }
}