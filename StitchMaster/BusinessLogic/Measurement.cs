using StitchMaster.HelperClasses;

namespace StitchMaster.BusinessLogic
{
    public class Measurement
    {
        // Backing Fields
        private readonly int _measurementId;
        private string _measurementName;
        private int _buyerId;
        private string _gender;

        private decimal? _chest;
        private decimal? _waist;
        private decimal? _shoulderWidth;
        private decimal? _sleveLength;
        private decimal? _neckSize;
        private decimal? _inseam;
        private decimal? _outseam;
        private decimal? _thigh;
        private decimal? _knee;

        #region Getter Setter Start --------------------------------------------

        public int MeasurementId => _measurementId;

        public string MeasurementName
        {
            get => _measurementName;
            set => _measurementName = value;
        }

        public int BuyerId
        {
            get => _buyerId;
            set => _buyerId = value;
        }

        public string Gender
        {
            get => _gender;
            set => _gender = value;
        }

        public decimal? Chest
        {
            get => _chest;
            set => _chest = value;
        }

        public decimal? Waist
        {
            get => _waist;
            set => _waist = value;
        }

        public decimal? ShoulderWidth
        {
            get => _shoulderWidth;
            set => _shoulderWidth = value;
        }

        public decimal? SleveLength
        {
            get => _sleveLength;
            set => _sleveLength = value;
        }

        public decimal? NeckSize
        {
            get => _neckSize;
            set => _neckSize = value;
        }

        public decimal? Inseam
        {
            get => _inseam;
            set => _inseam = value;
        }

        public decimal? Outseam
        {
            get => _outseam;
            set => _outseam = value;
        }

        public decimal? Thigh
        {
            get => _thigh;
            set => _thigh = value;
        }

        public decimal? Knee
        {
            get => _knee;
            set => _knee = value;
        }

        #endregion Getter Setter End --------------------------------------------

        #region Constructors Start ----------------------------------------------

        public Measurement(int measurementId, string measurementName, int buyerId, string gender,
            decimal? chest, decimal? waist, decimal? shoulderWidth, decimal? sleveLength,
            decimal? neckSize, decimal? inseam, decimal? outseam, decimal? thigh, decimal? knee)
        {
            if (!IsValid.DBID(measurementId))
            {
                throw new InvalidOperationException("Invalid Measurement ID");
            }

            _measurementId = measurementId;
            MeasurementName = measurementName;
            BuyerId = buyerId;
            Gender = gender;
            Chest = chest;
            Waist = waist;
            ShoulderWidth = shoulderWidth;
            SleveLength = sleveLength;
            NeckSize = neckSize;
            Inseam = inseam;
            Outseam = outseam;
            Thigh = thigh;
            Knee = knee;
        }

        public Measurement(string measurementName, int buyerId, string gender,
            decimal? chest, decimal? waist, decimal? shoulderWidth, decimal? sleveLength,
            decimal? neckSize, decimal? inseam, decimal? outseam, decimal? thigh, decimal? knee)
        {
            MeasurementName = measurementName;
            BuyerId = buyerId;
            Gender = gender;
            Chest = chest;
            Waist = waist;
            ShoulderWidth = shoulderWidth;
            SleveLength = sleveLength;
            NeckSize = neckSize;
            Inseam = inseam;
            Outseam = outseam;
            Thigh = thigh;
            Knee = knee;
        }

        public Measurement(Measurement other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other), "Invalid Measurement object");
            }

            if (!IsValid.DBID(other.MeasurementId))
            {
                throw new InvalidOperationException("Invalid Measurement ID");
            }

            _measurementId = other.MeasurementId;
            MeasurementName = other.MeasurementName;
            BuyerId = other.BuyerId;
            Gender = other.Gender;
            Chest = other.Chest;
            Waist = other.Waist;
            ShoulderWidth = other.ShoulderWidth;
            SleveLength = other.SleveLength;
            NeckSize = other.NeckSize;
            Inseam = other.Inseam;
            Outseam = other.Outseam;
            Thigh = other.Thigh;
            Knee = other.Knee;
        }

        #endregion Constructors End ----------------------------------------------
    }
}
