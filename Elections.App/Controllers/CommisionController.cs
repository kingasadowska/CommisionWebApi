using Elections.App.Services.Abstract;
using ElectionsApiModels.ApiModels;
using Microsoft.AspNetCore.Mvc;

namespace Elections.App.Controllers
{
    [ApiController]
    public class CommisionController : ControllerBase
    {
        private readonly ICommisionService _commisionService;

        public CommisionController(ICommisionService commisionService)
        {
            _commisionService = commisionService;
        }

        [HttpPost]
        [Route("api/AddCandidate")]
        public ActionResult AddCandidate([FromBody] RequestCandidatesModel model)
        {
            _commisionService.AddCandidate(model);
            return Ok();
        }

        [HttpPut]
        [Route("api/UpdateCandidate/{id}")]
        public ActionResult UpdateCandidate(int id, [FromBody] RequestCandidatesModel updatedCandidatesModel)
        {
            _commisionService.UpdateCandidate(id, updatedCandidatesModel);
            return Ok();
        }

        [HttpDelete]
        [Route("api/RemoveById/{id}")]
        public ActionResult RemoveById(int id)
        {
            _commisionService.RemoveById(id);
            return Ok();
        }

        [HttpGet]
        [Route("api/ShowListForCommision")]
        public ActionResult ShowListForCommision()
        {
            return Ok(_commisionService.ShowListForCommision());
        }

        [HttpPut]
        [Route("api/EnableShowVotes")]
        public ActionResult EnableShowVotes([FromBody] EnableShowModel enableShowModel)
        {
            _commisionService.EnableShowVotes(enableShowModel);
            return Ok();
        }
    }
}
