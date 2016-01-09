using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CharlesNewVersion
{
    class WindowExplorer
    {
       //Code for use WinApi 
       //{
            [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
            public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [DllImport("USER32.DLL")]
            public static extern bool SetForegroundWindow(IntPtr hWnd);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
            static extern IntPtr SendMessage(IntPtr handle, UInt32 message, IntPtr w, IntPtr l);

            [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

            static uint WM_CLOSE = 0x10;
        //}
        //


        private IntPtr handleWindow = (IntPtr)0;
        private string currentPath, lastTitle;
        private bool opened = false;
        public WindowExplorer(string path)
        {
            currentPath = path;
        }

        public void Show()
        {
            if (!opened)
            {
                Process.Start("explorer.exe", currentPath);
                Thread.Sleep(500); //comlete openeng
                string titleWindow = currentPath.Remove(0, currentPath.LastIndexOf("\\") + 1);
                handleWindow = FindWindow(null, (titleWindow));
                lastTitle = titleWindow;
                opened = true;
            }
        }
        public void updateCurrentPath()
        {
            StringBuilder outstr = new StringBuilder();
            GetWindowText(handleWindow, outstr, 100);
            if (Convert.ToString(outstr) != lastTitle)
            {
                currentPath += "\\" + Convert.ToString(outstr);
            }
            lastTitle = Convert.ToString(outstr);
        }

        public void Close()
        {
            SendMessage(handleWindow, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            opened = false;
        }

        private void sendKey(string key)
        {
            SetForegroundWindow(handleWindow);
            SendKeys.SendWait(key);
            Thread.Sleep(100);//for complete last command
        }
        public void applySolution(string solution)
        {
            string command;
            while (solution.IndexOf(" ") != -1) //while commands are
            {
                command = solution.Substring(0, solution.IndexOf(" ")); //getting of comand
                solution = solution.Remove(0, solution.IndexOf(" ") + 1); //remove command from solution
                switch (command)
                {
                    case "Up":
                    {
                        sendKey("{UP}");
                        break;
                    }
                    case "Down":
                    {
                        sendKey("{DOWN}");
                        break;
                    }
                    case "Return":
                    {
                        sendKey("{ENTER}");
                        break;
                    }
                    case "Delete":
                    {
                        sendKey("{DEL}");
                        break;
                    }
                    case "Right":
                    {
                        sendKey("{RIGHT}");
                        break;
                    }
                }
            }
        }

        public void back()
        {
            SetForegroundWindow(handleWindow);
            SendKeys.SendWait("%{UP}");
            currentPath=currentPath.Remove(currentPath.LastIndexOf("\\"));
        }
        public string getContent()
        {
            string content="";
            DirectoryInfo dir = new DirectoryInfo(currentPath);
            foreach (FileInfo files in dir.GetFiles())
            {
                content += " " + files.Name;
            }
            foreach (var item in dir.GetDirectories())
            {
                content += " " + item.Name;
            }
            return content;
        }

        public string getPath()
        {
            return currentPath;
        }
    }
}
