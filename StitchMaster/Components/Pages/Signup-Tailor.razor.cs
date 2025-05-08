using StitchMaster.BusinessLogic;
using StitchMaster.DataLayer;
using Microsoft.AspNetCore.Components;

namespace StitchMaster.Components.Pages
{
    public partial class Signup_Tailor
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        private string Username, FullName, Email, Password, ConfirmPassword, Description;

        // Error messages  
        private string UsernameError, EmailError, PasswordError, ConfirmPasswordError;

        // Success state  
        private bool SignUpSuccess = false;
        private bool SignupFailure = false;

        private async void CreateAccount()
        {
            ClearErrors();
            bool hasError = false;

            if (UserData.UsernameExists(Username))
            {
                UsernameError = "Username already exists.";
                hasError = true;
            }

            if (UserData.EmailExists(Email))
            {
                EmailError = "Email already in use.";
                hasError = true;
            }

            if (!IsStrongPassword(Password))
            {
                PasswordError = "Password must contain both letters and numbers.";
                hasError = true;
            }

            if (Password != ConfirmPassword)
            {
                ConfirmPasswordError = "Passwords do not match.";
                hasError = true;
            }

            if (hasError)
            {
                SignUpSuccess = false;
                return;
            }

            //User u = new User(Username, FullName, Email, Password, UserRoleData.Instance.GetRoleByName(Role));
            //UserData.StoreUser(u);
            //UserRole ur = UserRoleData.Instance.GetRoleByName("Customer");
            //Customer c = new Customer(Gender, DOB, Username, FullName, Email, Password, null, DateTime.Now, ur);
            //int result = CustomerData.Instance.StoreCustomer(c);

            int result = 1;

            if (result == 1)
            {
                SignUpSuccess = true;
                ClearFields();

                await Task.Delay(1500);
                NavigationManager.NavigateTo("/signin");
            }
            else
                SignupFailure = true;
        }

        private bool IsStrongPassword(string pwd)
        {
            return pwd.Any(char.IsLetter) && pwd.Any(char.IsDigit);
        }

        private void ClearErrors()
        {
            UsernameError = EmailError = PasswordError = ConfirmPasswordError = string.Empty;
        }

        private void ClearFields()
        {
            Username = FullName = Email = Password = ConfirmPassword = Description = string.Empty;
        }
    }
}