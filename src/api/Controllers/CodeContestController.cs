namespace api.Controllers
{
    using api.Contracts;

    using core;
    using core.Delphi;
    using core.Model;
    using core.Provedor;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    [Route("api/v1/contests")]
    public class CodeContestController : Controller
    {
        private readonly IConfiguration configuration;

        public CodeContestController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var connectionString = this.configuration.GetConnectionString("default");
            using (var provider = new ContestProvider(connectionString))
            {
                return this.Ok(provider.GetAll());
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody]ContestAddContract contract)
        {
            var connectionString = this.configuration.GetConnectionString("default");
            using (var provider = new ContestProvider(connectionString))
            {
                var contest = new Contest();
                contest.ProblemDescription = contract.ProblemDescription;
                contest.StartupProject = contract.StartupProject;

                provider.Add(contest);
            }

            return this.Ok();
        }

        [HttpGet("{publicId}/tests")]
        public IActionResult AddTest([FromRoute]string publicId)
        {
            var connectionString = this.configuration.GetConnectionString("default");
            Contest contest = null;
            using (var contestProvider = new ContestProvider(connectionString))
            {
                contest = contestProvider.GetByPublicId(publicId);
            }

            if (contest == null)
            {
                return this.NotFound(publicId);
            }

            using (var provider = new TestCaseProvider(connectionString))
            {
                return this.Ok(provider.GetAllByContest(contest));
            }
        }

        [HttpPost("{publicId}/tests")]
        public IActionResult AddTest([FromRoute]string contestPublicId, [FromBody]TestContract contract)
        {
            return this.Ok();
        }

        [HttpPost("{publicId}/test/delphi")]
        public IActionResult DoTest([FromRoute]string publicId, [FromBody] CodeContract code)
        {
            var delphiExecutor = new DelphiExecutor();
            delphiExecutor.DoTest(code.Code);
            return this.Ok();
        }
    }
}