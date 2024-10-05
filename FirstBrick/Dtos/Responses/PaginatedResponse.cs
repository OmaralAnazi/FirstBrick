namespace FirstBrick.Dtos.Responses;
public class PaginatedResponse<T>(List<T> items, int totalCount, int pageNumber, int pageSize)
{
    public List<T> Items { get; set; } = items;
    public int PageNumber { get; set; } = pageNumber;
    public int PageSize { get; set; } = pageSize;
    public int TotalCount { get; set; } = totalCount;
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
}
