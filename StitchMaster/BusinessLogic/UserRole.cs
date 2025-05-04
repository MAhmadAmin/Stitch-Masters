namespace StitchMaster.BusinessLogic
{
    public class UserRole
    {
        // Backing Fields
        private readonly int _userRoleID;
        private string _userRoleValue;

        public int UserRoleID
        {
            get { return _userRoleID; }

        }
        public string UserRoleValue
        {
            get { return _userRoleValue; }
            set { _userRoleValue = value; }
        }
        public UserRole(int userRoleID, string userRoleValue)
        {
            if (IsValid.DBID(userRoleID))
            {
                this._userRoleID = userRoleID;
            }
            else
            {
                throw new InvalidOperationException("Invalid User Role ID");
            }
            this.UserRoleValue = userRoleValue;
        }
    }
}