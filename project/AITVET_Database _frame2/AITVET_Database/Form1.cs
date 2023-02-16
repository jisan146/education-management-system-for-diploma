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
    public partial class Form1 : Form
    {
        string imgloc = "";
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && textBox4.Text == textBox2.Text)
            {
                Class1 dbaccess = new Class1();
                dbaccess.Login_id = textBox1.Text;
                dbaccess.Login_password = textBox2.Text;
                dbaccess.Log_type = textBox3.Text;
                if (dbaccess.DataSaveInTable())
                {
                    button3.Visible = true;
                    button3.Text = "submit successfully ";
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    button4.Visible = false;
                }
                else
                {
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    button3.Visible = true;
                    button3.Text = "fail to submit ";
                    button4.Visible = false;
                }

                button1.Visible = false;
                button2.Visible = true;
                textBox3.Enabled = false;
                textBox3.Visible = true;
                comboBox1.Visible = false;


            }
            else
            {
                button3.Text = "Complete all field ";
                button3.Visible = true;
            }
            if (textBox4.Text == textBox2.Text)
            {  }
            else
            {
                button4.Text = "password not match ";
                button4.Visible = true;
                button3.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox3.Text = "";
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox2.Text = "";
            button1.Visible = true;
            button3.Visible = false;
            textBox3.Visible = false;
            comboBox1.Visible = true;
            button4.Visible = false;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = comboBox1.Text;
        }

        

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "administrator")
            {
                button9.Visible = true;
                button9.Text = "Don't have permission";
            }
            else
            {
                Class1 dbaccess = new Class1();
                dbaccess.Login_id = textBox6.Text;
                //  dbaccess.Login_password = textBox2.Text;
                //  dbaccess.Log_type = textBox3.Text;

                if (dbaccess.DataDeleInTable())
                {
                    button9.Visible = true;
                    button9.Text = "suceessfully delete";
                }
                else
                {
                    button9.Visible = true;
                    button9.Text = "fail to delete data";
                }
            }
            
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\AITVET\WindowsFormsApplication3.exe");



            Form3 t = new Form3();
            t.textBox21.Text = textBox5.Text;
            t.Show();

            Process[] p = Process.GetProcesses();
            foreach (Process ps in p)
            {
                string s = ps.ProcessName;
                s = s.ToLower();
                if (s.CompareTo("windowsformsapplication3") == 0) { ps.Kill(); }
            }
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\AITVET\WindowsFormsApplication3.exe");
            Form4 t1 = new Form4();
            t1.textBox16.Text = textBox5.Text;
            t1.Show();

            Process[] p = Process.GetProcesses();
            foreach (Process ps in p)
            {
                string s = ps.ProcessName;
                s = s.ToLower();
                if (s.CompareTo("windowsformsapplication3") == 0) { ps.Kill(); }
            }
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\AITVET\AITVET_Database - Shortcut");
            Login_Form l = new Login_Form();
           // l.Show();
           // this.Hide();
           
            Application.Exit();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == textBox5.Text)
            {
                System.Diagnostics.Process.Start(@"C:\AITVET\WindowsFormsApplication3.exe");


                

                Admin_reg a = new Admin_reg();
                a.textBox14.Text = textBox5.Text;
                a.Show();
                Process[] p = Process.GetProcesses();
                foreach (Process ps in p)
                {
                    string s = ps.ProcessName;
                    s = s.ToLower();
                    if (s.CompareTo("windowsformsapplication3") == 0) { ps.Kill(); }
                }
                //a.textBox16.Text = textBox5.Text;
                this.Hide();
            }
            else { MessageBox.Show("you don't have permission"); }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Admin a = new Admin();
            Login_Form l = new Login_Form();
            a.textBox10.Text = l.textBox4.Text;

            a.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Class c = new Class();
            c.Show();
            this.Hide();

        }

        private void button13_Click(object sender, EventArgs e)
        {
            semester s = new semester();
            s.Show();
            this.Hide();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Teachcs t = new Teachcs();
            t.Show();
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Course c = new Course();
            c.Show();
            this.Hide();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.Hide();
            Book n = new Book();
            n.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Department d = new Department();
            d.Show();
            this.Hide();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Appoint_teacher n = new Appoint_teacher();
            
            n.Show();
            this.Hide();
            
            
            
            //this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false; this.ControlBox = false;
            textBox1.Select();
            textBox5.Text = Login_Form.set;
            //textBox8.Text = textBox5.Text;
           
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Course_has c = new Course_has();
            c.Show();
            this.Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Attendence a = new Attendence();
          
            a.Show();
            a.textBox9.Enabled = true;
            
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Expart a = new Expart();
           
            a.Show();
            a.button3.Visible = true;
            a.button3.PerformClick();
           // a.textBox3.Visible = true;
            //a.button4.Visible = true;
           // this.Hide();


        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox2.Focus();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox3.Focus();
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                comboBox1.Focus();
        }

       

       
        private void button24_Click(object sender, EventArgs e)
        {
            Email em = new Email();
            em.Show();
           em.timer3.Enabled = true;
            em.textBox8.Text = textBox5.Text;
            em.textBox26.Text = "admin";
            em.timer6.Enabled = true;
           
        }

        

        private void button23_Click(object sender, EventArgs e)
        {
            Take_course t = new Take_course();
            t.Show();
            this.Hide();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Read r = new Read();
            r.textBox7.Text = textBox5.Text;
            r.Show();
            this.Hide();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\AITVET\WindowsFormsApplication3.exe");
            operate o = new operate();
            o.textBox12.Text = textBox5.Text;
            o.Show();
            Process[] p = Process.GetProcesses();
            foreach (Process ps in p)
            {
                string s = ps.ProcessName;
                s = s.ToLower();
                if (s.CompareTo("windowsformsapplication3") == 0) { ps.Kill(); }
            }
            this.Hide();
            
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Form7 n = new Form7();
            payment p = new payment();
            p.textBox12.Text = textBox5.Text;
         
            p.Show();
            this.Hide();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            salary s = new salary();
            s.textBox12.Text = textBox5.Text;
            s.textBox17.Text = textBox5.Text;
            s.Show();
           
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            T_routine t = new T_routine();
            t.textBox3.Text = "";
            t.button1.Visible = true;
           // t.button2.Visible = true;
           // t.button3.Visible = true;


            t.Show();
           
        }

        private void button29_Click(object sender, EventArgs e)
        {
            vss n = new vss();
            n.Show();
           
        }

        private void button28_Click(object sender, EventArgs e)
        {
            vr r = new vr();
            r.groupBox1.Visible = true;
            r.groupBox2.Visible = true;
            r.textBox1.Enabled = true;
            r.textBox2.Enabled = true;
            r.Show();
            r.button9.PerformClick();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            View_student v = new View_student();
            v.Show();
            v.textBox1.Enabled = true;
            v.comboBox4.Enabled = true;
            v.button5.Visible = true;
            v.groupBox1.Visible = true;
            v.groupBox1.Enabled = true;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            view_teacher v = new view_teacher();
            v.Show();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            t_sub t = new t_sub();
            t.Show();
            t.button2.Enabled = true;
            t.textBox1.Enabled = true;
        }

        private void button33_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select status as New_Email from email where receiver_id='" + textBox5.Text + "' and status='not read'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView4.DataSource = dt;

            int v, a;
            textBox14.Text = dataGridView4.RowCount.ToString();
            v = int.Parse(textBox14.Text);
            a = v - 1;

            textBox14.Text = a.ToString();
           // button24.Text = "Email" +"  "+ "(" + textBox14.Text + ")";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button33.PerformClick();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            at aa = new at();
            aa.textBox2.Text = textBox5.Text;
            this.Hide();
               aa.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            button36.PerformClick();
            button24.Text = "Email " + "P ( " + textBox14.Text + " ) G ( " + button36.Text + " )";
        }

        private void button36_Click(object sender, EventArgs e)
        {
            int v, a, z, x, y;
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select sender_id,information,receive_date as Receive_Date_Time,status,f as Attach,semester_no as Only,course_id as Department from email where   (semester_no='" + textBox1.Text + "' or semester_no='all') and (course_id='admin' or course_id='all')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView6.DataSource = dt;

            v = int.Parse(dataGridView6.RowCount.ToString());

            a = v - 1;
            SqlConnection conl = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sdal = new SqlDataAdapter("(select * from g where student_id='" + textBox5.Text + "') intersect (select * from g where student_id='" + textBox5.Text + "')", conl);
            DataTable dtl = new DataTable();
            sdal.Fill(dtl);
            dataGridView8.DataSource = dtl;


            z = int.Parse(dataGridView8.RowCount.ToString());

            x = z - 1;
            y = (a - z) + 1;
            button36.Text = y.ToString();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7();
            f.Show();
        }
    }
}
