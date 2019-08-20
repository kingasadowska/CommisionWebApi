using ElectionsApiModels;
using ElectionsApiModels.ApiModels;
using Newtonsoft.Json;
using System;
using VoterApp.Commands.Abstract;

namespace CommisionApp.Commands
{
    public class AddCandidateCommand : ICommand
    {
        public string Description => "AddCandidateCommand";

        public async void Execute()
        {
            Console.WriteLine("Enter candidate firstname:");
            var firstname = Console.ReadLine();

            Console.WriteLine("Enter candidate lastname:");
            var lastname = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(firstname) || string.IsNullOrWhiteSpace(lastname))
            {
                Console.WriteLine("You send me wrong data");
            }
            else
            {
                Console.WriteLine("You add new candidate!");
            }

            var parsedModel = JsonConvert.SerializeObject(new RequestCandidatesModel()
            {
                CandidateFirstName = firstname,
                CandidateLastName = lastname,
            });

            var service = new HttpClientElectionsService();
            await service.PostModel("http://localhost:5000/api/AddCandidate", parsedModel);

         
        }
    }
}
