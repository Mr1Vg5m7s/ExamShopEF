using ExamShopEF.Models;
using System;
using System.Collections.Generic;
using System.Text;

public static class DataSeeder
{
    public static void Seed(AppDbContext db)
    {
        var avtor = new Avtor
        {
            Name = "Stephen King",
            Surname = "sdasd"
        };

        var ganr = new Ganr
        {
            Name = "Horror"
        };

        var publisher = new Publisher
        {
            Name = "Me"
        };

        db.Avtors.Add(avtor);
        db.Ganrs.Add(ganr);
        db.Publishers.Add(publisher);

        db.SaveChanges();

        var book = new Book
        {
            Title = "IT",
            Pages = 500,
            Year = 1986,

            CostPrice = 100,
            SellPrice = 200,
            Quantity = 5,

            AvtorId = avtor.Id,
            GanrId = ganr.Id,
            PublisherId = publisher.Id
        };

        db.Books.Add(book);
        db.SaveChanges();
    }
}