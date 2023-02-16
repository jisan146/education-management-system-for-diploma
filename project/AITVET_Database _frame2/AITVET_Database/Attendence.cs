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
    public partial class Attendence : Form
    {
        int pos; int late;
        public Attendence()
        {
            InitializeComponent();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            textBox9.Enabled = true;
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
            textBox6.Clear();

            textBox4.Text = textBox9.Text;
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select  reads.student_id,board_roll,student_name  from student,reads,teach where student.student_id=reads.student_id and reads.course_id=teach.course_id and teach.teacher_id='" + textBox4.Text + "' and (student_type='Continue' or student_type='Re_admission') and teach.course_id='" + comboBox2.Text + "' and teach.semester_no='" + comboBox3.Text + "' and book_id='"+comboBox6.Text+ "' and reads.semester_no=teach.semester_no", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            this.dataGridView1.Sort(this.dataGridView1.Columns["student_id"], ListSortDirection.Ascending);
            int v, a;
            textBox16.Text = dataGridView1.RowCount.ToString();
            v = int.Parse(textBox16.Text);
            a = v - 1;
            textBox16.Text = a.ToString();
           
            button10.PerformClick();
            button11.PerformClick();
            button7.PerformClick();
            button6.PerformClick();
            Class1 d = new Class1();
            d.Teacher_id = textBox4.Text;
            d.Course_id = comboBox2.Text;
            d.Semester_no = comboBox3.Text;
            d.Book_id = comboBox6.Text;
            d.Day = textBox25.Text;
            d.Class_type = comboBox1.Text;
            if (d.QueryInoo())
            {
                textBox5.Text= d.Start_time;
                 textBox6.Text= d.End_time;
                comboBox1.Text= d.Class_type;
                 textBox28.Text= d.Day;
                  textBox111.Text= d.S;
                 textBox222.Text= d.E;
                textBox666.Text = d.Sm;
                textBox555.Text = d.Em;
                textBox31.Text = d.S + d.Sm;

            }
            else { }
            if (textBox5.Text == "") { button21.Enabled = false; button1.Enabled = false; button4.Enabled = false; } else {button21.Enabled=true; button1.Enabled = true; button4.Enabled = true; }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label9.Visible = false;
            label9.BackColor = Color.WhiteSmoke;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox20.Text = row.Cells[2].Value.ToString();
                textBox11.Text = textBox1.Text;

                button7.PerformClick();
                button10.PerformClick();
                button11.PerformClick();
                button18.PerformClick();
                button9.PerformClick();
                button8.PerformClick();
                button12.PerformClick();
                button13.PerformClick();
                button23.PerformClick();
                button9.PerformClick();
                button25.PerformClick();

               

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {//////////
            int att, btt, ctt;
            att = int.Parse(DateTime.Now.ToString("ssmmss"));
            btt = int.Parse(DateTime.Now.ToString("ssssss"));
            ctt = (att + btt * btt);
            SqlConnection contt = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sdatt = new SqlDataAdapter("update temp set login_password='" + ctt.ToString() +"' where login_id='"+textBox9.Text+"'", contt);
            DataTable dttt = new DataTable();
            sdatt.Fill(dttt);
            textBox17.Text = DateTime.Now.ToString("MMM  dd ,dddd, yyyy");
            textBox30.Text= DateTime.Now.ToString("HHmm");
            int lt1, lt2;
            lt1 = int.Parse(textBox31.Text);
            lt2 = int.Parse(textBox30.Text);
            if (lt2 > lt1) { late = lt2 - lt1; } else { late = lt1 - lt2; }
            textBox29.Text = late.ToString();
           
            button20.PerformClick();
            if (pos == 1)
            { 
           
            if (textBox25.Text != textBox28.Text)  { MessageBox.Show("Only possible in class schedule "); }
                else
                {
                textBox7.Text = DateTime.Now.ToString("MMM  dd ,dddd, yyyy");
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("select attendence.student_id,status,class_date,attendence.book_id,class_type,start_time,end_time,attendence.teacher_id,Temp_Teacher_ID from student,attendence,reads where reads.student_id= attendence.student_id and attendence.student_id=student.student_id and attendence.teacher_id='" + textBox9.Text + "' and (student_type='Continue' or student_type='Re_admission') and book_id='" + comboBox7.Text + "' and attendence.student_id='" + textBox1.Text + "' and class_date='" + textBox7.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView2.DataSource = dt;
                this.dataGridView2.Sort(this.dataGridView2.Columns["class_date"], ListSortDirection.Descending);
                DataGridViewColumn column1 = dataGridView2.Columns[6];
                column1.Width = 140;
                DataGridViewColumn column2 = dataGridView2.Columns[7];
                column2.Width = 80;
                int v, a;
                textBox18.Text = dataGridView2.RowCount.ToString();
                v = int.Parse(textBox18.Text);
                a = v - 1;

                textBox18.Text = a.ToString();
                ///////





                textBox8.Text = "p";
                textBox3.Text = comboBox1.Text;
                    // textBox5.Text = DateTime.Now.ToString("HH:mm:ss tt");

                    if (late>=10) { textBox8.Text = "Late "+late+" mins & Join time "+ DateTime.Now.ToString(" hh:mm:ss tt"); }
                if (a ==0)
                {

                    label9.Visible = true;

                    Class1 dbaccess = new Class1();
                    dbaccess.Student_id = textBox1.Text;
                    dbaccess.Book_id = comboBox6.Text;
                    dbaccess.Class_type = textBox3.Text;
                    dbaccess.Teacher_id = textBox4.Text;
                    dbaccess.Start_time = textBox5.Text;
                    dbaccess.End_time = textBox6.Text;
                    dbaccess.Class_date = textBox7.Text;
                    dbaccess.Status = textBox8.Text;
                        dbaccess.Temp_Teacher_ID = textBox35.Text;






                    if (dbaccess.DataSaveInA())
                    {

                        label9.Text = "submit suceessfull ";
                        label9.BackColor = Color.Green;

                    }
                    else
                    {
                        label9.Text = "submit fail ";
                        label9.BackColor = Color.Red;
                    }
                }
                else
                {
                    label9.Visible = true;
                    label9.Text = "not possible";
                    label9.BackColor = Color.Yellow;
                }
                button7.PerformClick();
                button10.PerformClick();
                button11.PerformClick();
                button18.PerformClick();
                button9.PerformClick();
                button8.PerformClick();
                button12.PerformClick();
                button13.PerformClick();
                button9.PerformClick();
            }
           
        }
    }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int att, btt, ctt;
            att = int.Parse(DateTime.Now.ToString("ssmmss"));
            btt = int.Parse(DateTime.Now.ToString("ssssss"));
            ctt = (att + btt * btt);
            SqlConnection contt = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sdatt = new SqlDataAdapter("update temp set login_password='" + ctt.ToString() + "' where login_id='" + textBox9.Text + "'", contt);
            DataTable dttt = new DataTable();
            sdatt.Fill(dttt);
            textBox30.Text = DateTime.Now.ToString("HHmm");
            int lt1, lt2;
            lt1 = int.Parse(textBox31.Text);
            lt2 = int.Parse(textBox30.Text);
            if (lt2 > lt1) { late = lt2 - lt1; } else { late = lt1 - lt2; }
            button20.PerformClick();
            if (pos == 1) { 
           
            if (textBox25.Text == textBox28.Text)
            {
                textBox7.Text = DateTime.Now.ToString("MMM  dd ,dddd, yyyy");
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("select attendence.student_id,status,class_date,attendence.book_id,class_type,start_time,end_time,attendence.teacher_id,Temp_Teacher_ID from student,attendence,reads where reads.student_id= attendence.student_id and attendence.student_id=student.student_id and attendence.teacher_id='" + textBox9.Text + "' and (student_type='Continue' or student_type='Re_admission') and book_id='" + comboBox7.Text + "' and attendence.student_id='" + textBox1.Text + "' and class_date='" + textBox7.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView2.DataSource = dt;
                this.dataGridView2.Sort(this.dataGridView2.Columns["class_date"], ListSortDirection.Descending);
                DataGridViewColumn column1 = dataGridView2.Columns[6];
                column1.Width = 140;
                DataGridViewColumn column2 = dataGridView2.Columns[7];
                column2.Width = 80;
                int v, a;
                textBox18.Text = dataGridView2.RowCount.ToString();
                v = int.Parse(textBox18.Text);
                a = v - 1;

                textBox18.Text = a.ToString();




                textBox8.Text = "A";
                textBox3.Text = comboBox1.Text;
                    // textBox5.Text = DateTime.Now.ToString("HH:mm:ss tt");
                    textBox7.Text = DateTime.Now.ToString("MMM  dd ,dddd, yyyy");

                    if (a == 0)
                {

                    label9.Visible = true;

                    Class1 dbaccess = new Class1();
                    dbaccess.Student_id = textBox1.Text;
                    dbaccess.Book_id = comboBox6.Text;
                    dbaccess.Class_type = textBox3.Text;
                    dbaccess.Teacher_id = textBox4.Text;
                    dbaccess.Start_time = textBox5.Text;
                    dbaccess.End_time = textBox6.Text;
                    dbaccess.Class_date = textBox7.Text;
                    dbaccess.Status = textBox8.Text;
                        dbaccess.Temp_Teacher_ID = textBox35.Text;






                        if (dbaccess.DataSaveInA())
                    {

                        label9.Text = "submit suceessfull ";
                        label9.BackColor = Color.Maroon;

                    }
                    else
                    {
                        label9.Text = "submit fail ";
                        label9.BackColor = Color.Red;
                    }
                }
                else
                {
                    label9.Visible = true;
                    label9.Text = "not possible";
                    label9.BackColor = Color.Yellow;
                }
                button7.PerformClick();
                button10.PerformClick();
                button11.PerformClick();
                button18.PerformClick();
                button9.PerformClick();
                button8.PerformClick();
                button12.PerformClick();
                button13.PerformClick();
                button9.PerformClick();
            }
            else { MessageBox.Show("Only possible in class schedule"); }

        }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select attendence.student_id,status,class_date,attendence.book_id,class_type,start_time,end_time,attendence.teacher_id,Temp_Teacher_ID from student,attendence,reads where reads.student_id= attendence.student_id and attendence.student_id=student.student_id and attendence.teacher_id='" + textBox9.Text + "' and (student_type='Continue' or student_type='Re_admission')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            this.dataGridView2.Sort(this.dataGridView2.Columns["class_date"], ListSortDirection.Ascending);
            DataGridViewColumn column1 = dataGridView2.Columns[6];
            column1.Width = 140;
           // DataGridViewColumn column2 = dataGridView2.Columns[7];
            //column2.Width = 25;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select attendence.student_id,status,class_date,attendence.book_id,class_type,start_time,end_time,attendence.teacher_id,Temp_Teacher_ID from student,attendence,reads where reads.student_id= attendence.student_id and attendence.student_id=student.student_id and attendence.teacher_id='" + textBox9.Text + "' and (student_type='Continue' or student_type='Re_admission') and book_id='" + comboBox7.Text + " 'and reads.course_id='" + comboBox5.Text + "' and reads.semester_no='" + comboBox4.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            this.dataGridView2.Sort(this.dataGridView2.Columns["class_date"], ListSortDirection.Descending);
            DataGridViewColumn column1 = dataGridView2.Columns[6];
            column1.Width = 140;
            DataGridViewColumn column2 = dataGridView2.Columns[7];
            column2.Width = 80;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("(select class_date as All_Class_Date from student,attendence,reads where reads.student_id= attendence.student_id and attendence.student_id=student.student_id and attendence.teacher_id='" + textBox9.Text + "' and (student_type='Continue' or student_type='Re_admission') and book_id='" + comboBox7.Text + " 'and reads.course_id='" + comboBox5.Text + "' and reads.semester_no='" + comboBox4.Text + "') intersect(select class_date from student,attendence,reads  where reads.student_id= attendence.student_id and attendence.student_id=student.student_id and attendence.teacher_id='" + textBox9.Text + "' and (student_type='Continue' or student_type='Re_admission') and book_id='" + comboBox7.Text + " 'and reads.course_id='" + comboBox5.Text + "' and reads.semester_no='" + comboBox4.Text + "')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            int v, a;
            textBox13.Text = dataGridView2.RowCount.ToString();
            v = int.Parse(textBox13.Text);
            a = v - 1;

            textBox13.Text = a.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button10.PerformClick();
            button11.PerformClick();
            button7.PerformClick();
            button6.PerformClick();
            button18.PerformClick();
            button8.PerformClick();
            button12.PerformClick();
            button13.PerformClick();

            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select attendence.student_id,status,class_date,attendence.book_id,class_type,start_time,end_time,attendence.teacher_id,Temp_Teacher_ID from student,attendence,reads where reads.student_id= attendence.student_id and attendence.student_id=student.student_id and attendence.teacher_id='" + textBox9.Text + "' and (student_type='Continue' or student_type='Re_admission') and book_id='" + comboBox7.Text + "' and attendence.student_id='" + textBox11.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            this.dataGridView2.Sort(this.dataGridView2.Columns["class_date"], ListSortDirection.Descending);
            DataGridViewColumn column1 = dataGridView2.Columns[6];
            column1.Width = 140;
            DataGridViewColumn column2 = dataGridView2.Columns[7];
            column2.Width = 80;

          

        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select attendence.student_id,status,class_date,attendence.book_id,class_type,start_time,end_time,attendence.teacher_id,Temp_Teacher_ID from student,attendence,reads where reads.student_id= attendence.student_id and attendence.student_id=student.student_id and attendence.teacher_id='" + textBox9.Text + "' and (student_type='Continue' or student_type='Re_admission') and book_id='" + comboBox7.Text + "' and attendence.student_id='" + textBox11.Text + "' and status='p'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            int v, a;
            textBox22.Text = dataGridView2.RowCount.ToString();
            v = int.Parse(textBox22.Text);
            a = v - 1;

            textBox22.Text = a.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("(select class_date as All_Theory_Class_Date from student,attendence,reads where reads.student_id= attendence.student_id and attendence.student_id=student.student_id and attendence.teacher_id='" + textBox9.Text + "' and (student_type='Continue' or student_type='Re_admission') and book_id='" + comboBox7.Text + "'and reads.course_id='" + comboBox5.Text + "' and reads.semester_no='" + comboBox4.Text + "' and class_type='Theory') intersect(select class_date from student,attendence,reads  where reads.student_id= attendence.student_id and attendence.student_id=student.student_id and attendence.teacher_id='" + textBox9.Text + "' and (student_type='Continue' or student_type='Re_admission') and book_id='" + comboBox7.Text + "'and reads.course_id='" + comboBox5.Text + "' and reads.semester_no='" + comboBox4.Text + "'and class_type='Theory')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            int v, a;
            textBox14.Text = dataGridView2.RowCount.ToString();
            v = int.Parse(textBox14.Text);
            a = v - 1;

            textBox14.Text = a.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("(select class_date as All_Lab_Class_Date from student,attendence,reads where reads.student_id= attendence.student_id and attendence.student_id=student.student_id and attendence.teacher_id='" + textBox9.Text + "' and (student_type='Continue' or student_type='Re_admission') and book_id='" + comboBox7.Text + "'and reads.course_id='" + comboBox5.Text + "' and reads.semester_no='" + comboBox4.Text + "' and class_type='Lab') intersect(select class_date from student,attendence,reads  where reads.student_id= attendence.student_id and attendence.student_id=student.student_id and attendence.teacher_id='" + textBox9.Text + "' and (student_type='Continue' or student_type='Re_admission') and book_id='" + comboBox7.Text + "'and reads.course_id='" + comboBox5.Text + "' and reads.semester_no='" + comboBox4.Text + "'and class_type='Lab')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            int v, a;
            textBox15.Text = dataGridView2.RowCount.ToString();
            v = int.Parse(textBox15.Text);
            a = v - 1;

            textBox15.Text = a.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select attendence.student_id,status,class_date,attendence.book_id,class_type,start_time,end_time,attendence.teacher_id,Temp_Teacher_ID from student,attendence,reads where reads.student_id= attendence.student_id and attendence.student_id=student.student_id and attendence.teacher_id='" + textBox9.Text + "' and (student_type='Continue' or student_type='Re_admission') and book_id='" + comboBox7.Text + "' and attendence.student_id='" + textBox11.Text + "' and status='p' and class_type='Theory'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            int v, a;
            textBox23.Text = dataGridView2.RowCount.ToString();
            v = int.Parse(textBox23.Text);
            a = v - 1;

            textBox23.Text = a.ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select attendence.student_id,status,class_date,attendence.book_id,class_type,start_time,end_time,attendence.teacher_id,Temp_Teacher_ID from student,attendence,reads where reads.student_id= attendence.student_id and attendence.student_id=student.student_id and attendence.teacher_id='" + textBox9.Text + "' and (student_type='Continue' or student_type='Re_admission') and book_id='" + comboBox7.Text + "' and attendence.student_id='" + textBox11.Text + "' and status='p' and class_type='Lab'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            int v, a;
            textBox24.Text = dataGridView2.RowCount.ToString();
            v = int.Parse(textBox24.Text);
            a = v - 1;

            textBox24.Text = a.ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select  reads.student_id,board_roll,student_name  from student,reads,teach where student.student_id=reads.student_id and reads.course_id=teach.course_id and teach.teacher_id='" + textBox4.Text + "' and (student_type='Continue' or student_type='Re_admission') and teach.course_id='" + comboBox2.Text + "' and reads.semester_no='" + comboBox3.Text + "' and book_id='" + comboBox6.Text + "' and reads.student_id='"+textBox12.Text+ "' and reads.semester_no=teach.semester_no", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            this.dataGridView1.Sort(this.dataGridView1.Columns["student_id"], ListSortDirection.Ascending);
        }

        private void Attendence_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false; this.ControlBox = false;
            // TODO: This line of code loads data into the 'aITVETDataSet19.book' table. You can move, or remove it, as needed.
            this.bookTableAdapter.Fill(this.aITVETDataSet19.book);
            // TODO: This line of code loads data into the 'aITVETDataSet17.semester' table. You can move, or remove it, as needed.
            this.semesterTableAdapter.Fill(this.aITVETDataSet17.semester);
            // TODO: This line of code loads data into the 'aITVETDataSet16.course' table. You can move, or remove it, as needed.
            this.courseTableAdapter.Fill(this.aITVETDataSet16.course);
            textBox25.Text = DateTime.Now.ToString("dddd");
            button5.PerformClick();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select attendence.student_id,status,class_date,attendence.book_id,class_type,start_time,end_time,attendence.teacher_id,Temp_Teacher_ID from student,attendence,reads where reads.student_id= attendence.student_id and attendence.student_id=student.student_id and attendence.teacher_id='" + textBox9.Text + "' and (student_type='Continue' or student_type='Re_admission') and book_id='" + comboBox7.Text + " 'and reads.course_id='" + comboBox5.Text + "' and reads.semester_no='" + comboBox4.Text + "' and class_date='"+textBox17.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            this.dataGridView2.Sort(this.dataGridView2.Columns["status"], ListSortDirection.Descending);

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox7_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select  reads.student_id,board_roll from student,reads,teach where student.student_id=reads.student_id and reads.course_id=teach.course_id and teach.teacher_id='" + textBox4.Text + "' and (student_type='Continue' or student_type='Re_admission') and teach.course_id='" + comboBox2.Text + "' and teach.semester_no='" + comboBox3.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            int v, a;
            textBox16.Text = dataGridView1.RowCount.ToString();
            v = int.Parse(textBox16.Text);
            a = v -1;
            textBox16.Text = a.ToString();
        }

        private void button17_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select count(status)as Total_present_student from student,attendence,reads where reads.student_id= attendence.student_id and attendence.student_id=student.student_id and attendence.teacher_id='" + textBox9.Text + "' and (student_type='Continue' or student_type='Re_admission') and book_id='" + comboBox7.Text + " 'and reads.course_id='" + comboBox5.Text + "' and reads.semester_no='" + comboBox4.Text + "' and class_date='" + textBox17.Text + "' and status='p'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;

        }

        private void button18_Click(object sender, EventArgs e)
        {
            button10.PerformClick();
            button11.PerformClick();
            button7.PerformClick();
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select attendence.student_id,status,class_date,attendence.book_id,class_type,start_time,end_time,attendence.teacher_id,Temp_Teacher_ID from student,attendence,reads where reads.student_id= attendence.student_id and attendence.student_id=student.student_id and attendence.teacher_id='" + textBox9.Text + "' and (student_type='Continue' or student_type='Re_admission') and book_id='" + comboBox7.Text + "' and status='p'  and attendence.student_id='" + textBox11.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            this.dataGridView2.Sort(this.dataGridView2.Columns["class_date"], ListSortDirection.Descending);
            DataGridViewColumn column1 = dataGridView2.Columns[6];
            column1.Width = 140;
            DataGridViewColumn column2 = dataGridView2.Columns[7];
            column2.Width = 80;
            int v, a;
            textBox19.Text = dataGridView2.RowCount.ToString();
            v = int.Parse(textBox19.Text);
            a = v -1;
            textBox19.Text = a.ToString();

            if (textBox13.Text != "" && textBox13.Text!="0" || textBox19.Text != "" && textBox19.Text != "0")
            {
                float t, p, per;
                t = float.Parse(textBox13.Text);
                p = float.Parse(textBox19.Text);
                per = (p / t) *100;
                textBox19.Text = per.ToString() ;
            }
            else { textBox19.Text = ""; }



        }

        private void button19_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select  reads.student_id,board_roll from student,reads,teach where student.student_id=reads.student_id and reads.course_id=teach.course_id and teach.teacher_id='" + textBox4.Text + "' and (student_type='Continue' or student_type='Re_admission') and teach.course_id='" + comboBox2.Text + "' and teach.semester_no='" + comboBox3.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            this.dataGridView1.Sort(this.dataGridView1.Columns["student_id"], ListSortDirection.Ascending);
            int v, a;
            textBox16.Text = dataGridView1.RowCount.ToString();
            v = int.Parse(textBox16.Text);
            a = v - 1;
            textBox16.Text = a.ToString();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Class1 d = new Class1();
            d.Teacher_id = textBox4.Text;
            d.Course_id = comboBox2.Text;
            d.Semester_no = comboBox3.Text;
            d.Book_id = comboBox6.Text;
            d.Day = textBox25.Text;
            d.Class_type = comboBox1.Text;
            if (d.QueryInoo())
            {
                textBox5.Text = d.Start_time;
                textBox6.Text = d.End_time;
                comboBox1.Text = d.Class_type;
                textBox28.Text= d.Day;
                textBox111.Text = d.S;
                textBox222.Text = d.E;
                textBox666.Text = d.Sm;
                textBox555.Text = d.Em;
             
                

            }
            else { }
            if (textBox5.Text != "") {
                

            textBox333.Text = DateTime.Now.ToString("HH");
            textBox444.Text = DateTime.Now.ToString("mm");
               
               
                int ddd, eee;
            int aaa, bbb, ccc;

            aaa = int.Parse(textBox111.Text);
            bbb = int.Parse(textBox222.Text);
            ccc = int.Parse(textBox333.Text);
            ddd = int.Parse(textBox111.Text);
            eee = int.Parse(textBox222.Text);
            if (ddd < eee)
            {
                textBox111.Text = textBox111.Text + textBox666.Text;
                textBox222.Text = textBox222.Text + textBox555.Text;
                textBox333.Text = textBox333.Text + textBox444.Text;


            }
            else if (ddd > eee)
            {
                if (ccc >= aaa)
                    {
                        aaa = aaa - 12;
                        textBox111.Text = aaa.ToString();
                        ccc = ccc - 12;
                    textBox333.Text = ccc.ToString();
                    bbb = bbb + 12;
                    textBox222.Text = bbb.ToString();
                    textBox111.Text = textBox111.Text + textBox666.Text;
                    textBox222.Text = textBox222.Text + textBox555.Text;
                    textBox333.Text = textBox333.Text + textBox444.Text;

                }
                else
                {
                    textBox111.Text = textBox111.Text + textBox666.Text;
                    textBox222.Text = textBox222.Text + textBox555.Text;
                    textBox333.Text = textBox333.Text + textBox444.Text;
                }
            }


            aaa = int.Parse(textBox111.Text);
            bbb = int.Parse(textBox222.Text);
            ccc = int.Parse(textBox333.Text);


            if (aaa < bbb)
            {
                if (ccc >= aaa && ccc <= bbb)
                {
                        
                        // textBox29.Text = late.ToString();

                        //   MessageBox.Show("y");
                        pos = 1;

                    textBox333.Clear();
                    textBox444.Clear();

                }
                else
                    {
                        pos = 0;
                        MessageBox.Show("Only possible in class schedule");
                   
                    textBox333.Clear();
                    textBox444.Clear();

                }
            }
            else if (aaa > bbb)
            {
                if (ccc >= aaa)
                {
                    if (ccc <= bbb)
                    {
                            //  MessageBox.Show("y");
                           
                            //  textBox29.Text = late.ToString();
                            pos = 1;
                        textBox333.Clear();
                        textBox444.Clear();
                    }
                }
                else
                {
                    if (ccc <= bbb)
                        {
                           
                            // MessageBox.Show("y");
                            //  late = int.Parse(textBox111.Text) - int.Parse(textBox333.Text);
                            //textBox29.Text = late.ToString();
                            pos = 1;
                        textBox333.Clear();
                        textBox444.Clear();
                    }
                    else
                        {
                            pos = 0;
                            MessageBox.Show("Only possible in class schedule");
                      

                        textBox333.Clear();
                        textBox444.Clear();
                    }
                }
            } }
            textBox111.Clear();
            textBox222.Clear();
            textBox666.Clear();
            textBox555.Clear();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button3.PerformClick();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            button20.PerformClick();
            if (pos == 1)
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("update attendence  set status='"+"Leave time "+ DateTime.Now.ToString("hh:mm tt ") +textBox8.Text+"'  where student_id='" + textBox1.Text + "' and teacher_id='" + textBox4.Text + "' and class_type='" + comboBox1.Text + "' and book_id='" + comboBox6.Text + "' and class_date='" + textBox7.Text + "' and start_time='" + textBox5.Text + "' and end_time='" + textBox6.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                button22.PerformClick();
                button25.PerformClick();
              
                // dataGridView2.DataSource = dt;
                //  MessageBox.Show(pos.ToString());

            }
           
        }

        private void button22_Click(object sender, EventArgs e)
        {
        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select attendence.student_id,status,class_date,attendence.book_id,class_type,start_time,end_time,attendence.teacher_id,Temp_Teacher_ID from student,attendence,reads where reads.student_id= attendence.student_id and attendence.student_id=student.student_id and attendence.teacher_id='" + textBox9.Text + "' and (student_type='Continue' or student_type='Re_admission') and book_id='" + comboBox7.Text + "' and attendence.student_id='" + textBox1.Text + "' and class_date='" + textBox7.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select attendence.student_id,status,class_date,attendence.book_id,class_type,start_time,end_time,attendence.teacher_id,Temp_Teacher_ID from student,attendence,reads where reads.student_id= attendence.student_id and attendence.student_id=student.student_id and attendence.teacher_id='" + textBox9.Text + "' and (student_type='Continue' or student_type='Re_admission') and book_id='" + comboBox7.Text + "' and attendence.student_id='" + textBox11.Text + "' and (status like'%late%' or status like'%leave%' ) and class_type='"+comboBox1.Text+"'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            int v, a;
            textBox23.Text = dataGridView2.RowCount.ToString();
            v = int.Parse(textBox23.Text);
            a = v - 1;

            textBox32.Text = a.ToString();
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button14.PerformClick();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            textBox9.Text = textBox35.Text;
            textBox35.Clear();
            dataGridView3.Visible = false;
            button5.PerformClick();
        }

        private void textBox34_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                dataGridView3.Visible = true;
            textBox35.Text = textBox9.Text;
                textBox4.Text = textBox9.Text;
            Class1 dbaccess = new Class1();
            dbaccess.Login_id = textBox33.Text;
            dbaccess.Login_password = textBox34.Text;


            if (dbaccess.QueryInTempt())
            {


                textBox9.Text = dbaccess.Login_id;



            }
                textBox33.Clear();
                textBox34.Clear();
               
            }
            
        }

        private void textBox33_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox34.Focus();
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {
            string s, b, ss,t;
            s = textBox1.Text;
            b = comboBox6.Text;
            ss = comboBox3.Text;
            t = textBox4.Text;
            
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select  * from percent1 where student_id='"+ s + "'and  semester_no='"+ss+"'  and book_id='"+b+"' and teacher_id='"+t+"' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView4.DataSource = dt;
            int fg;
            fg = int.Parse(dataGridView4.RowCount.ToString());
            fg = fg - 1;
            // MessageBox.Show(fg.ToString());
            if (fg > 0)
            {
                SqlConnection conu = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sdau = new SqlDataAdapter("update percent1 set s='" + textBox19.Text + "' where student_id='" + s + " ' and  semester_no='" + ss+ "'  and book_id='" + b + "' and teacher_id='" + t + "'", conu);
                DataTable dtu = new DataTable();
                sdau.Fill(dtu);
                dataGridView4.DataSource = dtu;
            }
            else if (fg == 0)
            {

                Class1 d = new Class1();
                d.Student_id = textBox1.Text;
                d.Semester_no = comboBox3.Text;
                d.S = textBox19.Text;
                d.Book_id = comboBox6.Text;
                d.Teacher_id = textBox4.Text;
                if (d.DataSaveInper()) { }
                { }
            }
        }
    }
}
