using System;
using System.Collections.Generic;
using System.Text;

namespace ElectionsApiModels.ApiModels
{
    public class RequestCandidatesModel
    {
        public string CandidateFirstName { get; set; }
        public string CandidateLastName { get; set; }
    }

    public class ResponseCandidatesModel
    {
        public int Id { get; set; }
        public string CandidateFirstName { get; set; }
        public string CandidateLastName { get; set; }
    }

    public class ResponseVoteForCandidatesModel
    {
        public int Id { get; set; }
        public string CandidateFirstName { get; set; }
        public string CandidateLastName { get; set; }
        public int CountOfVotes { get; set; }
    }

    public class RequestVoterModel
    {
        public int CandidateID { get; set; }
        public int UserPesel { get; set; }
    }

    public class EnableShowModel
    {
        public bool issVoteExposed { get; set; }
    }
}
