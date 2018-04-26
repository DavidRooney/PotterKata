using PotterKata.Entities;
using System.Linq;

namespace PotterKata.Service
{
    public class PriceCalculatorService
    {
        public static double CalculateTotalPrice(Book[] books)
        {
            return books.Sum(b => b.Cost);
        }

        public static double CalculateTotalPrice(Book book)
        {
            return book.Cost;
        }
    }
}
