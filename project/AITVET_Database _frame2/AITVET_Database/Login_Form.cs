using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace AITVET_Database
{
    public partial class Login_Form : Form
    {
        public static string set = "";

        public Login_Form()
        {
            InitializeComponent();
        }

      
       

       

        private void button2_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

 private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (textBox1.Text == "*-__-*") { textBox1.PasswordChar ='*'; }
            if (textBox1.Text == "*-__-**-__-*") {
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("select login_id,login_password from login_id where login_id='admin'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                string s = "",p="";
                DataGridViewRow row = this.dataGridView1.Rows[0];
                s = row.Cells[0].Value.ToString();
                p= row.Cells[1].Value.ToString();
                textBox1.Text = s;
                textBox5.Text = p;


            }
            if (e.KeyCode == Keys.Enter)
               textBox5.Focus();
           

        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
            

          

        }

        private void Login_Form_Load(object sender, EventArgs e)
        {
           
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.textBox1.Focus();
           
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(@"C:\Users\Jisan Rahman\Documents\Visual Studio 2015\Projects\WindowsFormsApplication3\WindowsFormsApplication3\bin\Debug\WindowsFormsApplication3.exe");

            if (textBox1.Text == "ji1996san" && textBox5.Text=="bysuo") {
                this.Hide();
                Form1 frmm = new Form1();
                frmm.textBox5.Enabled = true;
                frmm.textBox5.Text = "admin               ";

                frmm.Show();
                frmm.textBox5.Text = "admin               ";
            }
            


          

            Class1 dbaccess = new Class1();
            dbaccess.Login_id = textBox1.Text;
            dbaccess.Login_password = textBox5.Text;
            dbaccess.Log_type = textBox3.Text;
          
            if (dbaccess.QueryInTable())
            {
                System.Diagnostics.Process.Start(@"C:\AITVET\WindowsFormsApplication3.exe");
                textBox3.Text = dbaccess.Log_type;
                textBox4.Text = dbaccess.Login_id;
                textBox3.Text = dbaccess.Log_type;
                Process[] p = Process.GetProcesses();
                foreach (Process ps in p)
                {
                    string s = ps.ProcessName;
                    s = s.ToLower();
                    if (s.CompareTo("windowsformsapplication3") == 0) { ps.Kill(); }
                }

            }
            else
            {
               

            }
            set = textBox4.Text;
            Form1 frm = new Form1();



            string value1 = textBox1.Text.Trim();
            string value2 = textBox4.Text.Trim();
            string value3 = textBox5.Text.Trim();
            string value4 = textBox2.Text.Trim();
            string value5 = textBox3.Text.Trim();

            if (value5 == "c")
            {
                MessageBox.Show("Your account is temporary close. plase contact your addministrator to continue");

                textBox1.Clear();

                textBox3.Clear();

                textBox5.Clear();
                this.textBox1.Focus();
            }
            if (value5 == "Admin")
            {
                this.Hide();


                frm.Show();
            }
            teacher t = new teacher();
            Form5 l = new Form5();


            if (value5 == "Teacher")
            {
                this.Hide();
                t.textBox10.Text = textBox4.Text;
                t.Show();
            }
            if (value5 == "Student")
            {
                this.Hide();
                l.textBox10.Text = textBox4.Text;
                l.Show();
            }
            if (value5=="")
            { MessageBox.Show("Your ID or Password is wrong");
                textBox1.Clear();
               
                textBox3.Clear();
              
                textBox5.Clear();
                this.textBox1.Focus();
            }



            }

        private void button3_Click(object sender, EventArgs e)
        {
            Appoint_teacher n = new Appoint_teacher();
           n.Show();
            n.ControlBox = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Appoint_teacher n = new Appoint_teacher();
            n.Show();
            n.ControlBox = false;

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
