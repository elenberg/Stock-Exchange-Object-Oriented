using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockExchange
{
    public partial class ConfigurePanel : Form
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ConfigurePanel));

        public Panel p1 { get; set; }
        public Panel p2 { get; set; }
        public Panel p3 { get; set; }
        public Panel p4 { get; set; }
        public Panel p5 { get; set; }
        public Panel p6 { get; set; }
        public InterfacePanel interface1 { get; set; }
        public InterfacePanel interface2 { get; set; }
        public InterfacePanel interface3 { get; set; }
        public InterfacePanel interface4 { get; set; }
        public InterfacePanel interface5 { get; set; }
        public InterfacePanel interface6 { get; set; }
        private Portfolio portfolio { get; set; }
        
        public ConfigurePanel(Portfolio p, Panel pan1, Panel pan2, Panel pan3, Panel pan4, Panel pan5, Panel pan6, InterfacePanel interface1, InterfacePanel interface2, InterfacePanel interface3, InterfacePanel interface4, InterfacePanel interface5, InterfacePanel interface6)
        {
            InitializeComponent();

            this.interface1 = interface1;
            this.interface2 = interface2;
            this.interface3 = interface3;
            this.interface4 = interface4;
            this.interface5 = interface5;
            this.interface6 = interface6;

            portfolio = p;
            p1 = pan1;
            p2 = pan2;
            p3 = pan3;
            p4 = pan4;
            p5 = pan5;
            p6 = pan6;
            StockBox.Items.Clear();
            foreach (String symbol in p.getSymbols())
            {
                StockBox.Items.Add(symbol);
            }
            Logger.Debug("Created Configure Panels form.");
        }

        private void accept_Click(object sender, EventArgs e)
        {
            Logger.Debug("Closed form");
            this.Close();
        }
        private InterfacePanel getInterfaceForPanel()
        {
            InterfacePanel toUpdate = null;

            switch (comboBox1.Text)
            {
                case "Panel 1":
                    toUpdate = interface1;
                    break;
                case "Panel 2":
                    toUpdate = interface2;
                    break;
                case "Panel 3":
                    toUpdate = interface3;
                    break;
                case "Panel 4":
                    toUpdate = interface4;
                    break;
                case "Panel 5":
                    toUpdate = interface5;
                    break;
                case "Panel 6":
                    toUpdate = interface6;
                    break;
                default:
                    break;
            }
            return toUpdate;
        }


        private void setInterfaceForPanel(InterfacePanel facepanel)
        {

            switch (comboBox1.Text)
            {
                case "Panel 1":
                    interface1 = facepanel;
                    break;
                case "Panel 2":
                    interface2 = facepanel;
                    break;
                case "Panel 3":
                    interface3 = facepanel;
                    break;
                case "Panel 4":
                    interface4 = facepanel;
                    break;
                case "Panel 5":
                    interface5 = facepanel;
                    break;
                case "Panel 6":
                    interface6 = facepanel;
                    break;
                default:
                    break;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!comboBox1.Text.Equals("Select a Panel"))
            {
                comboBox2.Enabled = true;
                remove.Enabled = true;
            }
            else
            {
                comboBox2.Enabled = false;
                remove.Enabled = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!comboBox2.Text.Equals("Chart Type"))
            {
                selectionPanel.Enabled = true;
                if (!comboBox2.Text.Equals("Portfolio"))
                {
                    update.Enabled = false;
                }
                else
                {
                    update.Enabled = true;
                }
                selectionPanel.Visible = true;
            }
            else
            {
                selectionPanel.Enabled = false;
                selectionPanel.Visible = false;
            }
        }
        private void createStockPrice(Panel panel)
        {
            InterfacePanel previous = getInterfaceForPanel();
            if (previous != null)
            {
                previous.Unsubscribe();
            }
            Stock temp = portfolio.listOfStocks[StockBox.Text];
            StockPricePanel interfacePanel = new StockPricePanel(portfolio.listOfStocks[StockBox.Text], panel);
            portfolio.listOfStocks[StockBox.Text].Register(interfacePanel);
            panel.Controls.Clear();
            panel.Controls.AddRange(interfacePanel.getControls());
            if (!open.Checked)
            {
                portfolio.listOfStocks[StockBox.Text].Register(interfacePanel);
                setInterfaceForPanel(interfacePanel);
                panel.Controls.AddRange(interfacePanel.getControls());
            }
            else
            {
                LabelOpenClosePriceDecorator labeldec = new LabelOpenClosePriceDecorator(panel, interfacePanel, temp.OpeningPrice, temp.PreviousClosingPrice);
                portfolio.listOfStocks[StockBox.Text].Register(labeldec);
                setInterfaceForPanel(labeldec);
                panel.Controls.AddRange(labeldec.getControls());
                panel.Controls[1].BringToFront();

            }
        }
        private void createPortfolioPrices(Panel panel)
        {
            InterfacePanel previous = getInterfaceForPanel();
            if (previous != null)
            {
                previous.Unsubscribe();
            }
            PortFolioPanel portPanel = new PortFolioPanel(portfolio, open.Checked, panel);
            portfolio.Register(portPanel);
            panel.Controls.Clear();
            panel.Controls.AddRange(portPanel.getControls());
            setInterfaceForPanel(portPanel);


        }
        private void createStockVolume(Panel panel)
        {
            InterfacePanel previous = getInterfaceForPanel();
            if (previous != null)
            {
                previous.Unsubscribe();
            }
            Stock temp = portfolio.listOfStocks[StockBox.Text];
            StockVolumePanel interfacePanel = new StockVolumePanel(portfolio.listOfStocks[StockBox.Text], panel);
            panel.Controls.Clear();
            if (!open.Checked)
            {
                portfolio.listOfStocks[StockBox.Text].Register(interfacePanel);
                setInterfaceForPanel(interfacePanel);
                panel.Controls.AddRange(interfacePanel.getControls());
            }
            else
            {
                LabelOpenClosePriceDecorator labelDecorator = new LabelOpenClosePriceDecorator(panel, interfacePanel, temp.OpeningPrice, temp.PreviousClosingPrice);
                Control[] controls = labelDecorator.getControls();
                portfolio.listOfStocks[StockBox.Text].Register(labelDecorator);
                setInterfaceForPanel(labelDecorator);
                panel.Controls.AddRange(labelDecorator.getControls());
                // Need to bring the label to the front.
                panel.Controls[1].BringToFront();
            }

        }

        private void previousPrice_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void updatePanel(Panel p)
        {
            switch (comboBox2.Text)
            {
                case "Portfolio":
                    createPortfolioPrices(p);
                    break;
                case "Stock Price":
                    createStockPrice(p);
                    break;
                case "Stock Volume":
                    createStockVolume(p);
                    break;
                default:
                    break;
            }
        }
        private Panel currentPanel()
        {
            Panel toUpdate = new Panel();
            switch (comboBox1.Text)
            {
                case "Panel 1":
                    toUpdate = p1;
                    break;
                case "Panel 2":
                    toUpdate = p2;
                    break;
                case "Panel 3":
                    toUpdate = p3;
                    break;
                case "Panel 4":
                    toUpdate = p4;
                    break;
                case "Panel 5":
                    toUpdate = p5;
                    break;
                case "Panel 6":
                    toUpdate = p6;
                    break;
                default:
                    break;
            }
            return toUpdate;
        }
        private void update_Click(object sender, EventArgs e)
        {
            updatePanel(currentPanel());
            Update();
        }

        private void remove_Click(object sender, EventArgs e)
        {
            Logger.Debug("Updating " + comboBox1.Text);
            Panel toUpdate = currentPanel();
            InterfacePanel previous = getInterfaceForPanel();
            if(previous != null) previous.Unsubscribe();
            toUpdate.Controls.Clear();
            Logger.Debug("Removing all from " + comboBox1.Text);

        }

        private void StockBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!StockBox.Text.Equals("Stock Symbol"))
            {
                update.Enabled = true;
            }
            else
            {
                update.Enabled = false;
            }
        }
    }

}
