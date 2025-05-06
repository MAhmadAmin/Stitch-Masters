namespace StitchMaster.DataLayer
{
    public class StatusData
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
    }
}
