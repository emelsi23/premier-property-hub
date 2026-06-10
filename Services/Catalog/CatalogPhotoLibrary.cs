namespace ApartamentosRenta.Services.Catalog;

internal static class CatalogPhotoLibrary
{
    public const int PhotosPerListing = 12;

    private static readonly string[] Pool =
    [
        "https://images.unsplash.com/photo-1502672260266-1c1ef2d93688?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1560448204-e02f11c3d0e2?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1522708323590-d24dbb6b0267?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1484154210962-1977b2b13f98?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1564013799919-ab600027ffc6?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1493809842364-78817add7ffb?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1512917774080-9991f1c4c750?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600596542815-ffad4c1539a9?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600607687939-ce8a6c25118c?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600566753190-17f0baa2a6c3?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600047509807-ba8f88d28fcc?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600210492486-724fe5c67fb0?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1605276374102-4c046148abbf?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1613490493576-7fde63acd811?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600607687920-4e2a09cf159d?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600585154526-990dced4db0d?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600573472550-8090b5e0745e?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600585152915-d208bec867a1?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600607687644-c7171b42498f?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600566752355-35792bedcfea?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600585154363-67eb9e2e2099?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600047509398-747dc7d22bd6?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600607688969-a5bfcd646cdc?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1560185127-6ed189bf02f4?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1560185007-c5ca9d2c014d?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1574643156929-51fa098b0394?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1570129477492-45c003edd2be?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1580587771525-78b9dba3b914?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1582268611954-e0fa487a412c?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1598928506311-c55ded93925c?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1605146769289-440113cc3d00?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600607687644-aac4c3eac7f4?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600566753086-00f18fb576b9?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600585154084-4e5fe7c39198?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600607687920-4e2a09cf159d?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600607687644-c7171b42498f?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600047509807-ba8f88d28fcc?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1600210492486-724fe5c67fb0?w=960&h=640&fit=crop&q=80&auto=format",
        "https://images.unsplash.com/photo-1605276374102-4c046148abbf?w=960&h=640&fit=crop&q=80&auto=format"
    ];

    public static string[] GetPhotosForSlug(string slug) =>
        GetPhotosForListing(StringComparer.OrdinalIgnoreCase.GetHashCode(slug));

    public static string[] GetPhotosForListing(int seed, int count = PhotosPerListing)
    {
        var start = Math.Abs(seed) % Pool.Length;
        const int step = 7;
        var photos = new List<string>(count);

        for (var offset = 0; photos.Count < count && offset < Pool.Length * 2; offset++)
        {
            var url = Pool[(start + offset * step) % Pool.Length];
            if (photos.Contains(url))
            {
                continue;
            }

            photos.Add(url);
        }

        return photos.ToArray();
    }

    public static string[] MergeWithListingPhotos(IReadOnlyList<string> primary, string slug, int total = PhotosPerListing)
    {
        if (primary.Count >= total)
        {
            return primary.Take(total).ToArray();
        }

        var merged = new List<string>(primary);
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

        return merged.ToArray();
    }
}
