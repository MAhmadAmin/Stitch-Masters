namespace StitchMaster.BusinessLogic
{
    public class UserRole
    {
        private int _userRoleID;
        private string _userRoleValue;

        public int UserRoleID
        {
            get {
                Console.WriteLine("UserRoleValidator Called");
                return _userRoleID; }
            set { _userRoleID = value; }
        }
        public string UserRoleValue
        {
            get { return _userRoleValue; }
            set { _userRoleValue = value; }
        }
        public UserRole(int userRoleID, string userRoleValue)
        {
            this.UserRoleID = userRoleID;
            this.UserRoleValue = userRoleValue;
        }
    }
}
