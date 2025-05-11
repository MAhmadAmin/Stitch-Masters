using StitchMaster.BusinessLogic;

namespace StitchMaster.Interfaces
{
    public interface IStatusData
    {
        public bool StoreObject(Status status);
        public bool DeleteObject(Status status);
        public bool UpdateObject(Status status);
        public List<Status> GetAllObjects();
    }
}
