using StitchMaster.BusinessLogic;

namespace StitchMaster.Interfaces
{
    public interface IFabricProductData
    {
        public bool StoreObject(FabricStore store,FabricProduct fabricProduct);
        public bool DeleteObject(FabricProduct fabricProduct);
        public bool UpdateObject(FabricProduct fabricProduct);
        public List<FabricProduct> GetAllObjects();
    }
}
