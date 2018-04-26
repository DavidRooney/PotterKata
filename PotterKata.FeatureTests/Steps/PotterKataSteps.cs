using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotterKata.Entities;
using PotterKata.Service;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace PotterKata.FeatureTests.Steps
{
    [Binding]
    public sealed class PotterKataSteps
    {
        const string BooksKey = "HarryPotterBooksKey";
        const string BooksInBasketKey = "BooksInBasketKey";
        const double SingleBookCost = 8;

        [Given(@"There are harry potter books in the store")]
        public void GivenIHavePickedUpAHarryPotterBook()
        {
            var allBooks = new List<Book>()
            {
                new Book("Harry Potter and the Philosopher's Stone", SingleBookCost),
                new Book("Harry Potter and the Chamber of Secrets", SingleBookCost),
                new Book("Harry Potter and the Prisoner of Azkaban", SingleBookCost),
                new Book("Harry Potter and the Goblet of Fire", SingleBookCost),
                new Book("Harry Potter and the Order of the Phoenix", SingleBookCost)
            };
            ScenarioContext.Current.Set<List<Book>>(allBooks, BooksKey);
        }

        [When(@"I buy '(.*)' of the '(1st|2nd|3rd|4th|5th)' book")]
        public void WhenIBuyBooks(int numberOfBooks, string bookSeriesNumber)
        {
            var books = ScenarioContext.Current.Get<List<Book>>(BooksKey);
            var basket = new List<Book>();
            int bookNumber = 0;

            switch (bookSeriesNumber)
            {
                case "1st":
                    bookNumber = 0;
                    break;
                case "2nd":
                    bookNumber = 1;
                    break;
                case "3rd":
                    bookNumber = 2;
                    break;
                case "4th":
                    bookNumber = 3;
                    break;
                case "5th":
                    bookNumber = 4;
                    break;
                default:
                    break;
            }

            for (int i = 0; i < numberOfBooks; i++)
            {
                Assert.IsNotNull(books[bookNumber]);
                basket.Add(books[bookNumber]);
            }

            ScenarioContext.Current.Set<List<Book>>(basket, BooksInBasketKey);
        }

        [When(@"I buy '(.*)' book")]
        [When(@"I buy '(.*)' different book|books")]
        public void WhenIBuyDifferentBooks(int numberOfBooks)
        {
            var books = ScenarioContext.Current.Get<List<Book>>(BooksKey);
            var basket = new List<Book>();

            for (int i = 0; i < numberOfBooks; i++)
            {
                Assert.IsNotNull(books[i]);
                basket.Add(books[i]);
            }

            ScenarioContext.Current.Set<List<Book>>(basket, BooksInBasketKey);
        }

        [Then(@"the basket will cost (.*) euros")]
        public void ThenTheBookWillCostEuros(int basketCost)
        {
            var books = ScenarioContext.Current.Get<List<Book>>(BooksInBasketKey);
            var price = PriceCalculatorService.CalculateTotalPrice(books.ToArray());

            Assert.AreEqual(basketCost, price);
        }

        [Then(@"the basket will receive a (.*)% discount")]
        public void ThenTheBasketWillReceiveADiscount(double discountPercent)
        {
            var books = ScenarioContext.Current.Get<List<Book>>(BooksInBasketKey);
            var price = PriceCalculatorService.CalculateTotalPrice(books.ToArray());

            var totalSum = books.Sum(b => b.Cost);
            var percent = discountPercent / 100;
            var expectedPrice = totalSum - percent;

            Assert.AreEqual(expectedPrice, price);
        }
    }
}
