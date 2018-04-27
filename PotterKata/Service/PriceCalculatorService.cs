using PotterKata.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PotterKata.Service
{
    public static class PriceCalculatorService
    {
        private static readonly Dictionary<int, int> Discounts = new Dictionary<int, int>() { { 1, 0 }, { 2, 5 }, { 3, 10 } };

        public static double CalculateTotalPrice(Book[] books)
        {
            var totalCost = books.Sum(b => b.Cost);
            var basketCount = books.Count();
            var uniqueBooksInBasket = books.Distinct();

            var discount = Discounts[uniqueBooksInBasket.Count()];

            var groupedBooks = books.GroupBy(book => book.Name);

            for (int i = 0; i < groupedBooks.Count(); i++)
            {

            }


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
