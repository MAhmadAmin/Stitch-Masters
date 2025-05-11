using StitchMaster.BusinessLogic;

namespace StitchMaster.Interfaces
{
    public interface IFabricColorData
    {
        public bool StoreObject(FabricColor fabricColor);
        public bool DeleteObject(FabricColor fabricColor);
        public bool UpdateObject(FabricColor fabricColor);
        public List<FabricColor> GetAllObjects();
    }
}
