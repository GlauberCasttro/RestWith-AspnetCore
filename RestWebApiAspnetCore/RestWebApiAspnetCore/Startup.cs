using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RestWebApiAspnetCore.Business;
using RestWebApiAspnetCore.Business.Implementation;
using RestWebApiAspnetCore.Model.Context;
using RestWebApiAspnetCore.Repository;
using RestWebApiAspnetCore.Repository.Generic;
using RestWebApiAspnetCore.Repository.Implementation;


namespace RestWebApiAspnetCore
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        private readonly ILogger _logger;
        public IHostingEnvironment _environment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment, ILogger<Startup> logger)
        {
            _environment = environment;
            _logger = logger;
            _configuration = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Conexao com o banco, e configuaração na appSettings
            var connectionString = _configuration["MySqlConnection:MySqlConnectionString"];
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            if (_environment.IsDevelopment())
            {
                try
                {
                    var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                    var evolve = new Evolve.Evolve(evolveConnection, msg=> _logger.LogInformation(msg))
                    {
                        Locations = new List<string> { "db/migrations","db/dataset"  },
                        IsEraseDisabled = true,
                    };
                    evolve.Migrate();


                }
                catch (Exception e)
                {
                    _logger.LogCritical("Database filed migrations. " + e);
                    throw;
                }
            }

            //serviço para versionar a API
            services.AddApiVersioning();
            services.AddDbContext<MySqlContext>(options => options.UseMySql(connectionString));

            //injeção de dependence
            services.AddScoped<IPessoaBusiness, PessoaBusinessImpl>();
            services.AddScoped<IPessoaRepository, PessoaRepositoryImpl>();

            services.AddScoped<ILivroBusiness, LivroBusinessImpl>();
            services.AddScoped<ILivroRepository, LivroRepositoryImpl>();

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseMvc();
        }
    }
}
