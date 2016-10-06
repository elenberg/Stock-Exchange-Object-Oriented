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
    public partial class SelectStocks : Form
    {
        private List<Stock> symbols;
        public Portfolio p { get; set; }
        private static readonly ILog Logger = LogManager.GetLogger(typeof(SelectStocks ));

        public SelectStocks(List<Stock> symbols)
        {
            InitializeComponent();
            this.symbols = symbols;
            StockList.Items.Clear();
            if(symbols != null)
            foreach (Stock symbol in symbols)
            {
                Logger.Debug("Added " + symbol.toString() + " to stock List");
                stockBox.Items.Add(symbol.toString());
            }
        }

        private void SelectStocks_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public ListView getList()
        {
            return StockList;
        }

        private void StockList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(!stockBox.Text.Equals("Select Stock") && !StockList.Items.ContainsKey(stockBox.Text))
            {
                if(StockList.Items.Count == 0 || StockList.Items.Count % 15 == 0)
                {
                    ColumnHeader c = new ColumnHeader("Stock");
                    c.Width = 150;
                    StockList.Columns.Add(c);
                }
                StockList.Items.Add(stockBox.Text, stockBox.Text, 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for(int x = 0; x < StockList.Items.Count; x++)
            {
                if (StockList.Items[x].Checked)
                {
                    StockList.Items.RemoveAt(x);
                    x--;
                }
            }
        }
    }
}
