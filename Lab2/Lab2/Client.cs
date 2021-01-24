using System;
using MyBookLibrary;
using Validation;
//Quỳnh Anh
namespace Lab2
{
    //char: khi nhập chuỗi có độ dài > 1, throw Exception
    class Client
    {
        static void Main(string[] args)
        {
            BookManager lib = new BookManager();
            char option = '1';

            while(option != '5')
            {
                Console.WriteLine("Wellcome to my library");
                Console.WriteLine("1. Add new book");
                Console.WriteLine("2.Update a book");
                Console.WriteLine("3.Delete a book");
                Console.WriteLine("4.List all book");
                Console.WriteLine("5.Quit");
                Console.Write("Choose an option (from 1-5): ");
                option = new DataInput().CheckOption();

                switch (option)
                {
                    case '1':
                        if (lib.AddNewBook(lib.AddBook()))
                        {
                            Console.WriteLine("Saved!!!");
                        }
                        else
                            Console.WriteLine("Can not add to the book!!!");
                        break;
                    case '2':
                        if (lib.UpdateBookInfor())
                        {
                            Console.WriteLine("Done!!!");
                        }
                        else
                            Console.WriteLine("Can not update the book, double-check book's id " +
                                "or amount of book in the list");
                        break;
                    case '3':                        
                        bool result4 = lib.DeleteBook();
                        if (result4)
                            Console.WriteLine("Done!!!");
                        else
                            Console.WriteLine("Can not delete the requested book, double-check book's id " +
                                "or amount of book in the list");
                        break;
                    case '4':
                        if (lib.GetListBook().Count == 0)
                        {
                            Console.WriteLine("No book to show");
                            break;
                        }
                       
                        lib.DisplayAllBooks();
                        break;
                    case '5':
                        break;
                }



            }
            
        }
    }
}
