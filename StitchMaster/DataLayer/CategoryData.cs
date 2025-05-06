namespace StitchMaster.DataLayer
{
    public class CategoryData
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
    }
}
