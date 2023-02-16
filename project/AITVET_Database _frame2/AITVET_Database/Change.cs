using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AITVET_Database
{
    public partial class Change : Form
    {
        public Change()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Length > 3) { 
            Class1 dbaccess = new Class1();
            dbaccess.Login_id = textBox1.Text;
            dbaccess.Login_password = textBox2.Text;
            dbaccess.Log_type = textBox3.Text;

            if (dbaccess.QueryInTable())
            {
                textBox5.Text = dbaccess.Login_password;
                //  textBox4.Text = dbaccess.Login_id;
                //  textBox3.Text = dbaccess.Log_type;
                //MessageBox.Show("sucess");
            }
            else
            {
                //MessageBox.Show("fail");
                // textBox4.Text = textBox1.Text; 
            }
            string value1 = textBox2.Text.Trim();
            string value2 = textBox5.Text.Trim();
            string value3 = textBox3.Text.Trim();
            string value4 = textBox4.Text.Trim();
            if (value1 == value2 && value3 == value4)
            {
                Class1 dbaccess1 = new Class1();
                dbaccess1.Login_id = textBox1.Text;
                dbaccess1.Login_password = textBox3.Text;


                if (dbaccess1.DataUpdateInTable())
                {
                    MessageBox.Show("save");
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();

                    }
                else
                    MessageBox.Show("not");
            }
            else { }
            if (value1 != value2)
            { MessageBox.Show("Current password not match"); }
            if (value3 != value4)
            { MessageBox.Show("new password and confirm password not match"); }
            }else { MessageBox.Show("Pessword length must be 4 to 10"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Change_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false; this.ControlBox = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox3.Focus();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox4.Focus();
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }
    }
}
