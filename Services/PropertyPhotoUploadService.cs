using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ApartamentosRenta.Services;

public sealed class PropertyPhotoUploadService(IWebHostEnvironment environment)
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
        "properties");

    public IReadOnlyList<string> ValidateFiles(IReadOnlyList<IFormFile> files)
    {
        var errors = new List<string>();
        foreach (var file in files.Where(f => f.Length > 0))
        {
            if (file.Length > MaxBytes)
            {
                errors.Add($"{file.FileName}: máximo 5 MB.");
                continue;
            }

            if (!IsAllowedImage(file))
            {
                errors.Add($"{file.FileName}: solo JPG, PNG, WEBP o GIF.");
            }
        }

        return errors;
    }

    public async Task<IReadOnlyList<string>> SaveAsync(int propertyId, IReadOnlyList<IFormFile> files)
    {
        var urls = new List<string>();
        var directory = Path.Combine(_baseDirectory, propertyId.ToString());
        Directory.CreateDirectory(directory);

        foreach (var file in files.Where(f => f.Length > 0))
        {
            if (file.Length > MaxBytes || !IsAllowedImage(file))
            {
                continue;
            }

            var extension = ResolveExtension(file);
            var fileName = $"{Guid.NewGuid():N}{extension}";
            var fullPath = Path.Combine(directory, fileName);

            await using var stream = File.Create(fullPath);
            await file.CopyToAsync(stream);

            urls.Add($"/uploads/properties/{propertyId}/{fileName}");
        }

        return urls;
    }

    public void TryDeletePropertyFolder(int propertyId)
    {
        var directory = Path.Combine(_baseDirectory, propertyId.ToString());
        if (Directory.Exists(directory))
        {
            Directory.Delete(directory, recursive: true);
        }
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
