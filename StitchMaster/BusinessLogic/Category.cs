using StitchMaster.HelperClasses;

namespace StitchMaster.BusinessLogic
{
    public class Category
    {
        private readonly int _categoryID;
        private string _categoryName;
        private Gender.GenderType _gender;

        #region Getter Setter Start --------------------------------------------
        public int CategoryID
        {
            get { return _categoryID; }
        }
        public string CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; }
        }
        public Gender.GenderType Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        #endregion Getter Setter Start --------------------------------------------

        #region Constructors Start ----------------------------------------------
        public Category(int categoryID, string categoryName, Gender.GenderType gender)
        {
            if (IsValid.DBID(categoryID))
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
        #endregion Constructors End ----------------------------------------------


    }
}
