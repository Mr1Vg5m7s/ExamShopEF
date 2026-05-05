using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ExamShopEF.Services
{
    public class ShopService
    {
        //моя
        public void coutAllBooks(AppDbContext db)
        {
            var books = db.Books.ToList();
            if (books.Count > 0)
            {
                Console.WriteLine("Список всех книг:");
                foreach (var book in books)
                {
                    Console.WriteLine($"ID: {book.Id}, Название: {book.Title}, Автор: {book.Avtor.Name} , Жанр: {book.Ganr.Name}, Издатель: {book.Publisher.Name}, Цена: {book.SellPrice}");
                }
            }
            else
            {
                Console.WriteLine("Книги не найдены");
            }
        }
        /// /////////////////////
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
                    Console.WriteLine($"ID: {book.Id}, Название: {book.Title}, Автор: {book.Avtor.Name} , Жанр: {book.Ganr.Name}, Издатель: {book.Publisher.Name}, Цена: {book.SellPrice}");
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
