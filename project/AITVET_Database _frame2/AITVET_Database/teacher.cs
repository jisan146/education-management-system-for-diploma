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
    public partial class teacher : Form
    {
        public teacher()
        {
            InitializeComponent();
        }

        private void teacher_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false; this.ControlBox = false;
            textBox10.Text = Login_Form.set;
            Class1 dbaccess = new Class1();
            dbaccess.Teacher_id = textBox10.Text;
            // dbaccess.Teacher_name = textBox2.Text;
            // dbaccess.Email = textBox4.Text;
            // dbaccess.Permanent_Address = textBox6.Text;
            // dbaccess.Phone = textBox3.Text;
            // dbaccess.Picture = textBox9.Text;
            // dbaccess.Gender = textBox8.Text;
            //  dbaccess.DOB = textBox7.Text;
            // dbaccess.Current_Address = textBox5.Text;


            if (dbaccess.QueryInTeacher())
            {
                textBox2.Text = dbaccess.Teacher_name;
                textBox4.Text = dbaccess.Email;
                textBox6.Text = dbaccess.Permanent_Address;
                textBox3.Text = dbaccess.Phone;
                textBox9.Text = dbaccess.Picture;
                textBox8.Text = dbaccess.Gender;
                textBox7.Text = dbaccess.DOB;
                textBox5.Text = dbaccess.Current_Address;
                textBox1.Text = dbaccess.Teacher_id;

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
        {           // System.Diagnostics.Process.Start(@"C:\Users\Jisan Rahman\Documents\Visual Studio 2015\Projects\WindowsFormsApplication3\WindowsFormsApplication3\bin\Debug\WindowsFormsApplication3.exe");
            System.Diagnostics.Process.Start(@"C:\AITVET\AITVET_Database - Shortcut");
            Login_Form l = new Login_Form();
            //l.Show();
            //this.Hide();
         
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Email ee = new Email();
            ee.textBox8.Text = textBox10.Text;
            ee.textBox26.Text = "teacher";
            ee.Show();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Result r = new Result();
            r.textBox2.Text = textBox1.Text;
            r.Show();
            //this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            T_routine t = new T_routine();
            t.textBox4.Text = textBox1.Text;
            t.textBox4.Visible = true;
            t.textBox4.Enabled = false;
            t.comboBox1.Text = textBox1.Text;
            t.textBox3.Text = textBox1.Text;
            t.button2.Visible = true;
            t.button3.Visible =false;
           
            t.comboBox1.Visible = false;
            t.comboBox2.Visible = false;
            t.comboBox4.Visible = false;
           // t.button3.Text ="View All";
           // t.button2.Text = "Search";
            t.textBox3.Enabled = false;
            t.button2.PerformClick();
            t.Show();
            t.button2.PerformClick();
            t.label4.Visible = true;

        }

        private void button5_Click(object sender, EventArgs e)
        {
          
            View_student v = new View_student();
            v.textBox1.Text = textBox1.Text;
            v.comboBox4.Enabled = false;
            v.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            salary s = new salary();
            s.groupBox1.Visible = false;
            s.textBox1.Enabled = false;
            s.textBox1.Text = textBox1.Text;
            s.groupBox2.Visible = false;
            s.textBox17.Text = textBox1.Text;
            s.button16.Visible = true;
            s.Height = 428;
            s.Width = 579;
          
            s.Show();
            s.button15.PerformClick();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            vr n = new vr();
            n.groupBox2.Visible = false;
            n.groupBox1.Visible = true;
            n.textBox1.Enabled = false;
            n.textBox1.Text = textBox1.Text;
            n.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Attendence a = new Attendence();
            a.groupBox2.Enabled = true;
            a.textBox4.Text = textBox1.Text;
            a.textBox9.Enabled = false;
            a.textBox9.Text = textBox1.Text;
            
            
            a.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Change n = new Change();
            n.textBox1.Text = textBox1.Text;
            n.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Expart t = new Expart();

            t.Show();
            t.groupBox1.Visible = false;
                t.groupBox2.Visible = false;
            t.button7.Visible = true;
           /* t.button2.Enabled = false;
            t.textBox1.Enabled = false;*/
            t.textBox1.Text = textBox1.Text;
            t.button5.PerformClick();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select status as New_Email from email where receiver_id='" + textBox1.Text + "' and status='not read'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView4.DataSource = dt;

            int v, a;
            textBox14.Text = dataGridView4.RowCount.ToString();
            v = int.Parse(textBox14.Text);
            a = v - 1;

            textBox14.Text = a.ToString();
            //button2.Text = "Email" + " (" + textBox14.Text + " )";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button11.PerformClick();
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            int v, a, z, x, y;
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select sender_id,information,receive_date as Receive_Date_Time,status,f as Attach,semester_no as Only,course_id as Department from email where   (semester_no='" + textBox1.Text + "' or semester_no='all') and (course_id='teacher' or course_id='all')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView6.DataSource = dt;

            v = int.Parse(dataGridView6.RowCount.ToString());

            a = v - 1;
            SqlConnection conl = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sdal = new SqlDataAdapter("(select * from g where student_id='" + textBox1.Text + "') intersect (select * from g where student_id='" + textBox1.Text + "')", conl);
            DataTable dtl = new DataTable();
            sdal.Fill(dtl);
            dataGridView8.DataSource = dtl;


            z = int.Parse(dataGridView8.RowCount.ToString());

            x = z - 1;
            y = (a - z) + 1;
            button12.Text = y.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            button12.PerformClick();
            button2.Text = "Email " + "P ( " + textBox14.Text + " ) G ( " + button12.Text + " )";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            button13.Visible = false;
            button14.Visible = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("update teacher set Phone='"+textBox3.Text+ "',Email='" + textBox4.Text + "',Current_Address='" + textBox5.Text + "' where teacher_id='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
           // dataGridView1.DataSource = dt;

            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            button14.Visible = false;
            button13.Visible = true;
        }
    }
}
