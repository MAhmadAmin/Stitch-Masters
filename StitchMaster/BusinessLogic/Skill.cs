using StitchMaster.HelperClasses;

namespace StitchMaster.BusinessLogic
{
    public class Skill
    {
        private  readonly int _skillID;
        private string _skillValue;

        #region Getter Setter Start --------------------------------------------
        public int SkillID
        {
            get { return _skillID; }
        }
        public string SkillValue
        {
            get { return _skillValue; }
            set { _skillValue = value; }
        }
        #endregion Getter Setter Start --------------------------------------------

        #region Constructors Start ----------------------------------------------
        public Skill(int skillID, string skillValue)
        { // Full Param Constructor
            if(IsValid.DBID(skillID))
            {
                _skillID =  skillID;
            }
            else
            {
                throw new ArgumentException("Invalid Skill ID");
            }
            this.SkillValue = skillValue;
        }
        public Skill(Skill s)
        { // Coopy Constructor
            if (IsValid.DBID(s.SkillID))
            {
                _skillID = s.SkillID;
            }
            else
            {
                throw new ArgumentException("Invalid Skill ID");
            }
            this.SkillValue = s.SkillValue;
        }
        #endregion Constructors Start ----------------------------------------------

    }
}
