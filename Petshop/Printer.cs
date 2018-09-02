using Petshop.Core.ApplicationService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petshop.ConsoleApp
{
    public class Printer
    {
        readonly IPetService _petService;
        public Printer(IPetService petService)
        {
            _petService = petService;
            ShowAllPets();
        }

        private void ShowAllPets()
        {
            var listOfPets = _petService.GetPets();
            foreach (var pet in listOfPets)
            {
                Console.WriteLine($"ID: {pet.ID}\nName: {pet.Name}\nType: {pet.Type}\nBirthdate: {pet.Birthdate}\nSoldDate: {pet.SoldDate}\nColor: {pet.Color}\nPreviousOwner: {pet.PreviousOwner}\nPrice: {pet.Price}\n");
            }
        }
    }
}
