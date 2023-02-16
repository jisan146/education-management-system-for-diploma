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
    public partial class View_student : Form
    {
        public View_student()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select reads.student_id,board_roll,student_name,image,phone,email,teach.semester_no,teach.course_id as technology_id,teach.book_id as subject_id from student,reads,teach where student.student_id=reads.student_id and reads.course_id=teach.course_id and teach.teacher_id='"+textBox1.Text+ "' and student_type='" + textBox3.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            DataGridViewImageColumn image = new DataGridViewImageColumn();
            image = (DataGridViewImageColumn)dataGridView1.Columns[3];
            image.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
        }

        private void View_student_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false; this.ControlBox = false;
            // TODO: This line of code loads data into the 'aITVETDataSet12.course' table. You can move, or remove it, as needed.
            this.courseTableAdapter.Fill(this.aITVETDataSet12.course);
            // TODO: This line of code loads data into the 'aITVETDataSet11.semester' table. You can move, or remove it, as needed.
            this.semesterTableAdapter.Fill(this.aITVETDataSet11.semester);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
            //textBox3.Text = comboBox3.Text;
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select reads.student_id,board_roll,student_name,image,phone,email,teach.semester_no,teach.course_id as technology_id,teach.book_id as subject_id from student,reads,teach where student.student_id=reads.student_id and teach.teacher_id='" + textBox1.Text + "' and reads.course_id=teach.course_id and teach.semester_no='" + comboBox1.Text+"' and teach.course_id='"+comboBox2.Text+ "' and (student_type='Continue' or student_type='Re_admission')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView3.DataSource = dt;
            DataGridViewImageColumn image = new DataGridViewImageColumn();
            image = (DataGridViewImageColumn)dataGridView3.Columns[3];
            image.ImageLayout = DataGridViewImageCellLayout.Stretch;
           /* DataGridViewColumn column1 = dataGridView3.Columns[4];
            column1.Width = 60;
            DataGridViewColumn column2 = dataGridView3.Columns[5];
            column2.Width = 80;
            DataGridViewColumn column3 = dataGridView3.Columns[6];
            column3.Width = 60;
            DataGridViewColumn column4 = dataGridView3.Columns[3];
            column4.Width = 120;*/
            dataGridView3.Visible = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            //dataGridView3.Visible = false;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox1.Visible = false;
            this.Hide();
            textBox1.Enabled = false;
            button5.Visible = false;
            comboBox4.Enabled = false;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select reads.student_id,board_roll,student_name,image,phone,email,teach.semester_no,teach.course_id as technology_id,teach.book_id as subject_id from student,reads,teach where student.student_id=reads.student_id and reads.course_id=teach.course_id and reads.semester_no=teach.semester_no and teacher_id='" + textBox1.Text + "' and reads.student_id='" + textBox4.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            DataGridViewImageColumn image = new DataGridViewImageColumn();
            image = (DataGridViewImageColumn)dataGridView2.Columns[3];
            image.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView2.Visible = true;
            dataGridView1.Visible = false;
          /*  DataGridViewColumn column1 = dataGridView2.Columns[4];
            column1.Width = 60;
            DataGridViewColumn column2 = dataGridView2.Columns[5];
            column2.Width = 80;
            DataGridViewColumn column3 = dataGridView2.Columns[6];
            column3.Width = 60;
            DataGridViewColumn column4 = dataGridView2.Columns[3];
            column4.Width = 120;*/
            dataGridView3.Visible = false;
        }

        private void comboBox4_Click(object sender, EventArgs e)
        {
            textBox3.Text = comboBox3.Text;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = comboBox4.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select *from student", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select teach.teacher_id,reads.student_id,board_roll,student_name,teach.semester_no,teach.course_id as technology_id,teach.book_id as subject_id from student,reads,teach where student.student_id=reads.student_id and reads.course_id=teach.course_id  and reads.student_id='" + textBox5.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select *from student where student_id='" + textBox5.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            //populate the textbox from specific value of the coordinates of column and row.
            pictureBox1.ImageLocation = row.Cells[4].Value.ToString();
            textBox6.Text= row.Cells[3].Value.ToString();
            pictureBox1.ImageLocation = textBox6.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            pictureBox1.ImageLocation = textBox6.Text;
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
           // pictureBox1.ImageLocation = row.Cells[4].Value.ToString();
            textBox6.Text = row.Cells[4].Value.ToString();
            pictureBox1.ImageLocation = textBox6.Text;
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
            textBox6.Text = row.Cells[4].Value.ToString();
            pictureBox1.ImageLocation = textBox6.Text;
        }
    }
}
