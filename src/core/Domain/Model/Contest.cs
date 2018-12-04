namespace CodeContest.Core.Domain.Model
{
    using System.ComponentModel.DataAnnotations;
    using System;

    /// <summary>
    /// The contest model.
    /// </summary>
    public class Contest
    {
        /// <summary>
        /// Gets or sets the public id.
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the value that defines whether the contest is active.
        /// </summary>        
        public bool Active { get; set; }
    }
}