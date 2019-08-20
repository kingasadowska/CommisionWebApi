using System.Collections.Generic;
using ElectionsApiModels.ApiModels;

namespace Elections.App.Services.Abstract
{
    public interface ICommisionService
    {
        void AddCandidate(RequestCandidatesModel candidate);
        void UpdateCandidate(int id, RequestCandidatesModel updatedCandidatesModel);
        void RemoveById(int id);
        List<ResponseVoteForCandidatesModel> ShowListForCommision();
        void EnableShowVotes(EnableShowModel enableShowModel);
    }
}