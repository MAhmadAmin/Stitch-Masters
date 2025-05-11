using Google.Protobuf.WellKnownTypes;
using StitchMaster.HelperClasses;

namespace StitchMaster.BusinessLogic
{
    public class TailorOrder
    {
        private readonly int _tailorOrderID;
        private Tailor _tailor;
        private Customer _customer;
        private FabricPurchased _fabricPurchased;
        private Measurement _customerMeasurement;
        private string _description;
        private DateTime _orderDateTime;
        private Status _orderStatus;
        private Rating _orderRating;
        private int _price;

        #region Getter Setter Start --------------------------------------------
        public int TailorOrderID
        {
            get { return _tailorOrderID; }
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

        public int Price
        {
            get { return _price; }
            set { _price = value; }

        }
        public Measurement CustomerMeasurement
        {
            get { return new Measurement(_customerMeasurement); }
            set { _customerMeasurement = new Measurement(value); }
        }
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
        #endregion Getter Setter Start --------------------------------------------

        #region Constructors Start ----------------------------------------------
        public TailorOrder(int tailorOrderID, Tailor tailor, Customer customer, FabricPurchased fabricPurchased,Measurement customerMeasurement, string description  , DateTime orderDateTime, Status orderStatus, Rating orderRating)
        {
            if(IsValid.DBID(tailorOrderID))
            {
                _tailorOrderID = tailorOrderID;
            }
            else
            {
                throw new ArgumentException("Invalid Tailor Order ID");
            }
            this.Tailor = tailor;
            this.Customer = customer;
            this.FabricPurchased = fabricPurchased;
            this.CustomerMeasurement = customerMeasurement;
            this.Description = description;
            this.OrderDateTime = orderDateTime;
            this.OrderStatus = orderStatus;
            this.OrderRating = orderRating;
        }
        public TailorOrder( Tailor tailor, Customer customer, FabricPurchased fabricPurchased, Measurement customerMeasurement, string description, DateTime orderDateTime, Status orderStatus, Rating orderRating)
        {
            this.Tailor = tailor;
            this.Customer = customer;
            this.FabricPurchased = fabricPurchased;
            this.CustomerMeasurement = customerMeasurement;
            this.Description = description;
            this.OrderDateTime = orderDateTime;
            this.OrderStatus = orderStatus;
            this.OrderRating = orderRating;
        }

        #endregion Constructors End ----------------------------------------------
    }
}
