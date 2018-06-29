namespace core
{
    /// <summary>
    /// Builder interface.
    /// </summary>
    public interface IBuilder
    {
        /// <summary>
        /// Build the code.
        /// </summary>
        /// <param name="code">The code that will build.</param>
        /// <returns>The path of the artifact built.</returns>
        string Build(string code);
    }
}