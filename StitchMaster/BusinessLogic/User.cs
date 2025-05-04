using System.Globalization;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Bcpg;

namespace StitchMaster.BusinessLogic
{
    public class User
    {
        // Backing Fields
        private readonly int _userID;
        private string _username;
        private string _name;    // This is the Comman Attrib of Child Classes
        private string _email;
        private string _hashed_Password;
        private string _profile_Img_URL;
        private DateTime _accountCreationDate;
        private UserRole _userRole;

        public int UserID
        {
            get { return _userID; }
        }
        public string Username
        {
            get { return _username; }
            set
            {
                // Validations
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Username can't be empty");
                }
                _username = value;
            }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Hashed_Password
        {
            get { return _hashed_Password; }
            set { _hashed_Password = value; }
        }
        public string Profile_Img_URL
        {
            get { return Profile_Img_URL; }
            set { Profile_Img_URL = value; }

        }
        public DateTime AccountCreationDate
        {
            get { return _accountCreationDate; }
            set { _accountCreationDate = value; }
        }
        public UserRole UserRole
        {
            get { return _userRole; }
            set { _userRole = value; }
        }


        public User(int userID, string username, string name, string email, string hashed_Password, string profile_Img_URL, DateTime accountCreationDate, UserRole userRole)
        {
            if (IsValid.DBID(userID))
            {
                _userID = userID;
            }
            else
            {
                throw new ArgumentException("Invalid User ID");
            }
            Username = username;
            Name = name;
            Email = email;
            Hashed_Password = hashed_Password;
            Profile_Img_URL = profile_Img_URL;
            AccountCreationDate = accountCreationDate;
            UserRole = userRole;
        }
    }
}
