using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using StitchMaster.BusinessLogic;
using StitchMaster.DataLayer;

namespace StitchMaster.Components.Pages
{
    public partial class Tailor_TailorOrderDetails
    {
        [Inject] NavigationManager navigationManager { get; set; }
        [Parameter] public int TailorOrderID { get; set; }

        static TailorOrder order;
        protected override async Task OnInitializedAsync()
        {
            order = TailorOrderData.Instance.GetOrderByID(TailorOrderID);
        }

        private void Refresh()
        {
            order = TailorOrderData.Instance.GetOrderByID(TailorOrderID);

        }

        void GoBack()
        {
            navigationManager.NavigateTo("/tailor/my-orders");
        }
        void MarkComplete()
        {
            TailorOrderData.Instance.MarkCompleted(TailorOrderID);
            navigationManager.NavigateTo("/tailor/my-orders");
        }
    }
}
