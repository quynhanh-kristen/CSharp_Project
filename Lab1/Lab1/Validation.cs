using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab1
{
    class Validation
    {
        public bool checkDupplicate(string code, List<Item> itemLists)
        {
            foreach(Item i in itemLists)
            {
                if (i.GetCode().Equals(code))
                {
                    return true;
                }
            }
            return false;
        }

        public string CheckCode(List<Item> items)
        {
            bool error = true;
            String tmp = "";
            string patt = "^\\d{3}$";
            while (error)
            {
                error = false;
                tmp = Console.ReadLine();                
                if (!Regex.IsMatch(tmp.Trim(), patt))
                {
                    Console.Write("Invalid code, try again: ");
                    error = true;
                }
                if (new Validation().checkDupplicate(tmp, items))
                {                   
                    Console.Write("Dupplicated code, try again: ");
                    error = true;
                }
                if (!error)
                {
                    break;
                }
            }
            Console.WriteLine("code: {0}", tmp);
            return tmp;
        }


        public string CheckName()
        {
            bool error = true;
            string tmp = "";
            string patt = "^[\\sa-zA-Z]{2,30}$";

            while (error)
            {
                tmp = Console.ReadLine().Trim();
                if (Regex.IsMatch(tmp, patt))
                {
                    error = false;
                }
                if (error)
                {
                    Console.Write("Invalid name, try again: ");
                }
            }
            return tmp;
        }

        public float CheckPrice()
        {
            bool error = true;
            float tmp = 0;
            while (error)
            {
                try
                {
                    tmp = (float)Convert.ToDouble(Console.ReadLine());
                    error = false;                    
                }
                catch(Exception ex)
                {
                    ex.GetBaseException();
                    error = true;
                }
                finally
                {
                    if (error || tmp <= 0 || tmp > 1000000000000)
                    {
                        Console.Write("Invalid price, try again: ");
                        error = true;
                    }
                }
            }
            return tmp;
        }
    }
}
