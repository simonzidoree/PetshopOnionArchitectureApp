using System;
using System.Collections.Generic;
using Petshop.Core.ApplicationService;
using Petshop.Core.Entities;

namespace Petshop.ConsoleApp
{
    public class Printer : IPrinter
    {
        #region Service Area

        private readonly IPetService _petService;

        #endregion

        #region Printer Constructor

        public Printer(IPetService petService)
        {
            _petService = petService;
        }

        #endregion

        #region UI

        public void StartUI()
        {
            string[] menuItems =
            {
                "Show list of all Pets",
                "Search Pets by Type",
                "Create a new Pet",
                "Delete a Pet",
                "Update a Pet",
                "Get 5 cheapest available Pets",
                "Show Pets sorted by Highest price",
                "Show Pets sorted by Lowest price",
                "Exit"
            };

            var selection = ShowMenu(menuItems);

            while (selection != 9)
            {
                switch (selection)
                {
                    case 1:
                        var pets = _petService.GetAllPets();
                        ListAllPets(pets);
                        break;
                    case 2:
                        SearchPetsByType();
                        break;
                    case 3:
                        var name = AskQuestion("Enter a name for the pet: ");
                        var type = AskQuestion("Enter a type: ");
                        var birthDate = new DateTime(2000, 01, 01);
                        var soldDate = new DateTime(2000, 01, 01);
                        var color = AskQuestion($"Enter {name}'s color: ");
                        var previousOwner = AskQuestion($"Enter {name}'s previous owner: ");
                        var price = double.Parse(AskQuestion($"Enter the price of {name}: "));
                        var pet = _petService.NewPet(name, type, birthDate, soldDate, color, previousOwner, price);
                        _petService.CreatePet(pet);
                        break;
                    case 4:
                        var idForDelete = PrintFindPetByID();
                        _petService.DeletePet(idForDelete);
                        break;
                    case 5:
                        var idForEdit = PrintFindPetByID();
                        var petToEdit = _petService.FindPetById(idForEdit);
                        Console.WriteLine($"Editing {petToEdit.Name} with ID: {petToEdit.ID}");
                        var newName = AskQuestion("Enter a name for the pet: ");
                        var newType = AskQuestion("Enter a type: ");
                        var newBirthDate = new DateTime(2000, 01, 01);
                        var newSoldDate = new DateTime(2000, 01, 01);
                        var newColor = AskQuestion($"Enter {newName}'s color: ");
                        var newPreviousOwner = AskQuestion($"Enter {newName}'s previous owner: ");
                        var newPrice = double.Parse(AskQuestion($"Enter the price of {newName}: "));
                        _petService.UpdatePet(new Pet
                        {
                            ID = idForEdit,
                            Name = newName,
                            Type = newType,
                            Birthdate = newBirthDate,
                            SoldDate = newSoldDate,
                            Color = newColor,
                            PreviousOwner = newPreviousOwner,
                            Price = newPrice
                        });
                        break;
                    case 6:
                        FiveCheapestAvailablePets();
                        break;
                    case 7:
                        ShowPetsSortedByHighestPrice();
                        break;
                    case 8:
                        ShowPetsSortedByLowestPrice();
                        break;
                }

                selection = ShowMenu(menuItems);
            }

            Console.WriteLine("Exiting...");
            Console.ReadLine();
        }

        private void ShowPetsSortedByLowestPrice()
        {
            var i = 0;
            var list = _petService.GetSortedByLowestPricePets();

            Console.WriteLine("\nList of Pets sorted by Lowest price");
            Console.WriteLine("----------------");

            foreach (var pet in list)
            {
                Console.WriteLine(
                    $"{i + 1}: | ID: {pet.ID}\nName: {pet.Name}\nType: {pet.Type}\nBirthdate: {pet.Birthdate}\nSoldDate: {pet.SoldDate}\nColor: {pet.Color}\nPreviousOwner: {pet.PreviousOwner}\nPrice: {pet.Price}\n",
                    i++);
            }
        }

        private void ShowPetsSortedByHighestPrice()
        {
            var i = 0;
            var list = _petService.GetSortedByHighestPricePets();

            Console.WriteLine("\nList of Pets sorted by Highest price");
            Console.WriteLine("----------------");

            foreach (var pet in list)
            {
                Console.WriteLine(
                    $"{i + 1}: | ID: {pet.ID}\nName: {pet.Name}\nType: {pet.Type}\nBirthdate: {pet.Birthdate}\nSoldDate: {pet.SoldDate}\nColor: {pet.Color}\nPreviousOwner: {pet.PreviousOwner}\nPrice: {pet.Price}\n",
                    i++);
            }
        }

        private int PrintFindPetByID()
        {
            int id;
            Console.Write("\nEnter Pet ID: ");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("Please enter a number: ");
            }

            return id;
        }

        private string AskQuestion(string question)
        {
            Console.Write(question);
            return Console.ReadLine();
        }

        private void ListAllPets(List<Pet> pets)
        {
            var i = 0;
            Console.WriteLine("\nList of all Pets");
            Console.WriteLine("----------------");

            foreach (var pet in pets)
            {
                Console.WriteLine(
                    $"{i + 1}: | ID: {pet.ID}\nName: {pet.Name}\nType: {pet.Type}\nBirthdate: {pet.Birthdate}\nSoldDate: {pet.SoldDate}\nColor: {pet.Color}\nPreviousOwner: {pet.PreviousOwner}\nPrice: {pet.Price}\n",
                    i++);
            }

            Console.WriteLine();
        }

        private int ShowMenu(string[] menuItems)
        {
            int selection;

            Console.WriteLine("Choose an option:");
            Console.WriteLine("---------------------------");

            for (var i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{i + 1}: | {menuItems[i]}");
            }

            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > 9)
            {
                Console.WriteLine("\nPlease select a number between 1-9:");
            }

            return selection;
        }

        private void FiveCheapestAvailablePets()
        {
            var i = 0;
            var list = _petService.GetFiveCheapestPets();

            Console.WriteLine("\nList of 5 cheapest Pets");
            Console.WriteLine("----------------");

            foreach (var pet in list)
            {
                Console.WriteLine(
                    $"{i + 1}: | ID: {pet.ID}\nName: {pet.Name}\nType: {pet.Type}\nBirthdate: {pet.Birthdate}\nSoldDate: {pet.SoldDate}\nColor: {pet.Color}\nPreviousOwner: {pet.PreviousOwner}\nPrice: {pet.Price}\n",
                    i++);
            }
        }

        private void SearchPetsByType()
        {
            var i = 0;
            var petType = AskQuestion("Enter the type you are searching for: ");
            var list = _petService.GetAllByType(petType);

            Console.WriteLine($"\nList of Pets sorted by Type: {petType}");
            Console.WriteLine("-------------------------------------------------------");

            foreach (var pet in list)
            {
                Console.WriteLine(
                    $"{i + 1}: | ID: {pet.ID}\nName: {pet.Name}\nType: {pet.Type}\nBirthdate: {pet.Birthdate}\nSoldDate: {pet.SoldDate}\nColor: {pet.Color}\nPreviousOwner: {pet.PreviousOwner}\nPrice: {pet.Price}\n",
                    i++);
            }
        }

        #endregion
    }
}