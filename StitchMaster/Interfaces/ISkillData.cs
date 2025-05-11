using StitchMaster.BusinessLogic;

namespace StitchMaster.Interfaces
{
    public interface ISkillData
    {
        public bool StoreObject(Skill skill);
        public bool DeleteObject(Skill skill);
        public bool UpdateObject(Skill skill);
        public List<Skill> GetAllObjects();
    }
}
