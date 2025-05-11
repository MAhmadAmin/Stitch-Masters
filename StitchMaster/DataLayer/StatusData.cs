using System.Data;
using StitchMaster.BusinessLogic;
using StitchMaster.HelperClasses;
using StitchMaster.Interfaces;

namespace StitchMaster.DataLayer
{
    public class StatusData : IStatusData
    {
        static private IStatusData _statusData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private StatusData() { }

        static public IStatusData Instance
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

        public Status GetStatusByID(int ID)
        {
            string query = $"SELECT * FROM Lookup WHERE lookup_id = {ID}";
            DataTable dt = DatabaseHelper.Instance.GetDataTable(query);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                Status status = new Status(
                    Convert.ToInt32(dr["lookup_id"]),
                    dr["value"].ToString()
                );
                return status;
            }
            else
            {
                throw new InvalidOperationException("Status not found");
            }
        }
    }
}
