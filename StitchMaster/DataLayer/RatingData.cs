namespace StitchMaster.BusinessLogic
{
    public class RatingData
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
    }
}
