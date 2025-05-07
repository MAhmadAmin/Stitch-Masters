
namespace StitchMaster.Components.Layout
{
    public partial class NavMenu
    {
        private void Logout()
        {
            UserState.Logout();
            Navigation.NavigateTo("/");
        }
    }
}
