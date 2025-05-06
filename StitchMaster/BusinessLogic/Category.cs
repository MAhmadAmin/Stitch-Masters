namespace StitchMaster.BusinessLogic
{
    public class Category
    {
        private readonly int _categoryID;
        private string _categoryName;
        private string _gender;

        public int CategoryID 
        { 
            get { return _categoryID; } 
        }
        public string CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; }
        }
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public Category(int categoryID, string categoryName, string gender)
        {
            if(IsValid.DBID(categoryID))
            {
                _categoryID = categoryID;
            }
            else
            {
                throw new InvalidOperationException("Invalid Category ID");
            }
            this.CategoryName = categoryName;
            this.Gender = gender;
        }
        public Category(Category c)
        {   // Copy Constructor
            if (IsValid.DBID(c.CategoryID))
            {
                _categoryID = c.CategoryID;
            }
            else
            {
                throw new InvalidOperationException("Invalid Category ID");
            }
            this.CategoryName = c.CategoryName;
            this.Gender = c.Gender;
        }


    }
}
