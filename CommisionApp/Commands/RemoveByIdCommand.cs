using ElectionsApiModels;
using ElectionsApiModels.ApiModels;
using Newtonsoft.Json;
using System;
using VoterApp.Commands.Abstract;

namespace CommisionApp.Commands
{
    public class RemoveByIdCommand : ICommand
    {
        public string Description => "RemoveByIdCommand";

        public async void Execute()
        {
            Console.WriteLine("To delete candidate please enter id: ");
            string idInput = Console.ReadLine();

            int id = string.IsNullOrWhiteSpace(idInput) ? 0 : Convert.ToInt32(idInput);
            if (id == 0)
            {
                Console.WriteLine("Wrong data");
            }
            else
            {
                Console.WriteLine("You delete candidate!");

            }

            var service = new HttpClientElectionsService();
            await service.Delete($"http://localhost:5000/api/RemoveById/{id}");
        }
    }
}
