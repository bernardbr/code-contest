namespace CodeContest.Api.Controller
{
    using System.Collections.Generic;
    using System.Threading;
    using CodeContest.Core.Domain.Model;
    using CodeContest.Core.Provider;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using MongoDB.Bson;
    using MongoDB.Driver;

    /// <summary>
    /// The test controller.
    /// </summary>
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// The instance of configuration.
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of <see cref="UserController"/>.
        /// </summary>
        /// <param name="configuration"></param>
        public UserController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
    }
}