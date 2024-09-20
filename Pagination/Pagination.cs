namespace induccionef.Pagination;

public class PaginationResult<T>
{
    public int totalRecords { get; set; }
    public int totalPages { get; set; }
    public int currentPage { get; set; }
    public int pageSize { get; set; }
    public IEnumerable<T> items { get; set; }

}

public class PaginationResult
{
    public static PaginationResult<T> Paginate<T>(IEnumerable<T> items, int page, int pageSize)
    {
        var totalRecords = items.Count();
        var totalPages = (int)Math.Ceiling((decimal)totalRecords / pageSize);
        var pagedItems = items.Skip((page - 1) * pageSize).Take(pageSize);

        return new PaginationResult<T>{
            totalRecords = totalRecords,
            totalPages = totalPages,
            currentPage = page,
            pageSize = pageSize,
            items = pagedItems
        };
    }
}