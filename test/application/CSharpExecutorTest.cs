namespace CodeContest.Test.Application
{
    using System;

    using CodeContest.Core;
    using CodeContest.Core.CSharp;
    using NUnit.Framework;

    /// <summary>
    /// The test application for <see cref="CSharpExecutor"/>.
    /// </summary>
    [TestFixture]
    public class CSharpExecutorTest
    {
        /// <summary>
        /// Test: Should execute.
        /// </summary>
        [Test]
        public void ShouldExecute()
        {
            const string code = @"
                using System;
                using System.IO;

                class solveMeFirst
                {
                    public static long Sum(long first, long second)
                    {
                        return first + second;
                    }

                    static void Main(String[] args)
                    {
                        using (var textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable(""OUTPUT_PATH""), false))
                        {
                            long first = Convert.ToInt64(Console.ReadLine());
                            long second = Convert.ToInt64(Console.ReadLine());

                            textWriter.WriteLine(Sum(first, second));
                            textWriter.Flush();
                            textWriter.Close();
                        }
                    }
                }
            ";

            var session = Guid.NewGuid().ToString();

            IExecutor executor = new CSharpExecutor();
            var ret = executor.Execute(session, code, int.MaxValue, "4\n5", out var output, out var message);
            Assert.IsTrue(ret);
            Assert.IsNotEmpty(output);
            Assert.IsEmpty(message);
        }
    }
}
