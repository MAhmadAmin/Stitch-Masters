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
                    UserState.Email = email;
                    Navigation.NavigateTo("/");
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
