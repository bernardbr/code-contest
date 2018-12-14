namespace CodeContest.Api.Contracts
{
    using System.Collections.Generic;

    using CodeContest.Core.Domain.Model;

    /// <summary>
    /// Contest's contract.
    /// </summary>
    public class ContestContract
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ContestContract"/>.
        /// </summary>
        public ContestContract()
        {
            this.StartupCode = new List<StartupCode>();
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the startup code.
        /// </summary>
        public List<StartupCode> StartupCode { get; set; }
    }
}
