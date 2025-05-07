using StitchMaster.BusinessLogic;
using StitchMaster.DataLayer;
using StitchMaster;
using Microsoft.AspNetCore.Components;

namespace StitchMaster.Components.Pages
{
    public partial class Signin
    {
        private string email;
        private string password;
        private LoginStatus loginStatus = LoginStatus.None;
        private string userRoleName = null;
        [Inject] public UserStateService UserState { get; set; }
        [Inject] public NavigationManager Navigation { get; set; }
        private void Login()
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                bool isValidUser = UserData.IsValidUser(email, password);
                if (isValidUser)
                {
                    userRoleName = UserRoleData.Instance.GetUserRoleByEmail(email).RoleName;
                    loginStatus = LoginStatus.Success;
                    UserState.SetEmail(email, userRoleName);
                    if(userRoleName == "Customer")
                    {
                    Navigation.NavigateTo("/customer-dashboard");
                    }else if(userRoleName == "Tailor")
                    {
                        Navigation.NavigateTo("/tailor-dashboard");

                    }else if(userRoleName == "FabricStore")
                    {
                        Navigation.NavigateTo("/fabric-dashboard");

                    }else if(userRoleName == "Admin")
                    {
                        Navigation.NavigateTo("/admin-dashboard");

                    }
                }
                else
                {
                    loginStatus = LoginStatus.InvalidCredentials;
                }
            }
            else
            {
                loginStatus = LoginStatus.MissingFields;
            }
        }


        private enum LoginStatus
        {
            None,
            Success,
            InvalidCredentials,
            MissingFields
        }
    }
}
