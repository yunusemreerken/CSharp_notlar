using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12253025HW1
{
    class Stack<T> where T : IComparable
    {
        T[] items;
        int top;
        public Stack(int size)
        {
            this.items = new T[size];
            this.top = -1;
        }
        public int size()
        {
            return items.Length;
        }
        public void clear()
        {
            this.top = -1;
        }
        public bool isEmpty()
        {
            //if (this.top == -1)
            //    return true;
            //return false;
            return this.top == -1;
        }

        public bool isFull()
        {
            return this.top == items.Length - 1;
        }
        public void push(T newItem)
        {
            if (isFull())
                Console.WriteLine("Stack dolu");
            else
            {
                this.items[++this.top] = newItem;
            }
        }
        public T pop()
        {
            if (isEmpty())
                throw new Exception("stack bos");
            top--;
            return this.items[this.top + 1];
        }

        public void display()
        {
            if (isEmpty())
                Console.WriteLine("stack bos");
            else
            {
                int temp = this.top;
                while (temp != -1)
                    Console.WriteLine(this.items[temp--]);
            }
        }




    }
}
