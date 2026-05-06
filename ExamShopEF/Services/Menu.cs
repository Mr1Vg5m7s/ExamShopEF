using System;
using System.Collections.Generic;
using System.Text;

namespace ExamShopEF.Services
{
    public class Menu
    {
        BookService bookService = new BookService();
        ShopService shopService = new ShopService();

        public void Start(AppDbContext db)
        {
            while (true)
            {

                Console.WriteLine("Велком");
                Console.WriteLine("1. Опции конкретной книги");
                Console.WriteLine("2. Опции магазина книг");
                Console.WriteLine("0. Выход");

                string i = Console.ReadLine();

                switch (i)
                {
                    case "1":
                        BookMenu(db);
                        break;

                    case "2":
                        ShopMenu(db);
                        break;

                    case "0":
                        return;
                }
            }
        }
        public void BookMenu(AppDbContext db)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("=== BOOK OPTIONS ===");
                Console.WriteLine("1. Добавить книгу");
                Console.WriteLine("2. Удалить книгу");
                Console.WriteLine("3. Поменятт книгу");
                Console.WriteLine("4. Продать книгу");
                Console.WriteLine("5. Списать книгу");
                Console.WriteLine("6. Добавить в акцию");
                Console.WriteLine("7. Зарезервировать книгу");
                Console.WriteLine("0. Назад");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        bookService.AddBook(db);
                        break;

                    case "2":
                        bookService.deletedBook(db);
                        break;

                    case "3":
                        bookService.ChangeBook(db);
                        break;

                    case "4":
                        bookService.SaleBooks(db);
                        break;

                    case "5":
                        bookService.WrittenOffBooks(db);
                        break;

                    case "6":
                        bookService.AddToPromotions(db);
                        break;

                    case "7":
                        bookService.ReserveBooks(db);
                        break;


                    case "0":
                        return;
                }

                Console.WriteLine("Нажмите любую клавишу...");
                Console.ReadKey();
            }
        }

        public void ShopMenu(AppDbContext db)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("=== SHOP OPTIONS ===");
                Console.WriteLine("1. Все книги");
                Console.WriteLine("2. Поиск книг");
                Console.WriteLine("3. Новинки");
                Console.WriteLine("4. Популярные книги");
                Console.WriteLine("5. Популярные авторы");
                Console.WriteLine("6. Популярные жанры");
                Console.WriteLine("0. Назад");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        shopService.coutAllBooks(db);
                        break;

                    case "2":
                        shopService.SearchBooks(db);
                        break;

                    case "3":
                        //shopService.ShowNewestBooks(db);
                        break;

                    case "4":
                        //shopService.ShowPopularBooks(db);
                        break;

                    case "5":
                        //shopService.ShowPopularAuthors(db);
                        break;

                    case "6":
                        //shopService.ShowPopularGanrs(db);
                        break;

                    case "0":
                        return;
                }

                Console.WriteLine("\nНажмите любую клавишу...");
                Console.ReadKey();
            }
        }
    }
}


