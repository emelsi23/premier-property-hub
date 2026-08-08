using System.Text.RegularExpressions;

namespace ApartamentosRenta.Services.Catalog;

internal static class CatalogSpanishTranslator
{
    private static readonly (string Pattern, string Replacement)[] TitleReplacements =
    [
        (@"(\d+)\s+bd\s*·\s*(\d+)\s+ba", "$1 hab · $2 baño"),
        (@"(\d+)\s+bd", "$1 hab"),
        (@"(\d+)\s+ba\b", "$1 baño"),
    ];

    private static readonly (string English, string Spanish)[] AmenityPhrases =
    [
        ("In Unit Washer & Dryer", "Lavadora y secadora en unidad"),
        ("In-Unit Laundry", "Lavandería en unidad"),
        ("On-Site Laundry", "Lavandería en el sitio"),
        ("On-Site Management", "Administración en el sitio"),
        ("Fitness Center", "Gimnasio"),
        ("Fitness Studio", "Estudio de fitness"),
        ("Controlled Access", "Acceso controlado"),
        ("Package Lockers", "Casilleros para paquetes"),
        ("Pet Friendly", "Se admiten mascotas"),
        ("Pets Allowed", "Se admiten mascotas"),
        ("Pet Services", "Servicios para mascotas"),
        ("Pet Spa", "Spa para mascotas"),
        ("Rooftop Deck", "Terraza en la azotea"),
        ("Rooftop Terrace", "Terraza en la azotea"),
        ("Garage Parking", "Estacionamiento en garaje"),
        ("Coworking Lounge", "Sala coworking"),
        ("EV Charging", "Carga para vehículos eléctricos"),
        ("Bike Storage", "Almacenamiento para bicicletas"),
        ("Guest Parking", "Estacionamiento para visitas"),
        ("Hot Tub", "Jacuzzi"),
        ("Business Center", "Centro de negocios"),
        ("Dog Park", "Parque para perros"),
        ("Walk-In Closets", "Closets walk-in"),
        ("Hardwood Floors", "Pisos de madera"),
        ("Hard Surface Flooring", "Pisos de superficie dura"),
        ("Double Pane Windows", "Ventanas de doble panel"),
        ("Off-Street Parking", "Estacionamiento fuera de la calle"),
        ("Gated Parking", "Estacionamiento con portón"),
        ("Stainless Steel Appliances", "Electrodomésticos de acero inoxidable"),
        ("Quartz Countertops", "Encimeras de cuarzo"),
        ("Granite Countertops", "Encimeras de granito"),
        ("Wall AC", "Aire acondicionado de pared"),
        ("Air Conditioning", "Aire acondicionado"),
        ("Large Closet", "Closet amplio"),
        ("Spacious Closets", "Closets amplios"),
        ("Basketball Court", "Cancha de baloncesto"),
        ("Fire Pit", "Fogata"),
        ("Self-Guided Tours", "Visitas autoguiadas"),
        ("BBQ Area", "Área de BBQ"),
        ("DIY Space", "Espacio DIY"),
        ("Washer/Dryer", "Lavadora/secadora"),
        ("Dishwasher", "Lavavajillas"),
        ("Microwave", "Microondas"),
        ("Refrigerator", "Refrigerador"),
        ("Stove", "Estufa"),
        ("Elevator", "Ascensor"),
        ("Parking", "Estacionamiento"),
        ("Balcony", "Balcón"),
        ("Concierge", "Conserje"),
        ("Clubroom", "Sala club"),
        ("Playground", "Área de juegos"),
        ("Courtyard", "Patio interior"),
        ("Garage", "Garaje"),
        ("Pool", "Piscina"),
        ("Spa", "Spa"),
    ];

    public static CatalogProperty Localize(CatalogProperty property)
    {
        var titulo = TranslateTitle(property.Titulo);
        var amenities = TranslateAmenities(property.Amenidades);
        var descripcion = CatalogSpanishDescriptions.TryGetDescription(property.Slug)
            ?? TranslateDescriptionFallback(property.Descripcion);

        return property with
        {
            Titulo = titulo,
            Amenidades = amenities,
            Descripcion = descripcion
        };
    }

    public static string TranslateTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return title;
        }

        var result = title;
        foreach (var (pattern, replacement) in TitleReplacements)
        {
            result = Regex.Replace(result, pattern, replacement, RegexOptions.IgnoreCase);
        }

        return result;
    }

    public static string TranslateAmenities(string amenities)
    {
        if (string.IsNullOrWhiteSpace(amenities))
        {
            return amenities;
        }

        var result = amenities;
        foreach (var (english, spanish) in AmenityPhrases.OrderByDescending(p => p.English.Length))
        {
            result = Regex.Replace(
                result,
                Regex.Escape(english),
                spanish,
                RegexOptions.IgnoreCase);
        }

        return result;
    }

    private static string TranslateDescriptionFallback(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            return description;
        }

        var lines = description.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        if (lines.Length == 0)
        {
            return description;
        }

        return string.Join(
            "\n\n",
            lines.Select(line => CatalogSpanishDescriptionPhrases.TranslateLine(line)));
    }
}
