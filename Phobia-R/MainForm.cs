/*
██╗  ██╗ ██████╗ ██████╗ ██╗   ██╗██╗   ██╗██╗  ██╗
██║ ██╔╝██╔═══██╗██╔══██╗██║   ██║██║   ██║╚██╗██╔╝
█████╔╝ ██║   ██║██████╔╝██║   ██║██║   ██║ ╚███╔╝ 
██╔═██╗ ██║   ██║██╔══██╗╚██╗ ██╔╝██║   ██║ ██╔██╗ 
██║  ██╗╚██████╔╝██║  ██║ ╚████╔╝ ╚██████╔╝██╔╝ ██╗
╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═╝  ╚═══╝   ╚═════╝ ╚═╝  ╚═╝
###################################################
Software Version: 0.1.4
Author: Korvux
*/

using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using System.Collections.Generic;

namespace Phobia_R
{

    public partial class MainForm : Form
    {
        // This method is automatically created and managed by Windows Forms designer and it defines everything you see on the form.
        public MainForm() => InitializeComponent();

        bool flag = true;

        // -------------------------- Temporany location --------------------------
        // Explaination: https://www.codeproject.com/Articles/11114/Move-window-form-without-Titlebar-in-C

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        // --------------------------         End        --------------------------

        // Window functionality ---------------------------------------- Start ----
        private void MovablePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void CloseBox_Click(object sender, EventArgs e) { this.Close(); }

        private void UnderBox_Click(object sender, EventArgs e) { this.WindowState = FormWindowState.Minimized; }

        private void PhobiarBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Work In progress");
        }

        private void RightArrowBox_Click(object sender, EventArgs e)
        {
            if (flag != true)
            {
                MessageBox.Show("Message not elaborated yet\nPlease is suggested to insert a valid input");
                return;
            }
            // In this code example, use a hard-coded
            // IP address and message.
            string urlIP = urlBox.Text;
            string request = inputBox.Text; 
            int errorCounter = Regex.Matches(urlIP, @"[.]").Count;
                        
            if (urlIP == "" || request == "")
            {
                MessageBox.Show("Check inputs!");
                return;
            }

            if (errorCounter == 0)
            {
                MessageBox.Show("You missed the domain/dot in the url!");
                return;
            }
            /*
            Thread thchead = new Thread(() => ConnectAndSend(serverIP, message));
            thchead.Name = "Connection Thread";
            thchead.Start();
            */
            BackgroundWorker bg = new BackgroundWorker();

            if (bg.IsBusy == true)
            {
                bg.CancelAsync();
                bg.Dispose();
            }

            bg.DoWork += new DoWorkEventHandler(ConnectAndSend_DoWork);
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ConnectAndSend_RunWorkerCompleted);

            bg.RunWorkerAsync(new string[] { urlIP, request });
            //outputBox.Text = ConnectAndSend(serverIP, message);

        }

        // Window functionality ----------------------------------------  End  ----

        // Networking Function  ---------------------------------------- Start ----
        private void ConnectAndSend_DoWork(object sender, DoWorkEventArgs underWorker)
        {
            flag = false;
            string[] parameters = (string[])underWorker.Argument;
            string serverIP = parameters[0].ToString();
            string message = parameters[1].ToString();
            // Socket Creation.
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string body = "Error with calculation";

            // Variable Handling
            string GETrequest = message + "\r\n\r\n";

            // Checking errors phase

            try { socket.Connect(serverIP, 80); } catch (SocketException) { underWorker.Result = "No such host is known, check url!"; }
            try { socket.Send(Encoding.ASCII.GetBytes(GETrequest)); } catch (SocketException e) { underWorker.Result = e.ToString(); }

            bool f = true; // Just so we know we are still reading
            string headerString = ""; // To store header information
            int contentLength = 0; // The body length
            byte[] bodyBuff = new byte[0]; // To later hold the body content

            while (f)
            {
                // Read the header byte by byte, until \r\n\r\n
                byte[] buffer = new byte[1];
                try { socket.Receive(buffer, 0, 1, 0); } catch (SocketException e) { underWorker.Result = e.ToString(); }

                try { headerString += Encoding.ASCII.GetString(buffer); } catch (ArgumentNullException e) { underWorker.Result =  e.ToString(); }

                if (headerString.Contains("\r\n\r\n"))
                {
                    // Header is received, parsing content length

                    Regex reg = new Regex("\\\r\nContent-Length: (.*?)\\\r\n");
                    Match m = reg.Match(headerString);

                    try
                    {
                        contentLength = int.Parse(m.Groups[1].ToString());
                    }
                    catch (FormatException e)
                    {
                        body = e.ToString();
                        break;
                    }

                    f = false;  // Stop iteration while used to read the header byte by byte.
                    // Read the body
                    bodyBuff = new byte[contentLength];
                    socket.Receive(bodyBuff, 0, contentLength, 0);
                }
            }

            body = Encoding.ASCII.GetString(bodyBuff);

            if (body == "") body = headerString;

            socket.Close();

            underWorker.Result = body;

        }

        private void ConnectAndSend_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs underWorker)
        {
            outputBox.Text = (underWorker.Result).ToString();
            flag = true;

        }


        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveaswindow = new SaveFileDialog
            {
                Filter = "HTML Response|*.html|Json Response|*.json|Text Response|*.txt",
                Title = "Save a File"
            };

            if (saveaswindow.ShowDialog() == DialogResult.OK)
            {
                string path = saveaswindow.FileName;
                File.WriteAllText(path, outputBox.Text);
            }
        }

        private void btnLoadTemplate_Click(object sender, EventArgs e)
        {
            // Displays an OpenFileDialog so the user can select a Cursor.  
            OpenFileDialog selectFileDialog = new OpenFileDialog();
            selectFileDialog.Filter = "Preset Files|*.txt";
            selectFileDialog.Title = "Select a Preset File";

            string path =  Path.GetDirectoryName(Application.ExecutablePath) + "\\Data";

            if (Directory.Exists(path))
            {
                selectFileDialog.InitialDirectory = path;
            }
            else
            {
                selectFileDialog.InitialDirectory = @"C:\";
            }

            if (selectFileDialog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = selectFileDialog.FileName;
                string preset = File.ReadAllText(sFileName);
                inputBox.Text = preset;
            }
        }

        private void inputBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
