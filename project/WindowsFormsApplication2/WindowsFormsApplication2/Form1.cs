using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox4.Width = 100;
            textBox4.Height = 100;
            textBox4.Size.Equals(14);
            // textBox11.Text = DateTime.Now.ToString("HH:mm:ss tt");
            //textBox10.Text = DateTime.Now.ToString("MMM  dd ,dddd, yyyy hh:mm:ss tt");*/
        }

        private void button1_Click(object sender, EventArgs e)
        {

            textBox1.Text = DateTime.Now.ToString("HH");
            textBox6.Text = DateTime.Now.ToString("mm");
            textBox1.Text = textBox1.Text + textBox6.Text;
            textBox2.Text = textBox2.Text + textBox5.Text;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a, b, c;
            a = int.Parse(textBox1.Text);

            b = int.Parse(textBox2.Text);
            c = int.Parse(textBox3.Text);
            if (a < b) { 
            if (c >= a && c <= b)
            {


                    MessageBox.Show("y");
                }else { MessageBox.Show("n"); }
            }
            else if (a > b)
            {
                if (c >= a)
                { c = c - 12;textBox3.Text = c.ToString();
                  b = b + 12;textBox2.Text = b.ToString();
                    if (c <= b) { MessageBox.Show("y"); }
                }else
                {
                    if (c <= b) { MessageBox.Show("y"); }
                }
            }

          
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int a, b, c;
            a = int.Parse(textBox1.Text);
            if (textBox6.Text == "PM") { a = a + 12;textBox1.Text = a.ToString(); }
        }
    }
}
