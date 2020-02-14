

#region using statements


#endregion

namespace RandomArt
{

    #region class MainForm
    /// <summary>
    /// method [Enter Method Description]
    /// </summary>
    partial class MainForm
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox ArtBox;
        private System.Windows.Forms.Button RandomArtButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.ProgressBar Graph;
        private DataJuggler.Win.Controls.LabelComboBoxControl FilterControl;
        private DataJuggler.Win.Controls.LabelCheckBoxControl AutoSaveCheckBox;
        private DataJuggler.Win.Controls.LabelTextBoxControl WidthControl;
        private DataJuggler.Win.Controls.LabelTextBoxControl HeightControl;
        private DataJuggler.Win.Controls.LabelComboBoxControl SpeedControl;
        private DataJuggler.Win.Controls.LabelCheckBoxControl SmoothCheckbox;
        private DataJuggler.Win.Controls.LabelTextBoxControl ThresholdControl;
        private DataJuggler.Win.Controls.LabelComboBoxControl PointsControl;
        private DataJuggler.Win.Controls.LabelComboBoxControl BaseColorControl;
        private DataJuggler.Win.Controls.LabelComboBoxControl BorderWidthControl;
        private DataJuggler.Win.Controls.LabelComboBoxControl BorderColorControl;
        private System.Windows.Forms.Button SaveButton;
        private DataJuggler.Win.Controls.LabelTextBoxBrowserControl SaveFolderBrowser;
        private System.Windows.Forms.Button SaveNowButton;
        private DataJuggler.Win.Controls.LabelLabelControl SaveCountLabel;
        private System.Windows.Forms.Button AdvanceButton;
        private DataJuggler.Win.Controls.LabelComboBoxControl FilterFactorControl;
        private System.Windows.Forms.Button DrawFromPointButton;
        private System.Windows.Forms.Button DrawScenesButton;
        private System.Windows.Forms.Button DrawLinesButton;
        #endregion
        
        #region Methods
            
            #region Dispose(bool disposing)
            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            #endregion
            
