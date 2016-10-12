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
    public class StockTests
    {
        private Stock s { get; set; }
        [TestInitialize]
        public void setUP()
        {
            s = new Stock("ABCG", "NAME");
            

        }

        [TestMethod()]
        public void UpdateTest()
        {
            TickerMessage m1 = new TickerMessage()
            {
                Symbol = "ABCG",
                MessageTimestamp = DateTime.Now,
                OpeningPrice = 1001,
                PreviousClosingPrice = 1002,
                CurrentPrice = 1003,
                AskPrice = 1004,
                BidPrice = 1005,
                CurrentVolume = 1006,
                AverageVolume = 1007
            };
            s.Update(m1);
            Assert.AreEqual(m1.OpeningPrice, s.OpeningPrice);
            Assert.AreEqual(m1.CurrentPrice, s.CurrentPrice);
            Assert.AreEqual(m1.AskPrice, s.AskPrice);
        }

    }
}