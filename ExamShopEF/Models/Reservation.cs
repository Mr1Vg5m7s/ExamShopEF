using System;
using System.Collections.Generic;
using System.Text;

namespace ExamShopEF.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int Quantity { get; set; }
    }
}
