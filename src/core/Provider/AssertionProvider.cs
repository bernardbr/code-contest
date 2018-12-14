namespace CodeContest.Core.Provider
{
    using CodeContest.Core.Domain.Model;
    using CodeContest.Core.MongoDb;

    using Microsoft.Extensions.Configuration;

    using MongoDB.Driver;

    /// <summary>
    /// The <see cref="Assertion"/> provider.
    /// </summary>
    public class AssertionProvider : MongoDbContext<Assertion>
    {
        /// <inheritdoc />
        public AssertionProvider(IConfiguration configuration) : base(configuration) {}

        /// <inheritdoc />
        protected override IMongoCollection<Assertion> GetEntities(IMongoDatabase database)
        {
            return database.GetCollection<Assertion>("Assertions");
        }
    }
}
