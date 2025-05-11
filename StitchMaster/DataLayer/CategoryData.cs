using StitchMaster.BusinessLogic;
using StitchMaster.Interfaces;

namespace StitchMaster.DataLayer
{
    public class CategoryData : ICategoryData   
    {
        static private CategoryData _categoryData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private CategoryData() { }

        static public CategoryData Instance
        {
            get
            {
                if (_categoryData == null) // 1st Check (Multiple Threads Can Execute)
                {
                    lock (_lock)
                    {
                        if (_categoryData == null) // 2nd Check  (Only Single Thread Can Execute)
                        {
                            _categoryData = new CategoryData();
                        }
                    }
                }
                return _categoryData;
            }
        }
        public bool StoreObject(Category category)
        {
            return true;
        }
        public bool DeleteObject(Category category)
        {
            return true;
        }
        public bool UpdateObject(Category category)
        {
            return true;
        }
        public List<Category> GetAllObjects()
        {
            List<Category> allCategories = new List<Category>();
            return allCategories;
        }
    }
}
