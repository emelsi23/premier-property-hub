using ApartamentosRenta.Options;

namespace ApartamentosRenta.Services;

public static class EmailServiceExtensions
{
    public static IServiceCollection AddAppEmail(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailOptions>(configuration.GetSection(EmailOptions.SectionName));
        services.AddSingleton<AppointmentEmailService>();

        var provider = configuration[$"{EmailOptions.SectionName}:Provider"] ?? "Resend";
        if (provider.Equals("Smtp", StringComparison.OrdinalIgnoreCase))
        {
            services.AddSingleton<IEmailSender, SmtpEmailSender>();
        }
        else
        {
            services.AddHttpClient<IEmailSender, ResendEmailSender>();
        }

        return services;
    }
}
