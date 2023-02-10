using CharacterCreatorMvc.Application.Interfaces;
using CharacterCreatorMvc.Application.Mappings;
using CharacterCreatorMvc.Application.Services;
using CharacterCreatorMvc.Domain.Account;
using CharacterCreatorMvc.Domain.Interfaces;
using CharacterCreatorMvc.Infra.Data.Context;
using CharacterCreatorMvc.Infra.Data.Identity;
using CharacterCreatorMvc.Infra.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreatorMvc.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<ICharacterTypeRepository, CharacterTypeRepository>();
            services.AddScoped<ICharacterRepository, CharacterRepository>();

            services.AddScoped<ICharacterTypeService, CharacterTypeService>();
            services.AddScoped<ICharacterService, CharacterService>();
            services.AddScoped<IAuthenticate, AuthenticateService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myHandlers = AppDomain.CurrentDomain.Load("CharacterCreatorMvc.Application");
            services.AddMediatR(myHandlers);

            return services;
        }
    }
}
