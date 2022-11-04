do
{
    bool addNewProducts = true;
    List<Product> products = new List<Product>();
    List<Price> prices = new List<Price>();

    #region SampleData
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
    #endregion

    do
    {
        string productName = "";
        int productPrice = 0;
        string category = "";
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("To enter a new product - follow the steps | To quit - enter \"Q\"");
        Console.ForegroundColor = ConsoleColor.White;

        do
        {
            try
            {
                Console.WriteLine("Enter a category. Category name can't be lower than 2 letters unless you wish to quit by typing \"q\"");
                category = Console.ReadLine();
                if (CheckIfStringEmptyOrNotAcceptable(category)) { break; }
                else
                {
                    Console.WriteLine("Unacceptable answer! Write it again.");
                }

            }
            catch (FormatException)
            {
                Console.WriteLine($"The product name {category} was not accepted. Try again.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected error: {e.Message}. Try again.");
            }
        } while (true);


        if (category.ToLower().Equals("q"))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Exiting from the current view.");
            Console.WriteLine("");
            addNewProducts = false;
        }
        else
        {
            do
            {
                try
                {
                    Console.WriteLine("Enter a product name. Name can't be lower than 2 letters.");
                    productName = Console.ReadLine();
                    if (CheckIfStringEmptyOrNotAcceptable(productName)) { break; }
                    else
                    {
                        Console.WriteLine("Unacceptable answer! Write it again.");
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine($"The product name {productName} was not accepted. Try again.");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Unexpected error: {e.Message}. Try again.");
                }
            } while (true);

            do
            {
                try
                {
                    Console.WriteLine("Enter a product price: ");
                    productPrice = Int32.Parse(Console.ReadLine());
                    if (CheckIfIntegerEmptyOrNotAcceptable(productPrice)) { break; }
                    else
                    {
                        Console.WriteLine("Unacceptable answer! Write it again.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The product price {productPrice} was not accepted. Try again.");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Unexpected error: {e.Message}. Try again.");
                }

            } while (true);

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
            Console.WriteLine("--------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Category".PadRight(20) + "Product".PadRight(20) + "Price");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (var joined in products.Zip(prices, Tuple.Create))
            {
                Console.WriteLine(joined.Item1.Category.PadRight(20) + "" + joined.Item1.Name.PadRight(20) + "" + joined.Item2.ProductPrice.ToString());
            }

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Do you wish to continue adding products? Y/N)");
            string input = Console.ReadLine();

            if (input.ToLower().Equals("y")) { addNewProducts = true; }
        }

    } while (addNewProducts);
    break;
} while (true);

bool CheckIfStringEmptyOrNotAcceptable(string input)
{
    if (input.ToLower().Equals("q"))
    {
        return true;
    }
    else if (input == null || input.Length < 2)
    {
        return false;
    }
    else { return true; }
}

bool CheckIfIntegerEmptyOrNotAcceptable(int input)
{
    if (input == null || input < 10)
    {
        return false;
    }
    else { return true; }
}

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