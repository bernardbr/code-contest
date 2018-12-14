using System;

namespace CodeContest.Core.Domain.Model
{
    /// <summary>
    /// The contest assertion.
    /// </summary>
    public class Assertion : BaseModel
    {
        /// <summary>
        /// Gets or sets the timeout in seconds.
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// Gets or sets the input.
        /// </summary>
        public string Input { get; set; }

        /// <summary>
        /// Gets or sets the expected output;
        /// </summary>
        public string Expected { get; set; }

        /// <summary>
        /// Gets or sets the values that indicates if the assertion is public.
        /// </summary>
        public bool Public { get; set; }

        /// <summary>
        /// Gets or sets the contest's id.
        /// </summary>
        public Guid ContestId { get; set; }
    }
}
