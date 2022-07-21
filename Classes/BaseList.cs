using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    internal class BaseList<T>
    {
        protected static List<T> list = new List<T>();


        public List<T> getList()
        {
            return list;
        }

        public void printList()
        {
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine($"{i}. {list[i].ToString()}");
        }
    }


}
