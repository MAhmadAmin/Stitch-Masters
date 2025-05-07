using StitchMaster.BusinessLogic;
using StitchMaster.DataLayer;

namespace StitchMaster.Components.Pages
{
    public partial class Signup
    {
        private string Username, FullName, Email, Password, ConfirmPassword, Gender, Role;
        private DateTime DOB;

        // Error messages
        private string UsernameError, EmailError, PasswordError, ConfirmPasswordError;

        // Success state
        private bool SignUpSuccess = false;

        private void CreateAccount()
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
            User u = new User(Username, FullName, Email, Password, UserRoleData.Instance.GetRoleByName(Role));
            SignUpSuccess = true;
            ClearFields();
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
            Username = FullName = Email = Password = ConfirmPassword = Gender = Role = string.Empty;
            DOB = DateTime.MinValue;
        }

    }
}