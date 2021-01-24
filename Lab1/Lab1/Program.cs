using System;
using System.ServiceProcess;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            ItemManagement im = new ItemManagement();
            

            string option = "1";            

            while (!option.Equals("6"))
            {
                Console.WriteLine("{----------------Item Management----------------}");
                Console.WriteLine("{----------------1. Add new item----------------}");
                Console.WriteLine("{---------2. Update the price of item-----------}");
                Console.WriteLine("{----------------3. Delete item-----------------}");
                Console.WriteLine("{----4. Search for a item by the item's code----}");
                Console.WriteLine("{------------5. Display items (Asc)-------------}");
                Console.WriteLine("{-------------------6. Quit---------------------}");
                Console.Write("Your option (from 1-6): ");
                option = Console.ReadLine();  

                switch (option) {                 
                    case "1":
                        int again1 = 1;
                        do
                        {
                            if (im.AddItem(im.AddInforItem()))
                            {
                                Console.WriteLine("Added!!!");
                            }
                            else
                            {
                                Console.WriteLine("Can not add item into list!!!");

                            }
                            Console.Write("DO you want to add more items(1: yes; any character: no): ");
                            again1 = Convert.ToInt32(Console.ReadLine());

                        } while (again1 == 1);
                        break;
                    case "2":
                        int again2 = 1;
                        do
                        {
                            if (im.UpdatePriceOfitem())
                            {
                                Console.WriteLine("Done!!!");
                            }
                            else
                            {
                                Console.WriteLine("Can not udate price of item, list empty or your code can not be found!!!");

                            }
                            Console.Write("DO you want to continute update function (1: yes; any character: no): ");
                            again2 = Convert.ToInt32(Console.ReadLine());

                        } while (again2 == 1);
                        
                        break;
                    case "3":
                        int again3 = 1;
                        do
                        {
                            if (im.DeleteItem())
                            {
                                Console.WriteLine("Done!!!");
                            }
                            else
                            {
                                Console.WriteLine("Can not delete item, list empty or your code can not be found!!!");

                            }
                            Console.Write("DO you want to continute delete function (1: yes; any character: no): ");
                            again3 = Convert.ToInt32(Console.ReadLine());

                        } while (again3 == 1);
                        break;
                    case "4":
                        Item item = im.SearchItem();
                        if(item != null)
                        {
                            item.showItemInfor();
                        }
                        else
                        {
                            Console.WriteLine("No result");
                        }
                        break;
                    case "5":
                        im.DisplayItem();
                        break;
                    case "6":
                        option = "6";
                        break;
                }
            }
        }
    }

}
