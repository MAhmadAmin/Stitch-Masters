using StitchMaster.BusinessLogic;
using StitchMaster.Interfaces;

namespace StitchMaster.DataLayer
{
    public class StatusData : IStatusData
    {
        static private StatusData _statusData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private StatusData() { }

        static public StatusData Instance
        {
            get
            {
                if (_statusData == null) // 1st Check (Multiple Threads Can Execute)
                {
                    lock (_lock)
                    {
                        if (_statusData == null) // 2nd Check  (Only Single Thread Can Execute)
                        {
                            _statusData = new StatusData();
                        }
                    }
                }
                return _statusData;
            }
        }
        public bool StoreObject(Status status)
        {
            return true;
        }
        public bool DeleteObject(Status status)
        {
            return true;
        }
        public bool UpdateObject(Status status)
        {
            return true;
        }
        public List<Status> GetAllObjects()
        {
            List<Status> allStatus = new List<Status>();
            return allStatus;
        }
    }
}
