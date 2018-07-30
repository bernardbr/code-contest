namespace CodeContest.Api
{
    using Microsoft.AspNetCore.Hosting;

    using Microsoft.AspNetCore;

    /// <summary>
    /// The main class of Api..
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main method.
        /// </summary>
        /// <param name="args">The args.</param>           
        public static void Main(string[] args)
        {
            WebHost
                .CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build()
                .Run();
        }
    }
}