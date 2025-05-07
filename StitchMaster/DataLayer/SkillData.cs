namespace StitchMaster.DataLayer
{
    public class SkillData
    {
        static private SkillData _skillData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private SkillData() { }

        static public SkillData Instance
        {
            get
            {
                if (_skillData == null) // 1st Check (Multiple Threads Can Execute)
                {
                    lock (_lock)
                    {
                        if (_skillData == null) // 2nd Check  (Only Single Thread Can Execute)
                        {
                            _skillData = new SkillData();
                        }
                    }
                }
                return _skillData;
            }
        }
    }
}
