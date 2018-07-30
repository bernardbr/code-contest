namespace CodeContest.Core
{
    /// <summary>
    /// Builder interface.
    /// </summary>
    public interface IBuilder
    {
        /// <summary>
        /// Build the code.
        /// </summary>
        /// <param name="session">The session that is building the code.</param>
        /// <param name="code">The code that will build.</param>
        /// <param name="binaryPath">The path of generated binary on build.</param>
        /// <param name="message">The validation message when the build fails.</param>
        /// /// <returns>The path of the artifact built.</returns>
        bool Build(string session, string code, out string binaryPath, out string message);
    }
}