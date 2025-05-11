using Microsoft.AspNetCore.Components.Forms;
using StitchMaster.BusinessLogic;
using StitchMaster.DataLayer;
using StitchMaster.HelperClasses;


namespace StitchMaster.Components.Pages
{
    public partial class My_Gigs
    {

        static Tailor tailor = TailorData.Instance.GetTailorByEmail(CurrentUser.Email);
        static List<TailorGig> gigs = TailorGigData.Instance.GetAllTailorGigs(tailor);

        static public string email = CurrentUser.Email;
        public  My_Gigs()
        {
            if(CurrentUser.Email == null)
            {
                Navigation.NavigateTo("/signin");
            }
        }

        protected override void OnInitialized()
        {
            Refresh();
        }

        private void Refresh()
        {

            tailor = TailorData.Instance.GetTailorByEmail(CurrentUser.Email);
            gigs = TailorGigData.Instance.GetAllTailorGigs(tailor);
        }
        private void EditGig(int id)
        {
            // Navigate or open edit modal
        }

        private void DeleteGig(int id)
        {
            gigs = TailorGigData.Instance.GetAllTailorGigs(tailor);
            var GigToDEl = gigs.Find(G => G.GigID == id);
            TailorGigData.Instance.DeleteObject(GigToDEl); // <- call your data layer to delete it
            Refresh(); // <- reload the gigs list
            StateHasChanged(); // <- update the UI
        }
    }
}
