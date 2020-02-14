

#region using statements

using DataJuggler.Core.UltimateHelper;
using DataJuggler.Core.RandomShuffler;
using RandomArt.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace RandomArt.Util
{

    #region class ShorelineHelper
    /// <summary>
    /// This class is used to make it easy to draw a random shoreline
    /// </summary>
    public class ShorelineHelper
    {

        #region Private Variables
        private List<int> points;
        private RandomShuffler shuffler;
        private int maxHeight;
        private int minHeight;
        private int width;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a ShorelineHelper object
        /// </summary>
        public ShorelineHelper(int minHeight, int maxHeight, int width)
        {
            // Create a new collection of 'int' objects.
            this.Points = new List<int>();

            // Create the Shuffler
            this.Shuffler = new RandomShuffler(1, 100, 7);

            // Store the args
            this.MinHeight = minHeight;
            this.MaxHeight = maxHeight;
            this.Width = width;
        }
        #endregion

        #region Methods

            #region CreatePoints
            /// <summary>
            /// Create the list of Points
            /// </summary>
            /// <returns></returns>
            public List<int> CreatePoints()
            {
                // Get a value
                int item = this.Shuffler.PullNextItem();
                
                // Create the Points collection
                this.Points = new List<int>();

                // Get the start value
                int start = item + this.MinHeight;

                // locals
                int value = start;
                ChangeEnum lastChange = ChangeEnum.NoChange;
                
                // iterate the width of this object
                for (int x = 1; x < this.Width - 1; x++)
                {  
                    // Get a new value
                    item = this.Shuffler.PullNextItem();

                    // most of the time we want it to go straight to the right, but occassionaly it goes up or down a pixel
                    if (item <= 25)
                    {
                        // set the lastChange to moveDown
                        lastChange = ChangeEnum.MoveDown;

                        // Decrement the value for value
                        value--;
                    }
                    else if (item > 75)
                    {
                        // set the lastChange to moveUp
                        lastChange = ChangeEnum.MoveUp;

                        // Decrement the value for value
                        value++;
                    }
                    else
                    {
                        // if even
                        if (item % 2 == 0)
                        {
                            // Nothing happens
                        }
                        else
                        {
                            if (lastChange == ChangeEnum.MoveUp)
                            {
                                // Increment the value for value
                                value++;
                            }
                            else if (lastChange == ChangeEnum.MoveDown)
                            {   
                                // Decrement the value for value
                                value--;
                            }
                            else
                            {
                                // stay the same
                            }
                        }

                        // Stays the same
                        lastChange = ChangeEnum.NoChange;
                    }
                    
                    // if the value is greater than MaxHeight                   
                    if (value > MaxHeight)
                    {
                        // Set to the MaxHeight
                        value = MaxHeight;
                    }

                    // if the value is less than MinHeight                   
                    if (value > MaxHeight)
                    {
                        // Set to the MinHeight
                        value = MinHeight;
                    }

                    // Add this item
                    this.Points.Add(value);
                }

                // Return the Points
                return this.Points;
            }
            #endregion

        #endregion

        #region Properties

            #region HasPoints
            /// <summary>
            /// This property returns true if this object has a 'Points'.
            /// </summary>
            public bool HasPoints
            {
                get
                {
                    // initial value
                    bool hasPoints = (this.Points != null);
                    
                    // return value
                    return hasPoints;
                }
            }
            #endregion
            
            #region MaxHeight
            /// <summary>
            /// This property gets or sets the value for 'MaxHeight'.
            /// </summary>
            public int MaxHeight
            {
                get { return maxHeight; }
                set { maxHeight = value; }
            }
            #endregion
            
            #region MinHeight
            /// <summary>
            /// This property gets or sets the value for 'MinHeight'.
            /// </summary>
            public int MinHeight
            {
                get { return minHeight; }
                set { minHeight = value; }
            }
            #endregion
            
            #region Points
            /// <summary>
            /// This property gets or sets the value for 'Points'.
            /// </summary>
            public List<int> Points
            {
                get { return points; }
                set { points = value; }
            }
            #endregion
            
            #region Shuffler
            /// <summary>
            /// This property gets or sets the value for 'Shuffler'.
            /// </summary>
            public RandomShuffler Shuffler
            {
                get { return shuffler; }
                set { shuffler = value; }
            }
            #endregion
            
            #region Width
            /// <summary>
            /// This property gets or sets the value for 'Width'.
            /// </summary>
            public int Width
            {
                get { return width; }
                set { width = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
