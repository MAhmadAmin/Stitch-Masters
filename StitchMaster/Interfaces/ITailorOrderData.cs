using StitchMaster.BusinessLogic;

namespace StitchMaster.Interfaces
{
    public interface ITailorOrderData
    {
        public bool StoreObject(Tailor tailor, TailorOrder tailorOrder);
        public bool DeleteObject(TailorOrder tailorOrder);
        public bool UpdateObject(TailorOrder tailorOrder);
        public List<TailorOrder> GetAllObjects();

        public TailorOrder GetOrderByID(int ID);

        public bool MarkCompleted(int OrderID);
    }
}
