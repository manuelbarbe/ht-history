using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Core.DataContainers
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

        public static readonly Currency SEK = new Currency("SEK", 1.0);
        public static readonly Currency Euro = new Currency("€", 10.0);
    }

    public class Money : IComparable<Money>
    {
        public double Amount { get; private set; }
        public Currency Currency { get; private set; }

        public Money(double amount, Currency currency = null)
        {
            this.Currency = currency ?? Currency.SEK;
            this.Amount = amount;
        }

        public override string ToString()
        {
            return String.Format("{0:0,0.} {1}", this.Amount, this.Currency.Name);
        }

        public int CompareTo(Money other)
        {
            return (int)((this.Currency.Factor * this.Amount) - (other.Currency.Factor * other.Amount)); 
        }
    }
}
