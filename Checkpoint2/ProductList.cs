/* 
 TODO: 
> Add Error handling to your console app.
> Refactor your code using "Linq" if possible.
> Error handling for searching
*/



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