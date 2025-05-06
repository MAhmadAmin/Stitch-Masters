using Google.Protobuf.WellKnownTypes;

namespace StitchMaster.BusinessLogic
{
    public class TailorOrder
    {
        private readonly int _orderID;
        private Tailor _tailor;
        private Customer _customer;
        private FabricPurchased _fabricPurchased;
        //private CustomerMeasurement _customerMeasurement;
        private string _description;
        private DateTime _orderDateTime;
        private Status _orderStatus;
        private Rating _orderRating;

        public int OrderID
        {
            get { return _orderID; }
        }
        public Tailor Tailor
        {
            get { return new Tailor(_tailor); }
            set { _tailor = new Tailor(value); }
        }
        public Customer Customer
        {
            get { return new Customer(_customer); }
            set { _customer = new Customer(value); }
        }
        public FabricPurchased FabricPurchased
        {
            get { return new FabricPurchased(_fabricPurchased); }
            set { _fabricPurchased = new FabricPurchased(value); }
        }
        //public CustomerMeasurement
        //{

        //}
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public DateTime OrderDateTime
        {
            get { return new DateTime(_orderDateTime.Year, _orderDateTime.Month, _orderDateTime.Day, _orderDateTime.Hour, _orderDateTime.Minute, _orderDateTime.Second); }
            set { _orderDateTime =  new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, value.Second); }
        }
        public Status OrderStatus
        {
            get { return new Status(_orderStatus); }
            set { _orderStatus = new Status(value); }
        }
        public Rating OrderRating
        {
            get { return new Rating(_orderRating); }
            set { _orderRating = new Rating(value); }
        }
    }
}
