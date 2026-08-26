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
        protected string name;
        private int age;
        public abstract string Species { get; set; }

        public static int InstanceCount
        {
            get; private set;
        }



        public Animal(string name, int age)
        {
            this.name = name;
            this.age = age;
            InstanceCount++;
        }

        public abstract void Speak();

        public void Compare(Animal a)
        {
            if (age > a.age) Console.WriteLine($"{name} ist aelter als {a.name}.");
            else if (age < a.age) Console.WriteLine($"{name} ist juenger als {a.name}");
            else Console.WriteLine($"{name} und {a.name} sind gleich alt");
        }

    }

    class Dog : Animal
    {
        private string breed;
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

    class Cat : Animal
    {
        private string color;
        private string species;
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