using System;
using System.Collections.Generic;
using ElectionsApiModels;
using ElectionsApiModels.ApiModels;
using VoterApp.Commands.Abstract;

namespace CommisionApp.Commands
{
    public class ShowListForCommisionCommand : ICommand
    {
        public string Description => "ShowListForCommisionCommand";

        public async void Execute()
        {
            var service = new HttpClientElectionsService();
            var result = await service.Get<List<ResponseVoteForCandidatesModel>>("http://localhost:5000/api/ShowOfCandidatesWithVotes");

            foreach (var element in result)
            {
                Console.WriteLine(
                    $"Firstname: {element.CandidateFirstName} " +
                    $"Lastname: {element.CandidateLastName}" +
                    $"Id: {element.Id}" +
                    $"Count of votes:{element.CountOfVotes}");
            }
        }
    }
}
