namespace core.Provedor
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System;

    using core.Model;

    using Dapper;

    using Npgsql;

    public class TestCaseProvider : IDisposable
    {
        private const string INSERT = @"
            INSERT INTO test_case
            (
                contest_id, 
                ord, 
                timeout, 
                input, 
                output
            )
            VALUES 
            (
                @ContestId,
                @Timeout,
                @Input,
                @Output,
                @Order
            )
            RETURNING test_case_id;
        ";

        private const string SELECT = @"
            SELECT 
                test_case_id as Id, 
                contest_id as ContestId, 
                ord as Order, 
                timeout as Timeout,
                input as Input,
                output as Output
            FROM 
                test_case
            WHERE
                contest_id = @Id;
        ";

        private IDbConnection connection;

        public TestCaseProvider(string connectionString)
        {
            this.connection = new NpgsqlConnection(connectionString);
        }

        public void Add(TestCase testCase)
        {
            var param = new
            {
                testCase.ContestId,
                testCase.Input,
                testCase.Order,
                testCase.Output,
                testCase.Timeout
            };

            testCase.Id = this.connection.ExecuteScalar<long>(INSERT, param);
        }

        public IEnumerable<TestCase> GetAllByContest(Contest contest)
        {
            return this.connection.Query<TestCase>(SELECT, new { contest.Id }).ToList();
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
        // ~TestCaseProvider() {
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