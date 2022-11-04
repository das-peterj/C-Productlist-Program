/* 
 TODO: 
> Add Error handling to your console app.
> Refactor your code using "Linq" if possible.
> Error handling for searching
*/
internal class Product
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