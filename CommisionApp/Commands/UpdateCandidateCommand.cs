using ElectionsApiModels;
using ElectionsApiModels.ApiModels;
using Newtonsoft.Json;
using System;
using VoterApp.Commands.Abstract;

namespace CommisionApp.Commands
{
    public class UpdateCandidateCommand : ICommand
    {
        public string Description => "UpdateCandidateCommand";

        public async void Execute()
        {
            Console.WriteLine("To update candidate please enter id: ");
            string idInput = Console.ReadLine();

            int id = string.IsNullOrWhiteSpace(idInput) ? 0 : Convert.ToInt32(idInput);
            if (id == 0)
            {
                Console.WriteLine("Wrong data");
            }

            Console.WriteLine("Enter new candidate firstname:");
            var updatefirstname = Console.ReadLine();

            Console.WriteLine("Enter new candidate lastname:");
            var updatelastname = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(updatefirstname) || string.IsNullOrWhiteSpace(updatelastname))
            {
                Console.WriteLine("You send me wrong data");
            }
            else
            {
                Console.WriteLine("You update candidate!");
            }

            var parsedModel = JsonConvert.SerializeObject(new RequestCandidatesModel()
            {
                CandidateFirstName = updatefirstname,
                CandidateLastName = updatelastname
            });

            var service = new HttpClientElectionsService();
            await service.PostModel($"http://localhost:5000/api/UpdateCandidate/{id}", parsedModel);
        }
    }
}
