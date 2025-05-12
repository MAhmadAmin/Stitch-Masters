using System.Data;
using StitchMaster.BusinessLogic;
using StitchMaster.Interfaces;
using StitchMaster.HelperClasses;

namespace StitchMaster.DataLayer
{
    public class TailorOrderData:ITailorOrderData
    {
        static private ITailorOrderData _tailorOrderData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private TailorOrderData() { }

        static public ITailorOrderData Instance
        {
            get
            {
                if (_tailorOrderData == null) // 1st Check (Multiple Threads Can Execute)
                {
                    lock (_lock)
                    {
                        if (_tailorOrderData == null) // 2nd Check  (Only Single Thread Can Execute)
                        {
                            _tailorOrderData = new TailorOrderData();
                        }
                    }
                }
                return _tailorOrderData;
            }
        }
        public bool StoreObject(Tailor tailor, TailorOrder tailorOrder)
        {
            string query = $"INSERT INTO orders (tailor_id, buyer_id, fabric_purchased_id, description,image_url, order_date, status_id,price) VALUES ({tailor.TailorID}, {tailorOrder.Customer.CustomerID}, {tailorOrder.FabricPurchased.FabricPurchasedID}, '{tailorOrder.Description}','/product3.jpg' , '{tailorOrder.OrderDateTime.ToString("yyyy-MM-dd HH:mm:ss")}', {tailorOrder.OrderStatus.StatusID} ,'{tailorOrder.Price}')";
            int result = DatabaseHelper.Instance.ExecuteQuery(query);
            return true;
        }
        public bool DeleteObject(TailorOrder tailorOrder)
        {
            return true;
        }
        public bool UpdateObject(TailorOrder tailorOrder)
        {
            return true;
        }
        public List<TailorOrder> GetAllObjects()
        {
            List<TailorOrder> allTailorOrders = new List<TailorOrder>();
            string query = "SELECT * FROM orders";
            DataTable dt = DatabaseHelper.Instance.GetDataTable(query);
            foreach (DataRow dr in dt.Rows)
            {
                Tailor tailor = TailorData.Instance.GetTailorByID(Convert.ToInt32(dr["tailor_id"]));
                Customer customer = CustomerData.Instance.GetCustomerByID(Convert.ToInt32(dr["buyer_id"]));
                Measurement measurement = MeasurementData.Instance.GetMeasurementById(Convert.ToInt32(dr["measurement_id"]));
                FabricPurchased fabricPurchased = FabricPurchasedData.Instance.GetFabricPurchasedByID(Convert.ToInt32(dr["fabric_purchased_id"]));
                Status status = StatusData.Instance.GetStatusByID(Convert.ToInt32(dr["status_id"]));
                TailorOrder tailorOrder = new TailorOrder(Convert.ToInt32(dr["order_id"]), tailor, customer, fabricPurchased, measurement, dr["description"].ToString(), Convert.ToDateTime(dr["order_date"]), status, new Rating(1, 5, "Very Good"));
                
                allTailorOrders.Add(tailorOrder);
            }

            return allTailorOrders;
        }

        public TailorOrder GetOrderByID(int ID)
        {
            string query = $"SELECT * FROM orders WHERE order_id = {ID}";
            DataTable dt = DatabaseHelper.Instance.GetDataTable(query);
            DataRow dr = dt.Rows[0];

            Tailor tailor = TailorData.Instance.GetTailorByID(Convert.ToInt32(dr["tailor_id"]));
            Customer customer = CustomerData.Instance.GetCustomerByID(Convert.ToInt32(dr["buyer_id"]));
            Measurement measurement = MeasurementData.Instance.GetMeasurementById(Convert.ToInt32(dr["measurement_id"]));
            FabricPurchased fabricPurchased = FabricPurchasedData.Instance.GetFabricPurchasedByID(Convert.ToInt32(dr["fabric_purchased_id"]));
            Status status = StatusData.Instance.GetStatusByID(Convert.ToInt32(dr["status_id"]));
            TailorOrder tailorOrder = new TailorOrder(Convert.ToInt32(dr["order_id"]), tailor, customer, fabricPurchased,measurement, dr["description"].ToString(), Convert.ToDateTime(dr["order_date"]), status, new Rating(1, 5, "Very Good"));

            return tailorOrder;
        }

        public bool MarkCompleted(int OrderID)
        {
            string query = $"UPDATE orders SET status_id = 7 WHERE order_id = {OrderID}";
            int rowsAffected = DatabaseHelper.Instance.ExecuteQuery(query);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
