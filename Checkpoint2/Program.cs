/* 
 TODO: 
> Add Error handling to your console app.
> Refactor your code using "Linq" if possible.
> Error handling for searching
*/

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
        string searchProductName = "";
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("To enter a new product - follow the steps | To quit - enter \"Q\"");

        do
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Enter a category. Category name can't be lower than 2 letters unless you wish to quit by typing \"q\"");
                Console.ForegroundColor = ConsoleColor.White;
                category = Console.ReadLine();
                if (CheckIfStringEmptyOrNotAcceptable(category)) { break; }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unacceptable answer! Write it again.");
                }

            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"The product name {category} was not accepted. Try again.");
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
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
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Enter a product name. Name can't be lower than 2 letters.");
                    Console.ForegroundColor = ConsoleColor.White;
                    productName = Console.ReadLine();
                    if (CheckIfStringEmptyOrNotAcceptable(productName)) { break; }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Unacceptable answer! Write it again.");
                    }

                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"The product name {productName} was not accepted. Try again.");
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Unexpected error: {e.Message}. Try again.");
                }
            } while (true);

            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Enter a product price: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    productPrice = Int32.Parse(Console.ReadLine());
                    if (CheckIfIntegerEmptyOrNotAcceptable(productPrice)) { break; }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Unacceptable answer! Write it again.");
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"The product price {productPrice} was not accepted. Try again.");
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
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
            Console.WriteLine("--------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Category".PadRight(20) + "Product".PadRight(20) + "Price".PadRight(10));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("|");

            List<ProductList> productList = new List<ProductList>();


            foreach (var joined in products.Zip(prices, Tuple.Create))
            {
                //Console.WriteLine(joined.Item1.Category.PadRight(20) + "" + joined.Item1.Name.PadRight(20) + "" + joined.Item2.ProductPrice.ToString());
                ProductList productList1 = new ProductList(joined.Item1.Category, joined.Item1.Name, joined.Item2.ProductPrice);
                productList.Add(productList1);
            }

            List<ProductList> productListSorted = productList.OrderBy(pl => pl.ProductPrice).ToList();

            foreach (ProductList pl in productListSorted)
            {
                Console.WriteLine(pl.Category.PadRight(20) + pl.Name.PadRight(20) + pl.ProductPrice.ToString().PadRight(10) + "|");
            }

            int totalAmount = prices.Sum(price => price.ProductPrice);
            Console.WriteLine("".PadRight(50) + "|");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Total Amount:".PadRight(20) + totalAmount.ToString().PadRight(30));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("|");
            Console.WriteLine("--------------------------------------------------");

            do
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Do you wish to continue adding products? Y/N) || Do you wish to search for a product? (S)");
                Console.ForegroundColor = ConsoleColor.White;
                string input = Console.ReadLine();

                if (input.ToLower().Equals("y"))
                {
                    addNewProducts = true;
                    break;
                }
                else if (input.ToLower().Equals("n")) { break; }
                else if (input.ToLower().Equals("s"))
                {
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Enter the product you wish to search for.");
                        Console.ForegroundColor = ConsoleColor.White;

                        searchProductName = Console.ReadLine();
                        if (CheckIfStringEmptyOrNotAcceptable(searchProductName)) { break; }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Unacceptable search term. Try again.");
                        }

                        //List<ProductList> searchResult = (List<ProductList>)productList.Where(product => product.Name == searchProductName);
                    } while (true);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("--------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Category".PadRight(20) + "Product".PadRight(20) + "Price".PadRight(10));
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("|");

                    foreach (ProductList pl in productListSorted)
                    {
                        if (pl.Name.ToLower().Equals(searchProductName.ToLower()))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(pl.Category.PadRight(20) + pl.Name.PadRight(20) + pl.ProductPrice.ToString().PadRight(10) + "<");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(pl.Category.PadRight(20) + pl.Name.PadRight(20) + pl.ProductPrice.ToString().PadRight(10) + "|");
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("".PadRight(50) + "|");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Total Amount:".PadRight(20) + totalAmount.ToString().PadRight(30));
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("|");
                    Console.WriteLine("--------------------------------------------------");

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unacceptable answer.");
                }
            } while (true);
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

class ProductList
{
    public ProductList(string category, string name, int price)
    {
        Category = category;
        Name = name;
        ProductPrice = price;
    }

    //properties
    public string Category { get; set; }
    public string Name { get; set; }
    public int ProductPrice { get; set; }
}