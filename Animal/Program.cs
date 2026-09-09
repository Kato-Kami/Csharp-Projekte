namespace Animal
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Animal a = new Animal("Tier", 5);*/ // Compilerfehler
            Animal dog = new Dog("Bello", 10, "Labrador");
            dog.Speak(); // Bello sagt Wuff!
            Animal cat = new Cat("Garfield", 15, "schwarz");
            cat.Speak(); // Garfield sagt Miau!
            Console.WriteLine(Animal.InstanceCount); // 2
            cat.Compare(dog); // Garfield ist älter als Bello
            dog.Compare(dog);

        }
    }

    abstract class Animal
    {
        // Lässt abgeleitete Klassen wie Dog und Cat auf das Datum zugreifen
        protected string name;
        private int age;

        // Jede konkrete Tierklasse muss eine Species-Eigenschaft implementieren 
        public abstract string Species { get; set; }

        // Gibt die Anzahl der erzeugten Tiere wieder
        public static int InstanceCount
        {
            get; private set; //private set: Wert kann nur in dieser Klasse verändert werden
        }



        public Animal(string name, int age)
        {
            this.name = name;
            this.age = age;
            InstanceCount++;
        }

        public abstract void Speak();

        // Altersvergleich unter den erzeugten Tieren
        public void Compare(Animal a)
        {
            if (age > a.age) Console.WriteLine($"{name} ist aelter als {a.name}.");
            else if (age < a.age) Console.WriteLine($"{name} ist juenger als {a.name}");
            else Console.WriteLine($"{name} und {a.name} sind gleich alt");
        }

    }

    // Ein Hund besitzt alle vererbbaren Eigenschaften von einem Tier (Animal)
    class Dog : Animal
    {
        private string breed;

        // Implementierung der abstrakten Species-Eigenschaft
        public override string Species { get; set; }

        public Dog(string name, int age, string breed) : base(name, age)
        {
            this.breed = breed;
        }


        public override void Speak()
        {
            Console.WriteLine($"{name} sagt Wuff.");
        }







    }

    // Eine Katze besitzt alle vererbbaren Eigenschaften von einem Tier (Animal)
    class Cat : Animal
    {
        private string color;
        private string species;
        
        // Implementierung der abstrakten Species-Eigenschaft
        public override string Species
        {
            get { return species; }
            set { species = value; }
        }

        public Cat(string name, int age, string color) : base(name, age)
        {
            this.color = color;

        }
        
        public override void Speak()
        {
            Console.WriteLine($"{name} sagt Miau");
        }
    }
}
