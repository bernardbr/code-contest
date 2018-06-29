namespace api
{
    using Microsoft.AspNetCore.Hosting;

    using Microsoft.AspNetCore;

    /// <summary>
    /// Classe que representa a aplicação da API de Frontend.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Método principal da aplicação.
        /// </summary>
        /// <param name="args">Os argumentos da aplicação.</param>           
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