using ApartamentosRenta.Models;

namespace ApartamentosRenta.Services;

public static class PropertyContractContentHelper
{
    public static (string Title, string Subtitle, string NoticeHtml, string BodyHtml) GetLeaseContent(
        LeaseContract contract,
        PropertyContentLanguage language)
    {
        if (language == PropertyContentLanguage.Spanish && HasSpanishLease(contract))
        {
            return (
                contract.TitleEs!.Trim(),
                string.IsNullOrWhiteSpace(contract.SubtitleEs) ? contract.Subtitle : contract.SubtitleEs!.Trim(),
                string.IsNullOrWhiteSpace(contract.NoticeHtmlEs) ? contract.NoticeHtml : contract.NoticeHtmlEs!.Trim(),
                string.IsNullOrWhiteSpace(contract.BodyHtmlEs) ? contract.BodyHtml : contract.BodyHtmlEs!.Trim());
        }

        return (contract.Title, contract.Subtitle, contract.NoticeHtml, contract.BodyHtml);
    }

    public static (string Title, string Subtitle, string NoticeHtml, string BodyHtml) GetStampSealContent(
        StampSealContract contract,
        PropertyContentLanguage language)
    {
        if (language == PropertyContentLanguage.Spanish && HasSpanishStampSeal(contract))
        {
            return (
                contract.TitleEs!.Trim(),
                string.IsNullOrWhiteSpace(contract.SubtitleEs) ? contract.Subtitle : contract.SubtitleEs!.Trim(),
                string.IsNullOrWhiteSpace(contract.NoticeHtmlEs) ? contract.NoticeHtml : contract.NoticeHtmlEs!.Trim(),
                string.IsNullOrWhiteSpace(contract.BodyHtmlEs) ? contract.BodyHtml : contract.BodyHtmlEs!.Trim());
        }

        return (contract.Title, contract.Subtitle, contract.NoticeHtml, contract.BodyHtml);
    }

    private static bool HasSpanishLease(LeaseContract contract) =>
        !string.IsNullOrWhiteSpace(contract.TitleEs);

    private static bool HasSpanishStampSeal(StampSealContract contract) =>
        !string.IsNullOrWhiteSpace(contract.TitleEs);
}
