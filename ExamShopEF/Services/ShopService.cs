using System;
using System.Collections.Generic;
using System.Text;

namespace ExamShopEF.Services
{
    public class ShopService
    {
        public void SearchBooks(AppDbContext db)
        {
            Console.Write("Введите название книги для поиска: ");
            string title = Console.ReadLine();
            var books = db.Books.Where(b => b.Title.Contains(title)).ToList();
            if (books.Count > 0)
            {
                Console.WriteLine("Найдены следующие книги:");
                foreach (var book in books)
                {
                    Console.WriteLine($"ID: {book.Id}, Название: {book.Title}, Автор: {book.Avtor.Name} {book.Avtor.Surname}, Жанр: {book.Ganr.Name}, Издатель: {book.Publisher.Name}, Цена: {book.SellPrice}");
                }
            }
            else
            {
                Console.WriteLine("Книги не найдены");
            }
        }
    }
    ////////
    
}
