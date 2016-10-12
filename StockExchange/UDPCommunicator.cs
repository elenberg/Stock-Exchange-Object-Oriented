using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Collections;

namespace StockExchange
{
    public class UDPCommunicator
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(UDPCommunicator));
        private readonly UdpClient _myUdpClient;
        private Thread listener;
        private bool Done { get; set; }
        public IPEndPoint serverEP { get; set; }
        public AutoResetEvent waitHandle { get; set; }
        private StockMarketSimulator sms;
        public Queue list { get; set; }
        public UDPCommunicator(string IP, string port)
        {
            serverEP = new IPEndPoint(IPAddress.Parse(IP), int.Parse(port));
            IPEndPoint localEP = new IPEndPoint(IPAddress.Any, 0);
            _myUdpClient = new UdpClient(localEP);
            _myUdpClient.Connect(serverEP);
            list = Queue.Synchronized(new Queue());
        }

        public void Listen()
        {
            while (!Done)
            {
                try
                {
                    
                    IPEndPoint remoteEP = null;
                    byte[] received = _myUdpClient.Receive(ref remoteEP);
                    list.Enqueue(received);
                    Logger.Debug("Current Queue Size " + list.Count);
                    waitHandle.Set();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public void Start(StockMarketSimulator s)
        {
            sms = s;
            Done = false;
            waitHandle = new AutoResetEvent(false);
            listener = new Thread(new ThreadStart(Listen));
            listener.Start();
            Thread consumer = new Thread(new ThreadStart(consume));
            consumer.Start();
            Logger.Debug("Started thread");
        }
        public void consume()
        {
            while (!Done)
            {
                waitHandle.WaitOne();
                while (list.Count != 0)
                {
                    sms.doAction((byte[])list.Dequeue());
                }
            }
        }
        public void Stop()
        {
            Done = true;
            listener.Join();
            StreamStocksMessage temp = new StreamStocksMessage();
            Send(temp.Encode());
            Console.WriteLine("Sent closing message");
        }
        public void Send(byte[] outbound)
        {
            _myUdpClient.Send(outbound, outbound.Length);
            Logger.Debug("Sent message");
        }
    }
}
