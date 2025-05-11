using MySql.Data.MySqlClient;
﻿using System.Data;
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


//         public List<FabricProduct> GetAllProduts()
//         {
//             List<FabricProduct> products = new List<FabricProduct>();

//             string query = @"select f.fabric_id,f.title,f.description,f.material,f.gender,f.price_per_meter,f.in_stock_qty,f.image_url
//                             ,c.color_id,c.color_name
//                             from fabric_product f 
//                             inner join color c on f.color_id = c.color_id;";

//             MySqlDataReader reader = DatabaseHelper.Instance.getDataReader(query);

//             while (reader.Read())
//             {
//                 FabricColor color = new FabricColor(
//                     Convert.ToInt32(reader["color_id"]),
//                     reader["color_name"].ToString()
//                 );

//                 FabricProduct product = new FabricProduct(
//                     Convert.ToInt32(reader["fabric_id"]),
//                     reader["title"].ToString(),
//                     reader["description"].ToString(),
//                     color,
//                     reader["material"].ToString(),
//                     reader["gender"].ToString(),
//                     Convert.ToInt32(reader["price_per_meter"]),
//                     Convert.ToInt32(reader["in_stock_qty"]),
//                     reader["image_url"].ToString()
//                 );

//                 products.Add(product);
//             }

//             reader.Close();
//             return products;
//         }

        public FabricProduct? GetProductById(int productId)
        {
            string query = $@"select f.fabric_id,f.title,f.description,f.material,f.gender,f.price_per_meter,f.in_stock_qty,f.image_url
                            ,c.color_id,c.color_name
                            from fabric_product f 
                            inner join color c on f.color_id = c.color_id where fabric_id = {productId}";

            MySqlDataReader reader = DatabaseHelper.Instance.getDataReader(query);

            if (reader.Read())
            {
                FabricColor color = new FabricColor(
                    Convert.ToInt32(reader["color_id"]),
                    reader["color_name"].ToString()
                );

                FabricProduct product = new FabricProduct(
                    Convert.ToInt32(reader["fabric_id"]),
                    reader["title"].ToString(),
                    reader["description"].ToString(),
                    color,
                    reader["material"].ToString(),
                    reader["gender"].ToString(),
                    Convert.ToInt32(reader["price_per_meter"]),
                    Convert.ToInt32(reader["in_stock_qty"]),
                    reader["image_url"].ToString()
                );

                reader.Close();
                return product;
            }

            reader.Close();
            return null;
        }

        public int GetProductOwnerId(int productId)
        {
            string query = $"SELECT store_id FROM fabric_product WHERE fabric_id = {productId}";

            MySqlDataReader reader = DatabaseHelper.Instance.getDataReader(query);
            if (reader.Read())
            {
                return Convert.ToInt32(reader["store_id"]);
            }

            throw new InvalidOperationException("Product not found or store_id is invalid.");
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
