using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshop.Core.Entity
{
    public class Book
    {
        public int id { get; set; }

        public string name { get; set; }

        public string language { get; set; }

        public string author { get; set; }

        public string publisher { get; set; }

        public DateTime publishingDate { get; set; }

        public string genre { get; set; }

        public double price { get; set; }
    }
}
