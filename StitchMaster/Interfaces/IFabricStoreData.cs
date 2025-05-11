using StitchMaster.BusinessLogic;

namespace StitchMaster.Interfaces
{
    public interface IFabricStoreData
    {
        public bool StoreObject(FabricStore fabricStore);
        public bool DeleteObject(FabricStore fabricStore);
        public bool UpdateObject(FabricStore fabricStore);
        public List<FabricStore> GetAllObjects();
    }
}
