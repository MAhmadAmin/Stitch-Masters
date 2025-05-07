namespace StitchMaster.BusinessLogic
{
    public class UserStateService
    {
        public string? Email { get; set; }
        public string? Role { get; set; }

        public bool IsLoggedIn => !string.IsNullOrEmpty(Email);

        public event Action? OnChange;

        public void SetEmail(string email,string role)
        {
            Email = email;
            Role = role;
            NotifyStateChanged();
        }

        public void Logout()
        {
            Email = null;
            Role = null;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
