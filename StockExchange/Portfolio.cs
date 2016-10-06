using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange
{
    public class Portfolio : Subject
    {
        public Dictionary<String, Stock> listOfStocks { get; set; }
        public Portfolio()
        {
            listOfStocks = new Dictionary<string, Stock>();
        }
        public void addStock(Stock s, String symbol)
        {
            listOfStocks.Add(symbol, s);
        }
        public List<String> getSymbols()
        {
            return new List<String>(listOfStocks.Keys);
        }
        public void Update(TickerMessage message)
        {
            if (message == null) return;

            if (listOfStocks.ContainsKey(message.Symbol.PadRight(6)))
                listOfStocks[message.Symbol.PadRight(6)].Update(message);
            Notify();

        }
        public List<Dictionary<String, String>> updateMessages()
        {
            List<Dictionary<String, String>> toReturn = new List<Dictionary<String, String>>();
            foreach(String symbol in listOfStocks.Keys)
            {
                toReturn.Add(listOfStocks[symbol].toRow());
            }
            return toReturn;
        }
        public byte[] toMessage()
        {
            StreamStocksMessage stream = new StreamStocksMessage();
            foreach(String key in listOfStocks.Keys)
            {
                stream.Add(key);
            }
            return stream.Encode();
        }
        
        public override void Notify()
        {
            foreach(Observer o in observers)
            {
                PortfolioContext toReturn = new PortfolioContext(updateMessages());
                o.Update(toReturn);
            }
        }
    }
}
