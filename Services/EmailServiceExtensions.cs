namespace ApartamentosRenta.Services;

public static class EmailServiceExtensions
{
    public static IServiceCollection AddSubmissionEmail(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<SmtpEmailOptions>(configuration.GetSection(SmtpEmailOptions.SectionName));
        services.AddSingleton<SubmissionEmailService>();
        return services;
    }
}
