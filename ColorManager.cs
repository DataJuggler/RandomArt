

#region using statements

using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomArt.Enumerations;

#endregion

namespace RandomArt
{

    #region class ColorManager
    /// <summary>
    /// This class is used to hold 3 colors
    /// </summary>
    public class ColorManager
    {
        
        #region Private Variables
        private ColorEnum color1;
        private ColorEnum color2;
        private ColorEnum color3;
        #endregion

        #region Properties

            #region Color1
            /// <summary>
            /// This property gets or sets the value for 'Color1'.
            /// </summary>
            public ColorEnum Color1
            {
                get { return color1; }
                set { color1 = value; }
            }
            #endregion
            
            #region Color2
            /// <summary>
            /// This property gets or sets the value for 'Color2'.
            /// </summary>
            public ColorEnum Color2
            {
                get { return color2; }
                set { color2 = value; }
            }
            #endregion
            
            #region Color3
            /// <summary>
            /// This property gets or sets the value for 'Color3'.
            /// </summary>
            public ColorEnum Color3
            {
                get { return color3; }
                set { color3 = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
