using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange
{
    public class Stock : Subject
    {
        public String Name { get; set; }
        public String Symbol { get; set; }
        public int OpeningPrice { get; set; }
        public int PreviousClosingPrice { get; set; }
        public int CurrentPrice { get; set; }
        public int BidPrice { get; set; }
        public int AskPrice { get; set; }
        public int CurrentVolume { get; set; }
        public int AverageVolume { get; set; }
        public bool IsMonitored { get; set; }
        public int times { get; set; }
        public int lastupdate { get; set; }
        private int previousPrice { get; set; }
        public Stock(String symbol, String name) : base()
        {
            Name = name;
            Symbol = symbol;
            OpeningPrice = 0;
            PreviousClosingPrice = 0;
            CurrentPrice = 0;
            AskPrice = 0;
            BidPrice = 0;
            CurrentVolume = 0;
        }
        public Dictionary<String, String> toRow()
        {

            Dictionary<String, String> toReturn = new Dictionary<String, String>();
            String current = CurrentPrice + "";
            if(CurrentPrice > previousPrice)
            {
                current += "↑\t";
            }
            else
            {
                current += "↓\t";
            }
            toReturn["Symbol"] = Symbol;
            toReturn["Current"] = current;
            toReturn["BidPrice"] = BidPrice + "";
            toReturn["AskPrice"] = AskPrice + "";
            toReturn["OpenPrice"] = OpeningPrice + "";
            toReturn["ClosePrice"] = OpeningPrice + "";
            return toReturn;
        }
        public String toString()
        {
            return Symbol + ", " + Name; 
        }

        public void Update(TickerMessage m)
        {
            OpeningPrice = m.OpeningPrice;
            PreviousClosingPrice = m.PreviousClosingPrice;
            BidPrice = m.BidPrice;
            CurrentPrice = m.CurrentPrice;
            CurrentVolume = m.CurrentVolume;
            AverageVolume = m.AverageVolume;
            AskPrice = m.AskPrice;
            Notify();
        }
        public override void Notify()
        {
            previousPrice = CurrentPrice;
            foreach(Observer obs in observers)
            {
                obs.Update(new StockContext(this));
            }
        }
    }
}
