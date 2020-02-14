

#region using statements

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace RandomArt
{

    #region class PointInfo
    /// <summary>
    /// This class is used to indicate a Point and whether or not a Direction change took place at that point
    /// </summary>
    public class PointInfo
    {
        
        #region Private Variables
        private Point point;
        private bool changePoint;
        #endregion

        #region Constructors

            #region Constructor
            /// <summary>
            /// Create a new instance of a Point object and set the value for Point and ChangePoint
            /// </summary>
            /// <param name="point"></param>
            /// <param name="changePoint"></param>
            public PointInfo(Point point, bool changePoint)
            {
                // store the args
                Point = point;
                ChangePoint = changePoint;
            }
            #endregion

            #region Constructor(int x, int y, bool changePoint)
            /// <summary>
            /// Create a new instance of a Point object and set the values to make up a Point and ChangePoint
            /// </summary>
            /// <param name="point"></param>
            /// <param name="changePoint"></param>
            public PointInfo(int x, int y, bool changePoint)
            {
                // store the args
                Point = new Point(x, y);
                
                // Set the value for ChangePoint
                ChangePoint = changePoint;
            }
            #endregion

        #endregion
        
        #region Properties
        
            #region ChangePoint
            /// <summary>
            /// This property gets or sets the value for 'ChangePoint'.
            /// </summary>
            public bool ChangePoint
            {
                get { return changePoint; }
                set { changePoint = value; }
            }
            #endregion
            
            #region Point
            /// <summary>
            /// This property gets or sets the value for 'Point'.
            /// </summary>
            public Point Point
            {
                get { return point; }
                set { point = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
