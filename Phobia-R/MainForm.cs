/*
██╗  ██╗ ██████╗ ██████╗ ██╗   ██╗██╗   ██╗██╗  ██╗
██║ ██╔╝██╔═══██╗██╔══██╗██║   ██║██║   ██║╚██╗██╔╝
█████╔╝ ██║   ██║██████╔╝██║   ██║██║   ██║ ╚███╔╝ 
██╔═██╗ ██║   ██║██╔══██╗╚██╗ ██╔╝██║   ██║ ██╔██╗ 
██║  ██╗╚██████╔╝██║  ██║ ╚████╔╝ ╚██████╔╝██╔╝ ██╗
╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═╝  ╚═══╝   ╚═════╝ ╚═╝  ╚═╝
###################################################
Software Version: 0.1.3
Author: Korvux
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phobia_R
{
    public partial class MainForm : Form
    {
        // This method is automatically created and managed by Windows Forms designer and it defines everything you see on the form.
        public MainForm() => InitializeComponent();


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

        private void CloseBox_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UnderBox_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PhobiarBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Work In progress");
        }

        private void RightArrowBox_Click(object sender, EventArgs e)
        {
            // In this code example, use a hard-coded
            // IP address and message.
            string serverIP = urlBox.Text;
            string message = inputBox.Text;
            if (message == "" || serverIP == "")
            {
                MessageBox.Show("Check inputs!");
                return;
            }
            outputBox.Text = ConnectAndSend(serverIP, message);
        }

        // Window functionality ----------------------------------------  End  ----

        // Networking Function  ---------------------------------------- Start ----
        static string ConnectAndSend(string serverIP, string message)
        {
            // Socket Creation.
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string body = "Error with calculation";

            // Variable Handling
            string GETrequest = message + "\r\n\r\n";

            // Checking errors phase

            try { socket.Connect(serverIP, 80); } catch (SocketException) { return "No such host is known, check url!"; }
            try { socket.Send(Encoding.ASCII.GetBytes(GETrequest)); } catch (SocketException e) { return e.ToString(); }

            bool f = true; // Just so we know we are still reading
            string headerString = ""; // To store header information
            int contentLength = 0; // The body length
            byte[] bodyBuff = new byte[0]; // To later hold the body content

            while (f)
            {
                // Read the header byte by byte, until \r\n\r\n
                byte[] buffer = new byte[1];
                socket.Receive(buffer, 0, 1, 0);

                try { headerString += Encoding.ASCII.GetString(buffer); } catch (ArgumentNullException e) { return e.ToString(); }

                if (headerString.Contains("\r\n\r\n"))
                {
                    // header is received, parsing content length
                    // I use regular expressions, but any other method you can think of is ok
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

            return body;
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveaswindow = new SaveFileDialog();
            saveaswindow.Filter = "HTML Response|*.html|Json Response|*.json|Text Response|*.txt";
            saveaswindow.Title = "Save a File";
            if (saveaswindow.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = saveaswindow.FileName;
                System.IO.File.WriteAllText(path, outputBox.Text);
            }
        }
    }
}
