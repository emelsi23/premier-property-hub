namespace ApartamentosRenta.Services;

/// <summary>Verified royalty-free Pexels furniture/interior photos — one unique URL per product primary.</summary>
public static class FurniturePhotoLibrary
{
    private static readonly int[] PexelsIds =
    [
        1571460, 1866149, 1350789, 276583, 1571453, 1643383, 1457842, 1080721, 6758773, 6585764,
        1571468, 1571458, 1571459, 1648776, 2089698, 2098913, 2121121, 271816, 279719, 271795,
        271805, 280232, 280221, 280222, 667838, 1090638, 1125135, 1148955, 1169103, 1170412,
        1329711, 1396122, 1454806, 1457847, 1571463, 1571467, 1669799, 1743229, 1743231, 1827054,
        189333, 2029667, 2079246, 2082087, 210265, 210604, 2156881, 2227838, 2251247, 2343468,
        2440471, 2478248, 259580, 2635038, 271643, 2724748, 2724749, 2747901, 276724, 279618,
        280229, 280233, 2826787, 2883049, 2883047, 3201763, 3209035, 3315291, 3316922, 3330807,
        3355732, 3457200, 3623770, 373548, 373549, 374870, 3757055, 3935331, 3965513, 4050315,
        4050318, 4050320, 4112236, 4112237, 4207785, 4207791, 4392270, 447592, 4506271, 4506283,
        462235, 4846097, 4846100, 4846101, 5089208, 534151, 5632371, 5632402, 5824883, 5824903,
        5824904, 6032280, 6032281, 6032418, 6032422, 6186810, 6186815, 6585759, 6585761, 6585766,
        6585768, 6585770, 6758771, 6758775, 6782358, 7538068, 7538070, 7538071, 8135285, 8135286,
        8135287, 8135288, 8135289, 8135290, 8135291, 8135292, 8135293
    ];

    public static int Count => PexelsIds.Length;

    public static string Url(int index) =>
        $"https://images.pexels.com/photos/{PexelsIds[index]}/pexels-photo-{PexelsIds[index]}.jpeg?auto=compress&cs=tinysrgb&w=1200";

    /// <summary>Two distinct photos for product at catalog index (primary is unique across first Count products).</summary>
    public static string[] PairFor(int productIndex)
    {
        var primary = productIndex % PexelsIds.Length;
        var secondary = (productIndex + 41) % PexelsIds.Length;
        if (secondary == primary)
        {
            secondary = (primary + 1) % PexelsIds.Length;
        }

        return [Url(primary), Url(secondary)];
    }
}
