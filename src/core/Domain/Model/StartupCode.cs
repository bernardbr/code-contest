namespace CodeContest.Core.Domain.Model
{
    using CodeContest.Core.Domain.Model.Enum;

    /// <summary>
    /// Startup code.
    /// </summary>
    public class StartupCode
    {
        /// <summary>
        /// Gets or sets the language type.
        /// </summary>
        public ELanguageType LanguageType { get; set; }

        /// <summary>
        /// Gets or sets the code of startup.
        /// </summary>
        public string Code { get; set; }
    }
}
