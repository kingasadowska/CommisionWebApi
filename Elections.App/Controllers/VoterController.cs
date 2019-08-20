using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elections.App.Database;
using Elections.App.Services;
using Elections.App.Services.Abstract;
using ElectionsApiModels.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Elections.App.Controllers
{
    [ApiController]
    public class VoterController : ControllerBase
    {
        private readonly IVoterService _voterService;

        public VoterController(IVoterService voterService)
        {
            _voterService = voterService;
        }

        [HttpPost]
        [Route("api/VoteForCandidate")]
        public ActionResult AddCandidate([FromBody] RequestVoterModel model)
        {
            _voterService.VoteForCandidate(model);
            return Ok();
        }

        [HttpGet]
        [Route("api/GetAllCandidates")]
        public ActionResult GetAllCandidates()
        {
            return Ok(_voterService.GetAllCandidates());
        }

        [HttpGet]
        [Route("api/ShowOfCandidatesWithVotes")]
        public ActionResult ShowOfCandidatesWithVotes()
        {
            return Ok(_voterService.ShowOfCandidatesWithVotes());
        }
    }
}
