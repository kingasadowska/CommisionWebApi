using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elections.App.Database;
using Elections.App.Services.Abstract;
using ElectionsApiModels.ApiModels;
using Microsoft.EntityFrameworkCore;

namespace Elections.App.Services
{
    public class VoterService : IVoterService
    {
        private readonly CandidateContext _context;

        public VoterService(CandidateContext context)
        {
            _context = context;
        }

        public void VoteForCandidate(RequestVoterModel voter)
        {
            var candidate = _context.Candidates
                .Where(el => el.Id == voter.CandidateID)
                .Select(el => new
                {
                    IdCandidate = el.Id
                })
                .FirstOrDefault();

            var isnNewUserExist = _context.Users.Any(p => p.UserPesel == voter.UserPesel);
            if (!isnNewUserExist && candidate != null)
            {
                _context.Users.Add(new User()
                {
                    CandidatesId = candidate.IdCandidate,
                    UserPesel = voter.UserPesel,
                });

                _context.SaveChanges();
            }
        }

        public List<ResponseCandidatesModel> GetAllCandidates()
        {
            return _context.Candidates.OrderBy(p => p.Id)
                .ThenBy(p => p.CandidateLastName)
                .Select(p => new ResponseCandidatesModel()
                {
                    CandidateFirstName = p.CandidateFirstName,
                    CandidateLastName = p.CandidateLastName,
                    Id = p.Id,
                })
                .ToList();
        }

        public List<ResponseVoteForCandidatesModel> ShowOfCandidatesWithVotes()
        {
            var settings = _context.SettingApp.FirstOrDefault();

            if (settings != null && settings.IsVoteExposed)
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
            return new List<ResponseVoteForCandidatesModel>();
        }
    }
}
