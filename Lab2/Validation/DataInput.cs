
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Validation
{
    public class DataInput
    {
        
        public string CheckId()
        {
            bool error = true;
            string tmp = "";
            string patt = "^\\d{3}$";
            while (error)
            {
                error = false;
                tmp = Console.ReadLine();
                if (!Regex.IsMatch(tmp.ToString(), patt))
                {
                    Console.Write("Invalid code, try again: ");
                    error = true;
                }
                if (!error)
                {
                    break;
                }
            }
            return tmp;
        }
        public string CheckString()
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
        public long CheckPrice()
        {
            bool error = true;
            long  tmp = 0;
            while (error)
            {
                try
                {
                    tmp = Convert.ToInt64(Console.ReadLine());
                    error = false;
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    error = true;
                }
                finally
                {
                    if (error || tmp <= 0 || tmp > 5000000)
                    {
                        Console.Write("Invalid price, try again: ");
                        error = true;
                    }
                }
            }
            return tmp;
        }

        public char CheckOption()
        {
            char option = '0';
            string patt = @"[1-5]";
            while (true)
            {
                try
                {
                    option = Convert.ToChar(Console.ReadLine());
                    if (!Regex.IsMatch(option.ToString(), patt)){
                        throw new Exception();
                    }
                        
                    return option;
                }
                catch (FormatException e)
                {
                    Console.Write("Option must be from 1-5, try again: ");
                }
                catch (Exception e)
                {                    
                    Console.Write("Option must be from 1-5, try again: ");

                }
            }
        }
    }
}
