namespace StitchMaster.Interfaces
{
    public interface IData
    {
        public bool StoreObject();
        public bool DeleteObject();
        public bool UpdateObject();
        public void GetAllObjects();
    }
}
