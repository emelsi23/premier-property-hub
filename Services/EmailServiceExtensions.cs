namespace ApartamentosRenta.Services;

public static class EmailServiceExtensions
{
    public static IServiceCollection AddSubmissionEmail(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailOptions>(configuration.GetSection(EmailOptions.SectionName));
        services.AddHttpClient(nameof(EmailSender));
        services.AddSingleton<EmailSender>();
        services.AddSingleton<SubmissionEmailService>();
        return services;
    }
}
