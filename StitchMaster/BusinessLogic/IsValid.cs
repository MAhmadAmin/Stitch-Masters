namespace StitchMaster.BusinessLogic
{
    public class IsValid
    {
        //static public bool Email(string Email)
        //{
        //    if (Email != null)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        //static public bool Password(string Password)
        //{
        //    return true;
        //}
        static public bool DBID(int? ID)
        {
            if (ID > 0)
            {
                return true;
            }
            return false;
        }
    }
}