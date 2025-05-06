using StitchMaster.HelperClasses;

namespace StitchMaster.BusinessLogic
{
    public class Rating
    {
        private readonly int _ratingID;
        private int _ratingValue;
        private string _rewiew;

        #region Getter Setter Start --------------------------------------------
        public int RatingID
        {
            get { return _ratingID; }
        }
        public int RatingValue
        {
            set { _ratingValue = value; }
            get { return _ratingValue; }
        }
        public string Review
        {
            get { return _rewiew; }
            set { _rewiew = value; }
        }
        #endregion Getter Setter Start --------------------------------------------

        #region Constructors Start ----------------------------------------------
        public Rating(int ratingID, int ratingValue, string review)
        {
            if(IsValid.DBID(ratingID))
            {
                _ratingID = ratingID;
            }
            else
            {
                throw new InvalidOperationException("Invalid Rating ID");
            }
            RatingValue = ratingValue;
            Review = review;
        }
        public Rating(Rating r)
        {
            if (IsValid.DBID(r.RatingID))
            {
                _ratingID = r.RatingID;
            }
            else
            {
                throw new InvalidOperationException("Invalid Rating ID");
            }
            RatingValue = r.RatingValue;
            Review = r.Review;
        }
        #endregion Constructors Start ----------------------------------------------
    }
}
