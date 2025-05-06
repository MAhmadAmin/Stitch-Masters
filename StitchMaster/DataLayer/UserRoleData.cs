namespace StitchMaster.DataLayer
{
    public class UserRoleData
    {
        static private UserRoleData _userRoleData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private UserRoleData() { }

        static public UserRoleData Instance
        {
            get
            {
                if (_userRoleData == null) // 1st Check (Multiple Threads Can Execute)
                {
                    lock (_lock)
                    {
                        if (_userRoleData == null) // 2nd Check  (Only Single Thread Can Execute)
                        {
                            _userRoleData = new UserRoleData();
                        }
                    }
                }
                return _userRoleData;
            }
        }
    }
}
