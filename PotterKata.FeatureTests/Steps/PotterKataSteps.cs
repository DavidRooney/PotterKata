using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace PotterKata.FeatureTests.Steps
{
    [Binding]
    public sealed class PotterKataSteps
    {
        const string BooksKey = "HarryPotterBooksKey";
        const string SingleBookKey = "SingleBookKey";
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
                new Book("Harry Potter and the Order of the Phoenix", SingleBookCost),
                new Book("Harry Potter and the Half-Blood Prince", SingleBookCost),
                new Book("Harry Potter and the Deathly Hallows", SingleBookCost)
            };
            ScenarioContext.Current.Set<List<Book>>(allBooks, BooksKey);
        }

        [When(@"I buy the book")]
        public void WhenIBuyTheBook()
        {
            var book = ScenarioContext.Current.Get<List<Book>>(BooksKey).FirstOrDefault();
            Assert.IsNotNull(book);

            ScenarioContext.Current.Set<Book>(book, SingleBookKey);
        }

        [Then(@"the book will cost (.*) euros")]
        public void ThenTheBookWillCostEuros(int p0)
        {
            var book = ScenarioContext.Current.Get<Book>(bookKey);
            Assert.AreEqual(book.Cost, 8);
        }
    }
}
