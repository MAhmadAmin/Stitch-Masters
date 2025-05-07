using Microsoft.AspNetCore.Components;

namespace StitchMaster.Components.Pages
{
    public partial class Signup_as
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        private void NavigateTo(UserType userType)
        {
            if (userType == UserType.Customer)
                NavigationManager.NavigateTo("/signup/signup-as-customer");
            else if(userType == UserType.Tailor)
                NavigationManager.NavigateTo("/signup/signup-as-tailor");
            else if (userType == UserType.FabricStore)
                NavigationManager.NavigateTo("/signup/signup-as-fabricstore");
        }

        private enum UserType
        {
            Customer,
            Tailor,
            FabricStore
        }
    }
}
