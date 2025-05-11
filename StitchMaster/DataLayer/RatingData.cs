using StitchMaster.Interfaces;

namespace StitchMaster.BusinessLogic
{
    public class RatingData : IRatingData
    {
        static private RatingData _ratingData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private RatingData() { }

        static public RatingData Instance
        {
            get
            {
                if (_ratingData == null) // 1st Check (Multiple Threads Can Execute)
                {
                    lock (_lock)
                    {
                        if (_ratingData == null) // 2nd Check  (Only Single Thread Can Execute)
                        {
                            _ratingData = new RatingData();
                        }
                    }
                }
                return _ratingData;
            }
        }
        public bool StoreObject(Rating rating)
        {
            return true;   
        }
        public bool DeleteObject(Rating rating)
        {
            return true;
        }
        public bool UpdateObject(Rating rating)
        {
            return true;
        }
        public List<Rating> GetAllObjects()
        {
            List<Rating> allRatings = new List<Rating>();
            return allRatings;
        }
    }
}
