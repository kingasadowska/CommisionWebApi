using System;
using VoterApp.Commands.Abstract;

namespace VoterApp.Commands
{
    public class ExitCommand : ICommand
    {
        public string Description => "Exit.";

        public void Execute()
        {
            Environment.Exit(0);
        }
    }
}
