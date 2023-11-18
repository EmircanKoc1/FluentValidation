
using FluentValidation;
using FluentValidationMVC.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace FluentValidationMVC.AddServiceIoc
{
    public static class ValidationRulesServices
    {
        public static IServiceCollection AddValidationRules(this IServiceCollection services)
        {

            services.AddScoped<IProductValidator, ProductValidator>();


            return services;
        }


    }
}
