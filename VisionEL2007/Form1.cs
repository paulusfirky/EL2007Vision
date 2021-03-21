using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AForge;
using AForge.Video;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using AForge.Video.DirectShow;
using System.IO;
using System.Drawing.Imaging;
using System.Threading;

namespace Vision
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetWebCams();
        }

        HSLFiltering HSLfilter = new HSLFiltering();

        const int imgWidth = 160;

        int location = 0;
        int battery = 100;

        int targetSize = 75;
        int minBlobSize = 15;

        int hueRange = 318;
        int hueReplace = 0;

        float satMin = 0.25f;
        float satMax = 1.0f;

        float lumMin = 0.28f;
        float lumMax = 0.92f;

        bool abort = false;
        bool isBlob = false;
        bool isClose = false;
        bool inRoom = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            sp.Open();
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap img = (Bitmap)eventArgs.Frame.Clone();
            byte[] ImArray = new byte[1];
            ImArray = BmpToBytes_MemStream(img);
            img = (Bitmap)BytesToImg(ImArray);
            pbVideo.SizeMode = PictureBoxSizeMode.StretchImage;

            HSLfilter.Saturation = new AForge.Range(satMin, satMax);
            HSLfilter.Luminance = new AForge.Range(lumMin, lumMax);
            HSLfilter.Hue = new AForge.IntRange(hueRange, hueReplace);
            HSLfilter.ApplyInPlace(img);

            BlobCounterBase blobCounter = new BlobCounter();

            blobCounter.FilterBlobs = true;
            blobCounter.MinWidth = minBlobSize;
            blobCounter.MinHeight = minBlobSize;
            blobCounter.ObjectsOrder = ObjectsOrder.Size;
            blobCounter.ProcessImage(img);
            Blob[] blobs = blobCounter.GetObjectsInformation(); 

            if (blobs.Length > 0)
            {
                isBlob = true;
                Blob blob = blobs[0];
                blobCounter.ExtractBlobsImage(img, blob, true);

                location = blob.Rectangle.X + (blob.Rectangle.Width / 2);

                BeginInvoke(((Action)delegate ()
                {
                    tbWidth.Clear();
                    tbWidth.Text = blob.Rectangle.Width.ToString();
                }));

                if (blob.Rectangle.Width > targetSize)
                    isClose = true;
                else
                    isClose = false;

                BitmapData data = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadWrite, img.PixelFormat);

                Rectangle rect = blobs[0].Rectangle;
                Drawing.Rectangle(data, rect, Color.White);

                img.UnlockBits(data);
            }
            else
            {
                isBlob = false;
            }

            if (inRoom)
            {
                LocateObject(ImArray, isBlob, abort);
            }

            pbVideo.Image = img;
        }        

        private void btnBegin_Click(object sender, EventArgs e)
        {
            bwBattery.RunWorkerAsync();
            btnBegin.Enabled = false;
            tbData.Clear();
            abort = false;
            Thread questThread = new Thread(moveCommands);
            questThread.Start();
        }

        public void moveCommands()
        {
            if (!abort)
            {
                BeginInvoke(((Action)delegate ()
                {
                    tbData.AppendText("Moving Forwards" + Environment.NewLine);
                }));

                byte[] command = { 77, 85, 100, 100 };
                sp.Write(command, 0, 4);
                Thread.Sleep(1000);

                sp.Write(command, 0, 4);
                Thread.Sleep(1000);

                sp.Write(command, 0, 4);
                Thread.Sleep(1000);
                
                byte[] command2 = { 77, 85, 100, 35 };
                sp.Write(command, 0, 4);
                Thread.Sleep(200);
            }

            if (!abort)
            {
                BeginInvoke(((Action)delegate ()
                {
                    tbData.AppendText("Turning 90 Degrees" + Environment.NewLine);
                }));

                sp.Write("4");
                Thread.Sleep(350);
            }

            if (!abort)
            {
                byte[] command = { 77, 206, 100, 70 };
                sp.Write(command, 0, 4);
                Thread.Sleep(700);
                sp.Write(command, 0, 4);
                Thread.Sleep(700);
            }

            if (!abort)
            {
                BeginInvoke(((Action)delegate ()
                {
                    tbData.AppendText("Moving Forward" + Environment.NewLine);
                }));

                byte[] command = { 77, 85, 100, 100 };
                sp.Write(command, 0, 4);
                Thread.Sleep(1000);

                sp.Write(command, 0, 4);
                Thread.Sleep(1000);

                sp.Write(command, 0, 4);
                Thread.Sleep(1000);

                byte[] command2 = { 77, 85, 100, 50 };
                sp.Write(command2, 0, 4);
                Thread.Sleep(50);                
            }

            if (!abort)
            {
                BeginInvoke(((Action)delegate ()
                {
                    tbData.AppendText("Turning 90 Degrees" + Environment.NewLine);
                }));

                byte[] command = { 77, 206, 100, 70 };
                sp.Write(command, 0, 4);
                Thread.Sleep(700);
                sp.Write(command, 0, 4);
                Thread.Sleep(700);
            }

            if (!abort) 
            {
                BeginInvoke(((Action)delegate ()
                {
                    tbData.AppendText("Moving Forward" + Environment.NewLine);
                }));

                byte[] command = { 77, 85, 100, 40 };
                sp.Write(command, 0, 4);
                Thread.Sleep(400);

                sp.Write(command, 0, 4);
                Thread.Sleep(400);

                sp.Write("5");
                BeginInvoke(((Action)delegate ()
                {
                    tbData.AppendText("Reached Room" + Environment.NewLine);
                }));
            }

            if (!abort)
            {
                MessageBox.Show("Commencing Object Location");
            }

            if (!abort)
            {
                BeginInvoke(((Action)delegate ()
                {
                    tbData.Clear();
                    tbData.AppendText("Commencing Object Location" + Environment.NewLine);
                }));

                inRoom = true;
            }
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            abort = true;
            inRoom = false;
            tbTurn.Clear();
            tbLocation.Clear();
            sp.Write("5");
            bwBattery.CancelAsync();
            Thread abortThread = new Thread(Abort);
            abortThread.Start();
            btnBegin.Enabled = true;
        }

        public void Abort()
        {
            abort = true;
            sp.Write("5");

            BeginInvoke(((Action)delegate ()
            {
                sp.Write("5");
                tbData.AppendText("Mission Aborted!" + Environment.NewLine);
                MessageBox.Show("Mission Aborted!", "Mission Aborted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            abort = false;
            inRoom = true;
        }

        void LocateObject(byte[] bmpData, bool isBlob, bool abort)
        {
            if (abort)
            {
                sp.Write("5");
            }

            if (isClose && !abort)
            {
                sp.Write("5");
                inRoom = false;
                abort = true;

                BeginInvoke(((Action)delegate ()
                {
                    sp.Write("5");
                    tbTurn.Clear();
                    tbTurn.Text = "Stop, Object Close";
                    tbData.Text = (tbData.Text + Environment.NewLine + "Object Located" + Environment.NewLine + "Mission Accomplished!" + Environment.NewLine);
                    MessageBox.Show("Mission Accomplished!");
                }));
            }

            if (isBlob && !abort && !isClose)
            {
                BeginInvoke(((Action)delegate ()
                {
                    tbLocation.Clear();
                    tbLocation.Text = location.ToString();
                }));
            }

            if ((location > ((imgWidth / 5) * 2)) && (location <= ((imgWidth / 5) * 3)) && isBlob && !abort && !isClose)
            {
                sp.Write("8");

                BeginInvoke(((Action)delegate ()
                {
                    tbTurn.Clear();
                    tbTurn.Text = "Move Forward";
                }));
            }

            if (location < ((imgWidth / 5) * 2) && isBlob && !abort && !isClose)
            {
                sp.Write("6");

                BeginInvoke(((Action)delegate ()
                {
                    tbTurn.Clear();
                    tbTurn.Text = "Turn Left";
                }));
            }

            if (location >= ((imgWidth / 5) * 3) && isBlob && !abort && !isClose)
            {
                sp.Write("4");

                BeginInvoke(((Action)delegate ()
                {
                    tbTurn.Clear();
                    tbTurn.Text = "Move Right";
                }));
            }

            if (!isBlob && !abort && !isClose)
            {
                byte[] command = { 77, 206, 100, 00 };
                sp.Write(command, 0, 4);

                BeginInvoke(((Action)delegate ()
                {
                    tbLocation.Clear();
                    tbLocation.Text = "No Object Detected";
                    tbTurn.Text = "Searching...";
                }));
                return;
            }
        }

        private void bwBattery_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = battery; i > -1; i--)
            {
                if (bwBattery.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                bwBattery.ReportProgress(i);
                Thread.Sleep(2500);
            }
        }

        private void bwBattery_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbBattery.Value = e.ProgressPercentage;
            lblBattery.Text = ("Battery Level: " + e.ProgressPercentage.ToString() + "%");
        }

        private void bwBattery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!abort)
                MessageBox.Show("Battery Empty!");
        }

        private void btnDriftLeft_Click(object sender, EventArgs e)
        {
            sp.Write("7");
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            sp.Write("8");
        }

        private void btnDriftRight_Click(object sender, EventArgs e)
        {
            sp.Write("9");
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            sp.Write("4");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            sp.Write("5");
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            sp.Write("6");
        }

        private void btnBackLeft_Click(object sender, EventArgs e)
        {
            sp.Write("1");
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            sp.Write("2");
        }

        private void btnBackRight_Click(object sender, EventArgs e)
        {
            sp.Write("3");
        }

        private void btnEnableColor_Click(object sender, EventArgs e)
        {
            btnEnableColor.Enabled = false;
            btnDisableColor.Enabled = true;
            pnlColor.Enabled = true;
        }

        private void btnDisableColor_Click(object sender, EventArgs e)
        {
            btnDisableColor.Enabled = false;
            btnEnableColor.Enabled = true;
            pnlColor.Enabled = false;
        }

        private void trackHue_Scroll(object sender, EventArgs e)
        {
            hueRange = trackHue.Value;
            numHueRange.Value = trackHue.Value;
        }

        private void trackHueRep_Scroll(object sender, EventArgs e)
        {
            hueReplace = trackHueRep.Value;
            numHueReplace.Value = trackHueRep.Value;
        }

        private void trackSatMin_Scroll(object sender, EventArgs e)
        {
            satMin = (trackSatMin.Value / 100);
            numSatMin.Value = trackSatMin.Value;
        }

        private void trackSatMax_Scroll(object sender, EventArgs e)
        {
            satMax = (trackSatMax.Value / 100);
            numSatMax.Value = trackSatMax.Value;
        }

        private void trackLumMin_Scroll(object sender, EventArgs e)
        {
            lumMin = (trackLumMin.Value / 100);
            numLumMin.Value = trackLumMin.Value;
        }

        private void trackLumMax_Scroll(object sender, EventArgs e)
        {
            lumMax = (trackLumMax.Value / 100);
            numLumMax.Value = trackLumMax.Value;
        }

        private void numHueRange_ValueChanged(object sender, EventArgs e)
        {
            hueRange = (int)numHueRange.Value;
            trackHue.Value = (int)numHueRange.Value;
        }

        private void numHueReplace_ValueChanged(object sender, EventArgs e)
        {
            hueReplace = (int)numHueReplace.Value;
            trackHueRep.Value = (int)numHueReplace.Value;
        }

        private void numSatMin_ValueChanged(object sender, EventArgs e)
        {
            satMin = ((float)numSatMin.Value / 100);
            trackSatMin.Value = ((int)numSatMin.Value);
        }

        private void numSatMax_ValueChanged(object sender, EventArgs e)
        {
            satMax = ((float)numSatMax.Value / 100);
            trackSatMax.Value = ((int)numSatMax.Value);
        }

        private void numLumMin_ValueChanged(object sender, EventArgs e)
        {
            lumMin = ((float)numLumMin.Value / 100);
            trackLumMin.Value = ((int)numLumMin.Value);
        }

        private void numLumMax_ValueChanged(object sender, EventArgs e)
        {
            lumMax = ((float)numLumMax.Value / 100);
            trackLumMax.Value = ((int)numLumMax.Value);
        }

        private void rbRed_CheckedChanged(object sender, EventArgs e)
        {
            trackHue.Value = 300;
            trackHueRep.Value = 24;
            trackSatMin.Value = 48;
            trackSatMax.Value = 100;
            trackLumMin.Value = 33;
            trackLumMax.Value = 100;

            numHueRange.Value = 300;
            numHueReplace.Value = 24;
            numSatMin.Value = 48;
            numSatMax.Value = 100;
            numLumMin.Value = 33;
            numLumMax.Value = 100;
        }

        private void rbGreen_CheckedChanged(object sender, EventArgs e)
        {
            trackHue.Value = 112;
            trackHueRep.Value = 168;
            trackSatMin.Value = 25;
            trackSatMax.Value = 100;
            trackLumMin.Value = 25;
            trackLumMax.Value = 100;

            numHueRange.Value = 128;
            numHueReplace.Value = 164;
            numSatMin.Value = 40;
            numSatMax.Value = 100;
            numLumMin.Value = 42;
            numLumMax.Value = 72;
        }

        private void rbBlue_CheckedChanged(object sender, EventArgs e)
        {
            trackHue.Value = 186;
            trackHueRep.Value = 247;
            trackSatMin.Value = 52;
            trackSatMax.Value = 100;
            trackLumMin.Value = 15;
            trackLumMax.Value = 49;

            numHueRange.Value = 186;
            numHueReplace.Value = 247;
            numSatMin.Value = 52;
            numSatMax.Value = 100;
            numLumMin.Value = 15;
            numLumMax.Value = 49;
        }

        private void numTargetSize_ValueChanged(object sender, EventArgs e)
        {
            targetSize = (int)numTargetSize.Value;
        }

        private void numMinSize_ValueChanged(object sender, EventArgs e)
        {
            minBlobSize = (int)numMinSize.Value;
        }
    }
}