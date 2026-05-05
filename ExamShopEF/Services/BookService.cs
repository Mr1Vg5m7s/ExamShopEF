using ExamShopEF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

public class BookService
{
    public void AddBook(AppDbContext db)
    {
        Console.Write("Название: ");
        string title = Console.ReadLine();
        Console.Write("Cтраницы: ");
        string pages = Console.ReadLine();
        Console.Write("Год: ");
        string year = Console.ReadLine();
        Console.Write("Собівартість: ");
        string costprice = Console.ReadLine();
        Console.Write("Цена: ");
        string sellprice = Console.ReadLine(); 

        Console.Write("Автор: ");
        string avtorName = Console.ReadLine();

        Console.Write("Жанр: ");
        string ganrName = Console.ReadLine();

        Console.WriteLine("Издательство: ");
        string publisherName = Console.ReadLine();


        ///
        var avtor = db.Avtors
            .FirstOrDefault(x => x.Name == avtorName);

        if (avtor == null)
        {
            avtor = new Avtor
            {
                Name = avtorName
            };

            db.Avtors.Add(avtor);
            db.SaveChanges();
        } 

        ///
        var ganr = db.Ganrs
            .FirstOrDefault(x => x.Name == ganrName);
        if (ganr == null)
        {
            ganr = new Ganr
            {
                Name = ganrName
            };
            db.Ganrs.Add(ganr);
            db.SaveChanges();
        }

        ///
        var publisher = db.Publishers
             .FirstOrDefault(x => x.Name == publisherName);
        if (publisher == null)
        {
            publisher = new Publisher
            {
                Name = publisherName
            };

            db.Publishers.Add(publisher);
            db.SaveChanges();
        }
        //
        var books = db.Books
        .Include(x => x.Avtor)
        .Include(x => x.Ganr)
        .Include(x => x.Publisher)
        .ToList();
        ///

        var book = new Book
        {
            Title = title,
            Pages = int.Parse(pages),
            Year = int.Parse(year),
            Quantity = 1,
            CostPrice = int.Parse(costprice),
            SellPrice = int.Parse(sellprice),

            AvtorId = avtor.Id,
            GanrId = ganr.Id,
            PublisherId = publisher.Id


        };

        db.Books.Add(book);
        db.SaveChanges();

        Console.WriteLine("Книга добавлена");
    }






    //////
    public void deletedBook(AppDbContext db)
    {
        Console.Write("Введите ID книги для удаления: ");
        int id = int.Parse(Console.ReadLine());

        var book = db.Books.Find(id);
        if (book != null)
        {
            db.Books.Remove(book);
            db.SaveChanges();
            Console.WriteLine("Книга удалена");
        }
        else
        {
            Console.WriteLine("Книга не найдена");
        }
    }

    //////////
    public void ChangeBook(AppDbContext db)
    {
        Console.Write("Введите ID книги для изменения: ");
        int id = int.Parse(Console.ReadLine());
        var book = db.Books.Find(id);
        if (book != null)
        {
            Console.Write("Название: ");
            book.Title = Console.ReadLine();
            Console.Write("Cтраницы: ");
            book.Pages = int.Parse(Console.ReadLine());
            Console.Write("Год: ");
            book.Year = int.Parse(Console.ReadLine());
            Console.Write("Собівартість: ");
            book.CostPrice = int.Parse(Console.ReadLine());
            Console.Write("Цена: ");
            book.SellPrice = int.Parse(Console.ReadLine());
            db.SaveChanges();
            Console.WriteLine("Книга изменена");
        }
        else
        {
            Console.WriteLine("Книга не найдена");
        }
    }
    ///////////////////////
    public void SaleBooks(AppDbContext db)
    {
        Console.Write("Id книги: ");
        int id = int.Parse(Console.ReadLine());
        var book = db.Books.FirstOrDefault(x => x.Id == id);


        if (book == null)
        {
            Console.WriteLine("Книга не найдена");
            return;
        }

        Console.Write("Количество: ");
        int count = int.Parse(Console.ReadLine());

        if (book.Quantity < count)
        {
            Console.WriteLine("Недостаточно книг");
            return;
        }

        book.Quantity -= count;

        var sale = new Sale
        {
            BookId = book.Id,
            Quantity = count,
            Date = DateTime.Now
        };

        db.Sales.Add(sale);
        db.SaveChanges();
        Console.WriteLine("Продажа выполнена");
    }

    ///////////////////////

    public void WrittenOffBooks(AppDbContext db)
    {

        Console.Write("Id книги: ");
        int id = int.Parse(Console.ReadLine());
        var book = db.Books.FirstOrDefault(x => x.Id == id);

        if (book == null)
        {
            Console.WriteLine("Книга не найдена");
            return;
        }

        Console.Write("Количество списания: ");
        int count = int.Parse(Console.ReadLine());

        if (book.Quantity < count)
        {
            Console.WriteLine("Недостаточно книг");
            return;
        }

        book.Quantity -= count;

        var writeOff = new WriteOff
        {
            BookId = book.Id,
            Quantity = count,
            Date = DateTime.Now
        };

        db.WriteOffs.Add(writeOff);
        db.SaveChanges();
        Console.WriteLine("Книга списана");
    }
    ///////////////////////

    public void AddToPromotions(AppDbContext db)
    {
        Console.Write("Название акции: ");
        string name = Console.ReadLine();

        Console.Write("Скидка (%): ");
        int discount = int.Parse(Console.ReadLine());

        var promotion = new Promotion
        {
            Name = name,
            DiscountPercent = discount
        };

        db.Promotions.Add(promotion);
        db.SaveChanges();
        Console.WriteLine("Акция добавлена");
    }

    ///////////////////////
    public void ReserveBooks(AppDbContext db)
    {
        Console.Write("Id книги: ");
        int id = int.Parse(Console.ReadLine());

        var book = db.Books.FirstOrDefault(x => x.Id == id);

        if (book == null)
        {
            Console.WriteLine("Книга не найдена");
            return;
        }

        Console.Write("Имя покупателя: ");
        string name = Console.ReadLine();

        Console.Write("Количество: ");
        int count = int.Parse(Console.ReadLine());

        var reservation = new Reservation
        {
            CustomerName = name,
            BookId = id,
            Quantity = count
        };

        db.Reservations.Add(reservation);
        db.SaveChanges();
        Console.WriteLine("Книга отложена");
    }
}
