using System.Text.RegularExpressions;

namespace ApartamentosRenta.Services;

public static partial class StampSealContractDynamicEnricher
{
    public static string Enrich(string html)
    {
        if (string.IsNullOrEmpty(html) || html.Contains("contract-dynamic-items", StringComparison.Ordinal))
        {
            return html;
        }

        var stampsAmount = FormatMoney(StampSealSettings.StampsAmount);
        var sealsAmount = FormatMoney(StampSealSettings.SealsAmount);
        var totalAmount = FormatMoney(StampSealSettings.TotalAmount);

        var result = html;

        result = PurposePattern().Replace(result,
            "buy <span class=\"contract-dynamic-items-long\">official stamps and seals</span> through");

        result = ItemsStampsPattern().Replace(result,
            $"""<li data-purchase-line="stamps">Official stamps package: <strong>{stampsAmount}</strong></li>""");

        result = ItemsSealsPattern().Replace(result,
            $"""<li data-purchase-line="seals">Official seals package: <strong>{sealsAmount}</strong></li>""");

        result = TotalDuePattern().Replace(result, match =>
            $"""<strong>Total due:</strong> <strong class="contract-dynamic-total">{match.Groups[1].Value}</strong>""");

        result = StampSealDocPattern().Replace(result,
            "<span class=\"contract-dynamic-doc\">stamp and seal</span>");

        result = DeliveryItemsPattern().Replace(result,
            "<span class=\"contract-dynamic-items-cap\">Stamps and seals</span> <span class=\"contract-dynamic-verb\">are</span>");

        result = MisusePattern().Replace(result,
            "<span class=\"contract-dynamic-misuse\">stamps or seals</span>");

        result = RefundPattern().Replace(result,
            "Once <span class=\"contract-dynamic-refund\">stamps or seals</span> are ordered");

        result = AckItemsPattern().Replace(result,
            "that <span class=\"contract-dynamic-items\">stamps and seals</span> are required");

        result = AckTotalPattern().Replace(result,
            $"""total amount of <strong class="contract-dynamic-total">{totalAmount}</strong>""");

        return result;
    }

    private static string FormatMoney(decimal amount) =>
        "$" + amount.ToString("N0", System.Globalization.CultureInfo.GetCultureInfo("en-US"));

    [GeneratedRegex(@"buy official stamps and seals through", RegexOptions.IgnoreCase)]
    private static partial Regex PurposePattern();

    [GeneratedRegex(@"<li>Official stamps package: <strong>[^<]+</strong></li>", RegexOptions.IgnoreCase)]
    private static partial Regex ItemsStampsPattern();

    [GeneratedRegex(@"<li>Official seals package: <strong>[^<]+</strong></li>", RegexOptions.IgnoreCase)]
    private static partial Regex ItemsSealsPattern();

    [GeneratedRegex(@"<strong>Total due:</strong> (\$[\d,]+)", RegexOptions.IgnoreCase)]
    private static partial Regex TotalDuePattern();

    [GeneratedRegex(@"required stamp and seal documentation", RegexOptions.IgnoreCase)]
    private static partial Regex StampSealDocPattern();

    [GeneratedRegex(@"<li>Stamps and seals are issued", RegexOptions.IgnoreCase)]
    private static partial Regex DeliveryItemsPattern();

    [GeneratedRegex(@"misuse official stamps or seals", RegexOptions.IgnoreCase)]
    private static partial Regex MisusePattern();

    [GeneratedRegex(@"Once stamps or seals are ordered", RegexOptions.IgnoreCase)]
    private static partial Regex RefundPattern();

    [GeneratedRegex(@"that stamps and seals are required", RegexOptions.IgnoreCase)]
    private static partial Regex AckItemsPattern();

    [GeneratedRegex(@"total amount of <strong>\$[\d,]+</strong>", RegexOptions.IgnoreCase)]
    private static partial Regex AckTotalPattern();
}
