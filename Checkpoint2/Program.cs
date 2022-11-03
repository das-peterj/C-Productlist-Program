using System.Linq;

do { 
    bool addNewProducts = true;
    List<Product> products = new List<Product>();
    List<Price> prices = new List<Price>();

    // example sample data
    Product product1 = new Product("Phone", "Apple");
    products.Add(product1);
    Price price1 = new Price(12999);
    prices.Add(price1);

    Product product2 = new Product("Phone", "Samsung");
    products.Add(product2);
    Price price2 = new Price(11999);
    prices.Add(price2);

    Product product3 = new Product("Phone", "Oneplus");
    products.Add(product3);
    Price price3 = new Price(9999);
    prices.Add(price3);

    Product product4 = new Product("Phone", "Google Pixel");
    products.Add(product4);
    Price price4 = new Price(10999);
    prices.Add(price4);

    do
    {

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("To enter a new product - follow the steps | To quit - enter \"Q\"");
    Console.ForegroundColor = ConsoleColor.White;

    Console.WriteLine("Enter a category: ");
    string category = Console.ReadLine();

    if (category.ToLower().Equals("q")) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Exiting from the current view.");
        Console.WriteLine("");
        addNewProducts = false;
    } else { 

    Console.WriteLine("Enter a product name: ");
    string productName = Console.ReadLine();

    Console.WriteLine("Enter a price: ");
    int productPrice = Int32.Parse(Console.ReadLine());

    Product product = new Product(category, productName);
    products.Add(product);

    Price price = new Price(productPrice);
    prices.Add(price);

     

    if (product.Category == category && product.Name == productName && price.ProductPrice == productPrice)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The product has successfully been added to the list.");
        Console.WriteLine("");
    }
  }

    if (!addNewProducts)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Category".PadRight(20) + "Product".PadRight(20) + "Price");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (var joined in products.Zip(prices, Tuple.Create))
            {
                Console.WriteLine(joined.Item1.Category.PadRight(20) + "" + joined.Item1.Name.PadRight(20) + "" + joined.Item2.ProductPrice.ToString());
            }

        Console.WriteLine("-------------------------------");
        Console.WriteLine("Do you wish to continue adding products? Y/N)");
        string input = Console.ReadLine();

        if (input.ToLower().Equals("y")) { addNewProducts = true; }
        }

    } while (addNewProducts);
    break;
} while (true);

class Product
{
    public Product(string category, string name)
    {
        Category = category;
        Name = name;
    }

    //properties
    public string Category { get; set; }
    public string Name { get; set; }

}

class Price
{
    public Price(int price)
    {
        ProductPrice = price;
    }

    //propety
    public int ProductPrice { get; set; }

}