namespace Checkpoint22
{
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
}