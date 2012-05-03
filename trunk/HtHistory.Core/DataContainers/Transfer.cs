﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Core.DataContainers
{
    public class Transfer : HtObject
    {
        public DateTime Date { get; private set; }
        public Player Player { get; private set; }
        public Team Buyer { get; private set; }
        public Team Seller { get; private set; }
        public Money Price { get; private set; }

        public Transfer(uint id, DateTime date, Player player, Team buyer, Team seller, Money price) : base(id)
        {
            if (player == null || buyer == null || seller == null)
            {
                throw new ArgumentNullException("player || buyer || seller");
            }

            Date = date;
            Player = player;
            Buyer = buyer;
            Seller = seller;
            Price = price;
        }
    }
}
