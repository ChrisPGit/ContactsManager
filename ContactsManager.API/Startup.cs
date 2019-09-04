using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsManager.Core.Entities;
using ContactsManager.Core.Interfaces;
using ContactsManager.Core.Services;
using ContactsManager.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ContactsManager.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<ContactsManagerContext>(o =>
                o.UseSqlServer(Configuration["connectionStrings:ContactsManagerConnectionString"]));

            //services.AddDbContext<ContactsManagerDbContext>(opt =>
            //    opt.UseInMemoryDatabase("ContactsManager"));

            services.AddTransient<IRepository<Company>, Repository<Company>>();
            services.AddTransient<IRepository<Contact>, Repository<Contact>>();
            services.AddTransient<IRepository<CompanyAddress>, Repository<CompanyAddress>>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IContactService, ContactService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ContactsManagerContext contactsManagerContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            contactsManagerContext.EnsureSeedDataForContext();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
