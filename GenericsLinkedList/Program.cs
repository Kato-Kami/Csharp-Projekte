using System;
using System.Collections;
using System.Collections.Generic;


namespace Genericslinkedlist
{


    namespace PraktikumGenerics
    {
        // Generische LinkedList: T kann ein beliebiger vergleichbarer Datentyp sein 
        // IEnumerable<T> ermöglicht die Verwendung von foreach
        public class LinkedList<T> : IEnumerable<T> where T : IComparable<T>
        {
            // Speichert einen Wert und verweist auf den nächsten Knoten
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

            // head zeigt auf das erste, tail auf das letzte Element der Liste
            private LinkedListNode head;
            private LinkedListNode tail;

            public LinkedList()
            {
                head = null;
                tail = null;
            }

            // Neuen Knoten mit dem übergebenen Wert
            public void Add(T value)
            {
                var newNode = new LinkedListNode(value);
                if (head == null)
                {
                    // Falls die Liste leer ist: Neuer Knoten ist erstes und letztes Element
                    head = newNode;
                    tail = newNode;
                }
                else
                {
                    // Neues Element an das bisherige Ende anhängen
                    tail.Next = newNode;
                    tail = newNode;
                }
            }

            public T GetFirst()
            {
                // Fehler, wenn versucht wird, aus einer leeren Liste zu lesen
                if (head == null)
                {
                    throw new InvalidOperationException("Die Liste ist leer.");
                }

                // Wert des ersten Knotens wird gespeichert
                var firstValue = head.Value; 
                // Head wird auf den nächsten Knoten verschoben
                head = head.Next;

                if (head == null)
                {
                    tail = null;
                }

                return firstValue;
            }

            public void Print()
            {
                // foreach ist jetzt dank der Implementierung von IEnumerable verwendbar
                foreach (var item in this)
                {
                    Console.WriteLine(item);
                }
            }

            // Ermöglicht das Durchlaufen der LinkedList mit foreach
            public IEnumerator<T> GetEnumerator()
            {
                var current = head;
                while (current != null)
                {
                   // Gibt den aktuellen Wert zurück und pausiert die Methode
                    yield return current.Value;
                    current = current.Next;
                }
            }
            
            // Verwendet den bereits vorhandenen generischen Enumerator
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

            // Vergleich des Alters von Personen
            public int CompareTo(Person other)
            {
                if (other == null) return 1;
                return Alter.CompareTo(other.Alter);
            }

            // Festlegung, was beim Ausgeben eines Person-Objekts angezeigt wird
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
