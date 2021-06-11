using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeCycle2.Models
{
    public class exchanges
    {
        public int exchange_id { get; set; }
        public int item_id { get; set; }

        public string item_title { get; set; }
        public string email { get; set; }
        public int receiver_id { get; set; }
        public DateTime date_txn { get; set; }

        public List<exchanges> allexchanges { get; set; }
    }
}