using Microsoft.AspNetCore.Components.Forms;
using StitchMaster.BusinessLogic;
using StitchMaster.DataLayer;
using StitchMaster.HelperClasses;


namespace StitchMaster.Components.Pages
{
    public partial class My_Gigs
    {
        static public string email = CurrentUser.Email;
        public  My_Gigs()
        {
            if(CurrentUser.Email == null)
            {
                Navigation.NavigateTo("/signin");
            }
        }
        static Tailor tailor = TailorData.Instance.GetTailorByEmail(CurrentUser.Email);
        static List<TailorGig> gigs = TailorGigData.Instance.GetGigs(tailor);

        private void EditGig(int id)
        {
            // Navigate or open edit modal
        }

        private void DeleteGig(int id)
        {
            // Confirm and delete
        }
    }
}
