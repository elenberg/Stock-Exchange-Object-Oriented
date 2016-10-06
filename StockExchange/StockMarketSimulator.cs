using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockExchange
{
    public class StockMarketSimulator
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(StockMarketSimulator));
        public Boolean Active { get; set; }
        public UDPCommunicator Comms { get; set; }
        public Portfolio stocks { get; set; }
        public AutoResetEvent waitHandle { get; set; }
        public StockMarketSimulator(UDPCommunicator coms, Portfolio portfolio)
        {
            Comms = coms;
            stocks = portfolio;
        }
        public void startMarket()
        {
            // Sets activegame to true and also starts the udp connection. 
            Active = true;
            waitHandle = new AutoResetEvent(false);
            Comms.Start(waitHandle, this);
            Comms.Send(stocks.toMessage());

        }
        public void Stop()
        {
            Active = false;
            Comms.Stop();
        }
        
        public void doAction(byte[] message)
        {
            TickerMessage t = TickerMessage.Decode(message);
            Logger.Debug(t.Symbol);
            stocks.Update(t);
        }
}
}
