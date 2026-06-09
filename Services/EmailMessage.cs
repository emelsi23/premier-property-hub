namespace ApartamentosRenta.Services;

public sealed class EmailMessage
{
    public required string Subject { get; init; }

    public required string HtmlBody { get; init; }

    public IReadOnlyList<EmailAttachment> Attachments { get; init; } = [];
}

public sealed class EmailAttachment
{
    public required string FileName { get; init; }

    public required string ContentType { get; init; }

    public required byte[] Data { get; init; }
}
