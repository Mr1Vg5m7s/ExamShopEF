using System;
using System.Collections.Generic;
using System.Text;

namespace ExamShopEF.Models
{
    public class Avtor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<Book> Books { get; set; }
    }
}
