namespace StitchMaster.HelperClasses
{
    public static class CurrentUser
    {
        public static string Email { get; set; }
        public static string RoleName { get; set; }
        public static void SetCurrentUser(string email, string roleName)
        {
            Email = email;
            RoleName = roleName;
        }
        public static void ClearCurrentUser()
        {
            Email = null;
            RoleName = null;
        }
    }
}
