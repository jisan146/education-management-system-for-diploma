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
    public partial class Read : Form
    {
        public Read()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {/////
           
            SqlConnection cont = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sdat = new SqlDataAdapter("(select max(semester_no) from reads where student_id='"+comboBox4.Text+"')", cont);
            DataTable dtt = new DataTable();
            sdat.Fill(dtt);
            dataGridView1.DataSource = dtt;
            DataGridViewRow row = this.dataGridView1.Rows[0];
            int t;
            t =int.Parse( row.Cells[0].Value.ToString());
            t = t + 1;
            comboBox2.Text = t.ToString();


            button6.PerformClick();
            if (textBox1.Text == "1" || textBox1.Text == "0")
            {
                button5.PerformClick();
                if (textBox6.Text == "1") { MessageBox.Show("semester already use"); }
                else
                {
                    SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                    SqlDataAdapter sda = new SqlDataAdapter("(select student_id,course_id,semester_no,student_type,admission_date,insert_by,update_time from reads where student_id='" + comboBox4.Text + "' and (student_type='Continue' or student_type='Re_admission'))", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    int v, a;
                    a = int.Parse(dataGridView1.RowCount.ToString());
                    v = a;
                    a = v - 1;

                    if (a == 1)
                    {/* MessageBox.Show("student already continue in other semeser");*/
                        int c;
                        c = int.Parse(comboBox2.Text);
                        if (c > 1)
                        {
                            c = c - 1;
                            SqlConnection con88 = new SqlConnection(Properties.Settings.Default._ConnectionString);
                            SqlDataAdapter sda88 = new SqlDataAdapter("Update reads set student_type='Pass' where student_id='" + comboBox4.Text + "' and (student_type='Continue' or student_type='Re_admission') and semester_no='" + c + "' ", con88);
                            DataTable dt88 = new DataTable();
                            sda88.Fill(dt88);
                            dataGridView1.DataSource = dt88;
                            button2.PerformClick();
                        }
                    }
                    else
                    {

                        /////
                        textBox2.Text = comboBox2.Text;
                        textBox3.Text = comboBox3.Text;
                        textBox5.Text = dateTimePicker1.Text;
                        label9.Visible = true;

                        Class1 dbaccess = new Class1();
                        dbaccess.Student_id = comboBox4.Text;
                        dbaccess.Semester_no = textBox2.Text;



                        dbaccess.Course_id = textBox3.Text;
                        dbaccess.Student_type = "Continue";
                        dbaccess.Admission_date ="Register Date"+ DateTime.Now.ToString(" MMM dd ,dddd, yyyy ");



                        if (dbaccess.DataSaveInRead())
                        {
                            /*          */
                            int c;
                            c = int.Parse(comboBox2.Text);
                            if (c > 1)
                            {
                                c = c - 1;
                                SqlConnection con88 = new SqlConnection(Properties.Settings.Default._ConnectionString);
                                SqlDataAdapter sda88 = new SqlDataAdapter("Update reads set student_type='Pass' where student_id='" + comboBox4.Text + "' and (student_type='Continue' or student_type='Re_admission') and semester_no='" + c + "' ", con88);
                                DataTable dt88 = new DataTable();
                                sda88.Fill(dt88);
                                dataGridView1.DataSource = dt88;
                            }

                            /*          */
                            Class1 d = new Class1();
                            d.Insert_By = DateTime.Now.ToString(" MMM dd ,dddd, yyyy hh:mm:ss tt ") + textBox7.Text;
                            d.Student_id = comboBox4.Text;
                            if (d.DataSaveInRead1()) { } else { }
                            // label9.Text = "submit suceessfull ";
                            MessageBox.Show("save successfull");
                            SqlConnection con22 = new SqlConnection(Properties.Settings.Default._ConnectionString);
                            SqlDataAdapter sda22 = new SqlDataAdapter("(select student_id,course_id,semester_no,student_type,admission_date,insert_by,update_time from reads where student_id='" + comboBox4.Text + "' and semester_no='" + comboBox2.Text + "')", con22);
                            DataTable dt22 = new DataTable();
                            sda22.Fill(dt22);
                            dataGridView1.DataSource = dt22;



                        }
                        else
                        {
                            label9.Text = "submit fail ";
                        }
                    }
                }
            }
            else { button4.PerformClick(); MessageBox.Show("insert wrong semester"); button4.PerformClick(); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4.Text = comboBox1.Text;
        }

        private void Read_Load(object sender, EventArgs e)
        {
            button4.PerformClick();
            // TODO: This line of code loads data into the 'aITVETDataSet49.student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.aITVETDataSet49.student);
            this.MaximizeBox = false; this.ControlBox = false;
            // TODO: This line of code loads data into the 'aITVETDataSet8.course' table. You can move, or remove it, as needed.
            this.courseTableAdapter.Fill(this.aITVETDataSet8.course);
            // TODO: This line of code loads data into the 'aITVETDataSet7.semester' table. You can move, or remove it, as needed.
            this.semesterTableAdapter.Fill(this.aITVETDataSet7.semester);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection cont = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sdat = new SqlDataAdapter("(select max(semester_no) from reads where student_id='" + comboBox4.Text + "')", cont);
            DataTable dtt = new DataTable();
            sdat.Fill(dtt);
            dataGridView1.DataSource = dtt;
            DataGridViewRow row = this.dataGridView1.Rows[0];
            int t;
            t = int.Parse(row.Cells[0].Value.ToString());
            
            comboBox2.Text = t.ToString();
            DialogResult dialogResult = MessageBox.Show("After update you can not change this data.Update this item", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)

            //do something


            {

                Class1 dbaccess1 = new Class1();
                dbaccess1.Student_type = "Re_admission";
                dbaccess1.Student_id = comboBox4.Text;
                dbaccess1.Semester_no = comboBox2.Text;
                dbaccess1.Course_id = comboBox3.Text;


                if (dbaccess1.upinread())
                {
                    MessageBox.Show("Update successfull");
                    ///
                    SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                    SqlDataAdapter sda = new SqlDataAdapter("update reads set Update_Time='" + DateTime.Now.ToString(" MMM dd ,dddd, yyyy hh:mm:ss tt ") + textBox7.Text + "'  where student_id='" + comboBox4.Text + "' and semester_no='" + comboBox2.Text + "' and student_type='" + comboBox1.Text + "'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    /// 
                    ////
                    SqlConnection con22 = new SqlConnection(Properties.Settings.Default._ConnectionString);
                    SqlDataAdapter sda22 = new SqlDataAdapter("(select student_id,course_id,semester_no,student_type,admission_date,insert_by,update_time from reads where student_id='" + comboBox4.Text + "' and semester_no='" + comboBox2.Text + "')", con22);
                    DataTable dt22 = new DataTable();
                    sda22.Fill(dt22);
                    dataGridView1.DataSource = dt22;
                    ////

                }
                else
                {
                    label9.Visible = true;
                    label9.Text = "update fail";
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("(select student_id,course_id,semester_no,student_type,admission_date,insert_by,update_time from reads)", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("(select student_id,course_id,semester_no,student_type,admission_date,insert_by,update_time from reads where student_id='" + comboBox4.Text + "' and semester_no='" + comboBox2.Text + "')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            int v, a;
            a = int.Parse(dataGridView1.RowCount.ToString());
            v = a;
            a = v - 1;
            textBox6.Text = a.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("(select MAX(semester_no) from reads where student_id='" + comboBox4.Text + "')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            DataGridViewRow row = this.dataGridView1.Rows[0];
            textBox1.Text = row.Cells[0].Value.ToString();
            int a, b, c;
            a = int.Parse(textBox1.Text);
            b = int.Parse(comboBox2.Text);
            c = b - a;
            textBox1.Text = c.ToString();


        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("(select course_id from take_course where student_id='" + comboBox4.Text + "')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            DataGridViewRow row = this.dataGridView1.Rows[0];
            comboBox3.Text = row.Cells[0].Value.ToString();
            button7.PerformClick();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("(select student_id,course_id,semester_no,student_type,admission_date,insert_by,update_time from reads where student_id='" + comboBox4.Text + "')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            comboBox3.Enabled = true;
            MessageBox.Show("only possible when student reads in first semester");

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Enabled != false)
            {
                comboBox3.Enabled = false;
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("(select course_id from reads where student_id='" + comboBox4.Text + "' and student_type='Continue' and semester_no='1')", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                int a;
                a = int.Parse(dataGridView1.RowCount.ToString());
                a = a - 1;
                button5.Text = a.ToString();
                if (a == 1)
                {
                    button9.PerformClick();
                    button10.PerformClick();

                    comboBox3.Enabled = false;
                }
                else { MessageBox.Show("Not possible. Beacuse this student already pass first semester."); button4.PerformClick(); comboBox3.Enabled = false; }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("update take_course set course_id='" + comboBox3.Text + "' where student_id='" + comboBox4.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            SqlConnection con1 = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda1 = new SqlDataAdapter("update reads set course_id='" + comboBox3.Text + "',Update_Time='" + DateTime.Now.ToString(" MMM dd ,dddd, yyyy hh:mm:ss tt ") + textBox7.Text + "' where student_id='" + comboBox4.Text + "' and semester_no='1'", con1);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            //


        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlConnection con11 = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda11 = new SqlDataAdapter("(select student_id,course_id,semester_no,student_type,admission_date,insert_by,update_time from reads where student_id='" + comboBox4.Text + "'  and course_id='" + comboBox3.Text + "' )", con11);
            DataTable dt11 = new DataTable();
            sda11.Fill(dt11);
            dataGridView1.DataSource = dt11;
        }
    }
}
