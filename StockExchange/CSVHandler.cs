using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange
{
    class CSVHandler
    {
        private String FileLocation { get; set; }
        public CSVHandler(String location)
        {
            FileLocation = location;
        }

        public List<Stock> fromCSV()
        {
            try
            {

                var reader = new StreamReader(File.OpenRead(FileLocation));
                List<Stock> p = new List<Stock>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(new char[] { ',' }, 2);
                    if(values[0].Length <= 6)
                    try
                    {
                        
                        Stock s = new Stock(values[0].PadRight(6), values[1]);
                        p.Add(s);
                    } catch (Exception e)
                    {
                            // Do nothing
                    }
                }
                 return p;
            }
            catch (Exception e)
            {
                    // Do Nothing
            }
        return null;
        }
    }
}
