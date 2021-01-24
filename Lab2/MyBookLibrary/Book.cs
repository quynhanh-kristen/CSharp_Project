using System;
using System.Collections.Generic;
using System.Text;

namespace MyBookLibrary
{
    public class Book
    {
        private string id;
        private string name;
        private string publisher;
        private decimal price;

        public Book(string id, string name, string publisher, decimal price)
        {
            this.id = id;
            this.name = name;
            this.publisher = publisher;
            this.price = price;
        }
        public string GetId()
        {
            return this.id;
        }
        public void SetId(string id)
        {
            this.id = id;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetPublisher()
        {
            return this.publisher;
        }

        public void SetPublisher(string publisher)
        {
            this.publisher = publisher;
        }

        public decimal GetPrice()
        {
            return this.price;
        }

        public void SetPrice(decimal price)
        {
            this.price = price;
        }

        public void showIforOfBook()
        {
            Console.WriteLine("{0} - {1} - {2} - {3}", id, name, publisher, price);
        }
        
    }
}
