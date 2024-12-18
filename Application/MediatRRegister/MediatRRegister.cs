using Application.Buhaviors;
using Microsoft.Extensions.DependencyInjection;

namespace Application.MediatRRegister;
public static class MediatRRegister
{
    public static void RegisterAllHandlers(this IServiceCollection services)
    {
        services.AddMediatR(conf =>
        {
            conf.RegisterServicesFromAssembly(typeof(Program).Assembly);
            conf.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
    }
}

