namespace Server.Domain.Shared.Contracts;

    public interface IPagination
    {
        int PageIndex { get; set; }
        int PageSize { get; set; }
        string SortField { get; set; }
        string SortType { get; set; }
    }
