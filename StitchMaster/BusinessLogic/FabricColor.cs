using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace StitchMaster.BusinessLogic
{
    public class FabricColor
    {
        // Backing Fields
        private readonly int _colorID;
        private string _colorName;

        #region Getter Setter Start --------------------------------------------
        public int ColorID
        {
            get { return _colorID; }
        }
        public string ColorName
        {
            get { return _colorName; }
            set { _colorName = value; }
        }
        #endregion Getter Setter End ----------------------------------------------

        #region Constructors Start ----------------------------------------------
        public FabricColor(int colorID, string colorName)
        {    //Full Param Constructor
            if(IsValid.DBID(colorID))
            {
                this._colorID = colorID;
            }
            else
            {
                throw new ArgumentException("Invalid Color ID");
            }
            ColorName = colorName;
        }
        public FabricColor(FabricColor fC)
        {    // Copy Constructor
            if(fC is null)
            {
                throw new ArgumentNullException("Invalid Fabric Color");
            }
            if (IsValid.DBID(fC.ColorID))
            {
                this._colorID = fC.ColorID;
            }
            else
            {
                throw new ArgumentException("Invalid Color ID");
            }
            this.ColorName = fC.ColorName;
        }
        #endregion Constructors End ----------------------------------------------
    }
}
