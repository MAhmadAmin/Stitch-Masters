using StitchMaster.BusinessLogic;

namespace StitchMaster.Interfaces
{
    public interface IRatingData
    {
        public bool StoreObject(Rating rating);
        public bool DeleteObject(Rating rating);
        public bool UpdateObject(Rating rating);
        public List<Rating> GetAllObjects();
    }
}
