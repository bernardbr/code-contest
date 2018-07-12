namespace CodeContest.Core.Service
{
    using System;

    using CodeContest.Core.Model;
    using CodeContest.Core.Provedor;

    /// <summary>
    /// The domain service of <see cref="Contest"/>.
    /// </summary>
    public class ContestService
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ContestService"/>.
        /// </summary>
        public ContestService(IConfiguration configuration)
        {
            this.contestProvider = new ContestProvider()
        }

        public void Add(Contest contest)
        {
            throw new NotImplementedException();
        }
    }
}