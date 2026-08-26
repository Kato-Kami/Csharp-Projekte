using System;
using System.Collections;
using System.Collections.Generic;


namespace Genericslinkedlist
{


    namespace PraktikumGenerics
    {
        public class LinkedList<T> : IEnumerable<T> where T : IComparable<T>
        {
            private class LinkedListNode
            {
                public T Value { get; set; }
                public LinkedListNode Next { get; set; }

                public LinkedListNode(T value)
                {
                    Value = value;
                    Next = null;
                }
            }

            private LinkedListNode head;
            private LinkedListNode tail;

            public LinkedList()
            {
                head = null;
                tail = null;
            }

            public void Add(T value)
            {
                var newNode = new LinkedListNode(value);
                if (head == null)
                {
                    head = newNode;
                    tail = newNode;
                }
                else
                {
                    tail.Next = newNode;
                    tail = newNode;
                }
            }

            public T GetFirst()
            {
                if (head == null)
                {
                    throw new InvalidOperationException("Die Liste ist leer.");
                }

                var firstValue = head.Value;
                head = head.Next;

                if (head == null)
                {
                    tail = null;
                }

                return firstValue;
            }

            public void Print()
            {
                foreach (var item in this)
                {
                    Console.WriteLine(item);
                }
            }

            public IEnumerator<T> GetEnumerator()
            {
                var current = head;
                while (current != null)
                {
                    yield return current.Value;
                    current = current.Next;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        public class Person : IComparable<Person>
        {
            public string Name { get; set; }
            public int Alter { get; set; }

            public Person(string name, int alter)
            {
                Name = name;
                Alter = alter;
            }

            public int CompareTo(Person other)
            {
                if (other == null) return 1;
                return Alter.CompareTo(other.Alter);
            }

            public override string ToString()
            {
                return Name;
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                // LinkedList<int> Test
                LinkedList<int> list1 = new LinkedList<int>();
                list1.Add(1);
                list1.Add(2);
                list1.Add(3);
                list1.Print();
                Console.WriteLine($"Erstes Element entfernt: {list1.GetFirst()}");
                list1.Print();
                Console.WriteLine();

                // LinkedList<string> Test
                LinkedList<string> list2 = new LinkedList<string>();
                list2.Add("eins");
                list2.Add("zwei");
                list2.Add("drei");
                list2.Print();
                Console.WriteLine($"Erstes Element entfernt: {list2.GetFirst()}");
                list2.Print();
                Console.WriteLine();

                // LinkedList<Person> Test
                LinkedList<Person> list3 = new LinkedList<Person>();
                list3.Add(new Person("Max Mustermann", 30));
                list3.Add(new Person("Anna Müller", 25));
                list3.Add(new Person("John Smith", 35));
                list3.Print();
                Console.WriteLine($"Erstes Element entfernt: {list3.GetFirst()}");
                list3.Print();
                Console.WriteLine();

                // Vergleich von Personen
                Person p1 = new Person("Max Mustermann", 30);
                Person p2 = new Person("Anna Müller", 25);

                int compareResult = p1.CompareTo(p2);
                if (compareResult > 0)
                {
                    Console.WriteLine($"{p1.Name} ist älter als {p2.Name}");
                }
                else if (compareResult < 0)
                {
                    Console.WriteLine($"{p1.Name} ist jünger als {p2.Name}");
                }
                else
                {
                    Console.WriteLine($"{p1.Name} und {p2.Name} sind gleich alt");
                }
            }
        }
    }

}
