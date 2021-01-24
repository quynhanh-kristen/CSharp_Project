using System;
using System.Collections;
using System.Collections.Generic;
using Validation;

namespace MyBookLibrary
{
    public class BookManager
    {
        private List<Book> listBook;
        DataInput input;

        public BookManager()
        {
            listBook = new List<Book>();
            input = new DataInput();

        }
        public List<Book> GetListBook()
        {
            return this.listBook;
        }
        public Book AddBook()
        {
            bool check = true;
            Console.WriteLine("Add new book:");
            Console.Write("ID (XXX, X is digit): ");
            string id = "";
            while (check)
            {
                id = input.CheckId();
                check = false;
                if (FindBook(id) != null)
                {
                    Console.Write("Id had already existed, try again: ");
                    check = true;
                }
            }

            Console.Write("Name (at least 2 chacaters): ");
            string name = input.CheckString();

            Console.Write("Publisher (at least 2 characters): ");
            string publisher = input.CheckString();

            Console.Write("Price (no less than 0 and no more than 5 millions): ");
            decimal price = input.CheckPrice();

            Book book = new Book(id, name, publisher, price);
            return book;
        }
        public bool AddNewBook (Book book)
        {
            if(book != null)
            {
                listBook.Add(book);
                return true;
            }
            return false;
        }

        public Book FindBook(string id)
        {
            if (listBook.Count == 0)
                return null;
            foreach(Book book in listBook)
            {
                if (book.GetId().Equals(id))
                {
                    return book;
                }
            }
            return null;
        }

        public bool DeleteBook()
        {            
            Console.Write("Id of the book: ");
            string id = Console.ReadLine();

            Console.Write("Are you sure to want to delete the book with id {0}" +
                "(1: no; any key: yes): ", id);
            string option = Console.ReadLine();
            if (option.Equals("1"))
                return true;

            Book book = FindBook(id);
            if (book == null)
            {
                return false;
            }

            return listBook.Remove(book);
        }
        private bool DeleteBook(string id)
        {
            Book book = FindBook(id);
            if (book == null)
            {
                return false;
            }

            return listBook.Remove(book);
        }

        public void DisplayAllBooks()
        {
            foreach(Book book in listBook)
            {
                book.showIforOfBook();
            }
        }

        public bool UpdateBookInfor()
        {
            bool check = true;
            Console.Write("Id of the book: ");
            string id = Console.ReadLine();
            Book tmp = FindBook(id);
            if (tmp == null)
                return false;

            string tmpId = tmp.GetId();
            string saveId = tmpId;
            Console.WriteLine("ID: " + tmpId);
            if (UpdateFieldOption("ID"))
            {
                Console.Write("New ID: ");
                string newId = "";
                while (check)
                {
                    newId = input.CheckId();
                    check = false;
                    if (FindBook(newId) != null)
                    {
                        Console.Write("Id had already existed, try again: ");
                        check = true;
                    }
                }
                tmpId = newId;
            }

            string tmpName = tmp.GetName();
            Console.WriteLine("Name: {0}", tmpName);
            if (UpdateFieldOption("name"))
            {
                Console.Write("New name: ");
                string newName = input.CheckString();
                tmpName = newName;
            }

            string tmpPublisher = tmp.GetPublisher();
            Console.WriteLine("Publisher: {0}", tmpPublisher);
            if (UpdateFieldOption("publisher"))
            {
                Console.Write("New publisher: ");
                string newPls = input.CheckString();
                tmpPublisher = newPls;
            }

            decimal tmpPrice = tmp.GetPrice();
            Console.WriteLine("Price: {0}", tmpPrice);
            if (UpdateFieldOption("Price"))
            {
                Console.Write("New price: ");
                decimal newPrice = input.CheckPrice();
                tmpPrice = newPrice;
            }

            Book book = new Book(tmpId, tmpName, tmpPublisher, tmpPrice);
            if (DeleteBook(saveId))
            {
                return AddNewBook(book);
            }
            return false;
            
        }

        bool UpdateFieldOption(string field)
        {
            Console.Write("Do you want to change {0} (1: no; any key: yes): ", field);
            if (Console.ReadLine().Equals("1"))
            {
                return false;
            }
            return true;
        }
        
    }
}
