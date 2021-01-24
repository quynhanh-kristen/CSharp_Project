using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Lab1
{
    class Item : IComparable<Item>
    {
        public Item (string code, string name, float price)
        {
            this.code = code;
            this.name = name;
            this.price = price;
        }

        private string code;

        public string GetCode()
        {
            return this.code;
        }
        public void SetCode(string code)
        {
            this.code = code;
        }

        public string name;
        
        public string GetName()
        {
            return this.code;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        float price;
        
        public float GetPrice()
        {
            return this.price;
        }
        public void SetPrice(float price)
        {
            this.price = price;
        }

        public void showItemInfor()
        {
            Console.WriteLine(code + "-" + name + "-" + price);
        }

        public int CompareTo([AllowNull] Item other)
        {
            if (this.price > other.price) return 1;
            else if (this.price < other.price) return 0;
            return 0;
        }
    }
}
