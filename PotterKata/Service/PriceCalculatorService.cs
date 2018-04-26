using PotterKata.Entities;
using System.Linq;

namespace PotterKata.Service
{
    public class PriceCalculatorService
    {
        public static double CalculateTotalPrice(Book[] books)
        {
            var totalCost = books.Sum(b => b.Cost);

            if (books.Count() == 2)
            {
                var discount = (double)5 / (double)100;
                return totalCost - discount;
            }

            return totalCost;
        }

        public static double CalculateTotalPrice(Book book)
        {
            return book.Cost;
        }
    }
}
