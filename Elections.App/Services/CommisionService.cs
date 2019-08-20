using System.Collections.Generic;
using System.Linq;
using Elections.App.Database;
using Elections.App.Services.Abstract;
using ElectionsApiModels.ApiModels;
using Microsoft.EntityFrameworkCore;

namespace Elections.App.Services
{
    public class CommisionService : ICommisionService
    {
        private readonly CandidateContext _context;

        public CommisionService(CandidateContext context)
        {
            _context = context;
        }

        public void AddCandidate(RequestCandidatesModel candidate)
        {
            _context.Candidates.Add(new Candidates()
            {
                CandidateLastName = candidate.CandidateLastName,
                CandidateFirstName = candidate.CandidateFirstName
            });

            _context.SaveChanges();
        }

        public void UpdateCandidate(int id, RequestCandidatesModel updatedCandidatesModel)
        {

            var candidateUpdate = _context.Candidates.FirstOrDefault(el => el.Id == id);
            if (candidateUpdate != null)
            {
                candidateUpdate.CandidateFirstName = updatedCandidatesModel.CandidateFirstName;
                candidateUpdate.CandidateLastName = updatedCandidatesModel.CandidateLastName;
            }

            _context.SaveChanges();
        }

        public void RemoveById(int id)
        {
             var candidate = _context.Candidates
                 .Include(p => p.Users)
                 .FirstOrDefault(p => id == p.Id);

             if (candidate != null)
             {
                 _context.Remove(candidate);
                 _context.SaveChanges();
             }
        }

        public List<ResponseVoteForCandidatesModel> ShowListForCommision()
        {
            var listOdCandidate = _context.Candidates
                    .Include(p => p.Users)
                    .Select(p => new ResponseVoteForCandidatesModel()
                    {
                        CandidateLastName = p.CandidateLastName,
                        CandidateFirstName = p.CandidateFirstName,
                        Id = p.Id,
                        CountOfVotes = p.Users.Count
                    }).ToList();
                return listOdCandidate;
        }


        public void EnableShowVotes(EnableShowModel enableShowModel)
        {
            var settings = _context.SettingApp.FirstOrDefault();
            if (settings != null) settings.IsVoteExposed = enableShowModel.issVoteExposed;
            _context.SaveChanges();
        }
    }
}

