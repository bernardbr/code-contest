namespace CodeContest.Api
{
    using System.IO;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.PlatformAbstractions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Swashbuckle.AspNetCore.Swagger;

    /// <summary>
    /// The startup class of Api.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Startup"/>.
        /// </summary>
        /// <param name="configuration">The configuration of Api.</param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the services of Api.
        /// </summary>
        /// <param name="services">The services that will be configured.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "API Code Contest", Version = "v1" });
                    c.IncludeXmlComments(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "api.xml"));
                })
                .AddSingleton<IConfiguration>(this.Configuration)
                .AddMvc()                
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
        }

        /// <summary>
        /// Configures the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The instance of <see cref="IApplicationBuilder"/>.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Code Contest V1");
                    c.RoutePrefix = "docs";
                })
                .UseCors(cors => cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())
                .UseMvc();
        }
    }
}