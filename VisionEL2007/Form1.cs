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

        //Set up the filtering Class, which uses Hue, Saturation and Luminance to filter out colours
        HSLFiltering HSLfilter = new HSLFiltering();

        //A constant integer that is used to set the width of the image, which will be used to calculate which way the robot needs to turn by dividing the total image size into
        //fifths
        const int imgWidth = 160;

        //Set up integers for the location, which is the X-axis value of the centre of the object found and an integer for the battery life
        int location = 0;
        int battery = 100;

        //Set up intgers to set the size the object must be on the screen to be declared as found and another integer for the minimum size of object that can be detected
        int targetSize = 75;
        int minBlobSize = 15;

        //Set up the default values for the HSL filter, which will be used to filter out all but red (these were determined through experimentation)
        int hueRange = 318;
        int hueReplace = 0;
        float satMin = 0.25f;
        float satMax = 1.0f;
        float lumMin = 0.28f;
        float lumMax = 0.92f;

        //Set up booleans that will be used to let the robot know which stage of the mission it is in, determine whether there is an object, and whether or not it is close 
        //enough to determine that it is found
        bool abort = false;
        bool isBlob = false;
        bool isClose = false;
        bool inRoom = false;

        //A method that opens up the serial port for communication when the form is loaded
        private void Form1_Load(object sender, EventArgs e)
        {
            sp.Open();
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap img = (Bitmap)eventArgs.Frame.Clone();           //Create a bitmap image from the frame captured from the webcam
            byte[] ImArray = new byte[1];                           //Create a byte array to store the values of each piel in the image for processing
            ImArray = BmpToBytes_MemStream(img);                    //Process the bytes of the image for Image Processing
            img = (Bitmap)BytesToImg(ImArray);                      // Convert the byte array back to bitmap so that it can be displayed
            pbVideo.SizeMode = PictureBoxSizeMode.StretchImage;     //Fit the image into the PictureBox used to display the output of the camera after processing

            // Configure the parameters of the HSL Filter. This will be set to the values declared earlier so that by default the filter will only show red objects
            HSLfilter.Saturation = new AForge.Range(satMin, satMax);
            HSLfilter.Luminance = new AForge.Range(lumMin, lumMax);
            HSLfilter.Hue = new AForge.IntRange(hueRange, hueReplace);            
            HSLfilter.ApplyInPlace(img);    //Once the parameters are set, apply the filter to the bitmap image

            // Create an instance of the BlobCounterBase Class, which will be used to find any 'blobs' that are left within the image after processing
            BlobCounterBase blobCounter = new BlobCounter();
            //Configure the parameters that the BlobCounter will use to determine which objects in the image are blobs, helping to remove noise
            blobCounter.FilterBlobs = true;                     //Filter using the parameters in the next two lines
            blobCounter.MinWidth = minBlobSize;                 //Blobs must have a greater width than the value stored in minBlobSize
            blobCounter.MinHeight = minBlobSize;                //Blobs must have a greater height than the value stored in minBlobSize
            blobCounter.ObjectsOrder = ObjectsOrder.Size;       //Determine what order the blobs are stored in within the array, in this case by size, so the largest blob can easily be extracted            
            blobCounter.ProcessImage(img);                      //Apply the blobCounterBase filter to the image
            Blob[] blobs = blobCounter.GetObjectsInformation(); //Create an array in which to store the information about each blob that has been detected. 
                                                                //blobs[0] will contain the largest blob due to sizing order

            //This if statement will check whether any blobs were detected by the filter, and if so, extract the largest one so that it can be displayed and the location of the
            //blob can be used to find the object
            if (blobs.Length > 0)
            {
                isBlob = true;          //Change the value of the isBlob boolean to true so that the robot knows an image is on the screen                
                Blob blob = blobs[0];   //Create a Blob object from the information stored in the first entry of the blobs array (this will be the largest blob)
                blobCounter.ExtractBlobsImage(img, blob, true);

                location = blob.Rectangle.X + (blob.Rectangle.Width / 2);   //Set the value stored in the location variable to be the X co-ordinate of the upper left
                                                                            //corner of the blobs rectangle plus half its width, which will give the objects centre.
                                                                            //The Y co-ordinate is not used as the camera can't be moved, so will be positioned in such
                                                                            //a way that it can see as much as possible

                //Used a delegate to update the text box on the GUI that will display the width of the ojject being displayed
                BeginInvoke(((Action)delegate ()
                {
                    tbWidth.Clear();
                    tbWidth.Text = blob.Rectangle.Width.ToString();
                }));

                //An if statement that will check to see how large the image is on the screen, and if it is greater than the value stored in targetSize
                //the isClose boolean will be changed to true so that the robot knows that it is close enough to the object
                if (blob.Rectangle.Width > targetSize)
                    isClose = true;
                else
                    isClose = false;

                //Lock the display image so that a box can be drawn around the extracted blob to show it has been recognised and is large enough
                BitmapData data = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadWrite, img.PixelFormat);

                Rectangle rect = blobs[0].Rectangle;         //Create a Rectangle object that uses the information stored of the largest blob
                Drawing.Rectangle(data, rect, Color.White);  //Draw a white rectangle around the blob

                img.UnlockBits(data);                     //Unlock the bits so the display image can be displayed in the picture box
            }
            //If no blobs are found, set the isBlob boolean to false so the robot will start its searching routine
            else
            {
                isBlob = false;
            }

            //If the boolean inRoom is set to true, which happens once the robot has finished travelling by dead reckoning, the robot should start the LocateObject method
            if (inRoom)
            {
                LocateObject(ImArray, isBlob, abort);
            }

            //Display the processed image in the picture box so it can be seen by the user
            pbVideo.Image = img;
        }        

        //This method will handle what happens when the user clicks the 'Begin' button
        private void btnBegin_Click(object sender, EventArgs e)
        {
            bwBattery.RunWorkerAsync();                     //Start the background worker that will handle the battery life display
            btnBegin.Enabled = false;                       //Set the Enabled property of the Begin button to false so it can not be clicked again
            tbData.Clear();                                 //Clear the text box that display mission information
            abort = false;                                  //Set the abort boolean to false so tha the abort button will function if pressed
            Thread questThread = new Thread(moveCommands);  //Create a new thread that will be used to carry out the moveCommands method, so that the GUI is still operative
            questThread.Start();                            //Start the thread that was created to do the moveCommands method            
        }

        //This method is called when the user clicks the 'Begin' button and sends commands over the Serial Port to guide the robot from its starting position to the room
        //where the object will be located. Each code block is set within an if statement that checks to make sure the abort boolean is false, otherwise it means the abort
        //button has been pressed and the robot should stop
        public void moveCommands()
        {
            if (!abort)
            {
                //Update the mission data text box to let the user know that the robot is moving fowards
                BeginInvoke(((Action)delegate ()
                {
                    tbData.AppendText("Moving Forwards" + Environment.NewLine);
                }));

                //This creates an array of bytes that is used to store four instructions to send to the robot all at once via Serial Port. 
                //The first entry in the array is M (77 is the ASCII value for 'M'), which tells the robot it is direct motor control.
                //The next two entries control the left and right motor speeds and the final entry is the time in milliseconds divided by 10
                //that the motors will run for, in this case 1000 milliseconds or 1 second
                byte[] command = { 77, 85, 100, 100 };
                sp.Write(command, 0, 4);    //The sp.Write method will write the previously created array of bites, starting at the first entry and going through all four
                Thread.Sleep(1000); //Sleep the thread for 1 second whilst the commands are carried out

                //The following code repeats the previous code two more times, equating to a move time of three seconds. Having the code split allows for fine tuning of timings.
                //Also, due to them being stored as bytes, the maximum value is 255 meaning the longest time that can be stored is 2550 milliseconds
                sp.Write(command, 0, 4);
                Thread.Sleep(1000);

                sp.Write(command, 0, 4);
                Thread.Sleep(1000);
                
                byte[] command2 = { 77, 85, 100, 35 };  //Change the command to make the robot move forward for a shorter period of time (350 milliseconds)
                sp.Write(command, 0, 4);
                Thread.Sleep(200);
            }

            if (!abort)
            {
                //Update the mission data textbox to tell the user the robot is rotating 90 degrees
                BeginInvoke(((Action)delegate ()
                {
                    tbData.AppendText("Turning 90 Degrees" + Environment.NewLine);
                }));

                sp.Write("4");      //Send the command to turn right via Serial Port
                Thread.Sleep(350);  //Sleep the thread for the necessary amount of time to turn
            }

            if (!abort)
            {
                //This byte array will power the motors in such a way that the robot will rotate right. The timings can be changed for different angles, in this case 90 degrees
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
                //This code blocks moves the robot forwards again in the same way as the first code block in the method
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
                //This code block also causes the robot to rotate 90 degrees right in the same way as the previous rotate command however for a shorter period of time
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
                //This code block moves the robot forward again
                byte[] command = { 77, 85, 100, 40 };
                sp.Write(command, 0, 4);
                Thread.Sleep(400);

                sp.Write(command, 0, 4);
                Thread.Sleep(400);

                sp.Write("5");  //Once the robot has finished moving forward, send the command to stop via the Serial Port
                BeginInvoke(((Action)delegate ()
                {
                    tbData.AppendText("Reached Room" + Environment.NewLine);    //Update the mission data text box to tell the user the robot has reached its destination
                }));
            }

            if (!abort)
            {
                MessageBox.Show("Commencing Object Location");  //Display a message box telling the user that the robot will start locating the object
            }

            if (!abort)
            {
                //Update the mission data text box to show that the robot is in Search Mode
                BeginInvoke(((Action)delegate ()
                {
                    tbData.Clear();
                    tbData.AppendText("Commencing Object Location" + Environment.NewLine);
                }));

                inRoom = true;  //Change the value of the inRoom boolean to true which will tell the robot to start locating the object
            }
        }

        //This method handles what happens when the user clicks the 'Abort' button
        private void btnAbort_Click(object sender, EventArgs e)
        {
            abort = true;                               //Set the value of the abort boolean to true so that the robot will stop carrying out any commands it is being given
            inRoom = false;                             //Set the value of the inRoom boolean to false so that the robot will stop its locateObject method
            tbTurn.Clear();                             //Clear the turn textbox
            tbLocation.Clear();                         //Clear the location text box
            sp.Write("5");                              //Send the 'stop' command via serial port to make sure that the robot stops
            bwBattery.CancelAsync();                    //Cancel the background worker thread that is dealing with the battery life progress bar
            Thread abortThread = new Thread(Abort);     //Create a new thread which will carry out the Abort method
            abortThread.Start();                        //Start the thread that was created to handle the abort method
            btnBegin.Enabled = true;
        }

        //This method is called when the user clicks the abort button and handles stopping the robot
        public void Abort()
        {
            abort = true;   //Change the abort bool to true which will stop the robot from moving
            sp.Write("5");  //Send the stop command via Serial Port to tell the robot to stop

            //This delegate updates the mission data textbook on the GUI
            BeginInvoke(((Action)delegate ()
            {
                sp.Write("5");  //Send the stop command via the Serial Port again to make sure the robot has definitely stopped
                tbData.AppendText("Mission Aborted!" + Environment.NewLine);    //Update the mission data textbox to acknowledge tha the mission was aborted
                MessageBox.Show("Mission Aborted!", "Mission Aborted!", MessageBoxButtons.OK, MessageBoxIcon.Information);  //Display a message box that also says the 
                                                                                                                            //mission was aborted
            }));
        }

        //This method will handle what happens when the user clicks the search button. This button allows the user to skip the dead reckoning movement into the room
        //and just carry out object location if the robot is already in the room
        private void btnSearch_Click(object sender, EventArgs e)
        {
            abort = false;  //Set the abort boolean to false so that the robot will carry out the commands even if it has been aborted
            inRoom = true;  //Set the inRoom boolean to true so that the robot will carry out the locateObject method
        }

        //This method will handle the object location logic of the robot. It takes in the bitmap data to analyse and uses two booleans isBlob and abort.
        //The isBlob boolean tells the robot if an object has been found and the abort boolean is used so that the robot can stop if the abort button is pressed by using
        //it within each if statement
        void LocateObject(byte[] bmpData, bool isBlob, bool abort)
        {
            //The first if statement checks to see if the abort button has been pressed and will stop the robot if it has
            if (abort)
            {
                sp.Write("5");  //Send the stop command via Serial Port
            }

            //If the isClose boolean has been set to true, the robot has found the object and moved close enough to it, so the object is found
            if (isClose && !abort)
            {
                sp.Write("5");              //Send the stop command via Serial Port
                inRoom = false;             //Set inRoom to false so the robot exits the LocateObject method 
                abort = true;               //Set abort to true to make sure the robot stops

                BeginInvoke(((Action)delegate ()
                {
                    sp.Write("5");  //Send the stop command again via Serial Port to make sure the robot has stopped
                    tbTurn.Clear(); //Clear the turn direction text box
                    tbTurn.Text = "Stop, Object Close"; //Add text letting the user know the robot is close to the object into the turn text box
                    tbData.Text = (tbData.Text + Environment.NewLine + "Object Located" + Environment.NewLine + "Mission Accomplished!" + Environment.NewLine);
                    MessageBox.Show("Mission Accomplished!");   //Show a message box to confirm the object has been located
                }));
            }

            //If an object has been located this statement will print the location of it into the location text box
            if (isBlob && !abort && !isClose)
            {
                BeginInvoke(((Action)delegate ()
                {
                    tbLocation.Clear();                         //Clear the location text box
                    tbLocation.Text = location.ToString();      //Add the objects location to the text box
                }));
            }

            //This if statement checks whether the object is located in the middle fifth of the screen and if so move forward because the object is directly in front of the robot
            if ((location > ((imgWidth / 5) * 2)) && (location <= ((imgWidth / 5) * 3)) && isBlob && !abort && !isClose)
            {
                sp.Write("8");  //Send the command to move straight forward via Serial Port

                BeginInvoke(((Action)delegate ()
                {
                    tbTurn.Clear(); //Clear the turn textbox
                    tbTurn.Text = "Move Forward";   //Notify the user the robot is moving forward via the turn textbox
                }));
            }

            //This if statement checks to see if the obect is within the left two fifths of the screen and if so turn left
            if (location < ((imgWidth / 5) * 2) && isBlob && !abort && !isClose)
            {
                sp.Write("6");  //Send the command to turn left via the Serial Port

                BeginInvoke(((Action)delegate ()
                {
                    tbTurn.Clear(); //Clear the turn textbox
                    tbTurn.Text = "Turn Left";  //Notify the user that the robot is turning left via the turn textbox
                }));
            }

            //This if statement check to see if the object is within the right two fifths of the screen and if so turn right
            if (location >= ((imgWidth / 5) * 3) && isBlob && !abort && !isClose)
            {
                sp.Write("4");  //Send the command to turn right via the Serial Port

                BeginInvoke(((Action)delegate ()
                {
                    tbTurn.Clear(); //Clear the turn textbox
                    tbTurn.Text = "Move Right"; //Notify the user that the robot is turning right via the turn textbox
                }));
            }

            //If no object has been located this if statement will make the robot rotate indefinitely until an object is located
            if (!isBlob && !abort && !isClose)
            {
                byte[] command = { 77, 206, 100, 00 };   //Byte array commands that will make the robot rotate right indefinitely
                sp.Write(command, 0, 4);                //Send the commands over the Serial Port

                BeginInvoke(((Action)delegate ()
                {
                    tbLocation.Clear();
                    tbLocation.Text = "No Object Detected"; //Change the text boxes so the user knows the robot is still searching
                    tbTurn.Text = "Searching...";
                }));
                return;
            }
        }

        //This method controls the background worker that is responsible for updating the battery progress bar. It is started when the user clicks the begin button
        private void bwBattery_DoWork(object sender, DoWorkEventArgs e)
        {
            //This for loop counts down from the value stored in the battery variable and reports its progress back to the main GUI thread to update the progress bar
            for (int i = battery; i > -1; i--)
            {
                //This if statement checks to see whether the background worker has been cancelled, which is triggered when the user clicks the abort button
                if (bwBattery.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                bwBattery.ReportProgress(i);    //Send the value of i to the progress changed method to update the battery progress bar
                Thread.Sleep(2500);             //Sleep the thread for 2.5 seconds to simulate battery drain over time
            }
        }

        //This method sends the value from the DoWork method to the main GUI thread to display the battery values
        private void bwBattery_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbBattery.Value = e.ProgressPercentage; //Update the progress bar with the value of i from DoWork
            lblBattery.Text = ("Battery Level: " + e.ProgressPercentage.ToString() + "%");  //Change the label text to display the current battery percentage
        }

        //This method is called when the value of battery reaches 0, meaning that the battery has been fully drained
        private void bwBattery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!abort)  //Check to see that the mission hasn't been aborted
                MessageBox.Show("Battery Empty!");  //Show a message box letting the user know that the battery has been fully drained
        }

        //The following methods are used for the manual control buttons on the form. They send pre-determined serial commands to the robot via the Serial Port
        private void btnDriftLeft_Click(object sender, EventArgs e)
        {
            sp.Write("7");  //Send the command to drift left via the Serial Port
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            sp.Write("8");  //Send the command to move forward via the Serial Port
        }

        private void btnDriftRight_Click(object sender, EventArgs e)
        {
            sp.Write("9");  //Send the command to drift right via the Serial Port
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            sp.Write("4");  //Send the command to turn left via the Serial Port
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            sp.Write("5");  //Send the command to stop via the Serial Port
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            sp.Write("6");  //Send the command to turn right via the Serial Port
        }

        private void btnBackLeft_Click(object sender, EventArgs e)
        {
            sp.Write("1");  //Send the command to reverse left via the Serial Port
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            sp.Write("2");  //Send the command to reverse via the Serial Port
        }

        private void btnBackRight_Click(object sender, EventArgs e)
        {
            sp.Write("3");  //Send the command to reverse right via the Serial Port
        }

        //This method is called when the user clicks the button to enable the colour controls
        private void btnEnableColor_Click(object sender, EventArgs e)
        {
            btnEnableColor.Enabled = false; //Set the enabled property of the enable colour controls button to false so that it can not be clicked while active
            btnDisableColor.Enabled = true; //Set the enabled property of the disable colour controls button to true so that the controls can be disabled
            pnlColor.Enabled = true;        //Enable the colour controls panel which contains all the controls (defaulted to disabled)
        }

        //This method is called when the user clicks the button to disable colour controls
        private void btnDisableColor_Click(object sender, EventArgs e)
        {
            btnDisableColor.Enabled = false; //Set the enabled property of the disable colour controls button to false so it can't be clicked when the controls are disabled
            btnEnableColor.Enabled = true;   //Set the enabled property of the enable colour controls button to true so the controls can be activated
            pnlColor.Enabled = false;        //Disable the colour controls panel which contains all the controls
        }

        //The following methods are used to change the variables used by the the HSL Filter when the sliders are changed. 
        //Each one changes the related variable and also sets the value in the numerical up/down to match that of the slider
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

        //The following methods change the variables used by the HSL Filter when the numeric up/down controls are changed.
        //Each one changes the related variable and also sets the value of their corresponding slider to match that of the numeric up/down
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

        //These methods are used by the preset colour radio buttons, one for red, blue and green. They each change the slider and numeric up/down values of every colour control
        //which in turn changes the variables used by the HSL Filter
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

        //This method is called when the numeric up/down control is changed which allows the user to specify how large the located image must be on the screen before the robot considers
        //it to be found
        private void numTargetSize_ValueChanged(object sender, EventArgs e)
        {
            targetSize = (int)numTargetSize.Value;  //Change the targetSize variable to the value of the target size numeric control
        }

        //This method is called when the numeric up/down control is changed which allows the user to specify the minimum size of object that can be located by the blob filter.
        //This can help to reduce noise within the image and reduce the chance of false positives
        private void numMinSize_ValueChanged(object sender, EventArgs e)
        {
            minBlobSize = (int)numMinSize.Value;    //Change the minBlobSize variable to the value of the minimum size numeric control
        }
    }
}