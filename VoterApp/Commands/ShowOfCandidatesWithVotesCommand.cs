using System;
using System.Collections.Generic;
using System.Text;
using ElectionsApiModels;
using ElectionsApiModels.ApiModels;
using VoterApp.Commands.Abstract;

namespace VoterApp.Commands
{
    public class ShowOfCandidatesWithVotesCommand : ICommand
    {
        public string Description => "ShowOfCandidatesWithVotesCommand";

        public async void Execute()
        {
           
             var service = new HttpClientElectionsService();
            

            var result = await service.Get<List<ResponseVoteForCandidatesModel>>("http://localhost:5000/api/ShowOfCandidatesWithVotes");

            foreach (var element in result)
            {
                Console.WriteLine(
                    $"Id: {element.Id} " +
                    $"Name: {element.CandidateFirstName} " +
                    $"Surname: {element.CandidateLastName} " +
                    $"Votes: {element.CountOfVotes}");
            }
        }
    }
}
