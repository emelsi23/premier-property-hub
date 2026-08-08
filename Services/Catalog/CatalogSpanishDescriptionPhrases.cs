namespace ApartamentosRenta.Services.Catalog;

internal static class CatalogSpanishDescriptionPhrases
{
    private static readonly (string English, string Spanish)[] Phrases =
    [
        ("state-of-the-art fitness center", "gimnasio de última generación"),
        ("state-of-the-art integrated electronics", "electrónica integrada de última generación"),
        ("in-unit washer and dryer", "lavadora y secadora en unidad"),
        ("in-unit washer/dryer", "lavadora/secadora en unidad"),
        ("in-unit washer/dryers", "lavadora/secadora en unidad"),
        ("stainless steel appliances", "electrodomésticos de acero inoxidable"),
        ("stainless-steel appliances", "electrodomésticos de acero inoxidable"),
        ("self-guided tours available", "visitas autoguiadas disponibles"),
        ("Matterport 3D tours available", "visitas 3D con Matterport disponibles"),
        ("Matterport 3D tours", "visitas 3D con Matterport"),
        ("floor-to-ceiling windows", "ventanas de piso a techo"),
        ("resort-style fitness center", "gimnasio estilo resort"),
        ("resort-style pool and spa", "piscina y spa estilo resort"),
        ("resort-style pool deck", "deck de piscina estilo resort"),
        ("resort-style pool", "piscina estilo resort"),
        ("resort-inspired amenities", "amenidades inspiradas en resort"),
        ("resort-inspired features", "características inspiradas en resort"),
        ("resort-inspired courtyard", "patio interior inspirado en resort"),
        ("contemporary finishes", "acabados contemporáneos"),
        ("modern fitness center", "gimnasio moderno"),
        ("modern finishes", "acabados modernos"),
        ("premium finishes", "acabados premium"),
        ("upscale amenities", "amenidades de lujo"),
        ("upscale features", "características de lujo"),
        ("spacious floor plans", "planos espaciosos"),
        ("open floor plans", "planos abiertos"),
        ("open-concept kitchens", "cocinas de concepto abierto"),
        ("quartz countertops", "encimeras de cuarzo"),
        ("granite countertops", "encimeras de granito"),
        ("hardwood floors", "pisos de madera"),
        ("hardwood flooring", "pisos de madera"),
        ("controlled access", "acceso controlado"),
        ("rooftop terrace", "terraza en la azotea"),
        ("rooftop deck", "terraza en la azotea"),
        ("rooftop pool", "piscina en la azotea"),
        ("rooftop lounge", "lounge en la azotea"),
        ("panoramic views", "vistas panorámicas"),
        ("panoramic city views", "vistas panorámicas de la ciudad"),
        ("city views", "vistas de la ciudad"),
        ("stunning city views", "impresionantes vistas de la ciudad"),
        ("walking distance", "a poca distancia a pie"),
        ("walk to", "caminar a"),
        ("steps from", "a pasos de"),
        ("luxury high-rise", "torre de lujo"),
        ("modern high-rise", "torre moderna"),
        ("boutique living", "vida boutique"),
        ("pet-friendly", "se admiten mascotas"),
        ("pet friendly", "se admiten mascotas"),
        ("fitness center", "gimnasio"),
        ("concierge services", "servicios de conserjería"),
        ("concierge service", "servicio de conserjería"),
        ("natural light", "luz natural"),
        ("abundant natural light", "abundante luz natural"),
        ("move-in specials", "ofertas de mudanza"),
        ("budget-friendly", "económico"),
        ("virtual tours", "visitas virtuales"),
        ("virtual tours offered", "visitas virtuales disponibles"),
        ("hot tub", "jacuzzi"),
        ("EV charging", "carga para vehículos eléctricos"),
        ("bike storage", "almacenamiento para bicicletas"),
        ("co-working spaces", "espacios de coworking"),
        ("co-working space", "espacio de coworking"),
        ("keyless entry", "entrada sin llave"),
        ("package lockers", "casilleros para paquetes"),
        ("private balconies", "balcones privados"),
        ("private balcony", "balcón privado"),
        ("easy freeway access", "fácil acceso a autopistas"),
        ("easy access to", "fácil acceso a"),
        ("near transit", "cerca del transporte público"),
        ("near BART", "cerca de BART"),
        ("near parks", "cerca de parques"),
        ("near beach", "cerca de la playa"),
        ("near shopping", "cerca de tiendas"),
        ("near museums", "cerca de museos"),
        ("luxury apartments", "apartamentos de lujo"),
        ("modern apartments", "apartamentos modernos"),
        ("apartment community", "comunidad de apartamentos"),
        ("apartment homes", "hogares en apartamento"),
        ("one-bedroom", "de una habitación"),
        ("two-bedroom", "de dos habitaciones"),
        ("studio and", "estudio y"),
        ("studios and", "estudios y"),
        ("built in", "construido en"),
        ("newly-constructed", "recién construido"),
        ("newly renovated", "recién renovado"),
        ("remodeled", "remodelado"),
        ("renovated", "renovado"),
        ("furnished and unfurnished", "amueblado y sin amueblar"),
        ("furnished units", "unidades amuebladas"),
        ("smart home features", "funciones de hogar inteligente"),
        ("smart home", "hogar inteligente"),
        ("sky lounge", "sky lounge"),
        ("infinity pool", "piscina infinita"),
        ("private cabanas", "cabañas privadas"),
        ("grilling area", "área de parrilla"),
        ("fire pit", "fogata"),
        ("dog park", "parque para perros"),
        ("business center", "centro de negocios"),
        ("community amenities", "amenidades comunitarias"),
        ("community spaces", "espacios comunitarios"),
        ("dining and entertainment", "restaurantes y entretenimiento"),
        ("restaurants and nightlife", "restaurantes y vida nocturna"),
        ("shopping and dining", "compras y restaurantes"),
        ("pool", "piscina"),
        ("spa", "spa"),
        ("concierge", "conserje"),
        ("balcony", "balcón"),
        ("elevator", "ascensor"),
        ("parking", "estacionamiento"),
    ];

    public static string TranslateLine(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            return line;
        }

        var result = line;
        foreach (var (english, spanish) in Phrases)
        {
            result = ReplaceIgnoreCase(result, english, spanish);
        }

        return result;
    }

    private static string ReplaceIgnoreCase(string input, string oldValue, string newValue)
    {
        var index = 0;
        while ((index = input.IndexOf(oldValue, index, StringComparison.OrdinalIgnoreCase)) >= 0)
        {
            input = string.Concat(input.AsSpan(0, index), newValue, input.AsSpan(index + oldValue.Length));
            index += newValue.Length;
        }

        return input;
    }
}
