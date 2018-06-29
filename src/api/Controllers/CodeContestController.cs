namespace api.Controllers
{
    using api.Model;

    using core;

    using Microsoft.AspNetCore.Mvc;

    [Route("api/v1/contest")]
    public class CodeContestController : Controller
    {
        [HttpPost("test")]
        public IActionResult DoTest([FromBody] CodeContract code)
        {
            Executor.Do(code.Code);
            return this.Ok();
        }

        [HttpPost("run")]
        public IActionResult DoContest([FromBody] CodeContract code)
        {
            Executor.Do(code.Code);
            return this.Ok();
        }
    }
}