using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using RestWebApiAspnetCore.Business;
using RestWebApiAspnetCore.Business.Implementation;
using RestWebApiAspnetCore.Hypermedia;
using RestWebApiAspnetCore.Model.Context;
using RestWebApiAspnetCore.Repository;
using RestWebApiAspnetCore.Repository.Generic;
using RestWebApiAspnetCore.Repository.Implementation;
using RestWebApiAspnetCore.Security.Configuration;
using Swashbuckle.AspNetCore.Swagger;
using Tapioca.HATEOAS;


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

            //Ajustando o servico mvc para responder a requisição via XML e via Json
            // PM > Install - Package Microsoft.AspNetCore.Mvc.Formatters.Xml - Version 2.1.0
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));

            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddXmlSerializerFormatters();


            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ObjectContentResponseEnricherList.Add(new PessoaEnricher());
            filterOptions.ObjectContentResponseEnricherList.Add(new Livroenricher());
            services.AddSingleton(filterOptions);


            //chama migration
            ExecuteMigrations(connectionString);

//----------------------------------------Autenticação--------------------------------------------------------//

            var signingConfigurations = new SigningConfiguration();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfiguration();

            new ConfigureFromConfigurationOptions<TokenConfiguration>(
                _configuration.GetSection("TokenConfigurations")
            )
            .Configure(tokenConfigurations);

            services.AddSingleton(tokenConfigurations);


            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

                // Validates the signing of a received token
                paramsValidation.ValidateIssuerSigningKey = true;

                // Checks if a received token is still valid
                paramsValidation.ValidateLifetime = true;

                // Tolerance time for the expiration of a token (used in case
                // of time synchronization problems between different
                // computers involved in the communication process)
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            // Enables the use of the token as a means of
            // authorizing access to this project's resources
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });
//-------------------------Serviço para versionar a API----------------------------------------------------------
            services.AddApiVersioning(option => option.ReportApiVersions = true);

            //Adcionando serviço do swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "APIRESTFULL",
                    Version = "v1"
                });
            });
//=-------------------------------------------------------------------------------------------------

            services.AddDbContext<MySqlContext>(options => options.UseMySql(connectionString));

            //----------------------------injeção de dependence--------------------------------------//
            services.AddScoped<IPessoaBusiness, PessoaBusinessImpl>();
            services.AddScoped<IPessoaRepository, PessoaRepositoryImpl>();

            services.AddScoped<ILivroBusiness, LivroBusinessImpl>();
            services.AddScoped<ILivroRepository, LivroRepositoryImpl>();

            //-------injeção de dependencia de login
            services.AddScoped<ILoginBusiness,LoginBusinessImpl>();
            services.AddScoped<IUsuarioRepository, UsuarioRepositorioImpl>();

            //----------------------------injeção de dependence--------------------------------------//

            //------------------------------injecao de dependencia do repositorio generico
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }

        private void ExecuteMigrations(string connectionString)
        {
            if (_environment.IsDevelopment())
            {
                try
                {
                    //string de conexao + migration
                    var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                    var evolve = new Evolve.Evolve(evolveConnection, msg => _logger.LogInformation(msg))
                    {
                        //locais para pegar os dados das migrations
                        Locations = new List<string> {"db/migrations", "db/dataset"},
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
//-----------------------------------------------------Configuração do Swagger---------------------------
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI");
            });
            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);
//---------------------------------------------Rota padrão do sistema--------------------------------------------------------------             
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "DefaultApi",
                template: "{controller=Values}/{id?}");
            });
        }
    }
}
