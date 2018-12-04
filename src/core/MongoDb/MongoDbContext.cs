namespace CodeContest.Core.MongoDb
{
    using System;

    using Microsoft.Extensions.Configuration;

    using MongoDB.Driver;

    /// <summary>
    /// The MongoDb context.
    /// </summary>
    public abstract class MongoDbContext<TModel>
    {
        /// <summary>
        /// The instance of MongoDb.
        /// </summary>
        private static IMongoDatabase database;

        /// <summary>
        /// Initializes a new instance of <see cref="MongoDbContext { TModel }" />.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public MongoDbContext(IConfiguration configuration) : this(
            configuration.GetSection("MongoConnection:Database").Value,
            configuration.GetSection("MongoConnection:ConnectionString").Value,
            Convert.ToBoolean(configuration.GetSection("MongoConnection:IsSSL").Value)) {}

        /// <summary>
        /// Initializes a new instance of <see cref="MongoDbContext { TModel }" />.
        /// </summary>
        /// <param name="databaseName">The database name.</param>
        /// <param name="connectionString">The connectionString.</param>
        /// <param name="isSSL">The value that indicates whether uses SSL.</param>
        public MongoDbContext(string databaseName, string connectionString, bool isSSL)
        {
            if (database != null)
            {
                return;
            }

            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            if (isSSL)
            {
                settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
            }

            var mongoClient = new MongoClient(settings);
            database = mongoClient.GetDatabase(databaseName);
        }

        /// <summary>
        /// Get the entities.
        /// </summary>
        public IMongoCollection<TModel> Entities => this.GetEntities(database);

        /// <summary>
        /// Get the entities.
        /// </summary>
        /// <param name="database"> The database.</param>
        /// <returns>A list of model <see cref="IMongoCollection { TModel }" />. </returns>
        protected abstract IMongoCollection<TModel> GetEntities(IMongoDatabase database);
    }
}