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

        [When(@"I buy (.*) book|books")]
        public void WhenIBuyBooks(int numberOfBooks)
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
