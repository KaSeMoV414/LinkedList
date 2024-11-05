using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linkedlist
{

    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    public class SinglyLinkedList<T>
    {
        private Node<T> head;

        public SinglyLinkedList()
        {
            head = null;
        }

        // إضافة عنصر في البداية
        public void AddFirst(T data)
        {
            Node<T> newNode = new Node<T>(data);
            newNode.Next = head;
            head = newNode;
        }

        // إضافة عنصر في النهاية
        public void AddLast(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        // إضافة عنصر في موقع محدد
        public void AddAtPosition(T data, int position)
        {
            if (position < 0) throw new ArgumentOutOfRangeException(nameof(position));

            Node<T> newNode = new Node<T>(data);
            if (position == 0)
            {
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                Node<T> current = head;
                for (int i = 0; i < position - 1; i++)
                {
                    if (current == null) throw new ArgumentOutOfRangeException(nameof(position));
                    current = current.Next;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
            }
        }

        // حذف عنصر من البداية
        public void RemoveFirst()
        {
            if (head == null) throw new InvalidOperationException("List is empty.");
            head = head.Next;
        }

        // حذف عنصر من النهاية
        public void RemoveLast()
        {
            if (head == null) throw new InvalidOperationException("List is empty.");
            if (head.Next == null)
            {
                head = null;
            }
            else
            {
                Node<T> current = head;
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }
                current.Next = null;
            }
        }

        // طباعة عناصر اللائحة
        public void PrintList()
        {
            Node<T> current = head;
            while (current != null)
            {
                Console.Write(current.Data + " -> ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }
    }

    public class Program
    {
        public static void Main()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            list.PrintList();
            list.AddFirst(10);
            list.PrintList();
            list.AddLast(20);
            list.PrintList();
            list.AddAtPosition(15, 1);
            list.PrintList();

            list.RemoveFirst();
            list.PrintList();

            list.RemoveLast();
            list.PrintList();
           
        }
    }

}
