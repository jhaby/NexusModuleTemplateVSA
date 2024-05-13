using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NexusModuleTemplate.Data;
using System.Reflection;

namespace NexusModuleTemplate.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddNexusModuleServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        //Add services from NexusModuleTemplate assemblies

        var assembly = Assembly.GetExecutingAssembly();
        string connectionString = configuration.GetConnectionString("DefaultConnection") ?? "";
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), config =>
            {
                config.MigrationsHistoryTable(DbConfigConstants.MigrationsTable, DbConfigConstants.Schema);
                config.EnableStringComparisonTranslations();
                config.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            });
        });
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(assembly);
        });

        services.AddCarter();
        services.AddValidatorsFromAssembly(assembly);
        return services;
    }

    
}
