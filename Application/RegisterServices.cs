using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using MediatR;
using FluentValidation;
using Application.Behaviour;

namespace Application
{
    public static class RegisterServices
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            //MediatR Pipeline
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviourcs<,>));

            return services;
        }
    }
}
