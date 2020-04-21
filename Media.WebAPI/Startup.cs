using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Media.BLL.Contracts;
using Media.BLL.Implementation;
using Media.DataAccess.Context;
using Media.DataAccess.Contracts;
using Media.DataAccess.Implementations;
using Media.Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Media.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            //BLL
            services.Add(new ServiceDescriptor(typeof(IAlbumCreateService),typeof(AlbumCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IAlbumGetService),typeof(AlbumGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IAlbumUpdateService),typeof(AlbumUpdateService), ServiceLifetime.Scoped));
            
            services.Add(new ServiceDescriptor(typeof(ITrackCreateService),typeof(TrackCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ITrackGetService),typeof(TrackGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ITrackUpdateService),typeof(TrackUpdateService), ServiceLifetime.Scoped));
            
            services.Add(new ServiceDescriptor(typeof(IPodcastCreateService),typeof(PodcastCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IPodcastGetService),typeof(PodcastGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IPodcastUpdateService),typeof(PodcastUpdateService), ServiceLifetime.Scoped));

            //DataAccess
            services.Add(new ServiceDescriptor(typeof(IAlbumDataAccess), typeof(AlbumDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(ITrackDataAccess), typeof(TrackDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IPodcastDataAccess), typeof(PodcastDataAccess), ServiceLifetime.Transient));

            //DB Contexts
            services.AddDbContext<AlbumContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("Media")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AlbumContext>();
                context.Database.EnsureCreated(); 
            }
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
        }
    }
}