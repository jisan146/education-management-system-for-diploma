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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\AITVET\AITVET_Database - Shortcut");
            Login_Form l = new Login_Form();
           // l.Show();
            //this.Hide();
          
            Application.Exit();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false; this.ControlBox = false;//textBox10.Text = Login_Form.set;

            Class1 dbaccess = new Class1();
            dbaccess.Student_id = textBox10.Text;
            // dbaccess.Teacher_name = textBox2.Text;
            // dbaccess.Email = textBox4.Text;
            // dbaccess.Permanent_Address = textBox6.Text;
            // dbaccess.Phone = textBox3.Text;
            // dbaccess.Picture = textBox9.Text;
            // dbaccess.Gender = textBox8.Text;
            //  dbaccess.DOB = textBox7.Text;
            // dbaccess.Current_Address = textBox5.Text;


            if (dbaccess.QueryInStudent())
            {
                textBox2.Text = dbaccess.Student_name;
                textBox4.Text = dbaccess.Email;
                textBox6.Text = dbaccess.Permanent_Address;
                textBox3.Text = dbaccess.Phone;
                textBox9.Text = dbaccess.Picture;
                textBox8.Text = dbaccess.Gender;
                textBox7.Text = dbaccess.DOB;
                textBox5.Text = dbaccess.Current_Address;
                textBox1.Text = dbaccess.Student_id;
                textBox11.Text = dbaccess.Board_roll;

                // MessageBox.Show("sucess");
            }
            else
            {
                // MessageBox.Show("fail");
                // textBox4.Text = textBox1.Text; 
            }
            pictureBox1.ImageLocation = @"\\\\JISANRAHMAN-PC\New folder\" + textBox9.Text;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1 dbaccess = new Class1();
            dbaccess.Student_id = textBox1.Text;


            if (dbaccess.QueryInOp())
            {
                textBox12.Text = dbaccess.Semester_no;
                textBox13.Text = dbaccess.Course_id;

                //MessageBox.Show("sucess");
            }
            else
            {
                //MessageBox.Show("fail");
                // textBox4.Text = textBox1.Text; 
            }
            Email ee = new Email();
            ee.textBox8.Text = textBox10.Text;
            ee.textBox1.Text = textBox12.Text;
            ee.textBox2.Text = textBox13.Text;
            ee.textBox26.Text = "student";
          
            ee.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            vss n = new vss();
            n.textBox1.Text = textBox1.Text;
            n.textBox1.Enabled = false;
            n.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            vr n = new vr();
            n.groupBox2.Visible = true;
            n.groupBox1.Visible = false;
            n.textBox2.Enabled = false;
            n.textBox2.Text = textBox1.Text;
            n.button22.Visible = true;
            n.Show();
            n.button2.PerformClick();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Class1 dbaccess = new Class1();
            dbaccess.Student_id = textBox1.Text;


            if (dbaccess.QueryInOp())
            {
                textBox12.Text = dbaccess.Semester_no;
                textBox13.Text = dbaccess.Course_id;

                //MessageBox.Show("sucess");
            }
            else
            {
                //MessageBox.Show("fail");
                // textBox4.Text = textBox1.Text; 
            }

            S_routine s = new S_routine();
            s.textBox3.Text = textBox12.Text;
            s.textBox1.Text = textBox13.Text;
            s.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Class1 dbaccess = new Class1();
            dbaccess.Student_id = textBox1.Text;
          
        
            if (dbaccess.QueryInOp())
            {
                textBox12.Text = dbaccess.Semester_no;
                textBox13.Text = dbaccess.Course_id;
              
                //MessageBox.Show("sucess");
            }
            else
            {
                //MessageBox.Show("fail");
                // textBox4.Text = textBox1.Text; 
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Change c = new Change();
            c.textBox1.Text = textBox1.Text;
            c.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button8.PerformClick();
        }

        private void button8_Click(object sender, EventArgs e)
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
           // button2.Text = "Email" + " (" + textBox14.Text + " )";
        

    }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select sender_id,information,receive_date as Receive_Date_Time,status,f as Attach,semester_no as Only,course_id as Department from email where   (semester_no='" + textBox12.Text + "' or semester_no='all') and (course_id='" + textBox13.Text + "' or course_id='all' or course_id='student')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            int v, a,x,y,z;
            v = int.Parse(dataGridView1.RowCount.ToString());
          
            a = v - 1;
            SqlConnection conl = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sdal = new SqlDataAdapter("(select * from g where student_id='" + textBox1.Text + "') intersect (select * from g where student_id='" + textBox1.Text + "')", conl);
            DataTable dtl = new DataTable();
            sdal.Fill(dtl);
            dataGridView8.DataSource = dtl;


            z = int.Parse(dataGridView8.RowCount.ToString());

            x = z - 1;
            y = (a - z) + 1;

            button9.Text = y.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            button10.PerformClick();
            button2.Text = "Email "+"P"+"( "+textBox14.Text +" )"+" G"+ "( "+button9.Text+" )";
            button9.PerformClick();
           

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Class1 dbaccess = new Class1();
            dbaccess.Student_id = textBox1.Text;


            if (dbaccess.QueryInOp())
            {
                textBox12.Text = dbaccess.Semester_no;
                textBox13.Text = dbaccess.Course_id;

                //MessageBox.Show("sucess");
            }
            else
            {
                //MessageBox.Show("fail");
                // textBox4.Text = textBox1.Text; 
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            button11.Visible = false;
            button12.Visible = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("update student set Phone='" + textBox3.Text + "',Email='" + textBox4.Text + "',Current_Address='" + textBox5.Text + "' where student_id='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            // dataGridView1.DataSource = dt;

            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            button11.Visible = false;
            button12.Visible = true;
        }
    }
}
