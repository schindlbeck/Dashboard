using BlazorServer.Models;
using Dash.Data;
using Dash.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.Pages
{
    public partial class Overview
    {
        [Parameter] public List<OrderContainer> Orders { get; set; }

        protected override void OnParametersSet()
        {
            Orders = service.DataModels;
        }

    }
}
