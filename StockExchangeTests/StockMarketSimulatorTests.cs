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
    public class StockMarketSimulatorTests
    {
        private Portfolio portfolio { get; set; }
        private StockMarketSimulator sms { get; set; }
        private TickerMessage goodTick { get; set; }
        private TickerMessage badTick { get; set; }
        private byte[] goodmessage { get; set; }
        private byte[] badmessage { get; set; }
        [TestInitialize]
        public void setUp()
        {
            portfolio = new Portfolio();
            goodTick = new TickerMessage()
            {
                Symbol = "ABCD  ",
                MessageTimestamp = DateTime.Now,
                OpeningPrice = 1001,
                PreviousClosingPrice = 1002,
                CurrentPrice = 1003,
                AskPrice = 1004,
                BidPrice = 1005,
                CurrentVolume = 1006,
                AverageVolume = 1007
            };
            goodmessage = goodTick.Encode();
            badTick = new TickerMessage()
            {
                Symbol = "NOTASTOCK"
            };
            badmessage = new byte[] { 0, 1, 12, 3, 5 };
            portfolio.addStock(new Stock("ABCD", "Something great"), "ABCD  ");
            sms = new StockMarketSimulator(portfolio);

        }

        [TestMethod()]
        public void doActionTest()
        {
            Stock temp = new Stock("ABCD  ", "Something Great");
            sms.doAction(badmessage);
            // Check data inside to verify nothing has changed.
            Assert.AreEqual(temp.CurrentVolume, portfolio.listOfStocks["ABCD  "].CurrentVolume);
            Assert.AreEqual(1, portfolio.listOfStocks.Count);

            // Check data to verify that the data has changed. 
            sms.doAction(goodmessage);
            Assert.AreNotEqual(temp.CurrentVolume, portfolio.listOfStocks["ABCD  "].CurrentVolume);
            Assert.AreEqual(portfolio.listOfStocks["ABCD  "].CurrentVolume, 1006);

        }
    }
}