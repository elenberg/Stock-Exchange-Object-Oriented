using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockExchange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Tests
{
    [TestClass()]
    public class PortfolioTests
    {
        private Portfolio portfolio { get; set; }

        [TestInitialize]
        public void setUp()
        {
            portfolio = new Portfolio();
        }

        [TestMethod()]
        public void addStockTest()
        {
            Assert.AreEqual(0, portfolio.listOfStocks.Count);
            portfolio.addStock(new Stock("ABCD  ", "NAME"), "ABCD  ");
            Assert.AreEqual(1, portfolio.listOfStocks.Count);
        }

        [TestMethod()]
        public void getSymbolsTest()
        {
            portfolio.addStock(new Stock("ABCD  ", "NAME"), "ABCD  ");
            portfolio.addStock(new Stock("ABCE  ", "NAME"), "ABCE  ");
            portfolio.addStock(new Stock("ABCF  ", "NAME"), "ABCF  ");
            portfolio.addStock(new Stock("ABCG  ", "NAME"), "ABCG  ");
            List<String> symbols = new List<string>();
            foreach(KeyValuePair<String, Stock> pair in portfolio.listOfStocks)
            {
                symbols.Add(pair.Key);
            }
            Assert.IsTrue(symbols.Contains("ABCD  "));
            Assert.IsFalse(symbols.Contains("BAD DATA"));

        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void updateMessagesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void toMessageTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void NotifyTest()
        {
            Assert.Fail();
        }
    }
}