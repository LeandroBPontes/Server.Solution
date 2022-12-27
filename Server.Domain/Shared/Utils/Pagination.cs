
using System.Text.Json.Serialization;
using Server.Domain.Shared.Contracts;

namespace Server.Domain.Shared.Utils;

public class Pagination : IPagination
{
    private int _pageSize = 20;

    public virtual int PageIndex { get; set; } = 1;

    public virtual int PageSize
    {
        get => this._pageSize <= this.MaxPageSize ? this._pageSize : this.MaxPageSize;
        set => this._pageSize = value;
    }

    public virtual string SortField { get; set; } = "Id";

    public virtual string SortType { get; set; } = "asc";

    [JsonIgnore]
    public virtual int MaxPageSize { get; set; } = 20;
}
