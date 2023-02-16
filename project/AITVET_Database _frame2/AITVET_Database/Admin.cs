using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AITVET_Database
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false; this.ControlBox = false;
            this.MaximizeBox = false;
           
            textBox10.Text = Login_Form.set;
            Class1 dbaccess = new Class1();
            dbaccess.Admin_id = textBox10.Text;
         


            if (dbaccess.QueryInAdmin())
            {
                textBox2.Text = dbaccess.Admin_name;
                textBox4.Text = dbaccess.Email;
               
                textBox3.Text = dbaccess.Phone;
                textBox9.Text = dbaccess.Picture;
                
               
                textBox5.Text = dbaccess.Current_Address;
                textBox1.Text = dbaccess.Admin_id;

                // MessageBox.Show("sucess");
            }
            else
            {
                // MessageBox.Show("fail");
                // textBox4.Text = textBox1.Text; 
            }
            pictureBox1.ImageLocation = @"\\\\JISANRAHMAN-PC\New folder\" + textBox9.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 n = new Form1();
            n.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Change c = new Change();
            c.textBox1.Text = textBox1.Text;
            c.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Class1 dbaccess1 = new Class1();
            dbaccess1.Admin_id= textBox1.Text;
              dbaccess1.Phone= textBox3.Text;
              dbaccess1.Email= textBox4.Text;
             dbaccess1.Current_Address= textBox5.Text;
           
            if (dbaccess1.updateadmin())
            {
                MessageBox.Show("update successfull");
                button4.Visible = true;
                button3.Visible = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;

            }
            else
            {
                MessageBox.Show("update fail");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("phone, email, current_address max lenght 11, 30, 30 ");
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            button3.Visible = true;
            button4.Visible = false;
        }
    }
}
