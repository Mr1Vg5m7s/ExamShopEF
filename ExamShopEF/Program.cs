using System.Diagnostics.Tracing;
using System.Runtime.InteropServices.Marshalling;
using System.Text.RegularExpressions;
using System.Collections;
using System.Text;
using System.Reflection.PortableExecutable;
using System;
using ExamShopEF.Services;

namespace ExamShopEF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;

            AppDbContext context = new AppDbContext();
            BookService bookServces = new BookService();
            ShopService shopServces = new ShopService();

            

            var service = new BookService();

            using (var db = new AppDbContext())
            {
                DataSeeder.Seed(db);
                var menu = new Menu();
                menu.Start(db);
            }


            /*
            bookServces.AddBook(context);
            shopServces.coutAllBooks(context);*/

        }
    }
}

