namespace Application.Products.Get
{
    public record GetProductsQuery(string? SearchTerm, string? SortColumn, string? SortOrder, int Page, int PageSize);
}
