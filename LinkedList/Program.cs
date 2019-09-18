using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp1
{
    /*interface IClonable
    {
        public void  
    }*/
    interface IInstructions<T>
    {
        void AddValue(T value);
        void AddValue(Node<T> NewNode);
        bool Remove(T value);
        bool Contains(T data);


    }
    class Node<T>
    {
        public T value { get; set; }
        public Node<T> previous { get; set; }
        public Node<T> next { get; set; }

        public Node(T v)
        {
            value = v;
        }
    }
    
    class List<T> : IEnumerable<T>, IInstructions<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int counter;
        public int Length { get { return counter; } }
        public bool IsEmpty { get { return counter == 0; } }

        public void AddValue(T value)
        {
            Node<T> node = new Node<T>(value);

            if(head == null)
            {
                head = node;
            }
            else
            {
                tail.next = node;
                tail.previous = tail;
            }
            tail = node;
            counter++;
        }
        public void AddValue(Node<T> NewNode)
        {
            if (head == null)
            {
                head = NewNode;
            }
            else
            {
                tail.next = NewNode;
                tail.previous = tail;
            }
            tail = NewNode;
            counter++;
        }

        public void AddFirst(T value)
        {
            Node<T> node = new Node<T>(value);
            Node<T> temp = head;
            node.next = temp;
            head = node;

            if(counter == 0) tail = head;
            else temp.previous = node;

            counter++;
        }

        public void AddFirst(Node<T> node)
        {
            Node<T> temp = head;
            node.next = temp;
            head = node;

            if (counter == 0) tail = head;
            else temp.previous = node;

            counter++;
        }

        public bool Remove(T value)
        {
            Node<T> current = head;

            while(current != null)
            {
                if (current.value.Equals(value))
                {
                    break;
                }
                current = current.next;
            }
            if (current != null)
            {
                if (current.next != null)
                {
                    current.next.previous = current.previous;
                }
                else
                {
                    tail = current.previous;
                }

                if (current.previous != null)
                {
                    current.previous.next = current.next;
                }
                else
                {
                    head = current.next;
                }
                counter--;
                return true;
            }
            return false;
        }
        
        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.value.Equals(data))
                    return true;
                current = current.next;
            }
            return false;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
 
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.value;
                current = current.next;
            }
        }
        public IEnumerable<T> BackEnumerator()
        {
            Node<T> current = tail;
            while (current != null)
            {
                yield return current.value;
                current = current.previous;
            }
        }
    }
    
    class Program
    {
        static void SetInformation<T>(List<T> l, T info)
        {
            l.AddValue(info);
        }

        static void GetInformation<T>(List<T>l)
        {
            foreach (var i in l)
            {
                Console.Out.WriteLine(i);
            }
        }
        static void GetInformationReverse<T>(List<T>l)
        {
            foreach (var j in l.BackEnumerator())
            {
                Console.Out.WriteLine(j);
            }
        }

        static int BinarySearch(int[] arr, int key)
        {
            int right = arr.Length;
            int left = 0;
            int middle;

            while (left <= right)
            {
                middle = (left + right) / 2;
                if (arr[middle] == key) return middle;
                if (arr[middle] > key) middle--;
                if (arr[middle] < key) middle++;
            }
            
            return -1;
        }
        static void Main(string[] args)
        {
/*          List<String> InformationList = new List<String>();
            SetInformation(InformationList, "vova");
            SetInformation(InformationList, "vova");
            SetInformation(InformationList, "denis");
            GetInformation(InformationList);
*/

            int[] arr = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9};
            Console.Out.WriteLine(BinarySearch(arr, 4));
        }
    }
}
