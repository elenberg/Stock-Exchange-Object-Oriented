using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange
{
    public abstract class Subject
    {
        public Subject()
        {
            observers = new List<Observer>();
        }
        public abstract void Notify();
        public void Register(Observer o)
        {
            observers.Add(o);

        }
        public void UnRegister(Observer o)
        {
            observers.Remove(o);
        }
        public List<Observer> observers;
    }
}
