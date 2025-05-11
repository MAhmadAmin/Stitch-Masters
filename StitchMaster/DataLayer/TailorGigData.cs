using StitchMaster.BusinessLogic;
using StitchMaster.Interfaces;

namespace StitchMaster.DataLayer
{
    public class TailorGigData : ITailorGigData
    {
        static private ITailorGigData _tailorGigData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private TailorGigData() { }

        static public ITailorGigData Instance
        {
            get
            {
                if (_tailorGigData == null) // 1st Check (Multiple Threads Can Execute)
                {
                    lock (_lock)
                    {
                        if (_tailorGigData == null) // 2nd Check  (Only Single Thread Can Execute)
                        {
                            _tailorGigData = new TailorGigData();
                        }
                    }
                }
                return _tailorGigData;
            }
        }
        public bool StoreObject(Tailor tailor, TailorGig tailorGig)
        {
            return true;
        }
        public bool DeleteObject(TailorGig tailorGig)
        {
            return true;
        }
        public bool UpdateObject(TailorGig tailorGig)
        {
            return true;
        }
        public List<TailorGig> GetAllObjects()
        {
            List<TailorGig> allTailorGigs = new List<TailorGig>();
            return allTailorGigs;
        }
    }
}
