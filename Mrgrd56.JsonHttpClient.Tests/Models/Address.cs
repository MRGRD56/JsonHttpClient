namespace Mrgrd56.JsonHttpClient.Tests.Models
{
    public record Address(
        string Street,
        string Suite,
        string City,
        string Zipcode,
        Geo Geo);
}