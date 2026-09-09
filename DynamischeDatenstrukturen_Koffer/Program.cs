using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Koffer_Dynamische_Datenstrukturen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Luggage
    {
        public double Weight { get; private set; }
        public string Description { get; private set; }

        public Luggage(double weight, string description)
        {
            Weight = weight;
            Description = description;
        }
    }

    // Koffer mit einer maximalen Gewichtskapazität
    public class Suitcase
    {
        private double maxWeight;
        private List<Luggage> luggageItems;

        public Suitcase(double maxWeight)
        {
            this.maxWeight = maxWeight;

            // Leere Liste wird beim Erstellen des Koffers angelegt
            luggageItems = new List<Luggage>();
        }

        // Fügt einen Gegenstand hinzu, wenn das Maximalgewicht nicht überschritten wird
        public bool GepäckHinzufügen(Luggage luggage)
        {
            if (this.Weight + luggage.Weight <= maxWeight)
            {
                luggageItems.Add(luggage);
                return true;
            }
            return false;
        }

        // Entfernt einen Gepäckgegenstand anhand seiner Beschreibung
        public Luggage GepäckEntfernen(string description)
        {
            for (int i = 0; i < luggageItems.Count; i++)
            {
                if (luggageItems[i].Description == description)
                {
                    Luggage removedItem = luggageItems[i];
                    luggageItems.RemoveAt(i);
                    return removedItem;
                }
            }
            return null;
        }

        public double Weight
        {
            get
            {
                return luggageItems.Sum(item => item.Weight);
            }
        }

        public void GetAllLuggage()
        {
            foreach (var item in luggageItems)
            {
                Console.WriteLine(item.Description);
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Suitcase suitcase = new Suitcase(20);  // Der Koffer kann maximal 20 kg aufnehmen

            Luggage item1 = new Luggage(5, "Shirts");
            Luggage item2 = new Luggage(8, "Schuhe");
            Luggage item3 = new Luggage(23, "Bücher");
            Luggage item4 = new Luggage(10, "Laptop");

            // Einfügen der Gegenstände mit detaillierter Ausgabe
            Console.WriteLine($"Füge {item1.Description} hinzu: {suitcase.GepäckHinzufügen(item1)}");  // True
            Console.WriteLine($"Füge {item2.Description} hinzu: {suitcase.GepäckHinzufügen(item2)}");  // True
            Console.WriteLine($"Füge {item3.Description} hinzu: {suitcase.GepäckHinzufügen(item3)}");  // False, da Gesamtgewicht 20 kg überschreiten würde
            Console.WriteLine($"Füge {item4.Description} hinzu: {suitcase.GepäckHinzufügen(item4)}");  // False, da Gesamtgewicht 20 kg überschreiten würde

            // Aktuelles Gesamtgewicht des Koffers
            Console.WriteLine("Derzeitiges Gesamtgewicht: " + suitcase.Weight);  // 13

            // Entfernen eines Gegenstands
            Luggage removedItem = suitcase.GepäckEntfernen("Shoes");
            Console.WriteLine("Entfernter Gegenstand: " + (removedItem != null ? removedItem.Description : "None"));  // Shoes

            // Aktuelles Gesamtgewicht des Koffers nach dem Entfernen
            Console.WriteLine("Derzeitiges Gesamtgewicht: " + suitcase.Weight);  // 5

            // Alle Gegenstände im Koffer ausgeben
            Console.WriteLine("Derzeit befinden sich im Koffer:");
            suitcase.GetAllLuggage();  // Shirts
        }
    }
}

