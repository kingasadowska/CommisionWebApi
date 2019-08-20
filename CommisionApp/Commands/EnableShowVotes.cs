using ElectionsApiModels;
using ElectionsApiModels.ApiModels;
using Newtonsoft.Json;
using System;
using VoterApp.Commands.Abstract;

namespace CommisionApp.Commands
{
    public class EnableShowVotesCommand : ICommand
    {
        public string Description => "EnableShowVotes";

        public async void Execute()
        {
            Console.WriteLine("Would you like to let voters to see list of current votes? Enter y for yes /n for no");
            char isVoteExposed = char.Parse(Console.ReadLine());
            var isVoted = false;
            if ((isVoteExposed == 'y') || (isVoteExposed == 'Y'))
            {
                Console.WriteLine("List of candidates votes is visible for votes!");
                isVoted = true;
            }

            else if ((isVoteExposed == 'n') || (isVoteExposed == 'N'))
            {
                Console.WriteLine("List of candidates votes is invisible for votes!");
                isVoted = false;
            }

            else
            {
                Console.WriteLine("Invalid input!");
            }

            var parsedModel = JsonConvert.SerializeObject(new EnableShowModel()
            {
                issVoteExposed = isVoted
            });

            var service = new HttpClientElectionsService();
            await service.PostModel("http://localhost:5000/api/ShowListForCommision", parsedModel);

        }
    }
}
