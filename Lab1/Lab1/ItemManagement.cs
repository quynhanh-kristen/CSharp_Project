using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class ItemManagement
    {
        List<Item> listItems;
        Validation valid;
        
        public ItemManagement()
        {
            listItems = new List<Item>();
            valid = new Validation();
        }

        #region Get & Set
        public List<Item> getListItems() => listItems;

        public Validation GetValidation() => valid;
        #endregion

        #region CURD

        #region Add Item 
        public Item AddInforItem()
        {
            

            Console.WriteLine("1. Please fill information: ");
            Console.Write("Code (XXXX, X is digit): ");
            string code = valid.CheckCode(this.getListItems());

            Console.Write("\nName (not include digit): ");
            string name = valid.CheckName();

            Console.Write("\nPrice (not inlcude characters and larger than 0 VND): ");
            float price = valid.CheckPrice();

            Item item = new Item(code, name, price);
            return item;
        }
        public bool AddItem(Item i)
        {
            if (i != null)
            {
                listItems.Add(i);
                return true;
            }
            return false;
        }
        #endregion
        public void DisplayItem()
        {
            
            if(listItems.Count != 0)
            {
                listItems.Sort();
                foreach (Item item in listItems)
                {
                    item.showItemInfor();
                }
            }else if(listItems.Count == 0)
            {
                Console.WriteLine("No items to display!!!");
            }
        }

        public bool UpdatePriceOfitem()
        {
            Console.Write("Code: ");
            string code = Console.ReadLine().Trim();
            
            if(!new Validation().checkDupplicate(code, listItems))
            {
                return false;
            }

            Console.Write("\nNew price (must larger than 0 VND): ");
            float price = valid.CheckPrice();
            foreach (Item i in listItems)
            {
                if (i.GetCode().Equals(code)){
                    i.SetPrice(price);
                    break;
                }
            }
            return true;
        }
        public bool DeleteItem()
        {
            Console.Write("Code: ");
            string code = Console.ReadLine();
            if(listItems.Count == 0)
            {
                return false;
            }
            if (!new Validation().checkDupplicate(code, listItems))
            {
                return false;
            }
            foreach (Item i in listItems)
            {
                if (i.GetCode().Equals(code))
                {
                    return listItems.Remove(i);
                }
            }
            return true;
        }

        public Item SearchItem()
        {
            Console.Write("Code: ");
            string code = Console.ReadLine();
            foreach (Item i in listItems)
            {
                if (i.GetCode().Equals(code))
                {
                    return i;
                }
            }
            return null;
        }

        #endregion

    }
}
