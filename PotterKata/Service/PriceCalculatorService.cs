using PotterKata.Entities;
using System.Linq;

namespace PotterKata.Service
{
    public class PriceCalculatorService
    {
        public static double CalculateTotalPrice(Book[] books)
        {
            var totalCost = books.Sum(b => b.Cost);
            var basketCount = books.Count();
            var uniqueBooksInBasket = books.Distinct();

            if (basketCount == 2 && uniqueBooksInBasket.Count() == basketCount)
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
