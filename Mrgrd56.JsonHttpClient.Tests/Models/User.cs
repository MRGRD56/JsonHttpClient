namespace Mrgrd56.JsonHttpClient.Tests.Models
{
    public record User(
        int Id,
        string Name,
        string Email,
        Address Address,
        string Phone,
        string Website,
        Company Company);
}