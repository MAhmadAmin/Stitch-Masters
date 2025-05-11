using StitchMaster.BusinessLogic;

namespace StitchMaster.Interfaces
{
    public interface ITailorData
    {
        public bool StoreObject(Tailor tailor);
        public bool DeleteObject(Tailor tailor);
        public bool UpdateObject(Tailor tailor);
        public List<Tailor> GetAllObjects();
        public int GetTailorUserId(int tailorid);
        public Tailor GetTailorByID(int ID);
        public Tailor GetTailorByEmail(string email);
    }
}
