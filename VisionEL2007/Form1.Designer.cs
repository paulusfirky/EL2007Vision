namespace Vision
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbVideo = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.cbWebCams = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbTurn = new System.Windows.Forms.TextBox();
            this.tbLocation = new System.Windows.Forms.TextBox();
            this.tbWidth = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.btnDriftLeft = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnDriftRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnBackLeft = new System.Windows.Forms.Button();
            this.btnReverse = new System.Windows.Forms.Button();
            this.btnBackRight = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbData = new System.Windows.Forms.TextBox();
            this.btnBegin = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.sp = new System.IO.Ports.SerialPort(this.components);
            this.pbBattery = new System.Windows.Forms.ProgressBar();
            this.timerBattery = new System.Windows.Forms.Timer(this.components);
            this.bwBattery = new System.ComponentModel.BackgroundWorker();
            this.lblBattery = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnEnableColor = new System.Windows.Forms.Button();
            this.btnDisableColor = new System.Windows.Forms.Button();
            this.pnlColor = new System.Windows.Forms.Panel();
            this.rbBlue = new System.Windows.Forms.RadioButton();
            this.rbGreen = new System.Windows.Forms.RadioButton();
            this.rbRed = new System.Windows.Forms.RadioButton();
            this.lblDefaults = new System.Windows.Forms.Label();
            this.numHueReplace = new System.Windows.Forms.NumericUpDown();
            this.numSatMin = new System.Windows.Forms.NumericUpDown();
            this.numSatMax = new System.Windows.Forms.NumericUpDown();
            this.numLumMin = new System.Windows.Forms.NumericUpDown();
            this.numLumMax = new System.Windows.Forms.NumericUpDown();
            this.numHueRange = new System.Windows.Forms.NumericUpDown();
            this.lblLumMax = new System.Windows.Forms.Label();
            this.lblLumMin = new System.Windows.Forms.Label();
            this.lblSatMax = new System.Windows.Forms.Label();
            this.lblSatMin = new System.Windows.Forms.Label();
            this.lblHueReplace = new System.Windows.Forms.Label();
            this.lblHueRange = new System.Windows.Forms.Label();
            this.trackLumMax = new System.Windows.Forms.TrackBar();
            this.trackSatMax = new System.Windows.Forms.TrackBar();
            this.trackHueRep = new System.Windows.Forms.TrackBar();
            this.lblLuminance = new System.Windows.Forms.Label();
            this.lblSaturation = new System.Windows.Forms.Label();
            this.lblHue = new System.Windows.Forms.Label();
            this.trackLumMin = new System.Windows.Forms.TrackBar();
            this.trackSatMin = new System.Windows.Forms.TrackBar();
            this.trackHue = new System.Windows.Forms.TrackBar();
            this.lbltargetSize = new System.Windows.Forms.Label();
            this.lblMinSize = new System.Windows.Forms.Label();
            this.numTargetSize = new System.Windows.Forms.NumericUpDown();
            this.numMinSize = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHueReplace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSatMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSatMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLumMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLumMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHueRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackLumMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSatMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackHueRep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackLumMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSatMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackHue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinSize)).BeginInit();
            this.SuspendLayout();
            // 
            // pbVideo
            // 
            this.pbVideo.Location = new System.Drawing.Point(53, 82);
            this.pbVideo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbVideo.Name = "pbVideo";
            this.pbVideo.Size = new System.Drawing.Size(427, 295);
            this.pbVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbVideo.TabIndex = 0;
            this.pbVideo.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(391, 30);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(89, 34);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cbWebCams
            // 
            this.cbWebCams.FormattingEnabled = true;
            this.cbWebCams.Location = new System.Drawing.Point(53, 36);
            this.cbWebCams.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbWebCams.Name = "cbWebCams";
            this.cbWebCams.Size = new System.Drawing.Size(123, 24);
            this.cbWebCams.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(204, 39);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(73, 17);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Stopped...";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbTurn
            // 
            this.tbTurn.Location = new System.Drawing.Point(53, 390);
            this.tbTurn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbTurn.Name = "tbTurn";
            this.tbTurn.ReadOnly = true;
            this.tbTurn.Size = new System.Drawing.Size(428, 22);
            this.tbTurn.TabIndex = 4;
            // 
            // tbLocation
            // 
            this.tbLocation.Location = new System.Drawing.Point(187, 427);
            this.tbLocation.Margin = new System.Windows.Forms.Padding(1);
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.ReadOnly = true;
            this.tbLocation.Size = new System.Drawing.Size(73, 22);
            this.tbLocation.TabIndex = 9;
            // 
            // tbWidth
            // 
            this.tbWidth.Location = new System.Drawing.Point(383, 427);
            this.tbWidth.Margin = new System.Windows.Forms.Padding(1);
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.ReadOnly = true;
            this.tbWidth.Size = new System.Drawing.Size(73, 22);
            this.tbWidth.TabIndex = 10;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(75, 427);
            this.lblLocation.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(108, 17);
            this.lblLocation.TabIndex = 11;
            this.lblLocation.Text = "Image Location:";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(289, 427);
            this.lblWidth.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(90, 17);
            this.lblWidth.TabIndex = 12;
            this.lblWidth.Text = "Image Width:";
            // 
            // btnDriftLeft
            // 
            this.btnDriftLeft.Location = new System.Drawing.Point(1, 1);
            this.btnDriftLeft.Margin = new System.Windows.Forms.Padding(1);
            this.btnDriftLeft.Name = "btnDriftLeft";
            this.btnDriftLeft.Size = new System.Drawing.Size(95, 64);
            this.btnDriftLeft.TabIndex = 13;
            this.btnDriftLeft.Text = "Drift Left";
            this.btnDriftLeft.UseVisualStyleBackColor = true;
            this.btnDriftLeft.Click += new System.EventHandler(this.btnDriftLeft_Click);
            // 
            // btnForward
            // 
            this.btnForward.Location = new System.Drawing.Point(116, 1);
            this.btnForward.Margin = new System.Windows.Forms.Padding(1);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(95, 64);
            this.btnForward.TabIndex = 14;
            this.btnForward.Text = "Forward";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnDriftRight
            // 
            this.btnDriftRight.Location = new System.Drawing.Point(231, 1);
            this.btnDriftRight.Margin = new System.Windows.Forms.Padding(1);
            this.btnDriftRight.Name = "btnDriftRight";
            this.btnDriftRight.Size = new System.Drawing.Size(95, 64);
            this.btnDriftRight.TabIndex = 15;
            this.btnDriftRight.Text = "Drift Right";
            this.btnDriftRight.UseVisualStyleBackColor = true;
            this.btnDriftRight.Click += new System.EventHandler(this.btnDriftRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(1, 85);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(1);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(95, 64);
            this.btnLeft.TabIndex = 16;
            this.btnLeft.Text = "Left";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(116, 85);
            this.btnStop.Margin = new System.Windows.Forms.Padding(1);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(95, 64);
            this.btnStop.TabIndex = 17;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(231, 85);
            this.btnRight.Margin = new System.Windows.Forms.Padding(1);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(95, 64);
            this.btnRight.TabIndex = 18;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnBackLeft
            // 
            this.btnBackLeft.Location = new System.Drawing.Point(1, 169);
            this.btnBackLeft.Margin = new System.Windows.Forms.Padding(1);
            this.btnBackLeft.Name = "btnBackLeft";
            this.btnBackLeft.Size = new System.Drawing.Size(95, 64);
            this.btnBackLeft.TabIndex = 19;
            this.btnBackLeft.Text = "Back Left";
            this.btnBackLeft.UseVisualStyleBackColor = true;
            this.btnBackLeft.Click += new System.EventHandler(this.btnBackLeft_Click);
            // 
            // btnReverse
            // 
            this.btnReverse.Location = new System.Drawing.Point(116, 169);
            this.btnReverse.Margin = new System.Windows.Forms.Padding(1);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(95, 64);
            this.btnReverse.TabIndex = 20;
            this.btnReverse.Text = "Reverse";
            this.btnReverse.UseVisualStyleBackColor = true;
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // btnBackRight
            // 
            this.btnBackRight.Location = new System.Drawing.Point(231, 169);
            this.btnBackRight.Margin = new System.Windows.Forms.Padding(1);
            this.btnBackRight.Name = "btnBackRight";
            this.btnBackRight.Size = new System.Drawing.Size(95, 64);
            this.btnBackRight.TabIndex = 21;
            this.btnBackRight.Text = "Back Right";
            this.btnBackRight.UseVisualStyleBackColor = true;
            this.btnBackRight.Click += new System.EventHandler(this.btnBackRight_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.btnBackRight, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnReverse, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnLeft, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnBackLeft, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnRight, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnStop, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnDriftLeft, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnForward, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDriftRight, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(537, 30);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(347, 254);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // tbData
            // 
            this.tbData.Location = new System.Drawing.Point(537, 302);
            this.tbData.Margin = new System.Windows.Forms.Padding(1);
            this.tbData.Multiline = true;
            this.tbData.Name = "tbData";
            this.tbData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbData.Size = new System.Drawing.Size(329, 192);
            this.tbData.TabIndex = 23;
            // 
            // btnBegin
            // 
            this.btnBegin.BackColor = System.Drawing.Color.Lime;
            this.btnBegin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBegin.Location = new System.Drawing.Point(921, 30);
            this.btnBegin.Margin = new System.Windows.Forms.Padding(1);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(201, 58);
            this.btnBegin.TabIndex = 24;
            this.btnBegin.Text = "Begin";
            this.btnBegin.UseVisualStyleBackColor = false;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.BackColor = System.Drawing.Color.Red;
            this.btnAbort.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbort.Location = new System.Drawing.Point(921, 325);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(1);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(201, 145);
            this.btnAbort.TabIndex = 25;
            this.btnAbort.Text = "ABORT!";
            this.btnAbort.UseVisualStyleBackColor = false;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // sp
            // 
            this.sp.BaudRate = 115200;
            this.sp.PortName = "COM14";
            // 
            // pbBattery
            // 
            this.pbBattery.Location = new System.Drawing.Point(921, 150);
            this.pbBattery.Margin = new System.Windows.Forms.Padding(1);
            this.pbBattery.Name = "pbBattery";
            this.pbBattery.Size = new System.Drawing.Size(201, 30);
            this.pbBattery.TabIndex = 26;
            this.pbBattery.Value = 100;
            // 
            // bwBattery
            // 
            this.bwBattery.WorkerReportsProgress = true;
            this.bwBattery.WorkerSupportsCancellation = true;
            this.bwBattery.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwBattery_DoWork);
            this.bwBattery.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwBattery_ProgressChanged);
            this.bwBattery.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwBattery_RunWorkerCompleted);
            // 
            // lblBattery
            // 
            this.lblBattery.AutoSize = true;
            this.lblBattery.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBattery.Location = new System.Drawing.Point(917, 188);
            this.lblBattery.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblBattery.Name = "lblBattery";
            this.lblBattery.Size = new System.Drawing.Size(206, 25);
            this.lblBattery.TabIndex = 27;
            this.lblBattery.Text = "Battery Level: 100%";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(921, 241);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(200, 42);
            this.btnSearch.TabIndex = 28;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnEnableColor
            // 
            this.btnEnableColor.Location = new System.Drawing.Point(53, 466);
            this.btnEnableColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEnableColor.Name = "btnEnableColor";
            this.btnEnableColor.Size = new System.Drawing.Size(149, 42);
            this.btnEnableColor.TabIndex = 29;
            this.btnEnableColor.Text = "Enable Color Controls";
            this.btnEnableColor.UseVisualStyleBackColor = true;
            this.btnEnableColor.Click += new System.EventHandler(this.btnEnableColor_Click);
            // 
            // btnDisableColor
            // 
            this.btnDisableColor.Enabled = false;
            this.btnDisableColor.Location = new System.Drawing.Point(333, 466);
            this.btnDisableColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDisableColor.Name = "btnDisableColor";
            this.btnDisableColor.Size = new System.Drawing.Size(149, 42);
            this.btnDisableColor.TabIndex = 36;
            this.btnDisableColor.Text = "Disable Color Controls";
            this.btnDisableColor.UseVisualStyleBackColor = true;
            this.btnDisableColor.Click += new System.EventHandler(this.btnDisableColor_Click);
            // 
            // pnlColor
            // 
            this.pnlColor.Controls.Add(this.rbBlue);
            this.pnlColor.Controls.Add(this.rbGreen);
            this.pnlColor.Controls.Add(this.rbRed);
            this.pnlColor.Controls.Add(this.lblDefaults);
            this.pnlColor.Controls.Add(this.numHueReplace);
            this.pnlColor.Controls.Add(this.numSatMin);
            this.pnlColor.Controls.Add(this.numSatMax);
            this.pnlColor.Controls.Add(this.numLumMin);
            this.pnlColor.Controls.Add(this.numLumMax);
            this.pnlColor.Controls.Add(this.numHueRange);
            this.pnlColor.Controls.Add(this.lblLumMax);
            this.pnlColor.Controls.Add(this.lblLumMin);
            this.pnlColor.Controls.Add(this.lblSatMax);
            this.pnlColor.Controls.Add(this.lblSatMin);
            this.pnlColor.Controls.Add(this.lblHueReplace);
            this.pnlColor.Controls.Add(this.lblHueRange);
            this.pnlColor.Controls.Add(this.trackLumMax);
            this.pnlColor.Controls.Add(this.trackSatMax);
            this.pnlColor.Controls.Add(this.trackHueRep);
            this.pnlColor.Controls.Add(this.lblLuminance);
            this.pnlColor.Controls.Add(this.lblSaturation);
            this.pnlColor.Controls.Add(this.lblHue);
            this.pnlColor.Controls.Add(this.trackLumMin);
            this.pnlColor.Controls.Add(this.trackSatMin);
            this.pnlColor.Controls.Add(this.trackHue);
            this.pnlColor.Enabled = false;
            this.pnlColor.Location = new System.Drawing.Point(1, 516);
            this.pnlColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(676, 311);
            this.pnlColor.TabIndex = 37;
            // 
            // rbBlue
            // 
            this.rbBlue.AutoSize = true;
            this.rbBlue.Location = new System.Drawing.Point(441, 279);
            this.rbBlue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbBlue.Name = "rbBlue";
            this.rbBlue.Size = new System.Drawing.Size(57, 21);
            this.rbBlue.TabIndex = 130;
            this.rbBlue.Text = "Blue";
            this.rbBlue.UseVisualStyleBackColor = true;
            this.rbBlue.CheckedChanged += new System.EventHandler(this.rbBlue_CheckedChanged);
            // 
            // rbGreen
            // 
            this.rbGreen.AutoSize = true;
            this.rbGreen.Location = new System.Drawing.Point(308, 279);
            this.rbGreen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbGreen.Name = "rbGreen";
            this.rbGreen.Size = new System.Drawing.Size(69, 21);
            this.rbGreen.TabIndex = 129;
            this.rbGreen.Text = "Green";
            this.rbGreen.UseVisualStyleBackColor = true;
            this.rbGreen.CheckedChanged += new System.EventHandler(this.rbGreen_CheckedChanged);
            // 
            // rbRed
            // 
            this.rbRed.AutoSize = true;
            this.rbRed.Checked = true;
            this.rbRed.Location = new System.Drawing.Point(175, 279);
            this.rbRed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbRed.Name = "rbRed";
            this.rbRed.Size = new System.Drawing.Size(55, 21);
            this.rbRed.TabIndex = 128;
            this.rbRed.TabStop = true;
            this.rbRed.Text = "Red";
            this.rbRed.UseVisualStyleBackColor = true;
            this.rbRed.CheckedChanged += new System.EventHandler(this.rbRed_CheckedChanged);
            // 
            // lblDefaults
            // 
            this.lblDefaults.AutoSize = true;
            this.lblDefaults.Location = new System.Drawing.Point(76, 284);
            this.lblDefaults.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDefaults.Name = "lblDefaults";
            this.lblDefaults.Size = new System.Drawing.Size(64, 17);
            this.lblDefaults.TabIndex = 127;
            this.lblDefaults.Text = "Defaults:";
            // 
            // numHueReplace
            // 
            this.numHueReplace.DecimalPlaces = 2;
            this.numHueReplace.Location = new System.Drawing.Point(500, 11);
            this.numHueReplace.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numHueReplace.Maximum = new decimal(new int[] {
            359,
            0,
            0,
            0});
            this.numHueReplace.Name = "numHueReplace";
            this.numHueReplace.Size = new System.Drawing.Size(77, 22);
            this.numHueReplace.TabIndex = 126;
            this.numHueReplace.ValueChanged += new System.EventHandler(this.numHueReplace_ValueChanged);
            // 
            // numSatMin
            // 
            this.numSatMin.DecimalPlaces = 2;
            this.numSatMin.Location = new System.Drawing.Point(200, 102);
            this.numSatMin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numSatMin.Name = "numSatMin";
            this.numSatMin.Size = new System.Drawing.Size(77, 22);
            this.numSatMin.TabIndex = 125;
            this.numSatMin.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numSatMin.ValueChanged += new System.EventHandler(this.numSatMin_ValueChanged);
            // 
            // numSatMax
            // 
            this.numSatMax.DecimalPlaces = 2;
            this.numSatMax.Location = new System.Drawing.Point(473, 102);
            this.numSatMax.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numSatMax.Name = "numSatMax";
            this.numSatMax.Size = new System.Drawing.Size(77, 22);
            this.numSatMax.TabIndex = 124;
            this.numSatMax.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numSatMax.ValueChanged += new System.EventHandler(this.numSatMax_ValueChanged);
            // 
            // numLumMin
            // 
            this.numLumMin.DecimalPlaces = 2;
            this.numLumMin.Location = new System.Drawing.Point(203, 190);
            this.numLumMin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numLumMin.Name = "numLumMin";
            this.numLumMin.Size = new System.Drawing.Size(77, 22);
            this.numLumMin.TabIndex = 123;
            this.numLumMin.Value = new decimal(new int[] {
            28,
            0,
            0,
            0});
            this.numLumMin.ValueChanged += new System.EventHandler(this.numLumMin_ValueChanged);
            // 
            // numLumMax
            // 
            this.numLumMax.DecimalPlaces = 2;
            this.numLumMax.Location = new System.Drawing.Point(476, 190);
            this.numLumMax.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numLumMax.Name = "numLumMax";
            this.numLumMax.Size = new System.Drawing.Size(77, 22);
            this.numLumMax.TabIndex = 122;
            this.numLumMax.Value = new decimal(new int[] {
            92,
            0,
            0,
            0});
            this.numLumMax.ValueChanged += new System.EventHandler(this.numLumMax_ValueChanged);
            // 
            // numHueRange
            // 
            this.numHueRange.DecimalPlaces = 2;
            this.numHueRange.Location = new System.Drawing.Point(220, 11);
            this.numHueRange.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numHueRange.Maximum = new decimal(new int[] {
            359,
            0,
            0,
            0});
            this.numHueRange.Name = "numHueRange";
            this.numHueRange.Size = new System.Drawing.Size(77, 22);
            this.numHueRange.TabIndex = 121;
            this.numHueRange.Value = new decimal(new int[] {
            318,
            0,
            0,
            0});
            this.numHueRange.ValueChanged += new System.EventHandler(this.numHueRange_ValueChanged);
            // 
            // lblLumMax
            // 
            this.lblLumMax.AutoSize = true;
            this.lblLumMax.Location = new System.Drawing.Point(432, 192);
            this.lblLumMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLumMax.Name = "lblLumMax";
            this.lblLumMax.Size = new System.Drawing.Size(33, 17);
            this.lblLumMax.TabIndex = 120;
            this.lblLumMax.Text = "Max";
            // 
            // lblLumMin
            // 
            this.lblLumMin.AutoSize = true;
            this.lblLumMin.Location = new System.Drawing.Point(163, 192);
            this.lblLumMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLumMin.Name = "lblLumMin";
            this.lblLumMin.Size = new System.Drawing.Size(30, 17);
            this.lblLumMin.TabIndex = 119;
            this.lblLumMin.Text = "Min";
            // 
            // lblSatMax
            // 
            this.lblSatMax.AutoSize = true;
            this.lblSatMax.Location = new System.Drawing.Point(429, 105);
            this.lblSatMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSatMax.Name = "lblSatMax";
            this.lblSatMax.Size = new System.Drawing.Size(33, 17);
            this.lblSatMax.TabIndex = 118;
            this.lblSatMax.Text = "Max";
            // 
            // lblSatMin
            // 
            this.lblSatMin.AutoSize = true;
            this.lblSatMin.Location = new System.Drawing.Point(160, 105);
            this.lblSatMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSatMin.Name = "lblSatMin";
            this.lblSatMin.Size = new System.Drawing.Size(30, 17);
            this.lblSatMin.TabIndex = 117;
            this.lblSatMin.Text = "Min";
            // 
            // lblHueReplace
            // 
            this.lblHueReplace.AutoSize = true;
            this.lblHueReplace.Location = new System.Drawing.Point(429, 14);
            this.lblHueReplace.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHueReplace.Name = "lblHueReplace";
            this.lblHueReplace.Size = new System.Drawing.Size(60, 17);
            this.lblHueReplace.TabIndex = 116;
            this.lblHueReplace.Text = "Replace";
            // 
            // lblHueRange
            // 
            this.lblHueRange.AutoSize = true;
            this.lblHueRange.Location = new System.Drawing.Point(160, 14);
            this.lblHueRange.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHueRange.Name = "lblHueRange";
            this.lblHueRange.Size = new System.Drawing.Size(50, 17);
            this.lblHueRange.TabIndex = 115;
            this.lblHueRange.Text = "Range";
            // 
            // trackLumMax
            // 
            this.trackLumMax.Location = new System.Drawing.Point(415, 219);
            this.trackLumMax.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackLumMax.Maximum = 100;
            this.trackLumMax.Name = "trackLumMax";
            this.trackLumMax.Size = new System.Drawing.Size(257, 56);
            this.trackLumMax.TabIndex = 114;
            this.trackLumMax.Value = 92;
            this.trackLumMax.Scroll += new System.EventHandler(this.trackLumMax_Scroll);
            // 
            // trackSatMax
            // 
            this.trackSatMax.Location = new System.Drawing.Point(415, 133);
            this.trackSatMax.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackSatMax.Maximum = 100;
            this.trackSatMax.Name = "trackSatMax";
            this.trackSatMax.Size = new System.Drawing.Size(257, 56);
            this.trackSatMax.TabIndex = 113;
            this.trackSatMax.Value = 100;
            this.trackSatMax.Scroll += new System.EventHandler(this.trackSatMax_Scroll);
            // 
            // trackHueRep
            // 
            this.trackHueRep.Location = new System.Drawing.Point(415, 46);
            this.trackHueRep.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackHueRep.Maximum = 359;
            this.trackHueRep.Name = "trackHueRep";
            this.trackHueRep.Size = new System.Drawing.Size(257, 56);
            this.trackHueRep.TabIndex = 112;
            this.trackHueRep.Scroll += new System.EventHandler(this.trackHueRep_Scroll);
            // 
            // lblLuminance
            // 
            this.lblLuminance.AutoSize = true;
            this.lblLuminance.Location = new System.Drawing.Point(59, 219);
            this.lblLuminance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLuminance.Name = "lblLuminance";
            this.lblLuminance.Size = new System.Drawing.Size(81, 17);
            this.lblLuminance.TabIndex = 111;
            this.lblLuminance.Text = "Luminance:";
            // 
            // lblSaturation
            // 
            this.lblSaturation.AutoSize = true;
            this.lblSaturation.Location = new System.Drawing.Point(64, 133);
            this.lblSaturation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSaturation.Name = "lblSaturation";
            this.lblSaturation.Size = new System.Drawing.Size(77, 17);
            this.lblSaturation.TabIndex = 110;
            this.lblSaturation.Text = "Saturation:";
            // 
            // lblHue
            // 
            this.lblHue.AutoSize = true;
            this.lblHue.Location = new System.Drawing.Point(101, 46);
            this.lblHue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHue.Name = "lblHue";
            this.lblHue.Size = new System.Drawing.Size(38, 17);
            this.lblHue.TabIndex = 109;
            this.lblHue.Text = "Hue:";
            // 
            // trackLumMin
            // 
            this.trackLumMin.Location = new System.Drawing.Point(149, 219);
            this.trackLumMin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackLumMin.Maximum = 100;
            this.trackLumMin.Name = "trackLumMin";
            this.trackLumMin.Size = new System.Drawing.Size(257, 56);
            this.trackLumMin.TabIndex = 108;
            this.trackLumMin.Value = 28;
            this.trackLumMin.Scroll += new System.EventHandler(this.trackLumMin_Scroll);
            // 
            // trackSatMin
            // 
            this.trackSatMin.Location = new System.Drawing.Point(149, 133);
            this.trackSatMin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackSatMin.Maximum = 100;
            this.trackSatMin.Name = "trackSatMin";
            this.trackSatMin.Size = new System.Drawing.Size(257, 56);
            this.trackSatMin.TabIndex = 107;
            this.trackSatMin.Value = 25;
            this.trackSatMin.Scroll += new System.EventHandler(this.trackSatMin_Scroll);
            // 
            // trackHue
            // 
            this.trackHue.Location = new System.Drawing.Point(149, 46);
            this.trackHue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackHue.Maximum = 359;
            this.trackHue.Name = "trackHue";
            this.trackHue.Size = new System.Drawing.Size(257, 56);
            this.trackHue.TabIndex = 106;
            this.trackHue.Value = 318;
            this.trackHue.Scroll += new System.EventHandler(this.trackHue_Scroll);
            // 
            // lbltargetSize
            // 
            this.lbltargetSize.AutoSize = true;
            this.lbltargetSize.Location = new System.Drawing.Point(716, 516);
            this.lbltargetSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltargetSize.Name = "lbltargetSize";
            this.lbltargetSize.Size = new System.Drawing.Size(85, 17);
            this.lbltargetSize.TabIndex = 38;
            this.lbltargetSize.Text = "Target Size:";
            // 
            // lblMinSize
            // 
            this.lblMinSize.AutoSize = true;
            this.lblMinSize.Location = new System.Drawing.Point(685, 555);
            this.lblMinSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMinSize.Name = "lblMinSize";
            this.lblMinSize.Size = new System.Drawing.Size(114, 17);
            this.lblMinSize.TabIndex = 39;
            this.lblMinSize.Text = "Min. Object Size:";
            // 
            // numTargetSize
            // 
            this.numTargetSize.Location = new System.Drawing.Point(809, 513);
            this.numTargetSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numTargetSize.Name = "numTargetSize";
            this.numTargetSize.Size = new System.Drawing.Size(59, 22);
            this.numTargetSize.TabIndex = 40;
            this.numTargetSize.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
            this.numTargetSize.ValueChanged += new System.EventHandler(this.numTargetSize_ValueChanged);
            // 
            // numMinSize
            // 
            this.numMinSize.Location = new System.Drawing.Point(809, 553);
            this.numMinSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numMinSize.Name = "numMinSize";
            this.numMinSize.Size = new System.Drawing.Size(59, 22);
            this.numMinSize.TabIndex = 41;
            this.numMinSize.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numMinSize.ValueChanged += new System.EventHandler(this.numMinSize_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1327, 844);
            this.Controls.Add(this.numMinSize);
            this.Controls.Add(this.numTargetSize);
            this.Controls.Add(this.lblMinSize);
            this.Controls.Add(this.lbltargetSize);
            this.Controls.Add(this.pnlColor);
            this.Controls.Add(this.btnDisableColor);
            this.Controls.Add(this.btnEnableColor);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblBattery);
            this.Controls.Add(this.pbBattery);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnBegin);
            this.Controls.Add(this.tbData);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.tbWidth);
            this.Controls.Add(this.tbLocation);
            this.Controls.Add(this.tbTurn);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cbWebCams);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pbVideo);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Search and Rescue Robot";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlColor.ResumeLayout(false);
            this.pnlColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHueReplace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSatMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSatMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLumMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLumMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHueRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackLumMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSatMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackHueRep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackLumMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSatMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackHue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbVideo;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cbWebCams;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tbTurn;
        private System.Windows.Forms.TextBox tbLocation;
        private System.Windows.Forms.TextBox tbWidth;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Button btnDriftLeft;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnDriftRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnBackLeft;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.Button btnBackRight;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tbData;
        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.Button btnAbort;
        private System.IO.Ports.SerialPort sp;
        private System.Windows.Forms.ProgressBar pbBattery;
        private System.Windows.Forms.Timer timerBattery;
        private System.ComponentModel.BackgroundWorker bwBattery;
        private System.Windows.Forms.Label lblBattery;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnEnableColor;
        private System.Windows.Forms.Button btnDisableColor;
        private System.Windows.Forms.Panel pnlColor;
        private System.Windows.Forms.RadioButton rbBlue;
        private System.Windows.Forms.RadioButton rbGreen;
        private System.Windows.Forms.RadioButton rbRed;
        private System.Windows.Forms.Label lblDefaults;
        private System.Windows.Forms.NumericUpDown numHueReplace;
        private System.Windows.Forms.NumericUpDown numSatMin;
        private System.Windows.Forms.NumericUpDown numSatMax;
        private System.Windows.Forms.NumericUpDown numLumMin;
        private System.Windows.Forms.NumericUpDown numLumMax;
        private System.Windows.Forms.NumericUpDown numHueRange;
        private System.Windows.Forms.Label lblLumMax;
        private System.Windows.Forms.Label lblLumMin;
        private System.Windows.Forms.Label lblSatMax;
        private System.Windows.Forms.Label lblSatMin;
        private System.Windows.Forms.Label lblHueReplace;
        private System.Windows.Forms.Label lblHueRange;
        private System.Windows.Forms.TrackBar trackLumMax;
        private System.Windows.Forms.TrackBar trackSatMax;
        private System.Windows.Forms.TrackBar trackHueRep;
        private System.Windows.Forms.Label lblLuminance;
        private System.Windows.Forms.Label lblSaturation;
        private System.Windows.Forms.Label lblHue;
        private System.Windows.Forms.TrackBar trackLumMin;
        private System.Windows.Forms.TrackBar trackSatMin;
        private System.Windows.Forms.TrackBar trackHue;
        private System.Windows.Forms.Label lbltargetSize;
        private System.Windows.Forms.Label lblMinSize;
        private System.Windows.Forms.NumericUpDown numTargetSize;
        private System.Windows.Forms.NumericUpDown numMinSize;
    }
}

