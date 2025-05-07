using StitchMaster.HelperClasses;

namespace StitchMaster.BusinessLogic
{
    public class UserRole
    {
        // Backing Fields
        private readonly int _roleID;
        private string _roleName;

        #region Getter Setter Start --------------------------------------------
        public int RoleID
        {
            get { return _roleID; }
            
        }
        public string RoleName
        {
            get { return _roleName; }
            set { _roleName = value; }
        }

        #endregion Getter Setter Start --------------------------------------------

        #region Constructors Start ----------------------------------------------
        public UserRole(int userRoleID, string userRoleValue)
        {
            if (IsValid.DBID(userRoleID))
            {
            this._roleID = userRoleID;
            }
            else
            {
                throw new InvalidOperationException("Invalid User Role ID");
            }
            this._roleName = userRoleValue;
        }
        #endregion Constructors Start ----------------------------------------------
    }
}
