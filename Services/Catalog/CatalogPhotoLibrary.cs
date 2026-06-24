namespace ApartamentosRenta.Services.Catalog;

internal static class CatalogPhotoLibrary
{
    public const int PhotosPerListing = 8;

    /// <summary>Verified working Unsplash URLs (HTTP 200 tested).</summary>
    private static readonly string[] Pool =
    [
        "https://images.unsplash.com/photo-1600585154084-4e5fe7c39198?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600585154363-67eb9e2e2099?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600566752355-35792bedcfea?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600585152915-d208bec867a1?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600573472550-8090b5e0745e?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600585154526-990dced4db0d?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600607687920-4e2a09cf159d?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1613490493576-7fde63acd811?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600210492486-724fe5c67fb0?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600566753190-17f0baa2a6c3?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600607687939-ce8a6c25118c?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600596542815-ffad4c1539a9?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1512917774080-9991f1c4c750?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1493809842364-78817add7ffb?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1564013799919-ab600027ffc6?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1522708323590-d24dbb6b0267?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1560448204-e02f11c3d0e2?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1502672260266-1c1ef2d93688?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1560185127-6ed189bf02f4?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1560185007-c5ca9d2c014d?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1570129477492-45c003edd2be?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1580587771525-78b9dba3b914?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1605146769289-440113cc3d00?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600607687644-c7171b42498f?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1631679706909-1844bbd07221?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1554995207-c18c203602cb?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1540518614846-7eded433c457?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1505693416388-ac5ce068fe85?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1513694203232-719a280e022f?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1523217582562-09d0def993a6?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1480074568708-e7b720bb3f09?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1479839672679-a46483c0e7c8?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1460317442991-0ec209397118?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1414235077428-338989a2e8c0?w=960&h=640&fit=crop&q=80&auto=format",
    ];

    public static string FallbackUrl => Pool[17];

    public static string[] GetPhotosForSlug(string slug) =>
        GetPhotosForListing(StringComparer.OrdinalIgnoreCase.GetHashCode(slug));

    public static string[] GetPhotosForListing(int seed, int count = PhotosPerListing)
    {
        var start = Math.Abs(seed) % Pool.Length;
        var photos = new string[count];

        for (var i = 0; i < count; i++)
        {
            photos[i] = Pool[(start + i) % Pool.Length];
        }

        return photos;
    }

    public static string[] MergeWithListingPhotos(IReadOnlyList<string> primary, string slug, int total = PhotosPerListing)
    {
        var merged = new List<string>(primary.Where(IsTrustedPhotoUrl));
        foreach (var url in GetPhotosForSlug(slug))
        {
            if (merged.Count >= total)
            {
                break;
            }

            if (!merged.Contains(url, StringComparer.OrdinalIgnoreCase))
            {
                merged.Add(url);
            }
        }

        while (merged.Count < total)
        {
            merged.Add(Pool[merged.Count % Pool.Length]);
        }

        return merged.Take(total).ToArray();
    }

    private static bool IsTrustedPhotoUrl(string url) =>
        !string.IsNullOrWhiteSpace(url)
        && (url.Contains("images.unsplash.com", StringComparison.OrdinalIgnoreCase)
            || url.Contains("ivesinvergrove.com", StringComparison.OrdinalIgnoreCase)
            || url.Contains("picsum.photos", StringComparison.OrdinalIgnoreCase));
}
