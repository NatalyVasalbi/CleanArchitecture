using CleanArchitecture.Application.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Application
{
    //Contenedor, Container
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
            // registramos el assembly de la libreria que me permite hacer el mapping de las clases origen a una clase destino
            // Assembly.GetExecutingAssembly() automaticamente va a leer todas las clases que esten heredando impplementando las interfaces del automapper y las va a inyectar
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // va a buscar todas las clases de mi proyecto application que esten referenciando al abstractValidation y los paquetes de FluentValidation y
            // automaticamente va a inyectar instanciar crear lo objetos para que esa validacion sea posible dentro de mi proyecto
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //AddTrasiant para los Behaviours pipelines de validation y de las excepciones
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            return services;
        }
    }
}
