namespace BuberDinner.Contracts.Menu
{
    public record MenuResponse
   (
       string Id,
        string Name,
        string Description,
         string HostId,
        float AverageRating,
        List<MenuSectionResponse> Sections,
        List<string> DinnerIds,
        List<string> MenuReviewIds,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime
    );

    public record MenuSectionResponse(
        string Id,
        string Name,
        string Description,
        List<MenuItemResponse> Items
    );

    public record MenuItemResponse(
        string Id,
        string Name,
        string Description
    );
}