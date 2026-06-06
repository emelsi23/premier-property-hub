namespace ApartamentosRenta.Services;

public static class DateTimeUtc
{
    public static DateTime FromForm(DateTime value) =>
        value.Kind == DateTimeKind.Utc
            ? value
            : DateTime.SpecifyKind(value, DateTimeKind.Utc);

    public static DateTime FromFormDate(DateTime value) =>
        DateTime.SpecifyKind(value.Date, DateTimeKind.Utc);
}
