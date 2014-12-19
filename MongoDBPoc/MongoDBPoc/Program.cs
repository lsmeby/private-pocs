using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace MongoDBPoc
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MongoClient("mongodb://localhost");
            var server = client.GetServer();
            var database = server.GetDatabase("test");
            var collection = database.GetCollection<Invoice>("invoices");

            var stopwatch = new Stopwatch();
            
            Console.WriteLine("The database contains {0} invoices. Going through them all...", collection.AsQueryable().Count());
            stopwatch.Start();
            Console.WriteLine("Found {0} sent invoices.", collection.AsQueryable().Count(i => i.Sent));
            stopwatch.Stop();
            Console.WriteLine("The operation took {0} milliseconds.", stopwatch.ElapsedMilliseconds);

            Console.WriteLine("Fetching invoice 18378...");
            stopwatch.Restart();
            var invoice = collection.FindOne(Query<Invoice>.EQ(i => i.Id, 18378));
            stopwatch.Stop();
            Console.WriteLine("Fetched invoice in {0} milliseconds.", stopwatch.ElapsedMilliseconds);
            Console.WriteLine(invoice.ToString());

            Console.Read();
        }

        static void InsertInvoice(MongoCollection<Invoice> collection, int nextId, bool isSent)
        {
            collection.Insert(new Invoice
            {
                Id = nextId,
                CustomerName = "Ole Olsson",
                Address = new Address
                {
                    StreetAddress = "Gateveien 2",
                    PostalCode = "0055",
                    City = "Oslo",
                    Country = "Norge"
                },
                Amount = 1000000.5,
                InvoiceDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(14),
                SomeNumericData = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9},
                SomeStringData = new List<string> {"A", "B", "C", "D", "E", "F", "G"},
                Sent = isSent
            });
        }
    }
}
