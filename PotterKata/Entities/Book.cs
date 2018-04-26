namespace PotterKata.Entities
{
    public class Book
    {
        public Book(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name { get; set; }
        public double Cost { get; set; }
    }
}
