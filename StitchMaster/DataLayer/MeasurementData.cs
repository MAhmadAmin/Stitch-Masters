using StitchMaster.BusinessLogic;
using StitchMaster.HelperClasses;
using System.Collections.Generic;
using System.Data;

namespace StitchMaster.DataLayer
{
    public class MeasurementData
    {
        private static MeasurementData _measurementData;
        private static readonly object _lock = new object();

        private MeasurementData() { }

        public static MeasurementData Instance
        {
            get
            {
                if (_measurementData == null)
                {
                    lock (_lock)
                    {
                        if (_measurementData == null)
                        {
                            _measurementData = new MeasurementData();
                        }
                    }
                }
                return _measurementData;
            }
        }

        public int StoreMeasurement(Measurement m)
        {
            string query = $@"
                INSERT INTO buyer_measurement 
                (measurement_name, gender, chest, waist, shoulder_width, sleve_length, neck_size, inseam, outseam, thigh, knee, buyer_id)
                VALUES 
                ('{m.MeasurementName}', '{m.Gender}', {m.Chest}, {m.Waist}, {m.ShoulderWidth}, {m.SleveLength}, {m.NeckSize}, 
                {m.Inseam}, {m.Outseam}, {m.Thigh}, {m.Knee}, {m.BuyerId})";

            return DatabaseHelper.Instance.ExecuteQuery(query);
        }
        public int DeleteMeasurement(int measurementId)
        {
            //string query = $"DELETE FROM buyer_measurement WHERE measurement_id = {measurementId}";
            string query = $"UPDATE buyer_measurement SET measurement_name = CONCAT('~', measurement_name) WHERE measurement_id = {measurementId}";
            return DatabaseHelper.Instance.ExecuteQuery(query);
        }
        public Measurement GetMeasurementById(int measurementid)
        {
            Measurement measurement = null;

            string query = $"SELECT * FROM buyer_measurement WHERE measurement_id = {measurementid}";
            DataTable dt = DatabaseHelper.Instance.GetDataTable(query);

            foreach (DataRow row in dt.Rows)
            {
                Measurement m = new Measurement(
                    Convert.ToInt32(row["measurement_id"]),
                    row["measurement_name"].ToString(),
                    Convert.ToInt32(row["buyer_id"]),
                    row["gender"].ToString(),
                    row["chest"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["chest"]),
                    row["waist"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["waist"]),
                    row["shoulder_width"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["shoulder_width"]),
                    row["sleve_length"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["sleve_length"]),
                    row["neck_size"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["neck_size"]),
                    row["inseam"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["inseam"]),
                    row["outseam"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["outseam"]),
                    row["thigh"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["thigh"]),
                    row["knee"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["knee"])
                );

                measurement = m;
            }

            return measurement;
        }
        public List<Measurement> GetMeasurementsByBuyerId(int buyerId)
        {
            List<Measurement> measurements = new List<Measurement>();

            string query = $"SELECT * FROM buyer_measurement WHERE buyer_id = {buyerId} AND measurement_name NOT LIKE '~%'";
            DataTable dt = DatabaseHelper.Instance.GetDataTable(query);

            foreach (DataRow row in dt.Rows)
            {
                Measurement m = new Measurement(
                    Convert.ToInt32(row["measurement_id"]),
                    row["measurement_name"].ToString(),
                    Convert.ToInt32(row["buyer_id"]),
                    row["gender"].ToString(),
                    row["chest"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["chest"]),
                    row["waist"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["waist"]),
                    row["shoulder_width"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["shoulder_width"]),
                    row["sleve_length"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["sleve_length"]),
                    row["neck_size"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["neck_size"]),
                    row["inseam"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["inseam"]),
                    row["outseam"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["outseam"]),
                    row["thigh"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["thigh"]),
                    row["knee"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["knee"])
                );

                measurements.Add(m);
            }

            return measurements;
        }

        public Measurement GetMeasurementsById(int Id)
        {

            string query = $"SELECT * FROM buyer_measurement WHERE measurement_id = {Id} AND measurement_name NOT LIKE '~%'";
            DataTable dt = DatabaseHelper.Instance.GetDataTable(query);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                Measurement m = new Measurement(
                    Convert.ToInt32(row["measurement_id"]),
                    row["measurement_name"].ToString(),
                    Convert.ToInt32(row["buyer_id"]),
                    row["gender"].ToString(),
                    row["chest"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["chest"]),
                    row["waist"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["waist"]),
                    row["shoulder_width"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["shoulder_width"]),
                    row["sleve_length"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["sleve_length"]),
                    row["neck_size"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["neck_size"]),
                    row["inseam"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["inseam"]),
                    row["outseam"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["outseam"]),
                    row["thigh"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["thigh"]),
                    row["knee"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["knee"])
                );

                return m;
            }

            else
                return null;

        }
    }
}
