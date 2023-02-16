using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\Jisan Rahman\Documents\Visual Studio 2015\Projects\WindowsFormsApplication3\WindowsFormsApplication3\bin\Debug\AITVET_Database.exe");
            
        }

        private void button17_Click(object sender, EventArgs e)
        {
            int aaa;
            aaa = int.Parse(textBox25.Text);
            aaa = aaa + 1;
            textBox25.Text = aaa.ToString();

            if (textBox25.Text == "15") textBox25.Text = "0";

            if (textBox25.Text == "1") { button9.Visible = true; button13.Visible = false; }
            if (textBox25.Text == "2") { button10.Visible = true; button9.Visible = false; }
            if (textBox25.Text == "3") { button12.Visible = true; button10.Visible = false; }
            if (textBox25.Text == "4") { button11.Visible = true; button12.Visible = false; }
            if (textBox25.Text == "5") { button16.Visible = true; button11.Visible = false; }
            if (textBox25.Text == "6") { button15.Visible = true; button16.Visible = false; }
            if (textBox25.Text == "7") { button14.Visible = true; button15.Visible = false; }
            if (textBox25.Text == "8") { button13.Visible = true; button14.Visible = false; }
            if (textBox25.Text == "9") { button14.Visible = true; button13.Visible = false; }
            if (textBox25.Text == "10") { button15.Visible = true; button14.Visible = false; }
            if (textBox25.Text == "11") { button16.Visible = true; button15.Visible = false; }
            if (textBox25.Text == "12") { button11.Visible = true; button16.Visible = false; }
            if (textBox25.Text == "13") { button12.Visible = true; button11.Visible = false; }
            if (textBox25.Text == "14") { button10.Visible = true; button12.Visible = false; }
            if (textBox25.Text == "15") { button9.Visible = true; button10.Visible = false;  }
           
          
          
          
            
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button17.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process[] p = Process.GetProcesses();
            foreach(Process ps in p) { string s = ps.ProcessName;
                s = s.ToLower();
                if (s.CompareTo("aitvet_database") == 0) { ps.Kill(); }
            }
        }
    }
}
