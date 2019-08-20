using System;
using System.Collections.ObjectModel;
using VoterApp.Commands;
using VoterApp.Commands.Abstract;

namespace VoterApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var options = new ReadOnlyCollection<ICommand>(new ICommand[]
            {
                new ExitCommand(),
                new GetAllCandidatesCommand(),
                new ShowOfCandidatesWithVotesCommand(),
                new VoteForCandidateCommand(),
            });

            new Menu(options).Run();
        }
    }
}
