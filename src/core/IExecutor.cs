namespace CodeContest.Core
{
    /// <summary>
    /// Executor interface.
    /// </summary>
    public interface IExecutor
    {
        /// <summary>
        /// Executes a code.
        /// </summary>
        /// <param name="session">The session that is building the code.</param>
        /// <param name="code">The code that will be executed.</param>
        /// <param name="timeout">The timeout (in milliseconds) that the code needs to run.</param>
        /// <param name="input">The string represents the console input.</param>
        /// <param name="output">The output that was generated by code.</param>
        /// <param name="message">The validation message when the code fails.</param>
        /// <returns>The value that indicates if the code had success.</returns>
        bool Execute(string session, string code, int timeout, string input, out string output, out string message);
    }
}
