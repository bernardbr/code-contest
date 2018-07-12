namespace CodeContest.Test.Application
{
    using core.Model;
    using core.Service;
    using NUnit.Framework;

    /// <summary>
    /// Application tests for Contest.
    /// </summary>
    [TestFixture]
    public class ContestTest
    {
        /// <summary>
        /// Test: Should add a contest.
        /// </summary>
        public void ShouldAddAContest()
        {
            var contest = new Contest();
            contest.ProblemDescription = "It's just a test";
            contest.StartupProject = @"
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

            var contestService = new ContestService();
            contestService.Add(contest);

            Assert.IsNotNull(contest.Id);
            Assert.IsNotNull(contest.PublicId);
        }
        
    }
}