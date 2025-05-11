using StitchMaster.BusinessLogic;

namespace StitchMaster.Interfaces
{
    public interface IUserRoleData
    {
        public bool StoreObject(UserRole userRole);
        public bool DeleteObject(UserRole userRole);
        public bool UpdateObject(UserRole userRole);
        public List<UserRole> GetAllObjects();
        public UserRole GetUserRoleByEmail(string email);
        public UserRole GetRoleByName(string roleName);
        public UserRole GetRoleByID(int ID);
    }
}
