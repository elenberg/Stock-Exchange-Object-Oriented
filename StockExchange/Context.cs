using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange
{
    public abstract class Context
    {
        public abstract Object getContents();
    }
    public class StockContext : Context
    {
        public Stock s { get; set; }
        public StockContext(Stock s)
        {
            this.s = s;
        }
        public override Object getContents()
        {
            return s;
        }

    }
    public class PortfolioContext : Context
    {
        private List<Dictionary<string, string>> list;

        public PortfolioContext(List<Dictionary<string, string>> list)
        {
            this.list = list;
        }
        
        public override Object getContents()
        {
            return list;
        }
    }

}
