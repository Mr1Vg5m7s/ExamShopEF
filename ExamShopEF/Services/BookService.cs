using System;
using System.Collections.Generic;
using System.Text;
using ExamShopEF.Models;

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

        var book = new Book
        {
            Title = title,
            Pages = int.Parse(pages),
            Year = int.Parse(year),
            Quantity = 1,
            CostPrice = int.Parse(costprice),
            SellPrice = int.Parse(sellprice),

            AvtorId = 1,
            GanrId = 1,
            PublisherId = 1
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
    public void SaleBooks(AppDbContext db)
    {
        
    }

    public void WrittenOffBooks(AppDbContext db)
    {

    }

    public void AddToPromotions(AppDbContext db)
    {
    }

    public void ReserveBooks(AppDbContext db)
    {
    }
}
