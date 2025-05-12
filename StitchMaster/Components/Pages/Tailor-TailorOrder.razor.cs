using StitchMaster.BusinessLogic;
using StitchMaster.DataLayer;
using StitchMaster.HelperClasses;

namespace StitchMaster.Components.Pages
{
    public partial class Tailor_TailorOrder
    {
        static Tailor tailor = new Tailor(1, "Tailor Description", 1, "This is username", "This is name", "Tailor EMail", "Tailor Password", "Profile Image", new DateTime(2020, 1, 1), new UserRole(1, "Role"));
        
        static Customer customer = new Customer(1, Gender.GenderType.M, new DateOnly(2020, 1, 1), new List<Address> { new Address(1, null, null, null, null, null, 1) }, 1, "Username", "Name", "Email", "Passwrod", "IMAGE", new DateTime(2020, 1, 1), new UserRole(1, "Role"));
        static FabricPurchased fabric = new FabricPurchased(1, new FabricProduct(1, null, null, new FabricColor(1, null), null, Gender.GenderType.M, 1, 1, 1, null), 1, 1, true);
        
        static TailorOrder order = new TailorOrder(1, tailor, customer, fabric,new Measurement(1,null,4,null,null,null,null,null,null,null,null,null,null), "Make Shalwar", new DateTime(2020, 1, 1), new Status(1, "In Progress"), new Rating(1, 5, "Good"));

        static List<TailorOrder> orders = TailorOrderData.Instance.GetAllObjects();
        public void ViewOrder()
        {

        }
    }
}
