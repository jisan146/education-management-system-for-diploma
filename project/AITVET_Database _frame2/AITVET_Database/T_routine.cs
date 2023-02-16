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
    public partial class T_routine : Form
    {
        public T_routine()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select teacher_id,room as room_no,operate.book_id as subject_id,course_id as technology_id,semester_no,day,start_time,end_time from operate,book where operate.book_id=book.book_id", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox3.Text;
            textBox2.Text = comboBox4.Text;
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select teacher_id,room as room_no,book_id as subject_id,course_id as technology_id,semester_no,day,start_time,end_time from operate where  teacher_id='" + textBox3.Text + "'  ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = comboBox4.Text;
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select room as room_no,book_id as subject_id,course_id as technology_id,semester_no,day,start_time,end_time from operate where  teacher_id='" + textBox3.Text+"'  ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            this.Hide();

        }

        private void T_routine_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false; comboBox1.Text = textBox3.Text;
            // TODO: This line of code loads data into the 'aITVETDataSet41.teacher' table. You can move, or remove it, as needed.
            //this.teacherTableAdapter.Fill(this.aITVETDataSet41.teacher);
            this.ControlBox = false;
            button1.PerformClick();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = comboBox1.Text;
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select teacher_id,room as room_no,book_id as subject_id,course_id as technology_id,semester_no,day,start_time,end_time from operate where  teacher_id='" +textBox3.Text + "'  ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select teacher_id,room as room_no,book_id as subject_id,course_id as technology_id,semester_no,day,start_time,end_time from operate where  day='" + comboBox4.Text + "'  ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Text = comboBox1.Text;
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("select teacher_id,room as room_no,book_id as subject_id,course_id as technology_id,semester_no,day,start_time,end_time from operate where  teacher_id='" + textBox3.Text + "'  ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void comboBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("select teacher_id,room as room_no,book_id as subject_id,course_id as technology_id,semester_no,day,start_time,end_time from operate where  day='" + comboBox4.Text + "'  ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select teacher_id,room as room_no,book_id as subject_id,course_id as technology_id,semester_no,day,start_time,end_time from operate where  day='" + comboBox3.Text + "' and  teacher_id='" + textBox3.Text + "'  ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
