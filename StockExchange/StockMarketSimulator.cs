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
        public UDPCommunicator Comms { get; set; }
        private Portfolio stocks { get; set; }
        public StockMarketSimulator(UDPCommunicator coms, Portfolio portfolio)
        {
            Comms = coms;
            stocks = portfolio;
        }
        public StockMarketSimulator(Portfolio portfolio)
        {
            // ONLY USED IN TESTING.
            stocks = portfolio;
        }
        public void startMarket()
        {
            // Sets activegame to true and also starts the udp connection. 
            Comms.Start(this);
            Comms.Send(stocks.toMessage());

        }
        public void Stop()
        {
            Comms.Stop();
        }
        
        public void doAction(byte[] message)
        {
            try
            {
                TickerMessage t = TickerMessage.Decode(message);
                stocks.Update(t);
                Logger.Debug(t.Symbol);

            }
            catch (Exception e)
            {
                Logger.Error("Invalid TickerMessage Received");
            }
        }
}
}
