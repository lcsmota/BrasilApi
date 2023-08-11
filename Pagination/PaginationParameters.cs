namespace BrasilAPI.Pagination;

public class PaginationParameters
{
    const int maxPageSize = 15;
    private int _pageSize = 5;

    public int PageNumber { get; set; } = 1;
    public int QuantityOfItems
    {
        get => _pageSize;
        set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
    }
}
