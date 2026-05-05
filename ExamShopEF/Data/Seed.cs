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
            Name = "I"
        };

        var ganr = new Ganr
        {
            Name = "Horror/Romantic/Fantasy"
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
            Id = 9,
            Title = "You.Me.Shadow",
            Pages = 540,
            Year = 2026,

            CostPrice = 8,
            SellPrice = 8,
            Quantity = 1,


            AvtorId = avtor.Id,
            GanrId = ganr.Id,
            PublisherId = publisher.Id
        };

        db.Books.Add(book);
        db.SaveChanges();
    }
}