using MySql.Data.MySqlClient;
using StitchMaster.BusinessLogic;
using StitchMaster.HelperClasses;

namespace StitchMaster.DataLayer
{
    public class FabricProductData
    {
        static private FabricProductData _fabricProductData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private FabricProductData() { }

        static public FabricProductData Instance
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

        public List<FabricProduct> GetAllProduts()
        {
            List<FabricProduct> products = new List<FabricProduct>();

            string query = @"select f.fabric_id,f.title,f.description,f.material,f.gender,f.price_per_meter,f.in_stock_qty,f.image_url
                            ,c.color_id,c.color_name
                            from fabric_product f 
                            inner join color c on f.color_id = c.color_id;";

            MySqlDataReader reader = DatabaseHelper.Instance.getDataReader(query);

            while (reader.Read())
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

                products.Add(product);
            }

            reader.Close();
            return products;
        }

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

    }
}
