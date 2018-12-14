namespace CodeContest.Core.Provider
{
    using CodeContest.Core.Domain.Model;
    using CodeContest.Core.MongoDb;

    using Microsoft.Extensions.Configuration;

    using MongoDB.Driver;

    /// <summary>
    /// The <see cref="Contest" /> provider.
    /// </summary>
    public class ContestProvider : MongoDbContext<Contest>
    {
        /// <inheritdoc />
        public ContestProvider(IConfiguration configuration) : base(configuration) {}

        /// <inheritdoc />
        protected override IMongoCollection<Contest> GetEntities(IMongoDatabase database)
        {
            return database.GetCollection<Contest>("Contests");
        }
    }
}
