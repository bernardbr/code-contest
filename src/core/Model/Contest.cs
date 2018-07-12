namespace CodeContest.Core.Model
{
    using System;

    /// <summary>
    /// Contest model.
    /// </summary>
    public class Contest
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Contest"/>.
        /// </summary>
        public Contest()
        {
            this.PublicId = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Gets or sets the public id.
        /// </summary>
        public string PublicId { get; set; }

        /// <summary>
        /// Gets or sets the problem description.
        /// </summary>
        public string ProblemDescription { get; set; }
    }
}