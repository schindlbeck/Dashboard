using BlazorTest.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorTest.Pages
{
    public partial class DragDrop
    {
        List<DataModel> DataModels = new();

        protected override void OnInitialized()
        {
            DataModels.Add(new DataModel { Id = 1, Name = "Blau" });
            DataModels.Add(new DataModel { Id = 2, Name = "Rot" });
            DataModels.Add(new DataModel { Id = 3, Name = "Gelb" });
            DataModels.Add(new DataModel { Id = 4, Name = "Grün" });
            DataModels.Add(new DataModel { Id = 5, Name = "Lila" });
        }
    }
}
