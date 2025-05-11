using StitchMaster.BusinessLogic;

namespace StitchMaster.Interfaces
{
    public interface ICategoryData
    {
        public bool StoreObject(Category category);
        public bool DeleteObject(Category category);
        public bool UpdateObject(Category category);
        public List<Category> GetAllObjects();
    }
}
