using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestWebApiAspnetCore.Model;
using RestWebApiAspnetCore.Business;
using RestWebApiAspnetCore.Business.Implementation;
using RestWebApiAspnetCore.Repository;
using RestWebApiAspnetCore.Repository.Implementation;


namespace RestWebApiAspnetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Conexao com o banco, e configuaração na appSettings
            var connection = Configuration["MySqlConnection:MySqlConnectionString"];
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //serviço para versionar a API
            services.AddApiVersioning();
            services.AddDbContext<MySqlContext>(options => options.UseMySql(connection));

            //injeção de dependence
            services.AddScoped<IPessoaBusiness, PessoaBusinessImpl>();
            services.AddScoped<IPessoaRepository, PessoaRepositoryImpl>();
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
