using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using US_Election.Dal.Database;
using US_Election.Dal.Repositories;
using US_Election.Dal.Repositories.Interface;
using US_Election.Dal.Services;
using US_Election.Dal.Services.Interface;
using US_Election.Services;
using US_Election.Services.Interface;

namespace US_Election
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));

            var connectionString = Configuration.GetConnectionString("usElection");
            services.AddDbContext<US_ElectionDbContext>(builder => builder.UseSqlServer(connectionString));

            services.AddCors(options => options.AddPolicy("AllowAll", p =>
                                                 p.WithOrigins("http://localhost:3000/")
                                                    .WithMethods("POST", "GET", "PUT", "DELETE")
                                                    .WithHeaders(HeaderNames.ContentType)
                                                    .AllowAnyOrigin()
                                                    .AllowAnyMethod()
                                                    .AllowAnyHeader())); 

            services.AddScoped<IVoteRepository, VoteRepository>();
            services.AddScoped<IElectorateRepository, ElectorateRepository>();
            services.AddScoped<IExceptionRepository, ExceptionRepository>();
            services.AddScoped<IVoteService, VoteService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowAll");

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseRouting();
            app.UseAuthorization();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}