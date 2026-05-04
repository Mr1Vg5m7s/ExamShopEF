using System;
using System.Collections.Generic;
using System.Text;
using ExamShopEF.Models;

namespace ExamShopEF.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int Pages { get; set; }
        public int Year { get; set; }

        public decimal CostPrice { get; set; }
        public decimal SellPrice { get; set; }

        public int Quantity { get; set; }

        //////////////////////////////////////////////
        public int AvtorId { get; set; }
        public Avtor Avtor { get; set; }

        public int GanrId { get; set; }
        public Ganr Ganr { get; set; }

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
    }
}
