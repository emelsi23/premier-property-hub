using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ApartamentosRenta.Services;

public sealed class AgentPhotoUploadService(IWebHostEnvironment environment)
{
    public const long MaxBytes = 5 * 1024 * 1024;

    private static readonly HashSet<string> AllowedImageTypes =
    [
        "image/jpeg",
        "image/png",
        "image/webp",
        "image/gif"
    ];

    private readonly string _baseDirectory = Path.Combine(
        environment.WebRootPath,
        "uploads",
        "agents");

    public string? ValidateFile(IFormFile? file)
    {
        if (file is null || file.Length == 0)
        {
            return null;
        }

        if (file.Length > MaxBytes)
        {
            return $"{file.FileName}: máximo 5 MB.";
        }

        if (!IsAllowedImage(file))
        {
            return $"{file.FileName}: solo JPG, PNG, WEBP o GIF.";
        }

        return null;
    }

    public async Task<string?> SaveAsync(int agentId, IFormFile? file)
    {
        if (file is null || file.Length == 0 || file.Length > MaxBytes || !IsAllowedImage(file))
        {
            return null;
        }

        var directory = Path.Combine(_baseDirectory, agentId.ToString());
        Directory.CreateDirectory(directory);

        var extension = ResolveExtension(file);
        var fileName = $"{Guid.NewGuid():N}{extension}";
        var fullPath = Path.Combine(directory, fileName);

        await using var stream = File.Create(fullPath);
        await file.CopyToAsync(stream);

        return $"/uploads/agents/{agentId}/{fileName}";
    }

    private static bool IsAllowedImage(IFormFile file)
    {
        if (AllowedImageTypes.Contains(file.ContentType))
        {
            return true;
        }

        if (!string.IsNullOrWhiteSpace(file.ContentType)
            && file.ContentType != "application/octet-stream")
        {
            return false;
        }

        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        return extension is ".jpg" or ".jpeg" or ".png" or ".webp" or ".gif";
    }

    private static string ResolveExtension(IFormFile file)
    {
        var fromName = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (fromName is ".jpg" or ".jpeg" or ".png" or ".webp" or ".gif")
        {
            return fromName == ".jpeg" ? ".jpg" : fromName;
        }

        return file.ContentType switch
        {
            "image/png" => ".png",
            "image/webp" => ".webp",
            "image/gif" => ".gif",
            _ => ".jpg"
        };
    }
}
