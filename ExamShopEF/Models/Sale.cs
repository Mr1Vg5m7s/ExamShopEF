using System;
using System.Collections.Generic;
using System.Text;

namespace ExamShopEF.Models
{
    public class Sale
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int Quantity { get; set; }

        public DateTime Date { get; set; }
    }
}
