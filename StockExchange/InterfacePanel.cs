using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace StockExchange
{
    public abstract class InterfacePanel : Observer
    {
        public abstract void Unsubscribe();
        public Panel p { get; set; }
        public bool toUpdate { get; set; }
        public InterfacePanel(Panel p)
        {
            this.p = p;
            toUpdate = false;
        }
        public abstract void updatePanels();
        public abstract Control[] getControls();
    }
    public class StockPricePanel : InterfacePanel
    {
        private Chart chart1 { get; set; }
        private Stock stock { get; set; }
        private Series series1 { get; set; }
        
        public StockPricePanel(Stock s, Panel p) : base(p)
        {
            stock = s;
            chart1 = new Chart();
            chart1.Series.Clear();
            chart1.Titles.Add(s.Symbol);
            
            series1 = new Series
            {
                Name = s.Symbol + "Price",
                ChartType = SeriesChartType.Line
            };
            chart1.Series.Add(series1);
            ChartArea chartArea1 = new ChartArea();
            chart1.ChartAreas.Add(chartArea1);
            chart1.Dock = DockStyle.Top;
            
            chart1.Invalidate();
        }
        public override void Update(Context c)
        {
            stock = (Stock)c.getContents();
            toUpdate = true;
        }
        public override void updatePanels()
        {

            if (series1.Points.Count >= 60)
            {
                series1.Points.RemoveAt(0);
            }
            series1.Points.AddY(stock.CurrentPrice);
            toUpdate = false;

        }
        public override void Unsubscribe()
        {
            stock.UnRegister(this);
        }

        public override Control[] getControls()
        {
            return new Control[] { chart1 };
        }
    }
    public class StockVolumePanel : InterfacePanel
    {
        private Chart chart1 { get; set; }
        private Stock stock { get; set; }
        Series series1 { get; set; }

        public StockVolumePanel(Stock s, Panel p) : base(p)
        {
            stock = s;
            chart1 = new Chart();
            chart1.Series.Clear();
            chart1.Titles.Add(s.Symbol);

            series1 = new Series
            {
                Name = s.Symbol + " Volume",
                ChartType = SeriesChartType.StackedBar
            };
            chart1.Series.Add(series1);
            ChartArea chartArea1 = new ChartArea();
            chart1.ChartAreas.Add(chartArea1);
            chart1.Dock = DockStyle.Top;

            chart1.Invalidate();
        }
        public override void Update(Context c)
        {
            stock = (Stock)c.getContents();
            toUpdate = true;

        }
        public override void updatePanels()
        {
            if(series1.Points.Count >= 60)
            {
                series1.Points.RemoveAt(0);
            }
            series1.Points.AddY(stock.CurrentVolume);
            toUpdate = false;
        }

        public override void Unsubscribe()
        {
            stock.UnRegister(this);
        }

        public override Control[] getControls()
        {
            return new Control[] { chart1 };
        }
    }
    public class PortFolioPanel : InterfacePanel
    {
        public DataTable table { get; set; }
        public Portfolio portfolio { get; set; }
        public List<Dictionary<String, String>> items { get; set; }
        public DataGridView dataGrid { get; set; }

        public PortFolioPanel(Portfolio p, bool open, Panel pa) : base(pa)
        {
            // Create the datatable and datagrid. This part is messy. Not sure how I could clean it 
            // up at all. Since I need to create the columns individually.
            dataGrid = new DataGridView();
            portfolio = p;
            portfolio.Register(this);
            items = portfolio.updateMessages();
            table = new DataTable();
            string[] listofstrings;
            if (open)
            {
                listofstrings = new string[] { "Symbol", "Current", "BidPrice", "AskPrice", "OpenPrice", "ClosePrice" };
            }
            else
            {
                listofstrings = new string[] { "Symbol", "Current", "BidPrice", "AskPrice" };
            }

            DataColumn dtColumn;
            foreach (String item in listofstrings)
            {
                dtColumn = new DataColumn();
                dtColumn.ColumnName = item;
                dtColumn.Caption = item;
                table.Columns.Add(dtColumn);

            }
            table.TableName = "Portfolio";
            table.Rows.Clear();

            foreach(Dictionary<String, String> item in items)
            {
                DataRow d = table.NewRow();
                table.Rows.Add(d);

                foreach (KeyValuePair<string, string> pair in item)
                {
                    if(table.Columns.Contains(pair.Key))
                    d[pair.Key] = pair.Value;
                }
            }
            dataGrid.DataSource = table;
            dataGrid.Dock = DockStyle.Fill;
            dataGrid.RowHeadersVisible = false;
            dataGrid.ReadOnly = true;
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid.Invalidate();
        }

        public override void Update(Context c)
        {
            items = (List<Dictionary<String, String>>)c.getContents();
            toUpdate = true;
            
        }

        public override void updatePanels()
        {
            table.Rows.Clear();
            foreach (Dictionary<String, String> item in items)
            {
                DataRow d = table.NewRow();
                table.Rows.Add(d);

                foreach (KeyValuePair<string, string> pair in item)
                {
                    if(table.Columns.Contains(pair.Key))
                    d[pair.Key] = pair.Value;
                }
            }
            dataGrid.DataSource = table;
            toUpdate = false;
        }

        public override void Unsubscribe()
        {
            portfolio.UnRegister(this);
        }

        public override Control[] getControls()
        {
            return new Control[] { dataGrid };
        }
    }
    public abstract class InterfaceDecorator : InterfacePanel
    {
        protected InterfacePanel interPanel { get; set; }
        public InterfaceDecorator(Panel p, InterfacePanel interPanel) : base(p)
        {
            this.interPanel = interPanel;
        }
        public override Control[] getControls()
        {
            Control[] current = interPanel.getControls();

            return current;
        }
    }
    public class LabelOpenClosePriceDecorator : InterfaceDecorator
    {
        private int OpenPrice { get; set; }
        private int ClosePrice { get; set; }
        private Label label { get; set; }
        public LabelOpenClosePriceDecorator(Panel p, InterfacePanel interPanel, int OpenPrice, int ClosePrice) : base(p, interPanel)
        {
            this.OpenPrice = OpenPrice;
            this.ClosePrice = ClosePrice;
            label = new Label();
            label.Text = "Open: " + OpenPrice + " Close: " + ClosePrice;
            label.Visible = true;
            label.Width = 120;
            label.Font = new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.Serif), 7);
        }

        public override Control[] getControls()
        {
            Control[] current = base.getControls();
            Control[] new_controls = new Control[current.Length + 1];
            current.CopyTo(new_controls, 0);
            new_controls[current.Length] = label;
            return new_controls;
        }
        public override void Update(Context c)
        {
            interPanel.Update(c);
            toUpdate = true;
        }
        public override void updatePanels()
        {
            interPanel.updatePanels();
            toUpdate = false;
        }

        public override void Unsubscribe()
        {
            interPanel.Unsubscribe();
        }
    }
}
