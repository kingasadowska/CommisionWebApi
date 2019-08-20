using System.Collections.Generic;
using ElectionsApiModels.ApiModels;

namespace Elections.App.Services.Abstract
{
    public interface IVoterService
    {
        void VoteForCandidate(RequestVoterModel voter);
        List<ResponseCandidatesModel> GetAllCandidates();
        List<ResponseVoteForCandidatesModel> ShowOfCandidatesWithVotes();
    }
}