using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            var database = new SqlDatabase("Server=.\\S2017E;Database=PetDatabase;Trusted_Connection=True;");
           
            while (true)
            {

                Console.WriteLine("**********************************************************");
                Console.WriteLine("*****This program asks you for a task for PetDatabase*****");
                Console.WriteLine("**************  Please Press a key for ...****************");
                Console.WriteLine("*************--------------------------------*************");
                Console.WriteLine("*************|          PetDatabase         |*************");
                Console.WriteLine("*************--------------------------------*************");
                Console.WriteLine("*************| 1. Read a data               |*************");
                Console.WriteLine("*************| 2. Read all data             |*************");
                Console.WriteLine("*************| 3. Insert data               |*************");
                Console.WriteLine("*************| 4. Update data               |*************");
                Console.WriteLine("*************| 5. Delete data               |*************");
                Console.WriteLine("*************--------------------------------*************");
                Console.WriteLine("**********************************************************");

                var choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {

                    case 1:
                        Console.WriteLine("You have selected 1: Read a data");
                        Console.WriteLine("At which row number?");
                        var rowNumber = Int32.Parse(Console.ReadLine());
                        var pet = database.Read(rowNumber);
                        Console.WriteLine("Name: " + pet.Name + "\r\nAge: " + pet.Age + "\r\nIs it Spotted? " + pet.IsSpotted + "\r\nWhat Color? " + pet.Color);
                        Console.WriteLine("Press 1 to go back to menu. To quit, press 2");
                        var quit = Int32.Parse(Console.ReadLine());
                        if (quit == 1)
                        {
                            Console.WriteLine("Press Enter 1 more time.");  
                        }
                        else if (quit == 2)
                        {
                            Environment.Exit(0);
                        }
                        break;
                    case 2:
                        Console.WriteLine("You have selected 2: Read all data");
                        

                        foreach (var Pet in database.GetAllPets())
                        {
                            Console.WriteLine("Pet Data #" + Pet.id);
                            Console.WriteLine($"Name: " + Pet.Name + "\r\nAge: " + Pet.Age + "\r\nIs it Spotted? " + Pet.IsSpotted + "\r\nWhat Color? " + Pet.Color);
                            Console.WriteLine("*******************************************************");
                            
                        }

                        Console.WriteLine("Press 1 + Enter to go back to menu. To quit, press 2");
                        quit = Int32.Parse(Console.ReadLine());
                        if (quit == 1)
                        {
                            Console.WriteLine("Press Enter 1 more time.");
                        }
                        else if (quit == 2)
                        {
                            Environment.Exit(0);
                        }
                        break;
                        
                    case 3:
                        Console.WriteLine("You have selected 3: Insert a data");
                        Console.WriteLine("What is the new pet's name: ");
                        var newName = Console.ReadLine();
                        Console.WriteLine("\r\nHow old: ");
                        var newAge = Console.ReadLine();
                        Console.WriteLine("\r\nIs it spotted? (true or false)");
                        var NewIsSpotted = Console.ReadLine();
                        Console.WriteLine("\r\nWhat color? ");
                        var newColor = Console.ReadLine();

                        var NewPet = new Pet()
                        {
                            Name = newName.ToString(),
                            Age = Convert.ToInt32(newAge),
                            IsSpotted = Convert.ToBoolean(NewIsSpotted),
                            Color = newColor.ToString()
                        };
                        AddPet(database, NewPet);

                        Console.WriteLine("Inserted Successfully!");
                        Console.WriteLine("Press 1 + Enter to go back to menu. To quit, press 2");
                        quit = Int32.Parse(Console.ReadLine());
                        if (quit == 1)
                        {
                            Console.WriteLine("Press Enter 1 more time.");
                        }
                        else if (quit == 2)
                        {
                            Environment.Exit(0);
                        }
                        break;

                    case 4:
                        Console.WriteLine("You have selected 4: Update a data");
                        Console.WriteLine("Which petId# would you like to update?");
                        var updateRow = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("New name to update: ");
                        var UpdateName = Console.ReadLine();
                        Console.WriteLine("\r\nNew age: ");
                        var UpdateAge = Console.ReadLine();
                        Console.WriteLine("\r\nIs it spotted? (true or false)");
                        var UpdateIsSpotted = Console.ReadLine();
                        Console.WriteLine("\r\nWhat color? ");
                        var UpdateColor = Console.ReadLine();

                        var updatePet = new Pet()
                        {
                            Name = UpdateName.ToString(),
                            Age = Convert.ToInt32(UpdateAge),
                            IsSpotted = Convert.ToBoolean(UpdateIsSpotted),
                            Color = UpdateColor.ToString()
                        };
                        UpdatePet(database, updatePet, updateRow);
                        Console.WriteLine("Press 1 + Enter to go back to menu. To quit, press 2");
                        quit = Int32.Parse(Console.ReadLine());
                        if (quit == 1)
                        {
                            Console.WriteLine("Press Enter 1 more time.");
                        }
                        else if (quit == 2)
                        {
                            Environment.Exit(0);
                        }

                        break;
                    case 5:
                        Console.WriteLine("You have selected 5: Delete a data");
                        Console.WriteLine("Which number of petID would you like to delete? ");
                        var numberToDelete = Int32.Parse(Console.ReadLine());
                        database.Delete(numberToDelete);
                        Console.WriteLine("PetID #" +numberToDelete+ " has been successfully deleted.");
                        Console.WriteLine("Press 1 + Enter to go back to menu. To quit, press 2");
                        quit = Int32.Parse(Console.ReadLine());
                        if (quit == 1)
                        {
                            Console.WriteLine("Press Enter 1 more time.");
                        }
                        else if (quit == 2)
                        {
                            Environment.Exit(0);
                        }
                        break;
                        
                    default:
                        Console.WriteLine("Please make a correct selection. Press 1-5 on menu.");
                        break;
                }

                Console.ReadKey();
            }
        }

        static void UpdatePet(SqlDatabase database, Pet updatePet, int updateRow)
        {
            database.Update(updatePet, updateRow);
        }
 

        static void AddPet(IDatabase database, Pet pet)
        {
            database.Create(pet);
        }

    }
}
