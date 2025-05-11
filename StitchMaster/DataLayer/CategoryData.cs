
﻿using System.Data;
using StitchMaster.BusinessLogic;
using StitchMaster.HelperClasses;
using StitchMaster.Interfaces;

namespace StitchMaster.DataLayer
{
    public class CategoryData : ICategoryData   
    {
        static private ICategoryData _categoryData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private CategoryData() { }

        static public ICategoryData Instance
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


        
        public Category GetCategoryByID(int ID)
        {
            string query = $"SELECT * FROM Category WHERE Category_id = {ID}";
            DataTable dt = DatabaseHelper.Instance.GetDataTable(query);
            return FillCategory(dt);
        }

        private Category FillCategory(DataTable dt)
        {
            if (dt.Rows.Count != 0)
            {
                DataRow dr = dt.Rows[0];
                int categoryID = Convert.ToInt32(dr["category_id"]);
                string categoryName = dr["category_name"].ToString();
                Gender.GenderType gender = Gender.StringToGenderType(dr["gender"].ToString());
                return new Category(categoryID, categoryName, gender);
            }
            else
                return null;
        }

        private List<Category> FillCategoriesList(DataTable dt)
        {
            List<Category> categories = new List<Category>();

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    int categoryID = Convert.ToInt32(row["category_id"]);
                    string categoryName = row["category_name"].ToString();
                    Gender.GenderType gender = Gender.StringToGenderType(row["gender"].ToString());
                    Category category = new Category(categoryID, categoryName, gender);
                    categories.Add(category);
                }
                return categories;
            }
            else
                return null;
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
            string query = "SELECT * FROM Category";
            DataTable dt = DatabaseHelper.Instance.GetDataTable(query);
            return FillCategoriesList(dt);

        }
    }
}
