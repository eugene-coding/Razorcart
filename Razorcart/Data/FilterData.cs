namespace Razorcart.Data;

public struct FilterData
{
    public FilterData(int itemsPerPage)
    {
        Take = itemsPerPage < 0 ? 0 : itemsPerPage;
    }

    public FilterData(int itemsPerPage, int page) : this(itemsPerPage)
    {
        if (page < 1)
        {
            page = 1;
        }

        Skip = (page - 1) * itemsPerPage;
    }

    public FilterData(int itemsPerPage, int page, Order order) : this(itemsPerPage, page)
    {
        Order = order;
    }

    public Order Order { get; private set; } = Order.Ascending;
    public int Skip { get; private set; } = 0;
    public int Take { get; private set; }
}

public enum Order
{
    Ascending,
    Descending
}
