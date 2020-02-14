

#region using statements

using DataJuggler.Core.UltimateHelper;
using DataJuggler.Core.RandomShuffler;
using DataJuggler.Win.Controls;
using DataJuggler.Win.Controls.Enumerations;
using DataJuggler.Win.Controls.Interfaces;
using RandomArt.Enumerations;
using RandomArt.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace RandomArt
{

    #region class MainForm
    /// <summary>
    /// This is the Main Form for this application
    /// </summary>
    public partial class MainForm : Form, ISelectedIndexListener, ITextChanged, ICheckChangedListener
    {
        
        #region Private Variables
        private RandomShuffler shuffler;
        private RandomShuffler shuffler2;
        private RandomShuffler shuffler3;
        private RandomShuffler shuffler4;
        private bool stop;
        private LightFilterEnum lightFilter;
        private int threshold;
        private Color baseColor;
        private Color borderColor;
        private int borderWidth;
        private string saveFolder;
        private bool autoSave;
        private int imageNumber;
        private int pointsCount;
        private bool advance;
        private int filterFactor;
        private const int RefreshInterval = 15000;
        private bool validCode;
        private int actualMinWater;
        private const int MinWater = 320;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'MainForm' object.
        /// </summary>
        public MainForm()
        {
            // Create Controls
            InitializeComponent();

            // Perform initializations for this object
            Init();
        }
        #endregion
        
        #region Events
            
            #region AdvanceButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'AdvanceButton' is clicked.
            /// </summary>
            private void AdvanceButton_Click(object sender, EventArgs e)
            {
                // Set Advance = true
                Advance = true;
            }
            #endregion
            
            #region Button_Enter(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Button _ Enter
            /// </summary>
            private void Button_Enter(object sender, EventArgs e)
            {
                // Change the cursor to a hand
                Cursor = Cursors.Hand;
            }
            #endregion
            
            #region Button_Leave(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Button _ Leave
            /// </summary>
            private void Button_Leave(object sender, EventArgs e)
            {
                // Change the cursor back to the default pointer
                Cursor = Cursors.Default;
            }
            #endregion
            
            #region DrawLinesButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'DrawLinesButton_Click' is clicked.
            /// </summary>
            private void DrawLinesButton_Click(object sender, EventArgs e)
            {
                // set to false
                Stop = false;
                StopButton.Visible = true;
                Graph.Visible = true;
                AdvanceButton.Visible = true;
                
                // Refresh everything
                Refresh();
                
                // Finishing drawing before continuing
                Application.DoEvents();

                // set the width and height
                int width = WidthControl.IntValue;
                int height = HeightControl.IntValue;
                
                // create a new bitmap
                Bitmap bitmap = new Bitmap(width, height);
                
                // Draw Random Scenes
                Bitmap image = DrawRandomLines(bitmap);
                
                // Set the background image
                ArtBox.BackgroundImage = image;
                
                // Refresh everything
                Refresh();
                
                // Finishing drawing before continuing
                Application.DoEvents();
            }
            #endregion
            
            #region DrawFromPointButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'DrawFromPointButton' is clicked.
            /// </summary>
            private void DrawFromPointButton_Click(object sender, EventArgs e)
            {
                // set to false
                Stop = false;
                StopButton.Visible = true;
                Graph.Visible = true;
                AdvanceButton.Visible = true;

                // Hide this button
                DrawFromPointButton.Visible = false;
                
                // Refresh everything
                Refresh();
                
                // Finishing drawing before continuing
                Application.DoEvents();

                // set the width and height
                int width = WidthControl.IntValue;
                int height = HeightControl.IntValue;
                
                // create a new bitmap
                Bitmap bitmap = new Bitmap(width, height);
                
                // Draw Random Pixels
                Bitmap image = DrawFromPoint(bitmap);
                
                // Set the background image
                ArtBox.BackgroundImage = image;
                
                // Show this button
                DrawFromPointButton.Visible = true;
                
                // Refresh everything
                Refresh();
                
                // Finishing drawing before continuing
                Application.DoEvents();      
            }
            #endregion
            
            #region DrawScenesButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'DrawScenesButton' is clicked.
            /// </summary>
            private void DrawScenesButton_Click(object sender, EventArgs e)
            {
                // set to false
                Stop = false;
                StopButton.Visible = true;
                Graph.Visible = true;
                AdvanceButton.Visible = true;
                
                // Refresh everything
                Refresh();
                
                // Finishing drawing before continuing
                Application.DoEvents();

                // set the width and height
                int width = WidthControl.IntValue;
                int height = HeightControl.IntValue;
                
                // create a new bitmap
                Bitmap bitmap = new Bitmap(width, height);
                
                // Draw Random Scenes
                Bitmap image = DrawRandomScenes(bitmap);
                
                // Set the background image
                ArtBox.BackgroundImage = image;
                
                // Refresh everything
                Refresh();
                
                // Finishing drawing before continuing
                Application.DoEvents();
            }
            #endregion
            
            #region HideButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'HideButton' is clicked.
            /// </summary>
            private void HideButton_Click(object sender, EventArgs e)
            {  
                // Refresh the UI
                Refresh();
                Application.DoEvents();
            }
            #endregion
            
            #region MainForm_FormClosed(object sender, FormClosedEventArgs e)
            /// <summary>
            /// event is fired when Main Form _ Form Closed
            /// </summary>
            private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
            {
                // Close this application
                Application.Exit();
            }
            #endregion
            
            #region MainForm_Resize(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Main Form _ Resize
            /// </summary>
            private void MainForm_Resize(object sender, EventArgs e)
            {
                // Get a working area
                int workingArea = Width - 300;

                // Center the ArtBox and button
                ArtBox.Left = 300 + (workingArea - ArtBox.Width) / 2;
                ArtBox.Top = (Height - ArtBox.Height) / 2;
                Graph.Left = ArtBox.Left;
                Graph.Top = ArtBox.Top + ArtBox.Height + 8;
                AdvanceButton.Left = ArtBox.Left;
                AdvanceButton.Top = ArtBox.Top - AdvanceButton.Height - 4;
            }
            #endregion

            #region OnCheckChanged(LabelCheckBoxControl sender, bool isChecked);
            /// <summary>
            /// The checkbox has been checked or unchecked.
            /// </summary>
            /// <param name="control"></param>
            /// <param name="selectedIndex"></param>
            public void OnCheckChanged(LabelCheckBoxControl sender, bool isChecked)
            {
                // If the sender object exists
                if (NullHelper.Exists(sender))
                {
                    // if this is the AutoSaveCheckBox
                    if (sender.Name == AutoSaveCheckBox.Name)
                    {
                        // set the vaue for AutoSave
                        AutoSave = sender.Checked;
                        SaveFolderBrowser.Visible = AutoSave;
                        SaveNowButton.Visible = AutoSave;
                        SaveCountLabel.Visible = AutoSave;
                    }
                    else if (sender.Name == SmoothCheckbox.Name)
                    {
                        // if isChecked
                        if (isChecked)
                        {
                            // Disable the SpeedControl
                            SpeedControl.Enabled = false;
                            SpeedControl.LabelColor = Color.DarkGray;
                        }
                        else
                        {
                            // Disable the SpeedControl
                            SpeedControl.Enabled = true;
                            SpeedControl.LabelColor = Color.LemonChiffon;
                        }
                    }
                }
            }
            #endregion

            #region OnTextChanged(Control control, string text);
            /// <summary>
            /// The Selected has changed.
            /// </summary>
            /// <param name="control"></param>
            /// <param name="selectedIndex"></param>
            public void OnTextChanged(Control control, string text)
            {
                // cast the control as a LabelTextBoxControl
                LabelTextBoxControl sender = control as LabelTextBoxControl;
                LabelTextBoxBrowserControl sender2 = control as LabelTextBoxBrowserControl;

                // if the sender exists
                if (NullHelper.Exists(sender))
                {
                    if (sender.Name == "WidthControl")
                    {
                        // Set the Width
                        ArtBox.Width = sender.IntValue;
                        Graph.Width = ArtBox.Width;
                    }
                    else if (sender.Name == "HeightControl")
                    {
                        // Set the Height
                        ArtBox.Height = sender.IntValue;
                    }
                    else if (sender.Name == "ThresholdControl")
                    {
                        // Set the value for Threshold
                        Threshold = sender.IntValue;
                    }
                    
                    // Reposition the ArtBox and Graph
                    MainForm_Resize(this, null);
                }
                else if (NullHelper.Exists(sender2))
                {
                    if (sender2.Name == "SaveFolderTextBox")
                    {
                        // Set the return value
                        SaveFolder = sender.Text;
                    }
                }
            }
            #endregion
            
            #region RandomArtButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'RandomArtButton' is clicked.
            /// </summary>
            private void RandomArtButton_Click(object sender, EventArgs e)
            {
                // set to false
                Stop = false;
                StopButton.Visible = true;
                Graph.Visible = true;
                AdvanceButton.Visible = true;

                // Hide this button
                RandomArtButton.Visible = false;
                
                // Refresh everything
                Refresh();
                
                // Finishing drawing before continuing
                Application.DoEvents();

                // set the width and height
                int width = WidthControl.IntValue;
                int height = HeightControl.IntValue;
                
                // create a new bitmap
                Bitmap bitmap = new Bitmap(width, height);
                
                // Draw Random Pixels
                Bitmap image = DrawRandomArt(bitmap);
                
                // Set the background image
                ArtBox.BackgroundImage = image;
                
                // Hide this button
                RandomArtButton.Visible = true;
                
                // Refresh everything
                Refresh();
                
                // Finishing drawing before continuing
                Application.DoEvents();
            }
            #endregion
            
            #region SaveButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'SaveButton' is clicked.
            /// </summary>
            private void SaveButton_Click(object sender, EventArgs e)
            {
                SaveFileDialog file = new SaveFileDialog();
                
                // Show the save file dialog
                DialogResult result = file.ShowDialog();

                // Get the fileName
                string fileName = file.FileName;

                // Save the current image
                SaveCurrentImage(fileName);
            }
            #endregion
            
            #region SaveNowButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'SaveNowButton' is clicked.
            /// </summary>
            private void SaveNowButton_Click(object sender, EventArgs e)
            {
                // If the SaveFolder string exists
                if (TextHelper.Exists(SaveFolder))
                {
                    // Increment the value for ImageNumber
                    ImageNumber++;

                     // get the fileName
                    string fileName = Path.Combine(SaveFolder, "Image" + imageNumber.ToString() + ".png");

                    // Save the current image
                    SaveCurrentImage(fileName, true);
                }
            }
            #endregion
            
            #region StopButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'StopButton' is clicked.
            /// </summary>
            private void StopButton_Click(object sender, EventArgs e)
            {
                // Set Stop to true
                Stop = true;
                StopButton.Visible = false;
                Graph.Visible = false;
                AdvanceButton.Visible = false;

                // Refresh Everything
                Refresh();
                Application.DoEvents();
            }
            #endregion
            
        #endregion
        
        #region Methods
            
            #region AdjustColor(int color)
            /// <summary>
            /// This method returns the Color
            /// </summary>
            public int AdjustColor(int color)
            { 
                // not used values
                int value2 = 0;
                int value3 = 0;

                // get the adjustment
                int temp = Shuffler4.PullNextItem();

                // if the value for HasShuffler4 is true
                if (HasShuffler4)
                {
                    // if this is an even number
                    if (temp % 2 == 1)
                    {
                        // Decrement the value for green
                        color--;
                    }
                    else
                    {
                        // Increment the value for green
                        color++;
                    }
                } 
                
                // ensure the value for color is in range
                EnsureColorsAreInRange(ref color, ref value2, ref value3);
                
                // return value
                return color;
            }
            #endregion
            
            #region AdjustColor(int red, int green, int blue)
            /// <summary>
            /// This method randomly adjusts the values for red, green and blue from the source
            /// but only by one (possible) shade difference for each color
            /// </summary>
            public Color AdjustColor(int red, int green, int blue)
            {
                // if the value for HasShuffler4 is true
                if (HasShuffler4)
                {
                    // Adjust the color slightly (possibly)
                    red = AdjustColor(red);

                    // Adjust the color slightly (possibly)
                    green = AdjustColor(green);

                    // Adjust the color slightly (possibly)
                    blue = AdjustColor(blue);
                }

                // initial value
                Color color = Color.FromArgb(red, green, blue);
                
                // return value
                return color;
            }
            #endregion
            
            #region ApplyBorder(ref Bitmap target, int x, int y)
            /// <summary>
            /// This method Apply Border
            /// </summary>
            public void ApplyBorder(ref Bitmap target, int x, int y)
            {
                // if the target bitmap exists
                if ((NullHelper.Exists(target)) && (BorderWidth > 0))
                {
                    // First X

                    // if the value for x is less than the border width
                    if (x < BorderWidth)
                    {
                        // Apply the BorderColor
                        target.SetPixel(x, y, BorderColor);
                    }
                    else if (x >= (target.Width - BorderWidth - 1))
                    {   
                        // Apply the BorderColor
                        target.SetPixel(x, y, BorderColor);
                    }

                    // Now Y

                    // if the value for x is less than the border width
                    if (y < BorderWidth)
                    {
                        // Apply the BorderColor
                        target.SetPixel(x, y, BorderColor);
                    }
                    else if (y >= (target.Height - BorderWidth - 1))
                    {   
                        // Apply the BorderColor
                        target.SetPixel(x, y, BorderColor);
                    }
                }
            }
            #endregion
            
            #region ApplyDarkLightFilter(ref int red, ref int green, ref int blue, ColorEnum selectedColor)
            /// <summary>
            /// This method Apply Dark Light Filter
            /// </summary>
            public void ApplyDarkLightFilter(ref int red, ref int green, ref int blue, ColorEnum selectedColor)
            {
                // locals
                int diff = 0;

                // if the SelectedColor is Red
                if (selectedColor == ColorEnum.Red)
                {
                    // if the color is not 255
                    if (red < 255)
                    {
                        // get the half the differences from 255
                        diff = (int) (Math.Sqrt(255 - red) * FilterFactor);

                        // subtract the diff
                        red = red - diff;
                    }
                }
                // if the SelectedColor is Red
                else if (selectedColor == ColorEnum.Green)
                {
                    // if the color is not 255
                    if (green < 255)
                    {
                        // get two times the square root of the difference
                        diff = (int) (Math.Sqrt(255 - green) * FilterFactor);

                        // subtract the diff
                        green = green - diff;
                    }
                }
                else
                {   
                    // Blue

                    // if the color is not 255
                    if (blue < 255)
                    {
                      // get two times the square root of the difference
                        diff = (int) (Math.Sqrt(255 - blue) * FilterFactor);

                        // subtract the diff
                        blue = blue - diff;
                    }
                }
            }
            #endregion
            
            #region ApplyLightFilter(ref int red, ref int green, ref int blue, ColorEnum selectedColor)
            /// <summary>
            /// This method Apply Light Filter
            /// </summary>
            public void ApplyLightFilter(ref int red, ref int green, ref int blue, ColorEnum selectedColor)
            {
                // local
                Color color = Color.Transparent;

                // If there is not a light filter applied
                if (LightFilter == LightFilterEnum.None)
                {
                    // Create the color    
                    color = Color.FromArgb(red, green, blue);
                }
                else
                {
                    // if the LightFilter is dark
                    if (LightFilter == LightFilterEnum.Dark)
                    {
                        // Apply the DarkFilter
                        ApplyDarkLightFilter(ref red, ref green, ref blue, selectedColor);
                    }
                    else
                    {
                        // Apply the ApplyLightFilter
                        ApplyLightLightFilter(ref red, ref green, ref blue, selectedColor);
                    }
                }

               // Ensure the colors are in a range of 0 - 255
               EnsureColorsAreInRange(ref red, ref green, ref blue);
            }
            #endregion
            
            #region ApplyLightLightFilter(ref int red, ref int green, ref int blue, ColorEnum selectedColor)
            /// <summary>
            /// This method Apply Light Light Filter
            /// </summary>
            public void ApplyLightLightFilter(ref int red, ref int green, ref int blue, ColorEnum selectedColor)
            {
                // local
                int diff = 0;
                double squareRoot = 0;

                // if the filterFactor is set
                if (filterFactor > 0)
                {
                    // if the SelectedColor is red
                    if (selectedColor == ColorEnum.Red)
                    {
                        // if the color is not 255
                        if (red < 255)
                        {
                           // get the squareRoot
                            squareRoot = Math.Sqrt(255 - red);

                            // get the half the differences from 255
                            diff = (int) (squareRoot * FilterFactor);

                            // Add the diff
                            red = red + diff;
                        }
                    }
                    // if the SelectedColor is Green
                    else if (selectedColor == ColorEnum.Green)
                    {
                        // if the color is not 255
                        if (green < 255)
                        {
                            // get the squareRoot
                            squareRoot = Math.Sqrt(255 - green);

                            // get the half the differences from 255
                            diff = (int) (squareRoot * FilterFactor);

                            // Add the diff
                            green = green + diff;
                        }
                    }
                    else
                    {
                        // blue

                        // if the color is not 255
                        if (blue < 255)
                        {
                           // get the squareRoot
                            squareRoot = Math.Sqrt(255 - blue);

                            // get the half the differences from 255
                            diff = (int) (squareRoot * FilterFactor);

                            // Add the diff
                            blue = blue + diff;
                        }
                    }
                }
            }
            #endregion
            
            #region ApplyThreshold(ref Bitmap target, int counter, int a, int b, Color color)
            /// <summary>
            /// This method Apply Threshold
            /// </summary>
            public void ApplyThreshold(ref Bitmap target, int counter, int a, int b, Color color)
            {
                // if the Threshhold is 0, just draw the base color
                if (Threshold > 0)
                {
                    // if the Threshold is 100, this will always fire
                    if (Threshold >= (counter % 100))
                    {
                        // Set this piaels color
                        target.SetPixel(a, b, color);
                    }
                    else
                    {
                        // Draw a black pixel
                        target.SetPixel(a, b, BaseColor);
                    }
                }
                else
                {
                    // Draw a black pixel
                    target.SetPixel(a, b, BaseColor);
                }
            }
            #endregion
            
            #region CreateColorManager(int red, int green, int blue)
            /// <summary>
            /// This method returns the Color Manager
            /// </summary>
            public ColorManager CreateColorManager(int red, int green, int blue)
            {
                // initial value
                ColorManager colorManager = new ColorManager();
                
                // if red is the highest
                if ((red >= green) && (red >= blue))
                {
                    // green
                    colorManager.Color1 = ColorEnum.Red;
                            
                    if (green >= blue)
                    {
                        colorManager.Color2 = ColorEnum.Green;
                        colorManager.Color3 = ColorEnum.Blue;
                    }
                    else
                    {
                        colorManager.Color2 = ColorEnum.Blue;
                        colorManager.Color3 = ColorEnum.Green;
                    }
                }
                // if green is the highest
                else if ((green >= red) && (green >= blue))
                {
                    // green
                    colorManager.Color1 = ColorEnum.Green;
                            
                    if (red >= blue)
                    {
                        colorManager.Color2 = ColorEnum.Red;
                        colorManager.Color3 = ColorEnum.Blue;
                    }
                    else
                    {
                        colorManager.Color2 = ColorEnum.Blue;
                        colorManager.Color3 = ColorEnum.Red;
                    }
                }
                else
                {
                    // blue
                    colorManager.Color1 = ColorEnum.Blue;
                            
                    if (red >= green)
                    {
                        colorManager.Color2 = ColorEnum.Red;
                        colorManager.Color3 = ColorEnum.Green;
                    }
                    else
                    {
                        colorManager.Color2 = ColorEnum.Green;
                        colorManager.Color3 = ColorEnum.Red;
                    }
                }
                
                // return value
                return colorManager;
            }
            #endregion
            
            #region DrawBackground(Bitmap source, Bitmap target)
            /// <summary>
            /// This method Draw Background
            /// </summary>
            public void DrawBackground(Bitmap source, Bitmap target)
            {
                // locals
                int counter = 0;

                // Set color to the BaseColor
                Color color = BaseColor;

                // color = Color.SkyBlue;
                
                // First Pass (Draw Background)
                    
                // iterate the width of this image
                for (int x = 0; x < source.Width; x++)
                {
                    // if stop is true or advance is true
                    if ((stop) || (advance))
                    {
                        // break out of the loop
                        break;
                    }

                    // iterate the height of this image
                    for (int y = 0; y < target.Height; y++)
                    {
                        // if stop is true or advance is true
                        if ((stop) || (advance))
                        {
                            // break out of the loop
                            break;
                        }
                        // Increment the value for counter
                        counter++;
                            
                        // Set this pixels color
                        target.SetPixel(x, y, color);
                            
                        // Set the BackgroundImage while this is in progress
                        ArtBox.BackgroundImage = target;
                            
                        //// refresh every RefreshInterval records (much faster)
                        //if (counter % RefreshInterval == 0)
                        //{
                        //    // Refresh everything
                        //    Refresh();
                        
                        //    // Finishing drawing before continuing
                        //    Application.DoEvents();
                        //}
                    }
                }
                    
                // Refresh everything
                Refresh();
                    
                // Finishing drawing before continuing
                Application.DoEvents();
            }
            #endregion
            
            #region DrawBorder(Bitmap target)
            /// <summary>
            /// This method Draw Border
            /// </summary>
            public void DrawBorder(Bitmap target)
            {
                // set the color
                for (int x = 0; x < this.ArtBox.Width; x++)
                {
                    // Drop Top Border
                    target.SetPixel(x, 0, this.BorderColor);

                    // Drop bottom border
                    target.SetPixel(x, this.ArtBox.Height -1, this.BorderColor);
                }

                // set the color
                for (int x = 0; x < this.ArtBox.Height; x++)
                {
                    // Drop Top Border
                    target.SetPixel(0, x, this.BorderColor);

                    // Drop bottom border
                    target.SetPixel(this.ArtBox.Width - 1, x, this.BorderColor);
                }
            }
            #endregion
            
            #region DrawFromPoint()
            /// <summary>
            /// This method returns the From Point
            /// </summary>
            public Bitmap DrawFromPoint(Bitmap source)
            {
                 // Initial value
                Bitmap target = new Bitmap(source.Width, source.Height);
                
                // locals
                Color color = Color.Transparent;
                int red = 0;
                int green = 0;
                int blue = 0;
                int a = 0;
                int b = 0;
                int limit = 5;
                List<List<PointInfo>> pointsCollection = new List<List<PointInfo>>();

                Point point = new Point(a, b);
                
                // Perform initializations for this object
                Init(true);
                
                // Reset the value for Advance
                Advance = false;
                
                // if the source and Shuffler objects both exist                
                if (NullHelper.Exists(source, Shuffler))
                {
                    // Draw the background
                   DrawBackground(source, target);
 
                    do
                    {
                        // Increment the value for ImageNumber
                        ImageNumber++;

                        // Reset Advance
                        Advance = false;
                        
                        // Pull 3 values
                        red = Shuffler.PullNextItem();
                        green = Shuffler.PullNextItem();
                        blue = Shuffler.PullNextItem();

                        // Create a color
                        color = Color.FromArgb(red, green, blue);
                        
                        // default to 5 million
                        int loops = 5000000;

                        // test only
                        loops = 1;

                        // Setup the Graph
                        Graph.Maximum = loops;
                        Graph.Value = 0;
                        Graph.Visible = true;

                        // get the speed
                        int speed = NumericHelper.ParseInteger(SpeedControl.ComboBoxText, 0, -1);

                        // if speed is in range of 1 - 20
                        if ((speed > 0) && (speed <= 20))
                        {
                            // times the speed by one million
                            loops = speed * 1000000;
                        }

                        // Create a random point
                        a = Shuffler2.PullNextItem();
                        b = Shuffler3.PullNextItem();
                        point = new Point(a, b);
                        
                        // iterate up to loops
                        for (int x = 0; x < loops; x++)
                        { 
                             // Pull 3 values
                            red = Shuffler.PullNextItem();
                            green = Shuffler.PullNextItem();
                            blue = Shuffler.PullNextItem();

                            // Create a color
                            color = Color.FromArgb(red, green, blue);

                            // Create a random point
                            a = Shuffler2.PullNextItem();
                            b = Shuffler3.PullNextItem();
                            point = new Point(a, b);

                            // Get the Threshhold
                            Threshold = ThresholdControl.IntValue;

                            // Get the points to draw a line between the two points
                            List<PointInfo> points = GetPoints(point, source.Width, source.Height);
                            
                            // if there are one or more points
                            if (ListHelper.HasOneOrMoreItems(points))
                            {
                                // Add this points
                                pointsCollection.Add(points);

                                // if we have reached the limit
                                if (pointsCollection.Count > limit)
                                {
                                    // Set a reference to the one to remove
                                    List<PointInfo> pointsToRemove = pointsCollection[0];

                                    // iterate the points
                                    foreach (PointInfo tempPoint in pointsToRemove)
                                    { 
                                        if ((tempPoint.Point.X < target.Width) && (tempPoint.Point.Y < target.Height))
                                        {
                                            // Set a pixel
                                            target.SetPixel(tempPoint.Point.X, tempPoint.Point.Y, BaseColor);
                                        }
                                    }

                                    // Remove the oldest one
                                    pointsCollection.RemoveAt(0);
                                }

                                // iterate the points
                                foreach (PointInfo tempPoint in points)
                                {
                                    // Create a random point
                                    a = Shuffler2.PullNextItem();
                                    b = Shuffler3.PullNextItem();
                                    
                                    // get a value
                                    int value = a * b;

                                    // if this is a change direction point
                                    if (tempPoint.ChangePoint)
                                    {
                                        // change the color

                                        // Pull 3 values
                                        red = Shuffler.PullNextItem();
                                        green = Shuffler.PullNextItem();
                                        blue = Shuffler.PullNextItem();

                                        // Create a color
                                        color = Color.FromArgb(red, green, blue);
                                    }

                                    if ((tempPoint.Point.X < target.Width) && (tempPoint.Point.Y < target.Height))
                                    {
                                        if ((value % 100) <= Threshold)
                                        { 
                                            // Set a pixel
                                            target.SetPixel(tempPoint.Point.X, tempPoint.Point.Y, color);
                                        }
                                        else
                                        {
                                            // Set a pixel
                                            target.SetPixel(tempPoint.Point.X, tempPoint.Point.Y, BaseColor);
                                        }
                                    }
                                }
                            }
                            
                            // Set the BackgroundImage while this is in progress
                            ArtBox.BackgroundImage = target;

                            // if x is less than the Max of the Graph
                            if (x < Graph.Maximum)
                            {
                                // Set the value
                                Graph.Value = x;
                            }
                            else
                            {
                                // Set the value
                                Graph.Value = Graph.Maximum;
                            }
                               
                            // Refresh everything
                            Refresh();
                        
                            // Finishing drawing before continuing
                            Application.DoEvents();

                            // Wait for seconds before next pass
                            // System.Threading.Thread.Sleep(2000);
                        }
                        
                        // if AutoSave is true
                        if ((AutoSave) && (TextHelper.Exists(SaveFolder)))
                        {
                            // get the fileName
                            string fileName = Path.Combine(SaveFolder, "Image" + imageNumber.ToString() + ".png");

                            // Save the current image
                            SaveCurrentImage(fileName, true);
                        }

                        // Wait for seconds before next pass
                        System.Threading.Thread.Sleep(2000);

                        // if stop is true, break out of the loop
                        if (stop)
                        {
                            break;
                        }
                        
                    } while (!stop);
                }
                    
                // return value
                return target;
            }
            #endregion

            #region DrawFromPoint2()
            /// <summary>
            /// This method returns the From Point
            /// </summary>
            public Bitmap DrawFromPoint2(Bitmap source)
            {
                 // Initial value
                Bitmap target = new Bitmap(source.Width, source.Height);
                
                // locals
                Color color = Color.Transparent;
                int red = 0;
                int green = 0;
                int blue = 0;
                int a = 0;
                int b = 0;
                Point point = new Point(a, b);
                
                // Perform initializations for this object
                Init();
                
                // Reset the value for Advance
                Advance = false;
                
                // if the source and Shuffler objects both exist                
                if (NullHelper.Exists(source, Shuffler))
                {
                    // Draw the background
                   DrawBackground(source, target);
 
                    do
                    {
                        // Increment the value for ImageNumber
                        ImageNumber++;

                        // Reset Advance
                        Advance = false;
                        
                        // Pull 3 values
                        red = Shuffler.PullNextItem();
                        green = Shuffler.PullNextItem();
                        blue = Shuffler.PullNextItem();

                        // Create a color
                        color = Color.FromArgb(red, green, blue);
                        
                        // default to 5 million
                        int loops = 5000000;

                        // Setup the Graph
                        Graph.Maximum = loops;
                        Graph.Value = 0;
                        Graph.Visible = true;

                        // get the speed
                        int speed = NumericHelper.ParseInteger(SpeedControl.ComboBoxText, 0, -1);

                        // if speed is in range of 1 - 20
                        if ((speed > 0) && (speed <= 20))
                        {
                            // times the speed by one million
                            loops = speed * 1000000;
                        }

                        // Create a random point
                        a = Shuffler2.PullNextItem();
                        b = Shuffler3.PullNextItem();
                        point = new Point(a, b);
                        
                        // iterate up to loops
                        for (int x = 0; x < loops; x++)
                        { 
                             // Pull 3 values
                            red = Shuffler.PullNextItem();
                            green = Shuffler.PullNextItem();
                            blue = Shuffler.PullNextItem();

                            // Create a color
                            color = Color.FromArgb(red, green, blue);

                            // Create a random point
                            a = Shuffler2.PullNextItem();
                            b = Shuffler3.PullNextItem();
                            point = new Point(a, b);

                            // Get the Threshhold
                            Threshold = ThresholdControl.IntValue;

                            // Get the points to draw a line between the two points
                            List<PointInfo> points = GetPoints(point, source.Width, source.Height);

                            // if there are one or more points
                            if (ListHelper.HasOneOrMoreItems(points))
                            {
                                // iterate the points
                                foreach (PointInfo tempPoint in points)
                                {
                                    // get a value
                                    int value = tempPoint.Point.X * tempPoint.Point.Y;

                                    if ((value % 100) < Threshold)
                                    {  
                                        // Set a pixel
                                        target.SetPixel(tempPoint.Point.X, tempPoint.Point.Y, color);
                                    }
                                    else
                                    {
                                        // Set a pixel
                                        target.SetPixel(tempPoint.Point.X, tempPoint.Point.Y, Color.Black);
                                    }
                                }
                            }
                            
                            // Set the BackgroundImage while this is in progress
                            ArtBox.BackgroundImage = target;

                            // if x is less than the Max of the Graph
                            if (x < Graph.Maximum)
                            {
                                // Set the value
                                Graph.Value = x;
                            }
                            else
                            {
                                // Set the value
                                Graph.Value = Graph.Maximum;
                            }
                               
                            // Refresh everything
                            Refresh();
                        
                            // Finishing drawing before continuing
                            Application.DoEvents();

                            // Wait for seconds before next pass
                            // System.Threading.Thread.Sleep(2000);
                        }
                        
                        // if AutoSave is true
                        if ((AutoSave) && (TextHelper.Exists(SaveFolder)))
                        {
                            // get the fileName
                            string fileName = Path.Combine(SaveFolder, "Image" + imageNumber.ToString() + ".png");

                            // Save the current image
                            SaveCurrentImage(fileName, true);
                        }

                        // Wait for seconds before next pass
                        System.Threading.Thread.Sleep(2000);

                        // if stop is true, break out of the loop
                        if (stop)
                        {
                            break;
                        }
                        
                    } while (!stop);
                }
                    
                // return value
                return target;
            }
            #endregion
            
            #region DrawGrassHills(Bitmap target)
            /// <summary>
            /// This method Draw Grass Hills
            /// </summary>
            public void DrawGrassHills(Bitmap target)
            {
                Image image = (Image) target;

                // locals
                Point p;
                Point origin;
                Pen pen = new Pen(Color.ForestGreen);
                pen.Width = 1;
                int baseline = 200;
                int length = 0;
                int width = 0;
                
                Graphics g = Graphics.FromImage(image);

                length = this.Shuffler.PullNextItem() + this.Shuffler.PullNextItem() + 60;

                if (length > 380)
                {
                    length = 380;
                }
                
                // set the width
                width = this.Shuffler.PullNextItem() + this.Shuffler.PullNextItem() + this.Shuffler.PullNextItem();

                if (width < 280)
                {
                    width = 280;
                }

                int startY = baseline;
                int height = length;
                int maxY = 0;

                // Create the rectange
                Rectangle rectangle = new Rectangle(0, startY, this.ArtBox.Width, length);

                for (int x = 0; x < rectangle.Width; x++)
                {
                    for (int y = 0; y < rectangle.Height; y++)
                    {
                        int yLocation = rectangle.Y + y;

                        if (yLocation > 600)
                        {
                            yLocation = 600;
                        }

                        if (yLocation > maxY)
                        {
                            maxY = yLocation;
                        }

                        target.SetPixel(x, yLocation, Color.ForestGreen);

                        // refresh every 100
                        if ((x % 200 == 0) && (y % 100 == 0))
                        {
                            this.Refresh();
                            Application.DoEvents();
                        }
                    }
                }

                this.Refresh();
                Application.DoEvents();

                // Now draw curves to draw from North East to South West lines to draw first hill
                pen = new Pen(Color.SkyBlue);
                pen.Width = 1;
                int factor = (int) ((this.Shuffler.PullNextItem() % 3 + 1) * Math.PI);
                double reduction = 1;
                int reduction2 = (int) reduction;
                double n = 9;
                double width2 = (double) width;

                for (int x = width; x > 0; x -= reduction2)
                {
                    origin = new Point(x, rectangle.Top);

                    int y = rectangle.Top + ((int) (Math.Sqrt(x) * factor));

                    if (y > rectangle.Bottom)
                    {
                        y = rectangle.Bottom;
                    }

                    p = new Point(0, y);

                    g.DrawLine(pen, origin, p);

                    // set the value for reduction
                    double temp = n / width2;
                    double x2 = width - x;
                    reduction = temp * x2;

                    if (reduction > 9)
                    {
                        reduction = 9;
                    }

                    if (reduction < 1)
                    {
                        reduction = 1;
                    }

                    // Set the value for reduction
                    reduction2 = (int) reduction;
                }
               
                this.Refresh();
                Application.DoEvents();

                System.Threading.Thread.Sleep(10000);
            }
            #endregion
            
            #region DrawPoints(Bitmap target, List<Point> points, ColorManager colorManager, int loops)
            /// <summary>
            /// This method Draw Point
            /// </summary>
            public void DrawPoints(Bitmap target, List<Point> points, ColorManager colorManager, int loops)
            {
                // locals
                int pixels = loops;
                int a = 0;
                int b = 0;
                ColorEnum selectedColor = ColorEnum.Red;    
                int counter = 0;
                int red = 0;
                int green = 0;
                int blue = 0;

                // reset the graph
                Graph.Maximum = pixels;
                Graph.Value = 0;
                
                // iterate the width of this image
                for (int p = 0; p < pixels; p++)
                {
                    // if stop is true or advance is true
                    if ((stop) || (advance))
                    {
                        // break out of the loop
                        break;
                    }
                    
                    // Increment the value for counter
                    counter++;

                    // Set the graph value
                    Graph.Value = counter;

                    // iterate the points
                    foreach (Point point in points)
                    {
                         // pull a random location
                        a = Shuffler2.PullNextItem();    
                        b = Shuffler3.PullNextItem();

                        // Set the values for Red, Green and Blue
                        SetColorValues(point, ref red, ref green, ref blue, ref selectedColor, colorManager, target, a, b);
                    
                        // Apply the LightFilter
                        ApplyLightFilter(ref red, ref green, ref blue, selectedColor);

                        // Set the color
                        Color color = Color.FromArgb(red, green, blue);
                    
                        // Apply the pixel if the counter is within the threshold Threshold
                        ApplyThreshold(ref target, counter, a, b, color);

                        // Apply the border if this cell is near the bounds of the border and BorderWidth is set
                        ApplyBorder(ref target, a, b);
                    
                        // Set the BackgroundImage while this is in progress
                        ArtBox.BackgroundImage = target;
                    
                        // refresh every RefreshInterval records (much faster)
                        if (counter % RefreshInterval == 0)
                        {
                            // Refresh everything
                            Refresh();
                        
                            // Finishing drawing before continuing
                            Application.DoEvents();
                        }
                    }
                }

                // Refresh everything
                Refresh();
                        
                // Finishing drawing before continuing
                Application.DoEvents();
            }
            #endregion

            #region DrawPointsEx(Bitmap target, List<Point> points, ColorManager colorManager)
            /// <summary>
            /// This method Draw Point
            /// </summary>
            public void DrawPointsEx(Bitmap target, List<Point> points, ColorManager colorManager)
            {
                // locals
                int a = 0;
                int b = 0;
                int counter = 0;
                int red = 0;
                int green = 0;
                int blue = 0;
                ColorEnum selectedColor = ColorEnum.Red;    
                int pointCounter = 0;
                int desiredPoint = 0;
                
                // calculate the distance from the center
                int maxDistance = target.Width + target.Height;

                 // reset the graph
                Graph.Maximum = target.Width * target.Height;
                Graph.Value = 0;
                
                 // iterate the width of this image
                for (int x = 0; x < target.Width; x++)
                {
                    // if stop is true or advance is true
                    if ((stop) || (advance))
                    {
                        // break out of the loop
                        break;
                    }

                    // iterate the height of this image
                    for (int y = 0; y < target.Height; y++)
                    {
                        // if stop is true or advance is true
                        if ((stop) || (advance))
                        {
                            // break out of the loop
                            break;
                        }

                        // Increment the value for counter
                        counter++;
                        
                        // Set the current value
                        Graph.Value = counter;

                        // get a randomValue
                        int randomValue = Shuffler.PullNextItem();

                        // reset
                        pointCounter = 0;

                        // set the desiredPoint
                        desiredPoint = (randomValue % PointsCount) + 1;

                         // iterate the points
                        foreach (Point point in points)
                        {
                            // increment the value for pointCounter
                            pointCounter++;

                            // only draw the pixel for the point that matches the desiredPoint
                            if (pointCounter == desiredPoint)
                            {
                                // set the current location
                                a = x;
                                b = y;
                        
                                // Set the values for Red, Green and Blue
                                SetColorValues(point, ref red, ref green, ref blue, ref selectedColor, colorManager, target, a, b);
                    
                                // Apply the LightFilter
                                ApplyLightFilter(ref red, ref green, ref blue, selectedColor);

                                // Set the color
                                Color color = Color.FromArgb(red, green, blue);
                    
                                // Apply the Threshold
                                ApplyThreshold(ref target, counter, a, b, color);

                                 // Apply the border if this cell is near the bounds of the border and BorderWidth is set
                                ApplyBorder(ref target, a, b);
                    
                                // Set the BackgroundImage while this is in progress
                                ArtBox.BackgroundImage = target;
                            }
                        }
                    
                        // refresh every RefreshInterval records (much faster)
                        if (counter % RefreshInterval == 0)
                        {
                            // Refresh everything
                            Refresh();
                        
                            // Finishing drawing before continuing
                            Application.DoEvents();
                        }
                    }
                }

                // Refresh everything
                Refresh();
                        
                // Finishing drawing before continuing
                Application.DoEvents();
            }
            #endregion
            
            #region DrawRandomLines(Bitmap source)
            /// <summary>
            /// This method draws a bunch of random lines.
            /// Not really sure if this is useful, just something I tried once.
            /// </summary>
            public Bitmap DrawRandomLines(Bitmap source)
            {
                // Initial value
                Bitmap target = new Bitmap(source.Width, source.Height);
                
                // locals
                Color color = Color.Transparent;
                
                // Perform initializations for this object
                Init();

                // Reset the value for Advance
                Advance = false;

                // Set the threshold
                int loops = this.Threshold;
                
                // if the source and target objects exist
                if (NullHelper.Exists(source, target))
                {  
                    do
                    {
                        // Increment the value for ImageNumber
                        ImageNumber++;

                        // Reset Advance
                        Advance = false;

                        // Draw the background
                        DrawBackground(source, target);

                        // locals
                        Image image = (Image) target;
                        Graphics g = Graphics.FromImage(image);
                        int x = 0;
                        int x2 = 0;
                        int y = 0;
                        int y2 = 0;
                        Point point1 = new Point();
                        Point point2 = new Point();

                        // loop # of times up to whatever Threshhold is set at
                        for (int l = 0; l < loops; l++)
                        {
                            // First we need to get a random color
                            int red = Shuffler.PullNextItem();
                            int green = Shuffler.PullNextItem();
                            int blue = Shuffler.PullNextItem();

                            // Create the color
                            color = Color.FromArgb(red, green, blue);

                            // Set the origin
                            int origin = Shuffler.PullNextItem() % 4 + 1;
                            int second = Shuffler.PullNextItem() % 3;

                            // the second is the left pane
                            x = this.Shuffler2.PullNextItem();
                            x2 = this.Shuffler2.PullNextItem();
                            y = this.Shuffler3.PullNextItem();
                            y2 = this.Shuffler3.PullNextItem();

                            // Determine the action by the origin
                            switch (origin)
                            {
                                case 1:

                                    // The origin is the bottom plane

                                    // Set Point1
                                    point1 = new Point(x, source.Height - 1);

                                    // Now handle the second
                                    switch (second)
                                    {
                                        case 0:

                                            // the second is the left pane

                                            // Set point2
                                            point2 = new Point(0, y2);

                                            // required
                                            break;

                                        case 1:

                                            // the second is the top pane

                                            // Set point2
                                            point2 = new Point(x2, 0);

                                            // required
                                            break;

                                        case 2:

                                            // the second is the right pane

                                            // Set point2
                                            point2 = new Point(source.Width - 1, y2);

                                            // required
                                            break;
                                    }

                                    // required
                                    break;

                                case 2:

                                    // The origin is the left plane

                                    // Set Point1
                                    point1 = new Point(0, y);

                                    // Now handle the second
                                    switch (second)
                                    {
                                        case 0:

                                            // the second is the top pane

                                            // now set point2
                                            point2 = new Point(x2, 0);

                                            // required
                                            break;

                                        case 1:

                                            // the second is the right pane

                                            // now set point2
                                            point2 = new Point(source.Width - 1, y2);

                                            // required
                                            break;

                                        case 2:

                                            // the second is the bottom pane

                                            // now set the points
                                            point2 = new Point(x2, source.Height - 1);

                                            // required
                                            break;
                                    }

                                    // required
                                    break;

                                case 3:

                                    // The origin is the top plane

                                    // Set Point1
                                    point1 = new Point(x, 0);

                                    // Now handle the second
                                    switch (second)
                                    {
                                        case 0:

                                            // the second is the right pane

                                            // now set the points
                                            point2 = new Point(source.Width - 1, y2);

                                            // required
                                            break;

                                        case 1:

                                            // the second is the bottom pane

                                            // now set point2
                                            point2 = new Point(source.Width - 1, y2);

                                            // required
                                            break;

                                        case 2:

                                            // the second is the left pane

                                            // now set point2
                                            point2 = new Point(0, y2);

                                            // required
                                            break;
                                    }

                                    // required
                                    break;

                                case 4:
                                
                                    // The origin is the right plane

                                    // set point1
                                    point1 = new Point(source.Width - 1, y);

                                    // Now handle the second
                                    switch (second)
                                    {
                                        case 0:

                                            // the second is the bottom pane

                                            // set point2
                                            point2 = new Point(x2, source.Height - 1);

                                            // required
                                            break;

                                        case 1:

                                            // the second is the left pane

                                            // set point2
                                            point2 = new Point(0, y2);

                                            // required
                                            break;

                                        case 2:

                                            // the second is the top pane

                                             // set point2
                                            point2 = new Point(x2, 0);

                                            // required
                                            break;
                                    }

                                    // required
                                    break;
                            }

                            // Create the pen
                            Pen pen = new Pen(color, 1);

                            // Draw a line
                            g.DrawLine(pen, point1, point2);
                      
                            //// refresh every 100
                            //if (x % 5 == 0)
                            //{
                            //    // Refresh everything
                            Refresh();
                
                            //    // Finishing drawing before continuing
                            Application.DoEvents();
                            //}
                        }

                        // Update the image
                        this.ArtBox.BackgroundImage = target;
                        
                        // if AutoSave is true
                        if ((AutoSave) && (TextHelper.Exists(SaveFolder)))
                        {
                            // get the fileName
                            string fileName = Path.Combine(SaveFolder, "Image" + imageNumber.ToString() + ".png");

                            // Save the current image
                            SaveCurrentImage(fileName, true);
                        }

                        // Wait for seconds before next pass
                        System.Threading.Thread.Sleep(12000);

                        // if stop is true, break out of the loop
                        if (stop)
                        {
                            break;
                        }
                        
                    } while (!stop);
                }
                    
                // return value
                return target;
            }
            #endregion
            
            #region DrawRandomArt(Bitmap source)
            /// <summary>
            /// This method Draw Random Art
            /// </summary>
            public Bitmap DrawRandomArt(Bitmap source)
            {
                // Initial value
                Bitmap target = new Bitmap(source.Width, source.Height);
                
                // locals
                Color color = Color.Transparent;
                int red = 0;
                int green = 0;
                int blue = 0;
                
                // Perform initializations for this object
                Init();

                // Reset the value for Advance
                Advance = false;
                
                // if the source and Shuffler objects both exist                
                if ((NullHelper.Exists(source, Shuffler)) && (PointsControl.HasSelectedObject))
                {
                    // Draw the background
                   DrawBackground(source, target);

                    // Set the PointsCount
                    PointsCount = NumericHelper.ParseInteger(PointsControl.SelectedObject.ToString(), 0, -1);
                    
                    do
                    {
                        // Increment the value for ImageNumber
                        ImageNumber++;

                        // Reset Advance
                        Advance = false;

                        // create the points
                        List<Point> points = new List<Point>();

                        // iterate up to Points
                        for (int x = 0; x < PointsCount; x++)
                        {
                            // pull a random location
                            int a = Shuffler2.PullNextItem();
                            int b = Shuffler3.PullNextItem();

                            // Create a new instance of a 'Point' object.
                            Point point = new Point(a, b);

                            // Add this point
                            points.Add(point);
                        }
                     
                        // Pull 3 values
                        red = Shuffler.PullNextItem();
                        green = Shuffler.PullNextItem();
                        blue = Shuffler.PullNextItem();

                        // Create the colorManager
                        ColorManager colorManager = CreateColorManager(red, green, blue);
                        
                        // default to 5 million
                        int loops = 5000000;
    
                        // get the speed
                        int speed = NumericHelper.ParseInteger(SpeedControl.ComboBoxText, 0, -1);

                        // if speed is in range of 1 - 20
                        if ((speed > 0) && (speed <= 20))
                        {
                            // times the speed by one million
                            loops = speed * 1000000;
                        }
                        
                            // if Smooth is checked
                        if (SmoothCheckbox.Checked)
                        {
                            // Draw Points
                            DrawPointsEx(target, points, colorManager);
                        }
                        else
                        {
                            // Draw Points
                            DrawPoints(target, points, colorManager, loops);
                        }
                        
                        // if AutoSave is true
                        if (AutoSave)
                        {
                            // The SaveFolder must be set
                            SaveFolder = this.SaveFolderBrowser.Text;
                        }

                        // if AutoSave is true
                        if ((AutoSave) && (TextHelper.Exists(SaveFolder)))
                        {
                            // get the fileName
                            string fileName = Path.Combine(SaveFolder, "Image" + imageNumber.ToString() + ".png");

                            // Save the current image
                            SaveCurrentImage(fileName, true);
                        }

                        // Wait for seconds before next pass
                        System.Threading.Thread.Sleep(2000);

                        // if stop is true, break out of the loop
                        if (stop)
                        {
                            break;
                        }
                        
                    } while (!stop);
                }
                    
                // return value
                return target;
            }
            #endregion
                
            #region DrawRandomScenes(Bitmap source)
            /// <summary>
            /// This method draws Random Scenes
            /// </summary>
            public Bitmap DrawRandomScenes(Bitmap source)
            {
                // Initial value
                Bitmap target = new Bitmap(source.Width, source.Height);
                
                // locals
                Color color = Color.Transparent;
                
                // Perform initializations for this object
                Init();

                // Reset the value for Advance
                Advance = false;
                
                // if the source and target objects exist
                if (NullHelper.Exists(source, target))
                {  
                    do
                    {
                        // Increment the value for ImageNumber
                        ImageNumber++;

                        // Reset Advance
                        Advance = false;

                        // Draw the background
                        DrawBackground(source, target);

                         // Draw the water (this is needed to set ActualMinWater
                        //  ShorelineHelper helper = DrawWater(target);

                        // Draw the sand leading up from the water
                        // DrawSand(target);
                        
                        // Draw the water again (with the same Shoreline; this was needed to sed ActualMinWater)
                        // DrawWater(target, helper);

                        // Draw the hils of gass above the target
                        DrawGrassHills(target);

                        // Draw the border
                        DrawBorder(target);

                        // Refresh everything
                        Refresh();
                
                        // Finishing drawing before continuing
                        Application.DoEvents();

                        // Update the image
                        this.ArtBox.BackgroundImage = target;
                        
                        // if AutoSave is true
                        if ((AutoSave) && (TextHelper.Exists(SaveFolder)))
                        {
                            // get the fileName
                            string fileName = Path.Combine(SaveFolder, "Image" + imageNumber.ToString() + ".png");

                            // Save the current image
                            SaveCurrentImage(fileName, true);
                        }

                        // Wait for seconds before next pass
                        System.Threading.Thread.Sleep(12000);

                        // if stop is true, break out of the loop
                        if (stop)
                        {
                            break;
                        }
                        
                    } while (!stop);
                }
                    
                // return value
                return target;
            }
            #endregion
            
            #region DrawSand(Bitmap target)
            /// <summary>
            /// This method Draw Sand
            /// </summary>
            public void DrawSand(Bitmap target)
            {
                // 237, 214, 110
                Color sand = Color.FromArgb(237, 214, 110);

                // local
                int minWater = this.ArtBox.Height;

                // iterate the width of the ArtBox
                for (int x = 0; x < this.ArtBox.Width; x++)
                {
                    for (int y = this.ActualMinWater - 120; y < this.ActualMinWater + 120; y++)
                    {
                        target.SetPixel(x, y, sand);
                    }
                }

                 
            }
            #endregion
            
            #region DrawWater(Bitmap target, ShorelineHelper helper = null)
            /// <summary>
            /// This method Draw Water
            /// </summary>
            public ShorelineHelper DrawWater(Bitmap target, ShorelineHelper helper = null)
            {
                // if the helper does not exist
                if (NullHelper.IsNull(helper))
                {
                    // locals
                    helper = new ShorelineHelper(MinWater, 520, target.Width);
                }

                // Create the points
                helper.CreatePoints();

                // locals
                int red = 0;
                int green = 0;
                int blue = 0;
                int count = 0;

                // Set the value for ActualMinWater; used in the DrawSand method
                this.ActualMinWater = 9999;

                // get the max length of any point
                int max = helper.Points.Max();

                // if the helper has Points
                if (helper.HasPoints)
                {
                    // Iterate the Points
                    for (int x = 0; x < helper.Points.Count; x++)
                    {
                        // reset 
                        count = 0;

                        // iterate each line down from where the point starts
                        for (int y = helper.Points[x]; y < target.Height; y++)
                        {
                            // incrment the value for count
                            count++;

                            // Get the scaled value based upon the Y
                            red = (int) GetYScale(ColorEnum.Red, y, max, count);
                            green = (int) GetYScale(ColorEnum.Green, y, max, count);
                            blue = (int) GetYScale(ColorEnum.Blue, y, max, count);
                            
                            // For safety
                            EnsureColorsAreInRange(ref red, ref green, ref blue);

                            // Get the color
                            Color color = Color.FromArgb(red, green, blue);
                            
                            // blue for now
                            target.SetPixel(x, y, color);

                            if (y < this.ActualMinWater)
                            {
                                // reset this value
                                this.ActualMinWater = y;
                            }
                        }
                    }
                }

                // return value
                return helper;
            }
            #endregion
            
            #region EnsureColorsAreInRange(ref int red, ref int green, ref int blue)
            /// <summary>
            /// This method Ensure Colors Are In Range
            /// </summary>
            public void EnsureColorsAreInRange(ref int red, ref int green, ref int blue)
            {
                 // if red is less than zero
                if (red < 0)
                {
                    // reset to 0
                    red = 0;
                }
                else if (red > 255)
                { 
                    // reset to 255
                    red = 255;
                }

                // if green is less than zero
                if (green < 0)
                {
                    // reset to 0
                    green = 0;
                }
                else if (green > 255)
                { 
                    // reset to 255
                    green = 255;
                }

                // if blue is less than zero
                if (blue < 0)
                {
                    // reset to 0
                    blue = 0;
                }
                else if (blue > 255)
                { 
                    // reset to 255
                    blue = 255;
                }
            }
            #endregion
            
            #region GetPoints(Point point, int width, int height)
            /// <summary>
            /// This method returns a list of Points
            /// </summary>
            public List<PointInfo> GetPoints(Point point, int width, int height)
            {
                // initial value
                List<PointInfo> points = new List<PointInfo>();
                
                // locals
                int max = 0;
                int min = 0;
                int size = Shuffler4.PullNextItem();
                int range = 0;
                int horCount = 0;
                int verCount = 0;
                Point tempPoint = new Point(0, 0);
                PointInfo tempPointInfo = null;
                DirectionEnum direction = DirectionEnum.North;
                bool firstItemThisDirection = false;
                bool outOfBounds = false;
                int lineThickness = 20;
                Point point2 = new Point(0,0);

                // Create a pointInfo object
                PointInfo pointInfo = new PointInfo(point, true);

                // Add the first pointInfo
                points.Add(pointInfo);

                do 
                {
                    // if we have reached out of bounds
                    if (outOfBounds)
                    {
                        // break out of this loop
                        break;
                    }

                    // Turn Right (Change Direction)
                    int directionValue = (int) direction + 1;

                    // Reset the value
                    firstItemThisDirection = true;

                    // If directionValue is greater than or equal to 4
                    if (directionValue >= 4)
                    {
                        // Reset the direction value
                        directionValue = 0;
                    }

                    // Set the value for direction
                    direction = (DirectionEnum) directionValue;

                    // if East or West
                    if ((direction == DirectionEnum.East) || (direction == DirectionEnum.West))
                    {
                        // Increment the value for horCount
                        horCount++;

                        // set the value for range
                        range = size * horCount;
                    }

                    // if North or South
                    if ((direction == DirectionEnum.North) || (direction == DirectionEnum.South))
                    {
                        // Increment the value for verCount
                        verCount++;

                        // set the value for range
                        range = size * verCount;
                    }
                    
                    switch (direction)
                    {
                        case DirectionEnum.North:

                            // set the value for point2
                            point2 = new Point(point.X, point.Y - range);

                            // if point2 is less than zero
                            if (point2.Y < 0)
                            {
                                // ensure it stays in bounds
                                point2.Y = 0;
                            }

                            // set the value for min
                            min = point.Y - range;

                            for (int y = point.Y - 1; y > min; y--)
                            {
                                // if out of bounds
                                if (y < 0)
                                {
                                    // this is out of bounds
                                    outOfBounds = true;

                                    // break out of the loop
                                    break;
                                }

                                // iterate East for 20 pixels
                                for (int n = point.X; n < (point.X - lineThickness); n++)
                                {
                                    // if this item is range
                                    if (n < (width - 1))
                                    {
                                        // create a point
                                        tempPoint = new Point(n, y);
                                    
                                        // set the value for point
                                        point = tempPoint;

                                        // if this is the first one
                                        if (firstItemThisDirection)
                                        {
                                            // create a tempPointInfo object
                                            tempPointInfo = new PointInfo(tempPoint, true);

                                            // Reset to false
                                            firstItemThisDirection = false;
                                        }
                                        else
                                        {
                                            // create a tempPointInfo object
                                            tempPointInfo = new PointInfo(tempPoint, false);
                                        }

                                        // Add this tempPointInfo
                                        points.Add(tempPointInfo);
                                    }
                                }

                                 
                            }
                            
                            // required
                            break;

                        case DirectionEnum.East:

                            // set the value for point2
                            point2 = new Point(point.X + range, point.Y);

                            // if out of bounds
                            if (point2.X > (width - 1))
                            {
                                // reset the value for X
                                point2.X = width - 1;
                            }

                            // set the value for max
                            max = point.X + range;

                            for (int x = point.X + 1; x < max; x++)
                            {
                                // if out of bounds
                                if (x > (width - 1))
                                {
                                    // this is out of bounds
                                    outOfBounds = true;

                                    // break out of the loop
                                    break;
                                }

                                 // iterate South for 20 pixels
                                for (int n = point.Y; n < (point.Y + lineThickness); n++)
                                {
                                    // if this item is range
                                    if (n < (height - 1))
                                    {
                                        // create a point
                                        tempPoint = new Point(x, n);
                                        
                                        // if this is the first one
                                        if (firstItemThisDirection)
                                        {
                                            // create a tempPointInfo object
                                            tempPointInfo = new PointInfo(tempPoint, true);

                                            // Reset to false
                                            firstItemThisDirection = false;
                                        }
                                        else
                                        {
                                            // create a tempPointInfo object
                                            tempPointInfo = new PointInfo(tempPoint, false);
                                        }
                                
                                        // Add this tempPointInfo
                                        points.Add(tempPointInfo);
                                    }
                                }
                            }
                            
                            // required
                            break;

                        case DirectionEnum.South:

                            // set the value for point2
                            point2 = new Point(point.X, point.Y + range);

                            // if out of bounds
                            if (point2.Y > (height - 1))
                            {
                                // reset the value for Y
                                point2.Y = height - 1;
                            }

                            // set the value for max
                            max = point.Y + range;

                            for (int y = point.Y + 1; y < max; y++)
                            {
                                // if out of bounds
                                if (y > (height - 1))
                                {
                                    // this is out of bounds
                                    outOfBounds = true;

                                    // break out of the loop
                                    break;
                                }
                                
                                // iterate West for 20 pixels
                                for (int n = point.X + lineThickness; n > point.X; n--)
                                {
                                    // if this item is range
                                    if (n >= 0)
                                    {
                                        // create a point
                                        tempPoint = new Point(n, y);
                                        
                                        // if this is the first one
                                        if (firstItemThisDirection)
                                        {
                                            // create a tempPointInfo object
                                            tempPointInfo = new PointInfo(tempPoint, true);

                                            // Reset to false
                                            firstItemThisDirection = false;
                                        }
                                        else
                                        {
                                            // create a tempPointInfo object
                                            tempPointInfo = new PointInfo(tempPoint, false);
                                        }
                                
                                        // Add this tempPointInfo
                                        points.Add(tempPointInfo);
                                    }
                                }      
                            }
                            
                            // required
                            break;

                        case DirectionEnum.West:

                             // set the value for point2
                            point2 = new Point(point.X - range, point.Y);

                             // if point2.X is less than zero
                            if (point2.X < 0)
                            {
                                // ensure it stays in bounds
                                point2.X = 0;
                            }

                            // set the value for min
                            min = point.X - range;

                            for (int x = point.X - 1; x > min; x--)
                            {
                                // if out of bounds
                                if (x < 0)
                                {
                                    // this is out of bounds
                                    outOfBounds = true;

                                    // break out of the loop
                                    break;
                                }

                                // iterate North for 20 pixels
                                for (int n = point.Y + 20; n > (point.Y); n--)
                                {
                                    // if this item is range
                                    if (n > 0)
                                    {
                                        // create a point
                                        tempPoint = new Point(x, n);
                                        
                                         // if this is the first one
                                        if (firstItemThisDirection)
                                        {
                                            // create a tempPointInfo object
                                            tempPointInfo = new PointInfo(tempPoint, true);

                                            // Reset to false
                                            firstItemThisDirection = false;
                                        }
                                        else
                                        {
                                            // create a tempPointInfo object
                                            tempPointInfo = new PointInfo(tempPoint, false);
                                        }
                                
                                        // Add this tempPointInfo
                                        points.Add(tempPointInfo);
                                    }
                                }
                            }

                            // required
                            break;                        
                    }

                    // Set the value for Point
                    point = point2;

                } while (true);
                
                // return value
                return points;
            }
            #endregion
            
            #region GetYScale(ColorEnum color, int y, int max, int count)
            /// <summary>
            /// This method returns the Y Scale for Drawing water
            /// </summary>
            public double GetYScale(ColorEnum color, int y, int max, int count)
            {
                // initial value
                double yScale = 0;

                // values for Scale

                // Reduce max by 1
                max--;
                
                // locals
                double maxColor = 0;
                double minColor = 0;
                double total = 720 - max;
                double y2 = (double) y;
                double colorChange = 0;
                double changePerY = 0;
                
                switch (color)
                {
                    case ColorEnum.Red:

                        // Set the max and min color values
                        maxColor = 78;
                        minColor = 26;

                        // required
                        break;

                    case ColorEnum.Green:

                        // Set the max and min color values
                        maxColor = 233;
                        minColor = 131;

                        // required
                        break;

                    case ColorEnum.Blue:

                        // Set the max and min color values
                        maxColor = 237;
                        minColor = 186;

                        // required
                        break;
                }

                // Set the value for colorChange
                colorChange = maxColor - minColor;

                // Now set the value of changePerY
                changePerY = colorChange / total;

                // if this is the first pixel for y
                if (count == 1)
                {
                    // Set to maxColor
                    yScale = maxColor;
                }
                else
                {
                    // Set the value for yScale
                    yScale = maxColor - (changePerY * count);
                }
                
                // return value
                return yScale;
            }
            #endregion
            
            #region Init(bool createShuffler4 = false)
            /// <summary>
            /// This method  This method performs initializations for this object.
            /// </summary>
            public void Init(bool createShuffler4 = false)
            {  
                // if the items have not been loaded yet
                if (FilterControl.Items.Count == 0)
                {  
                     // Reset the ImageNumber 
                    ImageNumber = 0;
                    SaveCountLabel.Text = "0";

                    // Load the items
                    FilterControl.LoadItems(typeof(LightFilterEnum));
                    LightFilter = LightFilterEnum.None;

                    // Only set this the first time
                    WidthControl.Text = "1280";
                    HeightControl.Text = "720";
                    
                    // create a list of speeds (also used for points)
                    List<int> speeds = new List<int>();

                    // iterate up to 20
                    for (int x = 1; x <= 20; x++)
                    {
                        // Add this speed
                        speeds.Add(x);
                    }

                    // load the speeds
                    SpeedControl.LoadItems(speeds);

                    // The same 20 items can work for Points also
                    PointsControl.LoadItems(speeds);

                    // Default to 5
                    SpeedControl.SelectedIndex = 4;

                    // Default to 1
                    PointsControl.SelectedIndex = 0;

                    // Set the Threshhold
                    Threshold = 100;
                    ThresholdControl.Text = "100";
                       
                    // Load the comboboxes for BorderColor
                    BaseColorControl.LoadItems(typeof(KnownColor));
                    BaseColorControl.SelectedIndex = BaseColorControl.FindItemIndexByValue("Black");
                    BaseColorControl.SelectedIndexListener = this;
                    BaseColor = Color.Black;
   
                    // Load the comboboxes for BorderColor
                    BorderColorControl.LoadItems(typeof(KnownColor));
                    BorderColorControl.SelectedIndex = BaseColorControl.FindItemIndexByValue("White");
                    BorderColorControl.SelectedIndexListener = this;
                    BorderColor = Color.White;

                    // get a list of ints up to 8
                    List<int> borders = new List<int>();

                    // List Border Widths
                    for (int x = 0; x <= 8; x++)
                    {
                        // add to borders
                        borders.Add(x);
                    }

                    // Load the items
                    BorderWidthControl.LoadItems(borders);
                    BorderWidthControl.SelectedIndex = 1;
                    BorderWidthControl.SelectedIndexListener = this;
                    BorderWidth = 1;

                     // get a list of ints up to 5
                    List<int> factors = new List<int>();

                    // List Border Widths
                    for (int x = 1; x <= 5; x++)
                    {
                        // add to borders
                        factors.Add(x);
                    }

                    // Set the properties for the FilterFactorControl
                    FilterFactorControl.LoadItems(factors);
                    FilterFactorControl.SelectedIndex = 0;
                    FilterFactorControl.SelectedIndexListener = this;
                    FilterFactor = 1;
                    
                    // Set the properties on the SaveFolderBrowser
                    SaveFolderBrowser.BrowseType = BrowseTypeEnum.Folder;
                    SaveFolderBrowser.LabelWidth = 140;
                    SaveFolderBrowser.LabelText = "Save In:";
                    SaveFolderBrowser.OnTextChangedListener = this;
                    
                    // Setup the CheckChangedListener
                    AutoSaveCheckBox.CheckChangedListener = this;
                    AutoSaveCheckBox.Checked = true;
                    AutoSave = true;

                    // Setup the SmoothCheckbox
                    SmoothCheckbox.CheckChangedListener = this;
                    SmoothCheckbox.Checked = true;
                    OnCheckChanged(SmoothCheckbox, true);
                }

                int width = WidthControl.IntValue - 1;
                int height = HeightControl.IntValue - 1;

                // Create the Shuffler
                Shuffler = new RandomShuffler(0, 255, 25);
                Shuffler2 = new RandomShuffler(0, width, 10);
                Shuffler3 = new RandomShuffler(0, height, 10);
                
                // if the value for createShuffler4 is true
                if (createShuffler4)
                {
                    // Create a new instance of a 'RandomShuffler' object.
                    Shuffler4 = new RandomShuffler(16, 100, 100);
                }

                // Setup the Listener
                FilterControl.SelectedIndexListener = this;
                WidthControl.OnTextChangedListener = this;
                HeightControl.OnTextChangedListener = this;
                ThresholdControl.OnTextChangedListener = this;
                PointsControl.SelectedIndexListener = this;
            }
            #endregion

            #region MovePoint(int a, int b, int width, int height)
            /// <summary>
            /// This method returns the Point
            /// </summary>
            public Point MovePoint(int a, int b, int width, int height)
            {
                // initial value
                Point point = new Point();

                // get a value for moveMent
                int move = Shuffler4.PullNextItem();
                int move2 = Shuffler4.PullNextItem();
                
                // get the value down to 1 - 8
                move2 = (move2 % 8) + 1;
                
                // now calculate the value for a and b based upon this movement
                switch(move2)
                {
                    case 1:
                    
                        // North West from the current point
                        a = a - move;
                        b = b - move;

                        // required
                        break;

                    case 2:

                        // North of the current point
                        b = b - move;

                        // required
                        break;
                                
                    case 3:

                        // North East of the current point
                        a = a + move;
                        b = b - move;

                        // required
                        break;

                    case 4:

                        // West of the Current Point
                        a = a - move;

                        // required
                        break;
                                
                    case 5:

                        // Wast of the current point
                        a = a + move;
                                    
                        // required
                        break;

                    case 6:

                        // South West of the current point
                        a = a - move;
                        b = b + move;

                        // requiredf
                        break;
                                
                    case 7:

                        // South of the current point
                        b = b + move;
                                    
                        // required
                        break;

                    case 8:

                        // South East of the current point
                        a = a + move;
                        b = b + move;

                        // required
                        break;
                }

                // ensure a is in range of the image

                // if a is less than zero
                if (a < 0)
                {
                    // set the value for a
                    a = 0;
                }

                // if a is too wide
                if (a > (width -1))
                {
                    // set the max value for a
                    a = width - 1;
                }
                
                // ensure b is in range of the image

                // if b is less than zero
                if (b < 0)
                {
                    // set the value for b
                    b = 0;
                }

                // if b is too tall
                if (b > (height -1))
                {
                    // set the max value for b
                    b = height - 1;
                }
                
                // Create the return value
                point = new Point(a, b);

                // return value
                return point;
            }
            #endregion
            
            #region OnSelectedIndexChanged(LabelComboBoxControl control, int selectedIndex, object selectedItem);
            /// <summary>
            /// The Selected has changed.
            /// </summary>
            /// <param name="control"></param>
            /// <param name="selectedIndex"></param>
            /// <param name="selectedItem"></param>
            public void OnSelectedIndexChanged(LabelComboBoxControl control, int selectedIndex, object selectedItem)
            { 
                // If the control object exists
                if ((NullHelper.Exists(control)) && (control.HasSelectedObject))
                {   
                    // if this is the FilterControl
                    if (control.Name == FilterControl.Name)
                    {
                        // Reset
                        LightFilter = LightFilterEnum.None;

                        // get the text of the selected object
                        string text = control.SelectedObject.ToString();

                        // if Light
                        if (TextHelper.IsEqual(text, "Light"))
                        {
                            // Set to Light
                            LightFilter = LightFilterEnum.Light;
                        }
                        else if (TextHelper.IsEqual(text, "Dark"))
                        {
                            // Set to Dark
                            LightFilter = LightFilterEnum.Dark;
                        }
                    }
                    // if the BaseColorControl
                    else if (control.Name == BaseColorControl.Name)
                    {
                        // Get the colorName
                        string colorName = control.SelectedObject.ToString();

                        // Set the BaseColor
                        BaseColor = Color.FromName(colorName);
                    }
                    else if (control.Name == BorderWidthControl.Name)
                    {
                        // Set the BorderWidth
                        BorderWidth = NumericHelper.ParseInteger(BorderWidthControl.SelectedObject.ToString(), 0, -1);
                    }
                    else if (control.Name == BorderColorControl.Name)
                    {
                        // Get the colorName
                        string colorName = control.SelectedObject.ToString();

                        // Set the BaseColor
                        BorderColor = Color.FromName(colorName);
                    }
                    else if (control.Name == PointsControl.Name)
                    {
                        // set the pointsCount
                        PointsCount = NumericHelper.ParseInteger(PointsControl.SelectedObject.ToString(), 0, -1);
                    }
                    else if (control.Name == FilterFactorControl.Name)
                    {
                        // Set the FilterFactor
                        FilterFactor = NumericHelper.ParseInteger(FilterFactorControl.SelectedObject.ToString(), 0, -1);
                    }
                }
            }
            #endregion
            
            #region SaveCurrentImage(string fileName, bool updateCount = false)
            /// <summary>
            /// This method Save Current Image
            /// </summary>
            public void SaveCurrentImage(string fileName, bool updateCount = false)
            {
                // If the fileName string exists
                if (TextHelper.Exists(fileName))
                {
                    // create a fileInfo
                    FileInfo file = new FileInfo(fileName);
                    
                    // if the exension is not set
                    if (!TextHelper.Exists(file.Extension))
                    {
                        // add the extension
                        fileName = TextHelper.CombineStrings(fileName, ".png");
                    }

                    // Get the current image
                    Bitmap currentImage = new Bitmap(ArtBox.BackgroundImage);

                    // Set the Resolution of the image
                    currentImage.SetResolution(300, 300);

                    // Save the current image
                    currentImage.Save(fileName, ImageFormat.Png);

                    // if UpdateCount is true
                    if (updateCount) 
                    {
                        // Set the ImageNumber
                        SaveCountLabel.Text = ImageNumber.ToString();
                    }
                }
            }
            #endregion
            
            #region SetColorValues(Point point, ref int red, ref int green, ref int blue, ref ColorEnum selectedColor, ColorManager colorManager, Bitmap target, int a, int b)
            /// <summary>
            /// This method Set Color Values
            /// </summary>
            public void SetColorValues(Point point, ref int red, ref int green, ref int blue, ref ColorEnum selectedColor, ColorManager colorManager, Bitmap target, int a, int b)
            {
                // if the colorManager exists
                if (NullHelper.Exists(colorManager))
                {
                    // calculate the distance from the center
                    int maxDistance = target.Width + target.Height;

                    // get the distance from the center
                    int horizontal = Math.Abs(point.X - a);
                    int vertical = Math.Abs(point.Y - b);
                    
                    // add these two values up
                    int distance = horizontal + vertical;
                    
                    // calculate a value
                    double value =100000 / maxDistance * distance;
                    double value2 = 765 * (value * .00001);
                    int value3 = (int) value2;
                    
                    // if the value is in the first range
                    if (value3 <= 255)
                    {
                        if (colorManager.Color1 == ColorEnum.Red)
                        {
                            // set the value for red
                            red = 255 - value3;
                            blue = 0;
                            green = 0;
                            
                            // Set the selected color
                            selectedColor = ColorEnum.Red;
                        }
                        else if (colorManager.Color1 == ColorEnum.Green)
                        {
                            // set the value for green
                            green = 255 - value3;
                            blue = 0;
                            red = 0;
                            
                            // Set the selected color
                            selectedColor = ColorEnum.Green;
                        }
                        else if (colorManager.Color1 == ColorEnum.Blue)
                        {
                            // set the value for blue
                            blue = 255 - value3;
                            green = 0;
                            red = 0;
                            
                            // Set the selected color
                            selectedColor = ColorEnum.Blue;
                        }
                    }
                    // if the value is in the second range
                    else if (value3 <= 510)
                    {
                        if (colorManager.Color2 == ColorEnum.Red)
                        {
                            // set the value for red
                            red = 255 - (value3 - 255);
                            green = 0;
                            blue = 0;
                            
                            // Set the selected color
                            selectedColor = ColorEnum.Red;
                        }
                        else if (colorManager.Color2 == ColorEnum.Green)
                        {
                            // set the value for green
                            green = 255 - (value3 - 255);
                            red = 0;
                            blue = 0;
                            
                                // Set the selected color
                            selectedColor = ColorEnum.Green;
                        }
                        else if (colorManager.Color2 == ColorEnum.Blue)
                        {
                            // set the value for blue
                            blue = 255 - (value3 - 255);
                            red = 0;
                            green = 0;
                            
                                // Set the selected color
                            selectedColor = ColorEnum.Blue;
                        }
                    }
                    else
                    {
                        // Third Range

                        // if Color3 is Red
                        if (colorManager.Color3 == ColorEnum.Red)
                        {
                            // set the value for red
                            red = 255 - (value3 - 510);
                            green = 0;
                            blue = 0;
                            
                            // Set the selected color
                            selectedColor = ColorEnum.Red;
                        }
                        // if Color3 is Green
                        else if (colorManager.Color3 == ColorEnum.Green)
                        {
                            // Set the value for Green
                            green = 255 - (value3 - 510);
                            red = 0;
                            blue = 0;
                            
                                // Set the selected color
                            selectedColor = ColorEnum.Green;
                        }
                        else if (colorManager.Color3 == ColorEnum.Blue)
                        {
                            // Blue

                            // Set the value for blue
                            blue = 255 - (value3 - 510);
                            red = 0;
                            green = 0;
                            
                                // Set the selected color
                            selectedColor = ColorEnum.Blue;
                        }
                    }
                }
            }
            #endregion
            
        #endregion
            
        #region Properties
                
            #region ActualMinWater
            /// <summary>
            /// This property gets or sets the value for 'ActualMinWater'.
            /// </summary>
            public int ActualMinWater
            {
                get { return actualMinWater; }
                set { actualMinWater = value; }
            }
            #endregion
            
            #region Advance
            /// <summary>
            /// This property gets or sets the value for 'Advance'.
            /// </summary>
            public bool Advance
            {
                get { return advance; }
                set { advance = value; }
            }
            #endregion
            
            #region AutoSave
            /// <summary>
            /// This property gets or sets the value for 'AutoSave'.
            /// </summary>
            public bool AutoSave
            {
                get { return autoSave; }
                set { autoSave = value; }
            }
            #endregion
            
            #region BaseColor
            /// <summary>
            /// This property gets or sets the value for 'BaseColor'.
            /// </summary>
            public Color BaseColor
            {
                get { return baseColor; }
                set { baseColor = value; }
            }
            #endregion
            
            #region BorderColor
            /// <summary>
            /// This property gets or sets the value for 'BorderColor'.
            /// </summary>
            public Color BorderColor
            {
                get { return borderColor; }
                set { borderColor = value; }
            }
            #endregion
            
            #region BorderWidth
            /// <summary>
            /// This property gets or sets the value for 'BorderWidth'.
            /// </summary>
            public int BorderWidth
            {
                get { return borderWidth; }
                set { borderWidth = value; }
            }
            #endregion
            
            #region CreateParams
            /// <summary>
            /// This property here is what did the trick to reduce the flickering.
            /// I also needed to make all of the controls Double Buffered, but
            /// this was the final touch. It is a little slow when you switch tabs
            /// but that is because the repainting is finishing before control is
            /// returned.
            /// </summary>
            protected override CreateParams CreateParams
            {
                get
                {
                    // initial value
                    CreateParams cp = base.CreateParams;
                        
                    // Apparently this interrupts Paint to finish before showing
                    cp.ExStyle |= 0x02000000;
                        
                    // return value
                    return cp;
                }
            }
            #endregion
            
            #region FilterFactor
            /// <summary>
            /// This property gets or sets the value for 'FilterFactor'.
            /// </summary>
            public int FilterFactor
            {
                get { return filterFactor; }
                set { filterFactor = value; }
            }
            #endregion
            
            #region HasShuffler
            /// <summary>
            /// This property returns true if this object has a 'Shuffler'.
            /// </summary>
            public bool HasShuffler
            {
                get
                {
                    // initial value
                    bool hasShuffler = (this.Shuffler != null);
                        
                    // return value
                    return hasShuffler;
                }
            }
            #endregion
                
            #region HasShuffler2
            /// <summary>
            /// This property returns true if this object has a 'Shuffler2'.
            /// </summary>
            public bool HasShuffler2
            {
                get
                {
                    // initial value
                    bool hasShuffler2 = (this.Shuffler2 != null);
                        
                    // return value
                    return hasShuffler2;
                }
            }
            #endregion
                
            #region HasShuffler3
            /// <summary>
            /// This property returns true if this object has a 'Shuffler3'.
            /// </summary>
            public bool HasShuffler3
            {
                get
                {
                    // initial value
                    bool hasShuffler3 = (this.Shuffler3 != null);
                        
                    // return value
                    return hasShuffler3;
                }
            }
            #endregion
                
            #region HasShuffler4
            /// <summary>
            /// This property returns true if this object has a 'Shuffler4'.
            /// </summary>
            public bool HasShuffler4
            {
                get
                {
                    // initial value
                    bool hasShuffler4 = (this.Shuffler4 != null);
                        
                    // return value
                    return hasShuffler4;
                }
            }
            #endregion
            
            #region ImageNumber
            /// <summary>
            /// This property gets or sets the value for 'ImageNumber'.
            /// </summary>
            public int ImageNumber
            {
                get { return imageNumber; }
                set { imageNumber = value; }
            }
            #endregion
            
            #region LightFilter
            /// <summary>
            /// This property gets or sets the value for 'LightFilter'.
            /// </summary>
            public LightFilterEnum LightFilter
            {
                get { return lightFilter; }
                set { lightFilter = value; }
            }
            #endregion
                      
            #region PointsCount
            /// <summary>
            /// This property gets or sets the value for 'PointsCount'.
            /// </summary>
            public int PointsCount
            {
                get { return pointsCount; }
                set { pointsCount = value; }
            }
            #endregion
            
            #region SaveFolder
            /// <summary>
            /// This property gets or sets the value for 'SaveFolder'.
            /// </summary>
            public string SaveFolder
            {
                get { return saveFolder; }
                set { saveFolder = value; }
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
                
            #region Shuffler2
            /// <summary>
            /// This property gets or sets the value for 'Shuffler2'.
            /// </summary>
            public RandomShuffler Shuffler2
            {
                get { return shuffler2; }
                set { shuffler2 = value; }
            }
            #endregion
                
            #region Shuffler3
            /// <summary>
            /// This property gets or sets the value for 'Shuffler3'.
            /// </summary>
            public RandomShuffler Shuffler3
            {
                get { return shuffler3; }
                set { shuffler3 = value; }
            }
            #endregion
                
            #region Shuffler4
            /// <summary>
            /// This property gets or sets the value for 'Shuffler4'.
            /// </summary>
            public RandomShuffler Shuffler4
            {
                get { return shuffler4; }
                set { shuffler4 = value; }
            }
            #endregion
                
            #region Stop
            /// <summary>
            /// This property gets or sets the value for 'Stop'.
            /// </summary>
            public bool Stop
            {
                get { return stop; }
                set { stop = value; }
            }
            #endregion
            
            #region Threshold
            /// <summary>
            /// This property gets or sets the value for 'Threshold'.
            /// </summary>
            public int Threshold
            {
                get { return threshold; }
                set { threshold = value; }
            }
        #endregion

            #region ValidCode
            /// <summary>
            /// This property gets or sets the value for 'ValidCode'.
            /// </summary>
            public bool ValidCode
            {
                get { return validCode; }
                set { validCode = value; }
            }
        #endregion

        #endregion

    }
    #endregion

}
