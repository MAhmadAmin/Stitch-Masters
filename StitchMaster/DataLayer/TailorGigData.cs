
﻿using MySql.Data.MySqlClient;
using StitchMaster.BusinessLogic;
using StitchMaster.HelperClasses;

﻿using StitchMaster.BusinessLogic;
using StitchMaster.Interfaces;


namespace StitchMaster.DataLayer
{
    public class TailorGigData : ITailorGigData
    {
        static private ITailorGigData _tailorGigData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private TailorGigData() { }

        static public ITailorGigData Instance
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


        public List<TailorGig> GetAllGigs()
        {
            List<TailorGig> gigs = new List<TailorGig>();

            string query = @"SELECT g.gig_id, g.title, g.description, g.price, g.delivery_time, g.image_url,
                            c.category_id, c.category_name,c.gender
                     FROM gig g
                     INNER JOIN category c ON g.category_id = c.category_id";

            MySqlDataReader reader = DatabaseHelper.Instance.getDataReader(query);

            while (reader.Read())
            {
                Category category = new Category(
                    Convert.ToInt32(reader["category_id"]),
                    reader["category_name"].ToString(),
                    reader["gender"].ToString()
                );

                TailorGig gig = new TailorGig(
                    Convert.ToInt32(reader["gig_id"]),
                    reader["title"].ToString(),
                    reader["description"].ToString(),
                    category,
                    Convert.ToInt32(reader["price"]),
                    Convert.ToInt32(reader["delivery_time"]),
                    reader["image_url"].ToString()
                );

                gigs.Add(gig);
            }

            reader.Close();
            return gigs;
        }
        public TailorGig? GetGigById(int gigId)
        {
            string query = $@"SELECT g.gig_id, g.title, g.description, g.price, g.delivery_time, g.image_url,
                             c.category_id, c.category_name, c.gender
                      FROM gig g
                      INNER JOIN category c ON g.category_id = c.category_id
                      WHERE g.gig_id = {gigId}";

            MySqlDataReader reader = DatabaseHelper.Instance.getDataReader(query);

            if (reader.Read())
            {
                Category category = new Category(
                    Convert.ToInt32(reader["category_id"]),
                    reader["category_name"].ToString(),
                    reader["gender"].ToString()
                );

                TailorGig gig = new TailorGig(
                    Convert.ToInt32(reader["gig_id"]),
                    reader["title"].ToString(),
                    reader["description"].ToString(),
                    category,
                    Convert.ToInt32(reader["price"]),
                    Convert.ToInt32(reader["delivery_time"]),
                    reader["image_url"].ToString()
                );

                reader.Close();
                return gig;
            }

            reader.Close();
            return null;
        }

        public int GetGigOwner(int gigId)
        {
            string query = $"SELECT tailor_id FROM gig WHERE gig_id = {gigId}";

            MySqlDataReader reader = DatabaseHelper.Instance.getDataReader(query);
            if (reader.Read())
            {
                return Convert.ToInt32(reader["tailor_id"]);
            }

                throw new InvalidOperationException("Gig not found or tailor_id is invalid.");
        }


        public bool StoreObject(Tailor tailor, TailorGig tailorGig)
        {
            return true;
        }
        public bool DeleteObject(TailorGig tailorGig)
        {
            return true;
        }
        public bool UpdateObject(TailorGig tailorGig)
        {
            return true;
        }
        public List<TailorGig> GetAllObjects()
        {
            List<TailorGig> allTailorGigs = new List<TailorGig>();
            return allTailorGigs;
        }

    }
}
