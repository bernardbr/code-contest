namespace CodeContest.Core.Provedor
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System;

    using CodeContest.Core.Model;

    using Dapper;

    using Npgsql;

    public class ContestProvider : IDisposable
    {
        private const string SELECT = @"
            SELECT
                contest_id as Id,
                public_id as PublicId, 
                problem_description as ProblemDescription,
                startup_project as StartupProject
            FROM
                contest
            {0};
        ";

        private const string INSERT = @"
            INSERT INTO contest
            (
                public_id, 
                problem_description, 
                startup_project
            )
            VALUES
            (
                @PublicId,
                @ProblemDescription,
                @StartupProject
            )
            RETURNING contest_id;
        ";

        private IDbConnection connection;

        public ContestProvider(string connectionString)
        {
            this.connection = new NpgsqlConnection(connectionString);
        }

        public IEnumerable<Contest> GetAll()
        {
            return this.connection.Query<Contest>(string.Format(SELECT, string.Empty)).ToList();
        }

        public void Add(Contest contest)
        {
            var param = new
            {
                contest.PublicId,
                contest.ProblemDescription,
                contest.StartupProject
            };

            contest.Id = this.connection.ExecuteScalar<long>(INSERT, param);
        }

        public Contest GetByPublicId(string publicId)
        {
            const string WHERE = @"
                WHERE
                    (public_id = @publicId)
            ";

            var param = new {
                publicId
            };

            return this.connection.Query<Contest>(string.Format(SELECT, WHERE), param).FirstOrDefault();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    this.connection.Close();
                    this.connection.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ContestProvider() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}