using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eProdaja.Database;
using eProdaja.FIlters;
using eProdaja.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace eProdaja
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
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers(x =>
            {
                x.Filters.Add<ErrorFilter>();
            });

            services.AddSwaggerGen();
            //povezovanje interface s servisom
            services.AddScoped<IProizvodService, ProizvodService>();//zive dok traje request, tj svali prolaz kroz ctor dobija novu instancu 
            services.AddScoped<IKorisniciService, KorisniciService>();
            services.AddScoped<IJedinicaMjereService, JedinicaMjereService>();
            services.AddScoped<IVrsteProizvodaService, VrsteProizvodaService>();
            services.AddScoped<IProizvodiService, ProizvodiService>();



            //AddScoped- dok je je http request ziv, ako se radi o dva korinsika dobiju 2 instance ctora
            //services.AddSingleton<>//dok je ziva apk, i on ce raditi, za sve requeste ista je instanca

            //dodajemo context koji se nalazi u databse folder.
            //putanja do baze tj. DefaultConnection nam se nalazi u appsettings file-u.
            services.AddDbContext<eProdajaContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
