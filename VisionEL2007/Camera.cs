using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO;
using System.Drawing.Imaging;


namespace Vision
{
    public partial class Form1 : Form
    {
        private bool DeviceExist = false;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource = null;

        void GetWebCams()
        {
            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                cbWebCams.Items.Clear();
                if (videoDevices.Count == 0)
                    throw new ApplicationException();

                DeviceExist = true;
                foreach (FilterInfo device in videoDevices)
                {
                    cbWebCams.Items.Add(device.Name);
                }
                cbWebCams.SelectedIndex = 0; //make dafault to first cam
            }
            catch (ApplicationException)
            {
                DeviceExist = false;
                cbWebCams.Items.Add("No capture device on your system");
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "Start")
            {
                if (DeviceExist)
                {
                    videoSource = new VideoCaptureDevice(videoDevices[cbWebCams.SelectedIndex].MonikerString);
                    videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
                    CloseVideoSource();
                    videoSource.DesiredFrameSize = new Size(160, 120);
                    //videoSource.DesiredFrameRate = 10;
                    videoSource.Start();
                    lblStatus.Text = "Device running...";
                    btnStart.Text = "Stop";
                    timer1.Enabled = true;
                }
                else
                {
                    lblStatus.Text = "Error: No Device selected.";
                }
            }
            else
            {
                if (videoSource.IsRunning)
                {
                    timer1.Enabled = false;
                    CloseVideoSource();
                    lblStatus.Text = "Device stopped.";
                    btnStart.Text = "&Start";
                }
            }
        }

        private void CloseVideoSource()
        {
            if (!(videoSource == null))
                if (videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource = null;
                }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblStatus.Text = "Device running... " + videoSource.FramesReceived.ToString() + " FPS";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseVideoSource();
        }

        private byte[] BmpToBytes_MemStream(Bitmap bmp)
        {
            MemoryStream ms = new MemoryStream();
            // Save to memory using the Bmp format
            bmp.Save(ms, ImageFormat.Bmp);
            // read to end
            byte[] bmpBytes = ms.ToArray();
            bmp.Dispose();
            ms.Close();
            return bmpBytes;
        }
        //Bitmap bytes have to be created using Image.Save()
        private Image BytesToImg(byte[] bmpBytes)
        {
            MemoryStream ms1 = new MemoryStream(bmpBytes);
            //return new Bitmap(ms1);
            Image img1 = Image.FromStream(ms1);
            // Do NOT close the stream!

            return img1;
        }

    }

}