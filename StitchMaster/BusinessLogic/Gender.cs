namespace StitchMaster.BusinessLogic
{
    public class Gender
    {
        public enum GenderType
        {
            M,
            F,
            O
        }
        static public string GenderTypeToString(GenderType genderEnum)
        {
            string ResultGender = "";
            if (genderEnum == GenderType.M)
                ResultGender = "M";
            else if (genderEnum == GenderType.F)
                ResultGender = "F";
            else if (genderEnum == GenderType.O)
                ResultGender = "O";
            else
            {
                throw new ArgumentException("Invlaid Gender Type");
            }
                
            return ResultGender;
        }
        static public GenderType StringToGenderType(String genderStr)
        {
            GenderType ResultGenderEnum = GenderType.M;  // Once Defined bcz it gives error Without it
            if (genderStr == "M" || genderStr == "Male")
                ResultGenderEnum = Gender.GenderType.M;
            else if (genderStr == "F" || genderStr == "Female")
                ResultGenderEnum = Gender.GenderType.F;
            else if (genderStr == "O" || genderStr == "Other")
                ResultGenderEnum = Gender.GenderType.O;
            else
            {
                throw new ArgumentException("Invlaid Gender String");
            }
            return ResultGenderEnum;
        }
    }
}
