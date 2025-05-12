
﻿using System.Data;
using Microsoft.AspNetCore.Routing.Constraints;
using Org.BouncyCastle.Crypto.Parameters;
using StitchMaster.BusinessLogic;
using StitchMaster.HelperClasses;
﻿using MySql.Data.MySqlClient;
using StitchMaster.Interfaces;
using StitchMaster.Components.Pages;



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


        public List<TailorGig> GetAllTailorGigs(Tailor tailor)
        {
            //string query = $"SELECT * FROM Gig WHERE tailor_id = {tailor.TailorID} AND title NOT LIKE '~%'";
            string query = $"SELECT * FROM view_gig_with_rating WHERE tailor_id = {tailor.TailorID} AND title NOT LIKE '~%'";
            DataTable dt = DatabaseHelper.Instance.GetDataTable(query);
            return FillGigList(dt);
        }
        public List<TailorGig> GetAllObjects()
        {
            List<TailorGig> gigs = new List<TailorGig>();

            //string query = @"SELECT g.gig_id, g.title, g.description, g.price, g.delivery_time, g.image_url,
            //                             c.category_id, c.category_name,c.gender
            //                      FROM gig g
            //                      INNER JOIN category c ON g.category_id = c.category_id WHERE title NOT LIKE '~%'";

            string query = $"SELECT * FROM view_gig_with_rating g INNER JOIN category c ON g.category_id = c.category_id WHERE title NOT LIKE '~%'";


            MySqlDataReader reader = DatabaseHelper.Instance.getDataReader(query);

            while (reader.Read())
            {
                Category category = new Category(
                    Convert.ToInt32(reader["category_id"]),
                    reader["category_name"].ToString(),
                    Gender.StringToGenderType(reader["gender"].ToString())
                );

                TailorGig gig = new TailorGig(
                    Convert.ToInt32(reader["gig_id"]),
                    reader["title"].ToString(),
                    reader["description"].ToString(),
                    category,
                    Convert.ToInt32(reader["price"]),
                    Convert.ToInt32(reader["delivery_time"]),
                    Convert.ToDouble(reader["rating"]),
                    reader["image_url"].ToString()
                );

                gigs.Add(gig);
            }

            reader.Close();
            return gigs;
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
                    double rating = Convert.ToDouble(row["rating"]);

                    Tailor tailor = TailorData.Instance.GetTailorByID(tailorID);
                    Category category = CategoryData.Instance.GetCategoryByID(categoryID);

                    TailorGig gig = new TailorGig(gigID, title, description, category, price, deliveryTime, rating, imageURL);
                    
                    gigs.Add(gig);
                }
                return gigs;
            }
            else
                return null;
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
                    Gender.StringToGenderType(reader["gender"].ToString())
                );

                TailorGig gig = new TailorGig(
                    Convert.ToInt32(reader["gig_id"]),
                    reader["title"].ToString(),
                    reader["description"].ToString(),
                    category,
                    Convert.ToInt32(reader["price"]),
                    Convert.ToInt32(reader["delivery_time"]),
                    0,  // Here we have to add Rating 
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

        public Tailor GetGigTailor(int gigId)
        {
            return TailorData.Instance.GetTailorByID(GetGigOwner(gigId));
        }


        public bool StoreObject(Tailor tailor, TailorGig tailorGig)
        {
            string query = $"INSERT INTO Gig (tailor_id, title, description, price, delivery_time, image_url, category_id) VALUES ({tailor.TailorID}, '{tailorGig.GigTitle}', '{tailorGig.GigDescription}', {tailorGig.GigPrice}, {tailorGig.GigDeliveryDays}, '{tailorGig.ImageURL}', {tailorGig.GigCategory.CategoryID});";
            int result = DatabaseHelper.Instance.ExecuteQuery(query);
            return result > 0;
        }
        public bool DeleteObject(TailorGig tailorGig)
        {
            string query = $"UPDATE Gig SET title = Concat('~',title) WHERE gig_id = {tailorGig.GigID};";
            int result = DatabaseHelper.Instance.ExecuteQuery(query);
            return result > 0;
        }
        public bool UpdateObject(TailorGig tailorGig)
        {
            string query = $"UPDATE Gig SET title = '{tailorGig.GigTitle}', description = '{tailorGig.GigDescription}', price = {tailorGig.GigPrice}, delivery_time = {tailorGig.GigDeliveryDays}, image_url = '{tailorGig.ImageURL}', category_id = {tailorGig.GigCategory.CategoryID} WHERE gig_id = {tailorGig.GigID};";
            int result = DatabaseHelper.Instance.ExecuteQuery(query);
            return result > 0;
        }
//         public List<TailorGig> GetAllObjects() --------------Already Made
//         {
//             List<TailorGig> gigs = new List<TailorGig>();

//             string query = @"SELECT g.gig_id, g.title, g.description, g.price, g.delivery_time, g.image_url,
//                             c.category_id, c.category_name,c.gender
//                      FROM gig g
//                      INNER JOIN category c ON g.category_id = c.category_id";

//             MySqlDataReader reader = DatabaseHelper.Instance.getDataReader(query);

//             while (reader.Read())
//             {
//                 Category category = new Category(
//                     Convert.ToInt32(reader["category_id"]),
//                     reader["category_name"].ToString(),
//                     Gender.StringToGenderType(reader["gender"].ToString())
//                 );

//                 TailorGig gig = new TailorGig(
//                     Convert.ToInt32(reader["gig_id"]),
//                     reader["title"].ToString(),
//                     reader["description"].ToString(),
//                     category,
//                     Convert.ToInt32(reader["price"]),
//                     Convert.ToInt32(reader["delivery_time"]),
//                     reader["image_url"].ToString()
//                 );

//                 gigs.Add(gig);
//             }

//             reader.Close();
//             return gigs;
//         }


    }
}
