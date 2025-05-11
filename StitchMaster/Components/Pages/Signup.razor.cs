using StitchMaster.BusinessLogic;
using StitchMaster.DataLayer;
using Microsoft.AspNetCore.Components;

namespace StitchMaster.Components.Pages
{
    public partial class Signup
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        private string Username, FullName, Email, Password, ConfirmPassword, GenderString;
        Gender.GenderType GenderEnum;
        private DateOnly DOB = new DateOnly(2000, 1, 1);

        // Error messages  
        private string UsernameError, EmailError, PasswordError, ConfirmPasswordError;

        // Success state  
        private bool SignUpSuccess = false;
        private bool SignupFailure = false;

        private async void CreateAccount()
        {
            ClearErrors();
            bool hasError = false;

            if (UserData.Instance.UsernameExists(Username))
            {
                UsernameError = "Username already exists.";
                hasError = true;
            }

            if (UserData.Instance.EmailExists(Email))
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

            //if (GenderString == "Male")
            //    GenderEnum = Gender.GenderType.M;
            //else if (GenderString == "Female")
            //    GenderEnum = Gender.GenderType.F;
            //else if (GenderString == "Other")
            //    GenderEnum = Gender.GenderType.O;
            GenderEnum = Gender.StringToGenderType(GenderString);

            UserRole ur = UserRoleData.Instance.GetRoleByName("Customer"); 
            Customer c = new Customer(GenderEnum, DOB, Username, FullName, Email, Password, ur);
            bool result = CustomerData.Instance.StoreObject(c);

            if (result)
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
            Username = FullName = Email = Password = ConfirmPassword = string.Empty;
            DOB = new DateOnly(2000, 1, 1);
        }
    }
}