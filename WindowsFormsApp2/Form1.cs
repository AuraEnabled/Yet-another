using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Click += async (s, a) =>
            { 
                await Task.Delay(1000); 
                Process.Start("notepad");
            };
            button1.MouseEnter += (s, a) => { Process.Start("notepad"); };
            button1.MouseLeave += (s, a) => { foreach (Process process in Process.GetProcessesByName("notepad")) process.Kill(); };

            button2.Click += (s, a) => { label1.Text = "Eva"; };
        }

        void Cmd(string line)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = $"/c {line}",
                WindowStyle = ProcessWindowStyle.Hidden
            }).WaitForExit(); 
        }

        
    }
}
