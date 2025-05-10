namespace StitchMaster.BusinessLogic
{
    public class Measurement
    {
        public int MeasurementId { get; set; }
        public string MeasurementName { get; set; }
        public int BuyerId { get; set; }
        public string Gender { get; set; }

        public decimal? Chest { get; set; }
        public decimal? Waist { get; set; }
        public decimal? ShoulderWidth { get; set; }
        public decimal? SleveLength { get; set; }
        public decimal? NeckSize { get; set; }
        public decimal? Inseam { get; set; }
        public decimal? Outseam { get; set; }
        public decimal? Thigh { get; set; }
        public decimal? Knee { get; set; }
    }
}
