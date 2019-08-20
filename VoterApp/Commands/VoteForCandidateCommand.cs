using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ElectionsApiModels;
using ElectionsApiModels.ApiModels;
using Newtonsoft.Json;
using VoterApp.Commands.Abstract;

namespace VoterApp.Commands
{
    public class VoteForCandidateCommand : ICommand
    {
        public string Description => "VoteForCandidateCommand";

        public async void Execute()
        {
            Console.WriteLine("Enter candidate id:");
            var choosenCandidateIdInput = Console.ReadLine();

            int candidateId = string.IsNullOrWhiteSpace(choosenCandidateIdInput) ? 0 : Convert.ToInt32(choosenCandidateIdInput);
            if (candidateId == 0)
            {
                Console.WriteLine("Wrong data");
            }

            Console.WriteLine("Enter your PESEL: ");
            string peselInput = Console.ReadLine();

            try
            {
                var userPesel = int.Parse(Regex.Match(peselInput.ToString(), "[0-9]{9}").Value);
                var parsedModel = JsonConvert.SerializeObject(new RequestVoterModel()
                {
                    CandidateID = candidateId,
                    UserPesel = userPesel,
                });

                var service = new HttpClientElectionsService();
                await service.PostModel("http://localhost:5000/api/VoteForCandidate", parsedModel);

                Console.WriteLine("You vote it!");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid pesel");
            }
        }
    }
}
