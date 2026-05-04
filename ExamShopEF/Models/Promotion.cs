using System;
using System.Collections.Generic;
using System.Text;

namespace ExamShopEF.Models
{
    public class Promotion
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DiscountPercent { get; set; }
    }
}
