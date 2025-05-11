
using StitchMaster.BusinessLogic;
using StitchMaster.DataLayer;
using StitchMaster.HelperClasses;

namespace StitchMaster.Components.Layout
{
    public partial class NavMenu
    {
        protected override void OnInitialized()
        {
            UserState.OnChange += StateHasChanged;
        }

        public void Dispose()
        {
            UserState.OnChange -= StateHasChanged;
        }

        private void Logout()
        {
            UserState.Logout();
            CurrentUser.ClearCurrentUser();
            Navigation.NavigateTo("/");
        }
    }
}
