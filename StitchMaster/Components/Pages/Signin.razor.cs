using StitchMaster.BusinessLogic;
using StitchMaster.DataLayer;

namespace StitchMaster.Components.Pages
{
    public partial class Signin
    {
        private string email;
        private string password;
        private LoginStatus loginStatus = LoginStatus.None;
        private string userRoleName = null;

        private void Login()
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                bool isValidUser = UserData.IsValidUser(email, password);
                if (isValidUser)
                {
                    userRoleName = UserRoleData.Instance.GetUserRoleByEmail(email).RoleName;
                    loginStatus = LoginStatus.Success;

                    //Next Functionality
                }
                else
                {
                    loginStatus = LoginStatus.InvalidCredentials;
                }
            }
            else
                loginStatus = LoginStatus.MissingFields;
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
