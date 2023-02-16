using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AITVET_Database
{
    public partial class payment : Form
    {
        int aa, bb;
        public payment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           


            Class1 dbaccess = new Class1();
            dbaccess.Course_id = textBox1.Text;
            dbaccess.Course_name= textBox2.Text;
            dbaccess.Course_credit = textBox3.Text;
            dbaccess.Course_fees = textBox4.Text;
            dbaccess.Sit = textBox5.Text;

            if (dbaccess.QueryInCourse())
            {
                textBox1.Text = dbaccess.Course_id;
                textBox2.Text = dbaccess.Course_name;
                textBox3.Text = dbaccess.Course_credit;
                textBox4.Text = dbaccess.Course_fees;
                textBox5.Text = dbaccess.Sit;
                label7.Visible = true;
                label7.Text = "query suceess";
                button2.Visible = true;              
            }
            else
            {
                label7.Visible = true;
                label7.Text = "query Fail";               
            }        
         
          
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 n = new Form1();
            n.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            /*if (textBox9.Text != "") { 
            int value1, value2, v, result = 0;
            value1 = int.Parse(textBox10.Text);
            value2 = int.Parse(textBox9.Text);
            v = int.Parse(textBox18.Text);
            result = v - (value1 + value2);
            textBox18.Text = result.ToString(); }*/
            textBox11.Text = DateTime.Now.ToString("MMM dd ,dddd, yyyy hh:mm:ss tt");
            if (textBox9.Text == "") { textBox9.Text = "00"; }

            /* if (textBox18.Text == "")
             {
                 int value11, value22, result3 = 0;
                 value11 = int.Parse(textBox4.Text);
                 value22 = int.Parse(textBox9.Text);
                 result3 = value11 - value22;
                 textBox18.Text = result3.ToString();
             }*/

            Class1 dbaccess = new Class1();
            dbaccess.Admin_id = textBox12.Text;
            dbaccess.Student_id = comboBox1.Text;
            dbaccess.Course_id = textBox1.Text;
            dbaccess.Pay = textBox9.Text;
            dbaccess.Due = textBox18.Text;
            dbaccess.Payment_date = textBox11.Text;
            dbaccess.Exam_fee = textBox14.Text;
            dbaccess.Fine = textBox13.Text;
            dbaccess.Semester_no = comboBox2.Text;
            dbaccess.Comment = comboBox4.Text;




            if (dbaccess.DataSaveInPay())
            {
                // label7.Visible = true;
                // label7.Text = "submit suceessfull ";
                MessageBox.Show("save successfull");

                if (textBox16.Text == "Re_admission")
                {
                    /**/
                    SqlConnection con12 = new SqlConnection(Properties.Settings.Default._ConnectionString);
                    SqlDataAdapter sda12 = new SqlDataAdapter("select *from reads where  student_id='" + comboBox1.Text + "'   and student_type='Pass' and semester_no='" + comboBox2.Text + "' ", con12);
                    DataTable dt12 = new DataTable();
                    sda12.Fill(dt12);
                    dataGridView1.DataSource = dt12;
                    int v, a;
                    a = int.Parse(dataGridView1.RowCount.ToString());
                    a = a - 1;
                    if (a == 0) { 



                    /**/

                    SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                    SqlDataAdapter sda = new SqlDataAdapter("Update reads set student_type='Re_admission' where student_id='" + comboBox1.Text + "'  and semester_no='" + comboBox2.Text + "' ", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                } else { 
                /*                             */
                int a, b;
                a = int.Parse(textBox9.Text);
                b = int.Parse(comboBox2.Text);
                if (b == 1 && a > 0)
                {

                    SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                    SqlDataAdapter sda = new SqlDataAdapter("Update reads set admission_date='" + DateTime.Now.ToString("MMM dd ,dddd, yyyy") + "' where student_id='" + comboBox1.Text + "' and student_type='Continue' and semester_no='1' ", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }

                int c;
                c = int.Parse(comboBox2.Text);
                if (c > 1)
                {
                    c = c - 1;
                    SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                    SqlDataAdapter sda = new SqlDataAdapter("Update reads set student_type='Pass' where student_id='" + comboBox1.Text + "' and (student_type='Continue' or student_type='Re_admission') and semester_no='" + c + "' ", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    //
                    SqlConnection con1 = new SqlConnection(Properties.Settings.Default._ConnectionString);
                    SqlDataAdapter sda1 = new SqlDataAdapter("(select *from reads where student_id='" + comboBox1.Text + "' and student_type='Continue' )", con1);
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);
                    dataGridView2.DataSource = dt1;
                    int v, aa;
                    aa = int.Parse(dataGridView2.RowCount.ToString());
                    v = aa;
                    aa = v - 1;

                        if (aa == 1) { }
                        else
                        {
                            /*  int a, b;
                a = int.Parse(textBox9.Text);
                b = int.Parse(comboBox2.Text);
                if (b == 1 && a > 0)
                {

                    SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                    SqlDataAdapter sda = new SqlDataAdapter("Update reads set admission_date='" + DateTime.Now.ToString("MMM dd ,dddd, yyyy") + "' where student_id='" + comboBox1.Text + "' and student_type='Continue' and semester_no='1' ", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }*/
                            /////
                            SqlConnection cona = new SqlConnection(Properties.Settings.Default._ConnectionString);
                            SqlDataAdapter sdaa = new SqlDataAdapter("select max(semester_no) from reads where student_id='" + comboBox1.Text + "' ", cona);
                            DataTable dta = new DataTable();
                            sdaa.Fill(dta);
                            dataGridView1.DataSource = dta;
                            DataGridViewRow row = this.dataGridView1.Rows[0];
                            int z, x;
                            x = int.Parse(row.Cells[0].Value.ToString());
                            x = x + 1;
                            z = int.Parse(comboBox2.Text);
                            if (x == z)
                            {
                                int r;
                                r = int.Parse(textBox9.Text);
                                if (r > 0) { 

                                Class1 dbaccess1 = new Class1();
                                dbaccess1.Student_id = comboBox1.Text;
                                dbaccess1.Semester_no = comboBox2.Text;



                                dbaccess1.Course_id = textBox1.Text;
                                dbaccess1.Student_type = "Continue";
                                dbaccess1.Admission_date = DateTime.Now.ToString(" MMM dd ,dddd, yyyy ");
                                if (dbaccess1.DataSaveInRead()) { } else { }
                            }
                        }
                        //


                    }

                    /*                             */


                }
                else
                {

                }
            }
                /*SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("select student_id,admin_id,course_id,semester_no,pay as Payment,exam_fee,fine,payment_date,comment from payment", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;*/
                SqlConnection con66 = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda66 = new SqlDataAdapter("select student_id,admin_id,course_id,semester_no,pay as Payment,exam_fee,fine,payment_date,comment from payment where student_id='"+comboBox1.Text+"' and payment_date='"+textBox11.Text+"'", con66);
                DataTable dt66 = new DataTable();
                sda66.Fill(dt66);
                dataGridView1.DataSource = dt66;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            button2.Visible = false;
            button1.Visible = true;

        }

        private void textBox9_Click(object sender, EventArgs e)
        {
            textBox9.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox9.Text = "paid";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox14.Text = "paid";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select student_id,admin_id,course_id,semester_no,pay as Payment,exam_fee,fine,payment_date,comment from payment", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select student_id,admin_id,course_id,semester_no,pay as Payment,exam_fee,fine,payment_date,comment from payment where student_id='"+textBox17.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void payment_Load(object sender, EventArgs e)
        {
            button8.PerformClick();
            // TODO: This line of code loads data into the 'aITVETDataSet63.course' table. You can move, or remove it, as needed.
            this.courseTableAdapter.Fill(this.aITVETDataSet63.course);
            // TODO: This line of code loads data into the 'aITVETDataSet62.semester' table. You can move, or remove it, as needed.
            this.semesterTableAdapter.Fill(this.aITVETDataSet62.semester);
            // TODO: This line of code loads data into the 'aITVETDataSet61.student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.aITVETDataSet61.student);
            this.MaximizeBox = false; this.ControlBox = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {

            Class1 dbaccess = new Class1();
            dbaccess.Course_id = textBox22.Text;
            dbaccess.Course_name = textBox2.Text;
            dbaccess.Course_credit = textBox3.Text;
            dbaccess.Course_fees = textBox4.Text;
            dbaccess.Sit = textBox5.Text;

            if (dbaccess.QueryInCourse())
            {
                textBox1.Text = dbaccess.Course_id;
                textBox2.Text = dbaccess.Course_name;
                textBox3.Text = dbaccess.Course_credit;
                textBox4.Text = dbaccess.Course_fees;
                textBox5.Text = dbaccess.Sit;
              //  label7.Visible = true;
               // label7.Text = "query suceess";
                button2.Visible = true;
            }
            else
            {
                //label7.Visible = true;
                //label7.Text = "query Fail";
            }

            Class1 dbaccess1 = new Class1();
            dbaccess1.Student_id = textBox19.Text;
           

            if (dbaccess1.QueryInPayment())
            {
                textBox10.Text = dbaccess1.Pay;
            
               // label7.Text = "query suceess";
                button2.Visible = true;
                // button1.Visible = false;
            }
            else
            {
               // label7.Visible = true;
               // label7.Text = "query Fail";
                // textBox4.Text = textBox1.Text; 
            }



            if (textBox10.Text == "") { textBox10.Text = "0"; }
            if (textBox4.Text != "")
            {
                int value11, value22, result3 = 0;
                value11 = int.Parse(textBox4.Text);
                value22 = int.Parse(textBox10.Text);
                result3 = value11 - value22;
                textBox18.Text = result3.ToString();
            }
            

           
            
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
        }

        private void button11_Click(object sender, EventArgs e)
        {

            Class1 dbaccess = new Class1();
            dbaccess.Course_id = textBox1.Text;
            dbaccess.Course_name = textBox2.Text;
            dbaccess.Course_credit = textBox3.Text;
            dbaccess.Course_fees = textBox4.Text;
            dbaccess.Sit = textBox5.Text;

            if (dbaccess.QueryInCourse())
            {
                textBox1.Text = dbaccess.Course_id;
                textBox2.Text = dbaccess.Course_name;
                textBox3.Text = dbaccess.Course_credit;
                textBox4.Text = dbaccess.Course_fees;
                textBox5.Text = dbaccess.Sit;
                label7.Visible = true;
                label7.Text = "query suceess";
                button2.Visible = true;
            }
            else
            {
                label7.Visible = true;
                label7.Text = "query Fail";
            }

            Class1 dbaccess1 = new Class1();
            dbaccess1.Student_id = textBox6.Text;


            if (dbaccess1.QueryInPayment())
            {
                textBox10.Text = dbaccess1.Pay;

                label7.Text = "query suceess";
                button2.Visible = true;
                // button1.Visible = false;
            }
            else
            {
                label7.Visible = true;
                label7.Text = "query Fail";
                // textBox4.Text = textBox1.Text; 
            }



            if (textBox10.Text == "") { textBox10.Text = "0"; }
            if (textBox4.Text != "")
            {
                int value11, value22, result3 = 0;
                value11 = int.Parse(textBox4.Text);
                value22 = int.Parse(textBox10.Text);
                result3 = value11 - value22;
                textBox18.Text = result3.ToString();
            }




            /*  int value1, value2, v, result = 0;
              value1 = int.Parse(textBox10.Text);
              value2 = int.Parse(textBox9.Text);
              v = int.Parse(textBox18.Text);
              result = v - (value1 + value2);
              textBox10.Text = result.ToString();*/

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox19.Text = comboBox1.Text;
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select course_id from reads where student_id='" + comboBox1.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            
            
                DataGridViewRow row = this.dataGridView2.Rows[0];
                textBox1.Text = row.Cells[0].Value.ToString();
            
            textBox22.Text = textBox1.Text;
            button9.PerformClick();
            button300.PerformClick();
            button400.PerformClick();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox19.Text = comboBox1.Text;
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("select course_id from reads where student_id='" + comboBox1.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView2.DataSource = dt;
               
              
                
                    DataGridViewRow row = this.dataGridView2.Rows[0];
                    textBox1.Text = row.Cells[0].Value.ToString();
                
                textBox22.Text = textBox1.Text;
                button9.PerformClick();
                button300.PerformClick();
                button400.PerformClick();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox16.Text = "Re_admission";
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox16.Text = "Re_admission";
        }

        private void comboBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) textBox16.Text = "Re_admission";
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select student_id,admin_id,course_id,semester_no,pay as Payment,exam_fee,fine,payment_date,comment from payment where student_id='"+comboBox5.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void comboBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("select student_id,admin_id,course_id,semester_no,pay as Payment,exam_fee,fine,payment_date,comment from payment where student_id='" + comboBox5.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select student_id,admin_id,course_id,semester_no,pay as Payment,exam_fee,fine,payment_date,comment from payment where student_id='" + comboBox5.Text + "' and semester_no='"+comboBox6.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void comboBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("select student_id,admin_id,course_id,semester_no,pay as Payment,exam_fee,fine,payment_date,comment from payment where student_id='" + comboBox5.Text + "' and semester_no='" + comboBox6.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void button400_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select  sum(s)from percent1 where student_id='" + comboBox1.Text + "' and semester_no='" + textBox200.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView300.DataSource = dt;
            DataGridViewRow row = this.dataGridView300.Rows[0];
            textBox500.Text = row.Cells[0].Value.ToString();
            if (textBox500.Text != "")
            {
                aa = int.Parse(textBox500.Text);
                aa = aa / bb;
                textBox600.Text = aa.ToString() + "%";
            }
            else { textBox600.Clear(); }
        }

        private void button300_Click(object sender, EventArgs e)
        {
            Class1 dbaccess = new Class1();
            dbaccess.Student_id = comboBox1.Text;


            if (dbaccess.QueryInOp())
            {
                textBox200.Text = dbaccess.Semester_no;
                textBox300.Text = dbaccess.Course_id;

                //MessageBox.Show("sucess");
            }
            else
            {
                //MessageBox.Show("fail");
                // textBox4.Text = comboBox1.Text; 
            }
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select * from course_has where course_id='" + textBox300.Text + "' and semester_no='" + textBox200.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView200.DataSource = dt;
            bb = int.Parse(dataGridView200.RowCount.ToString());
            bb = bb - 1;
            textBox400.Text = bb.ToString();
        }
    }
}
