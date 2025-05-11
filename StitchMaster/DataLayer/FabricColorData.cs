using System.Data;
using StitchMaster.BusinessLogic;
using StitchMaster.HelperClasses;

namespace StitchMaster.DataLayer
{
    public class FabricColorData
    {
        static private FabricColorData _fabricColorData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private FabricColorData() { }

        static public FabricColorData Instance
        {
            get
            {
                if (_fabricColorData == null) // 1st Check (Multiple Threads Can Execute)
                {
                    lock (_lock)
                    {
                        if (_fabricColorData == null) // 2nd Check  (Only Single Thread Can Execute)
                        {
                            _fabricColorData = new FabricColorData();
                        }
                    }
                }
                return _fabricColorData;
            }
        }

        private List<FabricColor> GetAllObjects()
        {
            List<FabricColor> colors = new List<FabricColor>();
            string sql = "SELECT * FROM FabricColor";
            DataTable dt = DatabaseHelper.Instance.GetDataTable(sql);
            foreach (DataRow row in dt.Rows)
            {
                FabricColor color = new FabricColor(
                    Convert.ToInt32(row["Color_iD"]),
                    Convert.ToString(row["Color_name"])
                );
                colors.Add(color);
            }

            return colors;
        }
    }
}