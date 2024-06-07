using maERP.Shared.Wrapper;
using maERP.SharedUI.Contracts;
using maERP.SharedUI.Models.Order;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace maERP.SharedUI.Pages.Orders;

public partial class Orders
{
    [Inject]
    public required NavigationManager _navigationManager { get; set; }

    [Inject]
    public required IOrderService _orderService { get; set; }

    private string _searchString = string.Empty;

    private async Task<GridData<OrderListVM>> LoadGridData(GridState<OrderListVM> state)
    {
        var apiResponse = await _orderService.GetOrders(state.Page, state.PageSize);
        GridData<OrderListVM> data = new()
        {
            Items = apiResponse.Data,
            TotalItems = apiResponse.TotalCount
        };

        return data;
    }
}