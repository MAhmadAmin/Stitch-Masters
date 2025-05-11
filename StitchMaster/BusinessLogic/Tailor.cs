using System.Xml.Linq;
using Google.Protobuf.WellKnownTypes;
using StitchMaster.HelperClasses;

namespace StitchMaster.BusinessLogic
{
    public class Tailor : User
    {
        // Backing Fields
        private readonly int _tailorID;   // ID is unchangable/ Immutable/ Readonly After the Object is Created
        private string _tailorDescription;
        private Address _tailorAddress;
        private string _tailorRank;

        private List<Skill> _mySkills = new List<Skill>();
        private List<TailorGig> _myGigs  = new List<TailorGig>();
        
        #region Lists Getter Setter & Methods Start --------------------------

        public List<Skill> MySkills
        {
            get { return new List<Skill>(MySkills); }   // a New Copy List is Return to Add Encapsulation
            set { MySkills = new List<Skill>(value); } // A New Copy of List is Set to Add Encapsulation
        }
        public void AddSkill(Skill skill)
        {
            _mySkills.Add(skill);
        }
        
        public List<TailorGig> MyGigs
        {
            get { return _myGigs; }
            set { _myGigs = value; }
        }
        public void AddGig(TailorGig tailorGig)
        {
            MyGigs.Add(tailorGig);
        }
        #endregion Lists Getter Setter & Methods Start --------------------------

        #region Getter Setter Start --------------------------------------------
        public int TailorID
        {
            get { return _tailorID; }
        }
        public string TailorDescription
        {
            get { return _tailorDescription; }
            set { _tailorDescription = value; }
        }
        public Address TailorAddress
        {
            get { return  this._tailorAddress; }
            set { this._tailorAddress = value; }
        }
        public string TailorRank
        {
            get { return this._tailorRank; }
            set { this._tailorRank = value; }
        }
        #endregion Getter Setter Start --------------------------------------------

        #region Constructors Start ----------------------------------------------
        public Tailor(int tailorID, string tailorDescription, Address tailorAddress, string tailorRank, List<Skill> mySkills,int userID, string username, string name, string email, string hashed_Password, string profile_Img_URL, DateTime accountCreationDate, UserRole userRole): base (userID, username, name,email, hashed_Password,profile_Img_URL,accountCreationDate,userRole)
        {   // Full Param Constructor
            // Backing Fields are Never Assigned the Values Directly (except Readonly Backing Fields) .. Always use the Properties to Assign the Values so that Setter Function is Automatically Called
            if(IsValid.DBID(tailorID))
            {
                _tailorID = tailorID;
            }
            else
            {
                throw new ArgumentException("Invalid Tailor ID");
            }
            this.TailorDescription = tailorDescription; 
            this.TailorAddress = tailorAddress;
            this.TailorRank = tailorRank;
            this.MySkills = mySkills;
        }

        public Tailor(int tailorID, string tailorDescription, int userID, string username, string name, string email, string hashed_Password, string profile_Img_URL, DateTime accountCreationDate, UserRole userRole) : base(userID, username, name, email, hashed_Password, profile_Img_URL, accountCreationDate, userRole)
        {   // Full Param Constructor
            // Backing Fields are Never Assigned the Values Directly (except Readonly Backing Fields) .. Always use the Properties to Assign the Values so that Setter Function is Automatically Called
            if (IsValid.DBID(tailorID))
            {
                _tailorID = tailorID;
            }
            else
            {
                throw new ArgumentException("Invalid Tailor ID");
            }
            this.TailorDescription = tailorDescription;
        }

        public Tailor(string username, string name, string email, string hashed_Password, UserRole userRole) : base(username, name, email, hashed_Password, userRole)
        {
            TailorDescription = null;
        }

        public Tailor(Tailor t):base(t)
        { // Copy Constructor
            // Backing Fields are Never Assigned the Values Directly (except Readonly Backing Fields) .. Always use the Properties to Assign the Values so that Setter Function is Automatically Called
            if (IsValid.DBID(t.TailorID))
            {
                _tailorID = t.TailorID;
            }
            else
            {
                throw new ArgumentException("Invalid Tailor ID");
            }
            this.TailorDescription = t.TailorDescription;
            this.TailorAddress = t.TailorAddress;
            this.TailorRank = t.TailorRank;
            this.MySkills = t.MySkills;
        }
        #endregion
    }
}
