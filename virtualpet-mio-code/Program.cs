using pet;
using template_csharp_virtual_pet;
//List for PetHouse
List<Pet> petHouse = new List<Pet>();
List<Pet> selectedPets = new List<Pet>();
//Shelter class referencing myShelter which is PetHouse
Shelter petShelter = new Shelter(petHouse);
bool keepThinking = true;
string input;
petShelter.AddPet();



while (keepThinking)
{
    Console.Clear();
    Console.WriteLine("*****  Welcome to Virtual Pet MIO  *****");
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("               MAIN MENU                ");
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Select an option: ");
    Console.WriteLine("\n1. Create a new pet");
    Console.WriteLine("2. Select a pet");
    Console.WriteLine("3. Feed your pet");
    Console.WriteLine("4. See doctor");
    Console.WriteLine("5. Play with pet(s)");
    Console.WriteLine("6. Show all pets");
    Console.WriteLine("7. Remove your pet");

    Console.WriteLine("\nPress Q to quit");
    
    foreach (Pet pet in selectedPets)
    {
        Console.WriteLine("\nSelected Pet(s):" + "\n" + pet.Name);
    }

    Console.WriteLine("\n\n");

    Console.WriteLine("\nCreated by: Ibraheem Omar, Michael Gonzalez, and Omar Ali");
    input = Console.ReadLine();

    switch (input)
    {
        case "1":
            petShelter.AddPet();
            break;

        case "2":
            Console.WriteLine("How many pet(s) would you like to select?");
            //int numberOfPets1 = 0;
            //if (int.TryParse(petToCheck, out numberOfPets1))
            int numberOfPets = Convert.ToInt32(Console.ReadLine());
            petShelter.ListPets();
            selectedPets.Clear();
   
            for (int i = 0; i < numberOfPets; i++)
                {
                    Console.WriteLine("Select the next pet.");
                    int indexOfPet = Convert.ToInt32(Console.ReadLine());
                    Pet selectedPet = petHouse.ElementAt(indexOfPet - 1);
                    Console.WriteLine($"you selected {selectedPet.Name}");
                    selectedPets.Add(selectedPet);
                }
                Console.WriteLine($"Selected pet(s):");

                foreach (Pet pet in selectedPets)
                {
                    Console.WriteLine(pet.Name);
                }
                Console.ReadLine();
            
            //else 
            
               // Console.WriteLine("Invalid Item. Try again.");
            
            break;

        case "3":

            if (selectedPets.Count > 0)
            {


                foreach (Pet pet in selectedPets)
                {
                    pet.Feed();
                }

            }
            else
            {
                Console.WriteLine("Please select a pet first.");
                Console.WriteLine("\nPress 'Enter' to continue...");
                Console.ReadLine();
            }
            break;

        case "4":
            if (selectedPets.Count > 0)
            {

                foreach (Pet pet in selectedPets)
                {
                    pet.SeeDoctor();
                }
            }
            else
            {
                Console.WriteLine("Please select a pet first.");
                Console.WriteLine("\nPress 'Enter' to continue...");
                Console.ReadLine();
            }
            break;

        case "5":
            if (selectedPets.Count > 0)
            {

                foreach (Pet pet in selectedPets)
                {
                    pet.Play();
                }
            }
            else
            {
                Console.WriteLine("Please select a pet first.");
                Console.WriteLine("\nPress 'Enter' to continue...");
                Console.ReadLine();
            }
            break;

        case "6":

            petShelter.ListPets();
            Console.Write($"\nSelected Pet:");
            foreach (Pet pet in selectedPets)
            {
                Console.Write($" {pet.Name};");
            }
            Console.WriteLine("Press 'Enter' to continue...");
            Console.ReadLine();
            break;

        case "7":
            petShelter.RemovePet();
            break;



        case "Q":
            keepThinking = false;
            break;

        default:
            Console.WriteLine("Please choose one of the options available above.");
            Console.ReadLine();
            break;
    }

    petShelter.Tick();

}





