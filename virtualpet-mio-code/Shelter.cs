
using template_csharp_virtual_pet;

namespace pet

{
    public class Shelter
    {
        public List<Pet> PetHouse
        {
            get; set;
        }

        public Shelter(List<Pet> aPetHouse)
        {
            PetHouse = aPetHouse;
        }



        public void AddPet()
        {
            Console.Clear();
            Console.WriteLine("Pick a type:");
            Console.WriteLine("1. Organic pet");
            Console.WriteLine("2. Robotic pet");
            string input1 = Console.ReadLine();



            Console.WriteLine("Please enter your pet's species (ex: Dog, cat, etc).\n");

            string species = Console.ReadLine();

            Console.WriteLine("What is your pet's name?");
            string name = Console.ReadLine();

            Console.WriteLine("What is your pet's color?");
            string color = Console.ReadLine();



            switch (input1)
            {

                case "1":
                    PetHouse.Add(new OrganicPet(name, species, color, 60, 60, 60));
                    break;

                case "2":
                    PetHouse.Add(new RoboticPet(name, species, color, 60, 60, 60));
                    break;
            }
        }

        public void Tick()
        {

            foreach (Pet pet in PetHouse)
            {
                pet.Hunger = pet.Hunger + 5;
                if (pet.Hunger > 60)
                {
                    pet.Hunger = 60;
                }
                pet.Boredom = pet.Boredom + 5;
                if (pet.Boredom > 60)
                {
                    pet.Boredom = 60;
                }
                pet.Health = pet.Health - 5;
                if (pet.Health < 10)
                {
                    pet.Health = 0;
                }
            }

        }
        public void RemovePet()
        {
            ListPets();
            Console.WriteLine("Which pet number would you like to remove (select the number)?");

            int petHouse = Convert.ToInt32(Console.ReadLine());
            if (PetHouse.Count >= petHouse)
            {
                PetHouse.RemoveAt(petHouse - 1);
                ListPets();
                Console.WriteLine("Press 'Enter' to return to main menu");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Pet number {petHouse} not found");
            }
            Console.ReadKey();
        }
        public void ListPets()
        {
            int listNumber = 1;
            Console.Clear();
            foreach (Pet pet in PetHouse)
            {
                if (pet is OrganicPet)
                {
                    Console.WriteLine($" {listNumber++}.{pet.Name}:  Species:{pet.Species};  Color:{pet.Color}; " +
                    $" Hunger:{pet.Hunger}; Boredom: {pet.Boredom};  Health: {pet.Health}");
                }
                if (pet is RoboticPet)
                {
                    Console.WriteLine($" {listNumber++}.{pet.Name}:  Species:{pet.Species};  Color:{pet.Color}; " +
                    $" Battery:{pet.Hunger}; Boredom: {pet.Boredom};  Armor: {pet.Health}");
                }
            }

        }

    }
}
