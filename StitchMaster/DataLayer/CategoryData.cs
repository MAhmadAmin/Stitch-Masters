using System.Data;
using StitchMaster.BusinessLogic;
using StitchMaster.HelperClasses;

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

        public List<Category> GetAllCategories()
        {
            string query = "SELECT * FROM Category";
            DataTable dt = DatabaseHelper.Instance.GetDataTable(query);
            return GetCategoriesList(dt);
        }

        private List<Category> GetCategoriesList(DataTable dt)
        {
            List<Category> categories = new List<Category>();

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    int categoryID = Convert.ToInt32(row["category_id"]);
                    string categoryName = row["category_name"].ToString();
                    string gender = row["gender"].ToString();                 
                    Category category = new Category(categoryID, categoryName, gender);
                    categories.Add(category);
                }
                return categories;
            }
            else
            {
                return null;
            }
        }
    }
}
