namespace StitchMaster.BusinessLogic
{
    public class UserStateService
    {
        public string? Email { get; set; }

        public bool IsLoggedIn => !string.IsNullOrEmpty(Email);

        public void Logout()
        {
            Email = null;
        }
    }
}
