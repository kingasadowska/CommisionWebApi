using System.Collections.ObjectModel;
using CommisionApp.Commands;
using VoterApp.Commands;
using VoterApp.Commands.Abstract;

namespace CommisionApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var options = new ReadOnlyCollection<ICommand>(new ICommand[]
            {
                new ExitCommand(),
                new AddCandidateCommand(),
                new EnableShowVotesCommand(), 
                new RemoveByIdCommand(), 
                new ShowListForCommisionCommand(), 
                new UpdateCandidateCommand(), 
            });

            new Menu(options).Run();
        }
    }
}
