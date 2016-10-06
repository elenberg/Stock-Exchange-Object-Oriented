using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockExchange
{
    public partial class Form1 : Form
    {
        private CSVHandler csv;
        private Portfolio portfolio;
        private List<Stock> symbols;
        private SelectStocks s;
        private ConfigurePanel configForm;
        private StockMarketSimulator SMS;
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Form1));
        private readonly Timer _refreshForm = new Timer();
        private readonly object _myLock = new object();

        public int RefreshFrequency { get; set; }
        private InterfacePanel interface1 { get; set; }
        private InterfacePanel interface2 { get; set; }
        private InterfacePanel interface3 { get; set; }
        private InterfacePanel interface4 { get; set; }
        private InterfacePanel interface5 { get; set; }
        private InterfacePanel interface6 { get; set; }

        public Form1()
        {
            InitializeComponent();
            portfolio = new Portfolio();
            Logger.Debug("Form1 created.");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Logger.Debug("Form1 created.");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(SMS != null)
            {
                SMS.Stop();
            }
        }
        // Load from File
        private void loadFromCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.Debug("Load from CSV.");
            OpenFileDialog dlg = new OpenFileDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName;
                fileName = dlg.FileName;
                csv = new CSVHandler(fileName);
                symbols = csv.fromCSV();
                addSymbolsToMenu();
                
            }

        }

        private void addSymbolsToMenu()
        {
            if(symbols != null)
            {
                updateSymbols();

            }
        }

        public void updateSymbols()
        {
            Logger.Debug("Updating Symbols");
            s = new SelectStocks(symbols);
            s.ShowDialog();
            ListView items = s.getList();
            portfolio = new Portfolio();
            for (int i = 0; i < items.Items.Count; i++)
            {
                var values = items.Items[i].Text.Split(',');
                try
                {
                    Stock s = new Stock(values[0], values[1]);
                    portfolio.addStock(s, values[0]);
                }
                catch (Exception e)
                {
                    // Do nothing
                }
                
            }

        }

        private void writeToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            // set a default file name
            savefile.FileName = "unknown.csv";
            // set filters - this can be done in properties as well
            savefile.Filter = "CSV file (*.csv)|*.csv| All Files (*.*)|*.*";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(savefile.FileName));
                // TODO
            }
        }

        private void selectStocksToTrackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateSymbols();
        }

        private void configurePanelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Launch configure panels
            configForm =  new ConfigurePanel(portfolio, topLeft, TopMiddle, topRight, bottomLeft, bottomMiddle, bottomRight, interface1 , interface2, interface3, interface4, interface5, interface6);
            configForm.ShowDialog();
            interface1 = configForm.interface1;
            interface2 = configForm.interface2;
            interface3 = configForm.interface3;
            interface4 = configForm.interface4;
            interface5 = configForm.interface5;
            interface6 = configForm.interface6;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            // Connect   
            IPAddress badip = null;
            int value;
            if(portfolio.listOfStocks.Count == 0)
            {
                MessageBox.Show("You should load some stocks first.");
            }else if(!IPAddress.TryParse(ipAddress.Text, out badip) || !int.TryParse(portBox.Text,out value))
            {
                MessageBox.Show("Please input a valid IP/Port.");
            }else
            try
            {


                UDPCommunicator coms = new UDPCommunicator(ipAddress.Text, portBox.Text);
                SMS = new StockMarketSimulator(coms, portfolio);
                SMS.startMarket();
                button1.Enabled = false;
                StartRefreshTimer();
            }
            catch (Exception )
            {
                    // Do nothing
                button1.Enabled = true;
            }
        }

        // Refresh Timer 
        protected void StartRefreshTimer()
        {
            if (RefreshFrequency <= 0)
            {
                RefreshFrequency = 3000;
            }


            _refreshForm.Interval = RefreshFrequency;
            _refreshForm.Tick += refreshTimer_Tick;
            _refreshForm.Start();
        }
        private void refreshTimer_Tick(object sender, EventArgs e)
        {
                lock (_myLock)
                {
                    RefreshDisplay();
                }
        }

        private void RefreshDisplay()
        {
            if (interface1 != null && interface1.toUpdate)
            {

                interface1.updatePanels();
            }
            if (interface2 != null && interface2.toUpdate)
            {
                interface2.updatePanels();
            }
            if (interface3 != null && interface3.toUpdate)
            {
                interface3.updatePanels();
            }
            if (interface4 != null && interface4.toUpdate)
            {
                interface4.updatePanels();
            }
            if (interface5 != null && interface5.toUpdate)
            {
                interface5.updatePanels();
            }
            if (interface6 != null && interface6.toUpdate)
            {
                interface6.updatePanels();
            }
        }
    }
}
