namespace CodeContest.Core.Domain.Model
{
    using System.ComponentModel.DataAnnotations;
    using System;

    /// <summary>
    /// Base model.
    /// </summary>
    public abstract class BaseModel
    {
        /// <summary>
        /// Gets or sets the public id.
        /// </summary>
        [Required]
        public Guid Id { get; set; }
    }
}
