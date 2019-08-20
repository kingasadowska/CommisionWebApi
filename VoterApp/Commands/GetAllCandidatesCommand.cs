using System;
using System.Collections.Generic;
using System.Net.Http;
using ElectionsApiModels;
using ElectionsApiModels.ApiModels;
using VoterApp.Commands.Abstract;

namespace VoterApp.Commands
{
    public class GetAllCandidatesCommand : ICommand
    {
        public string Description => "GetAllCandidates";

        public async void Execute()
        {
            var service =  new HttpClientElectionsService();
            var result = await service.Get<List<ResponseCandidatesModel>>("http://localhost:5000/api/GetAllCandidates");

            foreach (var element in result)
            {
                Console.WriteLine(
                    $"Id: {element.Id} " +
                    $"Name: {element.CandidateFirstName} " +
                    $"Surname: {element.CandidateLastName}");
            }
        }
    }
}
