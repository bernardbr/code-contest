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
        private const string CODE_EXAMPLE_1 = @"
            using System;
            using System.IO;

            class SolveMeFirst
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

        /// <summary>
        /// Test: Should execute.
        /// </summary>
        [Test]
        [TestCase(CODE_EXAMPLE_1, "f356a7ee-055a-472b-9492-496eab0a2b00", "4\n5", "9")]
        [TestCase(CODE_EXAMPLE_1, "f356a7ee-055a-472b-9492-496eab0a2b02", "50\n-5", "45")]
        public void ShouldExecute(string code, string session, string input, string expectedOutput)
        {
            IExecutor executor = new CSharpExecutor();
            var ret = executor.Execute(session, code, int.MaxValue, input, out var output, out var message);
            Assert.IsTrue(ret);
            Assert.IsNotEmpty(output);
            Assert.IsEmpty(message);
            Assert.AreEqual(expectedOutput, output.Trim(), $"{expectedOutput} are not equal {output.Trim()}");
        }
    }
}
