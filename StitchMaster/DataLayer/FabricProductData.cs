using System.Data;
using StitchMaster.BusinessLogic;
using StitchMaster.HelperClasses;
using StitchMaster.Interfaces;

namespace StitchMaster.DataLayer
{
    public class FabricProductData : IFabricProductData
    {
        static private IFabricProductData _fabricProductData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private FabricProductData() { }

        static public IFabricProductData Instance
        {
            get
            {
                if (_fabricProductData == null) // 1st Check (Multiple Threads Can Execute)
                {
                    lock (_lock)
                    {
                        if (_fabricProductData == null) // 2nd Check  (Only Single Thread Can Execute)
                        {
                            _fabricProductData = new FabricProductData();
                        }
                    }
                }
                return _fabricProductData;
            }
        }
        
        
        
        
        public bool StoreObject(FabricStore Store,FabricProduct Product)
        {
            
            string query = $"INSERT INTO Fabric_product (`store_id`, `title`,`description`,`color_id`, `material`,`gender`, `price_per_meter`,`in_stock_qty`,`image_url`) Values ('{Store.FabricStoreID}', '{Product.FabricProductTitle}', '{Product.FabricProductDescription}', '{Product.FabricColor.ColorID}', '{Product.FabricMaterial}', '{Product.Gender}', '{Product.PricePerMeter}','{Product.StockQuantity}', '{Product.ImageURl}')";
            return (DatabaseHelper.Instance.ExecuteQuery(query) > 0);
            
        }
       
        public bool UpdateObject(FabricProduct Product)
        {
            string dml = $"Update fabric_product Set `title` = '{Product.FabricProductTitle}',`description`='{Product.FabricProductDescription}',`color_id` = '{Product.FabricColor.ColorID}',`material` = '{Product.FabricMaterial}', `gender` = '{Gender.GenderTypeToString(Product.Gender)}',`price_per_meter` = '{Product.PricePerMeter}',`in_stock_qty` = '{Product.StockQuantity}',image_url = '{Product.ImageURl}' where fabric_id = {Product.FabricProductID};";
            return (DatabaseHelper.Instance.ExecuteQuery(dml) > 0);
        }
        public bool DeleteObject(FabricProduct Product)
        {
            string dml = $"Delete from fabric_product where fabric_id = {Product.FabricProductID};";
            return (DatabaseHelper.Instance.ExecuteQuery(dml)>0);

        }
        public List<FabricProduct> GetAllObjects()
        {
            List<FabricProduct> allProducts = new List<FabricProduct>();
            string sql = "Select * from fabric_product;";
            DataTable dt = DatabaseHelper.Instance.GetDataTable(sql);
            List<FabricColor> allColors = FabricColorData.Instance.GetAllObjects();
            foreach (DataRow dr in dt.Rows)
            {
                FabricColor CuurentColor = allColors.Find(FP => FP.ColorID == int.Parse(dr["color_id"].ToString()));
                FabricProduct product = new FabricProduct(int.Parse(dr["fabric_id"].ToString()), dr["title"].ToString(), dr["description"].ToString(), CuurentColor, dr["material"].ToString(), Gender.StringToGenderType(dr["gender"].ToString()), int.Parse(dr["price_per_meter"].ToString()), int.Parse(dr["in_stock_qty"].ToString()), 0, dr["image_url"].ToString());
                allProducts.Add(product);
            }
            return allProducts;
        }
    }
    

}
