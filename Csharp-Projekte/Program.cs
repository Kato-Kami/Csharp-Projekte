namespace Csharp_Projekte
{
    delegate void ValueChanged(TemperatureSensor a, double b);

    class TemperatureSensor
    {
        // Gibt den Sensor an, an welchem eine Änderung vorgenommen wurde.
        public int ID { get; set; }


        public TemperatureSensor(int id) { ID = id; }


        // Das Event ValueChanged basiert auf dem gleichnamigen Delegate. 
        // Bei veränderter Temperatur werden alle angemeldeten Methoden aufgerufen. 
        public event ValueChanged TemperatureChanged; // Event => Instanzvariable // auch ohne Schlüsselwort event möglich, da Event auch ein Delegate ist

        private double temperature;

        public double Temperature
        {
            get { return temperature; }


            set
            {
                if (TemperatureChanged != null)
                {
                    TemperatureChanged(this, value); // value enthält automatisch den neuen Wert, der der Property zugewiesen werden soll, d. h. value = 23.7
                    temperature = value;
                    /*if (TemperatureChanged != null) TemperatureChanged(ID, value);*/ // Event auslösen

                }
            }
        }

        class Observer
        {
            // Ein Observer besitzt eine ID, damit in der Ausgabe ersichtlich wird, welcher Observer benachrichtigt wurde.
            public int ID { get; set; }

            public Observer(int id) { ID = id; }

            //public Observer(TemperatureSensor b)
            //{
            //    b.TemperatureChanged += ObserverMethod; // Hinzufügen der Methode zum Event
            //}


            // Besitzt die gleiche Signatur wie des Delegates ValueChanged,
            // daher kann diese Mehtode beim Event TemperatureChanged registriert werden.
            public void ObserverMethod(TemperatureSensor t, double newValue)
            {
                Console.WriteLine($"Sensor: {t.ID}, Observer{ID}, neuer Wert: {newValue}");
            }
        }

        class Program
        {
            static void Main()
            {
                TemperatureSensor b = new TemperatureSensor(11) { Temperature = 12.3 }; // Erzeugen des Broadcasters
                Observer o1 = new Observer(42);

                // Die Methode ObserverMethod von o1 wird
                // beim Event TemperatureChanged angemeldet.
                //
                // Wichtig: OHNE ()
                //
                // Wir führen die Methode hier nicht aus,
                // sondern speichern sie als Event-Handler.
                //
                // Wenn das Event später ausgelöst wird,
                // ruft C# diese Methode automatisch auf.
                b.TemperatureChanged += o1.ObserverMethod;
                b.Temperature = 23.7; // Alter Wert: 12,3 & neuer Wert: 23,7

                Observer o2 = new Observer(27);
                b.TemperatureChanged += o2.ObserverMethod;
                b.Temperature = 22.5;
                // Ausgabe: Alter Wert: 23,7 & neuer Wert: 22.5
                // Alter Wert: 23,7 & neuer Wert: 22.5
                TemperatureSensor b1 = new TemperatureSensor(22) { Temperature = 32.3 };
                b1.TemperatureChanged += o1.ObserverMethod;
                b1.Temperature = 21;
            }

        }
    }
}
