using System.Net.Http.Json;
using System.Text.Json.Serialization;
using ApartamentosRenta.Options;
using Microsoft.Extensions.Options;

namespace ApartamentosRenta.Services;

public sealed class ResendEmailSender(
    HttpClient httpClient,
    IOptions<EmailOptions> options) : IEmailSender
{
    public async Task SendAsync(string to, string subject, string htmlBody, CancellationToken cancellationToken = default)
    {
        var config = options.Value;
        if (string.IsNullOrWhiteSpace(config.ResendApiKey))
        {
            throw new InvalidOperationException("Email:ResendApiKey is not configured.");
        }

        using var request = new HttpRequestMessage(HttpMethod.Post, "https://api.resend.com/emails");
        request.Headers.Add("Authorization", $"Bearer {config.ResendApiKey.Trim()}");
        request.Content = JsonContent.Create(new ResendEmailRequest
        {
            From = config.FromAddress,
            To = [to],
            Subject = subject,
            Html = htmlBody
        });

        using var response = await httpClient.SendAsync(request, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync(cancellationToken);
            throw new InvalidOperationException($"Resend API error ({response.StatusCode}): {body}");
        }
    }

    private sealed class ResendEmailRequest
    {
        [JsonPropertyName("from")]
        public string From { get; set; } = string.Empty;

        [JsonPropertyName("to")]
        public List<string> To { get; set; } = [];

        [JsonPropertyName("subject")]
        public string Subject { get; set; } = string.Empty;

        [JsonPropertyName("html")]
        public string Html { get; set; } = string.Empty;
    }
}