            #region InitializeComponent()
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ArtBox = new System.Windows.Forms.PictureBox();
            this.RandomArtButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.Graph = new System.Windows.Forms.ProgressBar();
            this.FilterControl = new DataJuggler.Win.Controls.LabelComboBoxControl();
            this.AutoSaveCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.WidthControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.HeightControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.SpeedControl = new DataJuggler.Win.Controls.LabelComboBoxControl();
            this.SmoothCheckbox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.ThresholdControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.PointsControl = new DataJuggler.Win.Controls.LabelComboBoxControl();
            this.BaseColorControl = new DataJuggler.Win.Controls.LabelComboBoxControl();
            this.BorderWidthControl = new DataJuggler.Win.Controls.LabelComboBoxControl();
            this.BorderColorControl = new DataJuggler.Win.Controls.LabelComboBoxControl();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SaveFolderBrowser = new DataJuggler.Win.Controls.LabelTextBoxBrowserControl();
            this.SaveNowButton = new System.Windows.Forms.Button();
            this.SaveCountLabel = new DataJuggler.Win.Controls.LabelLabelControl();
            this.AdvanceButton = new System.Windows.Forms.Button();
            this.FilterFactorControl = new DataJuggler.Win.Controls.LabelComboBoxControl();
            this.DrawFromPointButton = new System.Windows.Forms.Button();
            this.DrawScenesButton = new System.Windows.Forms.Button();
            this.DrawLinesButton = new System.Windows.Forms.Button();
            this.WorthlessCodeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ArtBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ArtBox
            // 
            this.ArtBox.BackColor = System.Drawing.Color.Transparent;
            this.ArtBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ArtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ArtBox.Location = new System.Drawing.Point(367, 40);
            this.ArtBox.Name = "ArtBox";
            this.ArtBox.Size = new System.Drawing.Size(1280, 720);
            this.ArtBox.TabIndex = 0;
            this.ArtBox.TabStop = false;
            // 
            // RandomArtButton
            // 
            this.RandomArtButton.Location = new System.Drawing.Point(16, 16);
            this.RandomArtButton.Name = "RandomArtButton";
            this.RandomArtButton.Size = new System.Drawing.Size(220, 32);
            this.RandomArtButton.TabIndex = 1;
            this.RandomArtButton.Text = "Create Random Art";
            this.RandomArtButton.UseVisualStyleBackColor = true;
            this.RandomArtButton.Click += new System.EventHandler(this.RandomArtButton_Click);
            this.RandomArtButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.RandomArtButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(16, 59);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(220, 32);
            this.StopButton.TabIndex = 2;
            this.StopButton.Text = "Stop Drawing";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Visible = false;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            this.StopButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.StopButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // Graph
            // 
            this.Graph.Location = new System.Drawing.Point(52, 766);
            this.Graph.Name = "Graph";
            this.Graph.Size = new System.Drawing.Size(1280, 23);
            this.Graph.TabIndex = 3;
            this.Graph.Visible = false;
            // 
            // FilterControl
            // 
            this.FilterControl.BackColor = System.Drawing.Color.Transparent;
            this.FilterControl.ComboBoxLeftMargin = 1;
            this.FilterControl.ComboBoxText = "";
            this.FilterControl.ComoboBoxFont = null;
            this.FilterControl.Editable = true;
            this.FilterControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterControl.ForeColor = System.Drawing.Color.LemonChiffon;
            this.FilterControl.HideLabel = false;
            this.FilterControl.LabelBottomMargin = 0;
            this.FilterControl.LabelColor = System.Drawing.Color.LemonChiffon;
            this.FilterControl.LabelFont = null;
            this.FilterControl.LabelText = "Light Filter:";
            this.FilterControl.LabelTopMargin = 0;
            this.FilterControl.LabelWidth = 140;
            this.FilterControl.List = null;
            this.FilterControl.Location = new System.Drawing.Point(16, 102);
            this.FilterControl.Name = "FilterControl";
            this.FilterControl.SelectedIndex = -1;
            this.FilterControl.SelectedIndexListener = null;
            this.FilterControl.Size = new System.Drawing.Size(220, 28);
            this.FilterControl.Sorted = true;
            this.FilterControl.Source = null;
            this.FilterControl.TabIndex = 4;
            // 
            // AutoSaveCheckBox
            // 
            this.AutoSaveCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.AutoSaveCheckBox.CheckBoxHorizontalOffSet = 0;
            this.AutoSaveCheckBox.CheckBoxVerticalOffSet = 4;
            this.AutoSaveCheckBox.CheckChangedListener = null;
            this.AutoSaveCheckBox.Checked = true;
            this.AutoSaveCheckBox.Editable = true;
            this.AutoSaveCheckBox.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoSaveCheckBox.ForeColor = System.Drawing.Color.LemonChiffon;
            this.AutoSaveCheckBox.LabelColor = System.Drawing.Color.LemonChiffon;
            this.AutoSaveCheckBox.LabelFont = null;
            this.AutoSaveCheckBox.LabelText = "Auto Save:";
            this.AutoSaveCheckBox.LabelWidth = 140;
            this.AutoSaveCheckBox.Location = new System.Drawing.Point(16, 613);
            this.AutoSaveCheckBox.Name = "AutoSaveCheckBox";
            this.AutoSaveCheckBox.Size = new System.Drawing.Size(210, 28);
            this.AutoSaveCheckBox.TabIndex = 5;
            // 
            // WidthControl
            // 
            this.WidthControl.BackColor = System.Drawing.Color.Transparent;
            this.WidthControl.BottomMargin = 0;
            this.WidthControl.Editable = true;
            this.WidthControl.Encrypted = false;
            this.WidthControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WidthControl.ForeColor = System.Drawing.Color.LemonChiffon;
            this.WidthControl.LabelBottomMargin = 0;
            this.WidthControl.LabelColor = System.Drawing.Color.LemonChiffon;
            this.WidthControl.LabelFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
            this.WidthControl.LabelText = "Width:";
            this.WidthControl.LabelTopMargin = 0;
            this.WidthControl.LabelWidth = 140;
            this.WidthControl.Location = new System.Drawing.Point(16, 254);
            this.WidthControl.MultiLine = false;
            this.WidthControl.Name = "WidthControl";
            this.WidthControl.OnTextChangedListener = null;
            this.WidthControl.PasswordMode = false;
            this.WidthControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.WidthControl.Size = new System.Drawing.Size(220, 28);
            this.WidthControl.TabIndex = 6;
            this.WidthControl.TextBoxBottomMargin = 0;
            this.WidthControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.WidthControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.WidthControl.TextBoxFont = new System.Drawing.Font("Verdana", 14.25F);
            this.WidthControl.TextBoxTopMargin = 0;
            // 
            // HeightControl
            // 
            this.HeightControl.BackColor = System.Drawing.Color.Transparent;
            this.HeightControl.BottomMargin = 0;
            this.HeightControl.Editable = true;
            this.HeightControl.Encrypted = false;
            this.HeightControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeightControl.ForeColor = System.Drawing.Color.LemonChiffon;
            this.HeightControl.LabelBottomMargin = 0;
            this.HeightControl.LabelColor = System.Drawing.Color.LemonChiffon;
            this.HeightControl.LabelFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
            this.HeightControl.LabelText = "Height:";
            this.HeightControl.LabelTopMargin = 0;
            this.HeightControl.LabelWidth = 140;
            this.HeightControl.Location = new System.Drawing.Point(16, 292);
            this.HeightControl.MultiLine = false;
            this.HeightControl.Name = "HeightControl";
            this.HeightControl.OnTextChangedListener = null;
            this.HeightControl.PasswordMode = false;
            this.HeightControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.HeightControl.Size = new System.Drawing.Size(220, 28);
            this.HeightControl.TabIndex = 7;
            this.HeightControl.TextBoxBottomMargin = 0;
            this.HeightControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.HeightControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.HeightControl.TextBoxFont = new System.Drawing.Font("Verdana", 14.25F);
            this.HeightControl.TextBoxTopMargin = 0;
            // 
            // SpeedControl
            // 
            this.SpeedControl.BackColor = System.Drawing.Color.Transparent;
            this.SpeedControl.ComboBoxLeftMargin = 1;
            this.SpeedControl.ComboBoxText = "";
            this.SpeedControl.ComoboBoxFont = null;
            this.SpeedControl.Editable = true;
            this.SpeedControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpeedControl.ForeColor = System.Drawing.Color.LemonChiffon;
            this.SpeedControl.HideLabel = false;
            this.SpeedControl.LabelBottomMargin = 0;
            this.SpeedControl.LabelColor = System.Drawing.Color.LemonChiffon;
            this.SpeedControl.LabelFont = null;
            this.SpeedControl.LabelText = "Speed:";
            this.SpeedControl.LabelTopMargin = 0;
            this.SpeedControl.LabelWidth = 140;
            this.SpeedControl.List = null;
            this.SpeedControl.Location = new System.Drawing.Point(16, 178);
            this.SpeedControl.Name = "SpeedControl";
            this.SpeedControl.SelectedIndex = -1;
            this.SpeedControl.SelectedIndexListener = null;
            this.SpeedControl.Size = new System.Drawing.Size(220, 28);
            this.SpeedControl.Sorted = false;
            this.SpeedControl.Source = null;
            this.SpeedControl.TabIndex = 8;
            // 
            // SmoothCheckbox
            // 
            this.SmoothCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.SmoothCheckbox.CheckBoxHorizontalOffSet = 0;
            this.SmoothCheckbox.CheckBoxVerticalOffSet = 4;
            this.SmoothCheckbox.CheckChangedListener = null;
            this.SmoothCheckbox.Checked = true;
            this.SmoothCheckbox.Editable = true;
            this.SmoothCheckbox.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SmoothCheckbox.ForeColor = System.Drawing.Color.LemonChiffon;
            this.SmoothCheckbox.LabelColor = System.Drawing.Color.LemonChiffon;
            this.SmoothCheckbox.LabelFont = null;
            this.SmoothCheckbox.LabelText = "Smooth:";
            this.SmoothCheckbox.LabelWidth = 140;
            this.SmoothCheckbox.Location = new System.Drawing.Point(16, 372);
            this.SmoothCheckbox.Name = "SmoothCheckbox";
            this.SmoothCheckbox.Size = new System.Drawing.Size(210, 28);
            this.SmoothCheckbox.TabIndex = 9;
            // 
            // ThresholdControl
            // 
            this.ThresholdControl.BackColor = System.Drawing.Color.Transparent;
            this.ThresholdControl.BottomMargin = 0;
            this.ThresholdControl.Editable = true;
            this.ThresholdControl.Encrypted = false;
            this.ThresholdControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThresholdControl.ForeColor = System.Drawing.Color.LemonChiffon;
            this.ThresholdControl.LabelBottomMargin = 0;
            this.ThresholdControl.LabelColor = System.Drawing.Color.LemonChiffon;
            this.ThresholdControl.LabelFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
            this.ThresholdControl.LabelText = "Threshold:";
            this.ThresholdControl.LabelTopMargin = 0;
            this.ThresholdControl.LabelWidth = 140;
            this.ThresholdControl.Location = new System.Drawing.Point(16, 333);
            this.ThresholdControl.MultiLine = false;
            this.ThresholdControl.Name = "ThresholdControl";
            this.ThresholdControl.OnTextChangedListener = null;
            this.ThresholdControl.PasswordMode = false;
            this.ThresholdControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ThresholdControl.Size = new System.Drawing.Size(220, 28);
            this.ThresholdControl.TabIndex = 10;
            this.ThresholdControl.TextBoxBottomMargin = 0;
            this.ThresholdControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.ThresholdControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.ThresholdControl.TextBoxFont = new System.Drawing.Font("Verdana", 14.25F);
            this.ThresholdControl.TextBoxTopMargin = 0;
            // 
            // PointsControl
            // 
            this.PointsControl.BackColor = System.Drawing.Color.Transparent;
            this.PointsControl.ComboBoxLeftMargin = 1;
            this.PointsControl.ComboBoxText = "";
            this.PointsControl.ComoboBoxFont = null;
            this.PointsControl.Editable = true;
            this.PointsControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PointsControl.ForeColor = System.Drawing.Color.LemonChiffon;
            this.PointsControl.HideLabel = false;
            this.PointsControl.LabelBottomMargin = 0;
            this.PointsControl.LabelColor = System.Drawing.Color.LemonChiffon;
            this.PointsControl.LabelFont = null;
            this.PointsControl.LabelText = "Points:";
            this.PointsControl.LabelTopMargin = 0;
            this.PointsControl.LabelWidth = 140;
            this.PointsControl.List = null;
            this.PointsControl.Location = new System.Drawing.Point(16, 216);
            this.PointsControl.Name = "PointsControl";
            this.PointsControl.SelectedIndex = -1;
            this.PointsControl.SelectedIndexListener = null;
            this.PointsControl.Size = new System.Drawing.Size(220, 28);
            this.PointsControl.Sorted = false;
            this.PointsControl.Source = null;
            this.PointsControl.TabIndex = 11;
            // 
            // BaseColorControl
            // 
            this.BaseColorControl.BackColor = System.Drawing.Color.Transparent;
            this.BaseColorControl.ComboBoxLeftMargin = 1;
            this.BaseColorControl.ComboBoxText = "";
            this.BaseColorControl.ComoboBoxFont = null;
            this.BaseColorControl.Editable = true;
            this.BaseColorControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaseColorControl.ForeColor = System.Drawing.Color.LemonChiffon;
            this.BaseColorControl.HideLabel = false;
            this.BaseColorControl.LabelBottomMargin = 0;
            this.BaseColorControl.LabelColor = System.Drawing.Color.LemonChiffon;
            this.BaseColorControl.LabelFont = null;
            this.BaseColorControl.LabelText = "Base Color:";
            this.BaseColorControl.LabelTopMargin = 0;
            this.BaseColorControl.LabelWidth = 140;
            this.BaseColorControl.List = null;
            this.BaseColorControl.Location = new System.Drawing.Point(16, 411);
            this.BaseColorControl.Name = "BaseColorControl";
            this.BaseColorControl.SelectedIndex = -1;
            this.BaseColorControl.SelectedIndexListener = null;
            this.BaseColorControl.Size = new System.Drawing.Size(286, 28);
            this.BaseColorControl.Sorted = true;
            this.BaseColorControl.Source = null;
            this.BaseColorControl.TabIndex = 12;
            // 
            // BorderWidthControl
            // 
            this.BorderWidthControl.BackColor = System.Drawing.Color.Transparent;
            this.BorderWidthControl.ComboBoxLeftMargin = 1;
            this.BorderWidthControl.ComboBoxText = "";
            this.BorderWidthControl.ComoboBoxFont = null;
            this.BorderWidthControl.Editable = true;
            this.BorderWidthControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BorderWidthControl.ForeColor = System.Drawing.Color.LemonChiffon;
            this.BorderWidthControl.HideLabel = false;
            this.BorderWidthControl.LabelBottomMargin = 0;
            this.BorderWidthControl.LabelColor = System.Drawing.Color.LemonChiffon;
            this.BorderWidthControl.LabelFont = null;
            this.BorderWidthControl.LabelText = "Border:";
            this.BorderWidthControl.LabelTopMargin = 0;
            this.BorderWidthControl.LabelWidth = 140;
            this.BorderWidthControl.List = null;
            this.BorderWidthControl.Location = new System.Drawing.Point(16, 450);
            this.BorderWidthControl.Name = "BorderWidthControl";
            this.BorderWidthControl.SelectedIndex = -1;
            this.BorderWidthControl.SelectedIndexListener = null;
            this.BorderWidthControl.Size = new System.Drawing.Size(286, 28);
            this.BorderWidthControl.Sorted = true;
            this.BorderWidthControl.Source = null;
            this.BorderWidthControl.TabIndex = 13;
            // 
            // BorderColorControl
            // 
            this.BorderColorControl.BackColor = System.Drawing.Color.Transparent;
            this.BorderColorControl.ComboBoxLeftMargin = 1;
            this.BorderColorControl.ComboBoxText = "";
            this.BorderColorControl.ComoboBoxFont = null;
            this.BorderColorControl.Editable = true;
            this.BorderColorControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BorderColorControl.ForeColor = System.Drawing.Color.LemonChiffon;
            this.BorderColorControl.HideLabel = false;
            this.BorderColorControl.LabelBottomMargin = 0;
            this.BorderColorControl.LabelColor = System.Drawing.Color.LemonChiffon;
            this.BorderColorControl.LabelFont = null;
            this.BorderColorControl.LabelText = "Bor Color:";
            this.BorderColorControl.LabelTopMargin = 0;
            this.BorderColorControl.LabelWidth = 140;
            this.BorderColorControl.List = null;
            this.BorderColorControl.Location = new System.Drawing.Point(16, 489);
            this.BorderColorControl.Name = "BorderColorControl";
            this.BorderColorControl.SelectedIndex = -1;
            this.BorderColorControl.SelectedIndexListener = null;
            this.BorderColorControl.Size = new System.Drawing.Size(286, 28);
            this.BorderColorControl.Sorted = true;
            this.BorderColorControl.Source = null;
            this.BorderColorControl.TabIndex = 14;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(16, 576);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(220, 32);
            this.SaveButton.TabIndex = 15;
            this.SaveButton.Text = "Save Picture As";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            this.SaveButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.SaveButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // SaveFolderBrowser
            // 
            this.SaveFolderBrowser.BackColor = System.Drawing.Color.Transparent;
            this.SaveFolderBrowser.BrowseType = DataJuggler.Win.Controls.Enumerations.BrowseTypeEnum.File;
            this.SaveFolderBrowser.ButtonImage = ((System.Drawing.Image)(resources.GetObject("SaveFolderBrowser.ButtonImage")));
            this.SaveFolderBrowser.ButtonWidth = 48;
            this.SaveFolderBrowser.DisabledLabelColor = System.Drawing.Color.LightGray;
            this.SaveFolderBrowser.Editable = false;
            this.SaveFolderBrowser.EnabledLabelColor = System.Drawing.Color.LemonChiffon;
            this.SaveFolderBrowser.Filter = null;
            this.SaveFolderBrowser.Font = new System.Drawing.Font("Verdana", 12F);
            this.SaveFolderBrowser.HideBrowseButton = false;
            this.SaveFolderBrowser.LabelBottomMargin = 0;
            this.SaveFolderBrowser.LabelColor = System.Drawing.Color.LemonChiffon;
            this.SaveFolderBrowser.LabelFont = null;
            this.SaveFolderBrowser.LabelText = null;
            this.SaveFolderBrowser.LabelTopMargin = 0;
            this.SaveFolderBrowser.LabelWidth = 0;
            this.SaveFolderBrowser.Location = new System.Drawing.Point(16, 651);
            this.SaveFolderBrowser.Name = "SaveFolderBrowser";
            this.SaveFolderBrowser.OnTextChangedListener = null;
            this.SaveFolderBrowser.OpenCallback = null;
            this.SaveFolderBrowser.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SaveFolderBrowser.SelectedPath = null;
            this.SaveFolderBrowser.Size = new System.Drawing.Size(286, 32);
            this.SaveFolderBrowser.StartPath = null;
            this.SaveFolderBrowser.TabIndex = 16;
            this.SaveFolderBrowser.TextBoxBottomMargin = 0;
            this.SaveFolderBrowser.TextBoxDisabledColor = System.Drawing.Color.Empty;
            this.SaveFolderBrowser.TextBoxEditableColor = System.Drawing.Color.Empty;
            this.SaveFolderBrowser.TextBoxFont = null;
            this.SaveFolderBrowser.TextBoxTopMargin = 0;
            this.SaveFolderBrowser.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // SaveNowButton
            // 
            this.SaveNowButton.Location = new System.Drawing.Point(156, 693);
            this.SaveNowButton.Name = "SaveNowButton";
            this.SaveNowButton.Size = new System.Drawing.Size(146, 32);
            this.SaveNowButton.TabIndex = 17;
            this.SaveNowButton.Text = "Save Now";
            this.SaveNowButton.UseVisualStyleBackColor = true;
            this.SaveNowButton.Click += new System.EventHandler(this.SaveNowButton_Click);
            this.SaveNowButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.SaveNowButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // SaveCountLabel
            // 
            this.SaveCountLabel.BackColor = System.Drawing.Color.Transparent;
            this.SaveCountLabel.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveCountLabel.LabelColor = System.Drawing.Color.LemonChiffon;
            this.SaveCountLabel.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveCountLabel.LabelText = "Saved:";
            this.SaveCountLabel.LabelWidth = 88;
            this.SaveCountLabel.Location = new System.Drawing.Point(156, 727);
            this.SaveCountLabel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.SaveCountLabel.Name = "SaveCountLabel";
            this.SaveCountLabel.Size = new System.Drawing.Size(146, 28);
            this.SaveCountLabel.TabIndex = 18;
            this.SaveCountLabel.ValueLabelColor = System.Drawing.Color.LemonChiffon;
            this.SaveCountLabel.ValueLabelFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // AdvanceButton
            // 
            this.AdvanceButton.Location = new System.Drawing.Point(367, 2);
            this.AdvanceButton.Name = "AdvanceButton";
            this.AdvanceButton.Size = new System.Drawing.Size(265, 32);
            this.AdvanceButton.TabIndex = 19;
            this.AdvanceButton.Text = "Advance To Next Image";
            this.AdvanceButton.UseVisualStyleBackColor = true;
            this.AdvanceButton.Visible = false;
            this.AdvanceButton.Click += new System.EventHandler(this.AdvanceButton_Click);
            this.AdvanceButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.AdvanceButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // FilterFactorControl
            // 
            this.FilterFactorControl.BackColor = System.Drawing.Color.Transparent;
            this.FilterFactorControl.ComboBoxLeftMargin = 1;
            this.FilterFactorControl.ComboBoxText = "";
            this.FilterFactorControl.ComoboBoxFont = null;
            this.FilterFactorControl.Editable = true;
            this.FilterFactorControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterFactorControl.ForeColor = System.Drawing.Color.LemonChiffon;
            this.FilterFactorControl.HideLabel = false;
            this.FilterFactorControl.LabelBottomMargin = 0;
            this.FilterFactorControl.LabelColor = System.Drawing.Color.LemonChiffon;
            this.FilterFactorControl.LabelFont = null;
            this.FilterFactorControl.LabelText = "Filt. Factor:";
            this.FilterFactorControl.LabelTopMargin = 0;
            this.FilterFactorControl.LabelWidth = 140;
            this.FilterFactorControl.List = null;
            this.FilterFactorControl.Location = new System.Drawing.Point(16, 140);
            this.FilterFactorControl.Name = "FilterFactorControl";
            this.FilterFactorControl.SelectedIndex = -1;
            this.FilterFactorControl.SelectedIndexListener = null;
            this.FilterFactorControl.Size = new System.Drawing.Size(220, 28);
            this.FilterFactorControl.Sorted = true;
            this.FilterFactorControl.Source = null;
            this.FilterFactorControl.TabIndex = 20;
            // 
            // DrawFromPointButton
            // 
            this.DrawFromPointButton.Location = new System.Drawing.Point(16, 532);
            this.DrawFromPointButton.Name = "DrawFromPointButton";
            this.DrawFromPointButton.Size = new System.Drawing.Size(220, 32);
            this.DrawFromPointButton.TabIndex = 23;
            this.DrawFromPointButton.Text = "Draw From Point";
            this.DrawFromPointButton.UseVisualStyleBackColor = true;
            this.DrawFromPointButton.Click += new System.EventHandler(this.DrawFromPointButton_Click);
            this.DrawFromPointButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.DrawFromPointButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // DrawScenesButton
            // 
            this.DrawScenesButton.Location = new System.Drawing.Point(638, 2);
            this.DrawScenesButton.Name = "DrawScenesButton";
            this.DrawScenesButton.Size = new System.Drawing.Size(185, 32);
            this.DrawScenesButton.TabIndex = 24;
            this.DrawScenesButton.Text = "Draw Scenes";
            this.DrawScenesButton.UseVisualStyleBackColor = true;
            this.DrawScenesButton.Click += new System.EventHandler(this.DrawScenesButton_Click);
            this.DrawScenesButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.DrawScenesButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // DrawLinesButton
            // 
            this.DrawLinesButton.Location = new System.Drawing.Point(829, 2);
            this.DrawLinesButton.Name = "DrawLinesButton";
            this.DrawLinesButton.Size = new System.Drawing.Size(185, 32);
            this.DrawLinesButton.TabIndex = 25;
            this.DrawLinesButton.Text = "Draw Lines";
            this.DrawLinesButton.UseVisualStyleBackColor = true;
            this.DrawLinesButton.Click += new System.EventHandler(this.DrawLinesButton_Click);
            // 
            // WorthlessCodeLabel
            // 
            this.WorthlessCodeLabel.AutoSize = true;
            this.WorthlessCodeLabel.BackColor = System.Drawing.Color.Transparent;
            this.WorthlessCodeLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.WorthlessCodeLabel.Location = new System.Drawing.Point(1053, 13);
            this.WorthlessCodeLabel.Name = "WorthlessCodeLabel";
            this.WorthlessCodeLabel.Size = new System.Drawing.Size(539, 23);
            this.WorthlessCodeLabel.TabIndex = 26;
            this.WorthlessCodeLabel.Text = "The Draw Scenes button is at about 0.05% complete.  ";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.BackgroundImage = global::RandomArt.Properties.Resources.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1384, 801);
            this.Controls.Add(this.WorthlessCodeLabel);
            this.Controls.Add(this.DrawLinesButton);
            this.Controls.Add(this.DrawScenesButton);
            this.Controls.Add(this.DrawFromPointButton);
            this.Controls.Add(this.FilterFactorControl);
            this.Controls.Add(this.AdvanceButton);
            this.Controls.Add(this.SaveCountLabel);
            this.Controls.Add(this.SaveNowButton);
            this.Controls.Add(this.SaveFolderBrowser);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.BorderColorControl);
            this.Controls.Add(this.BorderWidthControl);
            this.Controls.Add(this.BaseColorControl);
            this.Controls.Add(this.PointsControl);
            this.Controls.Add(this.ThresholdControl);
            this.Controls.Add(this.SmoothCheckbox);
            this.Controls.Add(this.SpeedControl);
            this.Controls.Add(this.HeightControl);
            this.Controls.Add(this.WidthControl);
            this.Controls.Add(this.AutoSaveCheckBox);
            this.Controls.Add(this.FilterControl);
            this.Controls.Add(this.Graph);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.RandomArtButton);
            this.Controls.Add(this.ArtBox);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RandomArt";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.ArtBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }
        #endregion

        #endregion

        private System.Windows.Forms.Label WorthlessCodeLabel;
    }
    #endregion

}
