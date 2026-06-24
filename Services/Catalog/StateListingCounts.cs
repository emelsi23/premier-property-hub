namespace ApartamentosRenta.Services.Catalog;

internal static class StateListingCounts
{
  private static readonly Dictionary<string, int> Overrides = new(StringComparer.OrdinalIgnoreCase)
  {
    ["CA"] = 10,
    ["NJ"] = 8,
    ["NY"] = 10,
    ["TX"] = 10,
    ["FL"] = 9,
    ["MN"] = 8,
    ["IL"] = 8,
    ["PA"] = 7,
    ["OH"] = 6,
    ["GA"] = 8,
    ["NC"] = 7,
    ["VA"] = 7,
    ["WA"] = 8,
    ["AZ"] = 7,
    ["MA"] = 8,
    ["CO"] = 7,
    ["TN"] = 6,
    ["MI"] = 7,
    ["MD"] = 7,
    ["OR"] = 6,
    ["NV"] = 6,
    ["CT"] = 5,
    ["UT"] = 5,
    ["SC"] = 5,
    ["DC"] = 4,
    ["WY"] = 4,
    ["VT"] = 4,
    ["AK"] = 4,
    ["ND"] = 4,
    ["SD"] = 4,
  };

  public static int GetForState(string stateCode)
  {
    if (Overrides.TryGetValue(stateCode, out var count))
    {
      return count;
    }

    return 5;
  }
}
