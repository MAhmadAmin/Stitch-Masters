using System.Globalization;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Bcpg;
using StitchMaster.HelperClasses;

namespace StitchMaster.BusinessLogic
{
    public class User
    {
        // Backing Fields
        private readonly int _userID;
        private string _username;
        private string _fullName;    // This is the Comman Attrib of Child Classes
        private string _email;
        private string _Password;
        private string _profile_Img_URL;
        private DateTime _accountCreationDate;
        private UserRole _userRole;

        #region Getter Setter Start --------------------------------------------
        public int UserID
        {
            get { return _userID; }
        }
        public string Username
        {
            get { return _username; }
            set { 
                // Validations
                if(string.IsNullOrEmpty(value) )
                {
                    throw new ArgumentException("Username can't be empty");
                }
                _username = value; }
        }
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }
        
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
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
            get { return _userRole;}
            set { _userRole = value; }
        }
        #endregion Getter Setter Start --------------------------------------------

        #region Constructors Start ----------------------------------------------
        public User(int userID, string username, string name, string email, string password, string profile_Img_URL, DateTime accountCreationDate, UserRole userRole)
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
            FullName = name;
            Email = email;
            Password = password;
            Profile_Img_URL = profile_Img_URL;
            AccountCreationDate = accountCreationDate;
            UserRole = userRole;
        }

        public User(string username, string name, string email, string password, UserRole userRole)
        {
            Username = username;
            FullName = name;
            Email = email;
            Password = password;
            UserRole = userRole;
        }
        public User(User u)
        {
            if (IsValid.DBID(u.UserID))
            {
                _userID = u.UserID;
            }
            else
            {
                throw new ArgumentException("Invalid User ID");
            }
            Username = u.Username;
            FullName = u.FullName;
            Email = u.Email;
            Password = u.Password;
            Profile_Img_URL = u.Profile_Img_URL;
            AccountCreationDate = u.AccountCreationDate;
            UserRole = u.UserRole;
        }
        #endregion Constructors Start ----------------------------------------------
    }
}
