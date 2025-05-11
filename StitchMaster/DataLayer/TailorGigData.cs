using System.Data;
using Microsoft.AspNetCore.Routing.Constraints;
using Org.BouncyCastle.Crypto.Parameters;
using StitchMaster.BusinessLogic;
using StitchMaster.HelperClasses;


namespace StitchMaster.DataLayer
{
    public class TailorGigData
    {
        static private TailorGigData _tailorGigData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private TailorGigData() { }

        static public TailorGigData Instance
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

        public List<TailorGig> GetGigs(Tailor tailor)
        {
            string query = $"SELECT * FROM Gig WHERE tailor_id = {tailor.TailorID}";
            DataTable dt = DatabaseHelper.Instance.GetDataTable(query);
            return FillGigList(dt);
        }

        private List<TailorGig> FillGigList(DataTable dt)
        {
            List<TailorGig> gigs = new List<TailorGig>();

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    int gigID = Convert.ToInt32(row["gig_id"]);
                    int tailorID = Convert.ToInt32(row["tailor_id"]);
                    string title = Convert.ToString(row["title"]);
                    string description = Convert.ToString(row["description"]);
                    int price = Convert.ToInt32(row["price"]);
                    int deliveryTime = Convert.ToInt32(row["delivery_time"]);
                    string imageURL = Convert.ToString(row["image_url"]);
                    int categoryID = Convert.ToInt32(row["category_id"]);

                    Tailor tailor = TailorData.Instance.GetTailorByID(tailorID);
                    Category category = CategoryData.Instance.GetCategoryByID(categoryID);

                    TailorGig gig = new TailorGig(gigID, tailor, title, description, category, price, deliveryTime, 5, imageURL);
                    
                    gigs.Add(gig);
                }
                return gigs;
            }
            else
                return null;
        }

        public int StoreGig(TailorGig gig)
        {
            string query = $"INSERT INTO Gig (tailor_id, title, description, price, delivery_time, image_url, category_id) VALUES ({gig.Tailor.TailorID}, '{gig.GigTitle}', '{gig.GigDescription}', {gig.GigPrice}, {gig.GigDeliveryDays}, '{gig.ImageURL}', {gig.GigCategory.CategoryID});";
            int result = DatabaseHelper.Instance.ExecuteQuery(query);
            return result;
        }
    }
}
