using System;
using System.Collections.Generic;

namespace MongoDBPoc
{
    class Invoice
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public Address Address { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public double Amount { get; set; }
        public List<int> SomeNumericData { get; set; }
        public List<string> SomeStringData { get; set; }
        public bool Sent { get; set; }

        public override string ToString()
        {
            return String.Format("Id: {0}\r\n" +
                                 "CustomerName: {1}\r\n" +
                                 "Street: {2}\r\n" +
                                 "Postalcode: {3}\r\n" +
                                 "City: {4}\r\n" +
                                 "Country: {5}\r\n" +
                                 "Date: {6}\r\n" +
                                 "Due date: {7}\r\n" +
                                 "Amount: {8}\r\n" +
                                 "Sent: {9}",
                Id, CustomerName, Address.StreetAddress, Address.PostalCode, Address.City, Address.Country, InvoiceDate,
                DueDate, Amount, Sent);
        }
    }

    class Address
    {
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
