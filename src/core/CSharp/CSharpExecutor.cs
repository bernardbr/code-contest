namespace CodeContest.Core.CSharp
{
    using CodeContest.Core.Generics;

    /// <inheritedoc />
    public class CSharpExecutor : BaseExecutor, IExecutor
    {
        /// <summary>
        /// Initializes a new instance of <see cref="CSharpExecutor"/>.
        /// </summary>
        public CSharpExecutor() : base(new CSharpBuilder())
        {
        }
    }
}
