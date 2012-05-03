using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Core.DataContainers
{
    public struct Money : IComparable<Money>
    {
        public class Currency
        {
            public string Name { get; private set; }
            public double Factor { get; private set; }
            
            public Currency(string name, double factor)
            {
                Name = name ?? string.Empty;
                Factor = factor;
            }

            public static readonly Currency SEK     = new Currency("SEK", 1.0);
            public static readonly Currency Euro    = new Currency("€", 10.0);
        }


        private double _amount;
        private Currency _currency;

        public Money(double amount, Currency currency = null)
        {
            _currency = currency ?? Currency.SEK;
            _amount = amount;
        }

        public override string ToString()
        {
            return String.Format("{0:1.0} {1}", _amount, _currency.Name);
        }

        public int CompareTo(Money other)
        {
            return (int)((_currency.Factor * _amount) - (other._currency.Factor * other._amount)); 
        }
    }
}
