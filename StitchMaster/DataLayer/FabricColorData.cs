using System.Data;
using StitchMaster.BusinessLogic;
using StitchMaster.HelperClasses;
using StitchMaster.Interfaces;
namespace StitchMaster.DataLayer
{
    public class FabricColorData : IFabricColorData
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
        public bool StoreObject(FabricColor fabricColor)
        {
            return true;
        }
        public bool DeleteObject(FabricColor fabricColor)
        {
            return true;
        }
        public bool UpdateObject(FabricColor fabricColor)
        {
            return true;
        }
        public List<FabricColor> GetAllObjects()
        {
            List<FabricColor> allColors = new List<FabricColor>();
            string sql = "Select * from color;";
            DataTable dt = DatabaseHelper.Instance.GetDataTable(sql);
            foreach(DataRow dr in dt.Rows)
            {
                FabricColor color = new FabricColor(int.Parse(dr["color_id"].ToString()), dr["color_name"].ToString());
                allColors.Add(color);
            }
            return allColors;
        }

    }
}
