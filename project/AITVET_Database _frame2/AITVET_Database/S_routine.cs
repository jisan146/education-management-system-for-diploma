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
    public partial class S_routine : Form
    {
        public S_routine()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = comboBox4.Text;
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select room as room_no,teacher_name,operate.book_id as subject_id,book_name as subject_name,t,p,c, day,start_time,end_time from operate,book,teacher where teacher.teacher_id=operate.teacher_id and operate.book_id=book.book_id and  semester_no='" + textBox3.Text+"' and course_id='"+textBox1.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            DataGridViewColumn column1 = dataGridView1.Columns[4];
            column1.Width = 15;

            DataGridViewColumn column2 = dataGridView1.Columns[5];
            column2.Width = 15;

            DataGridViewColumn column = dataGridView1.Columns[6];
            column.Width = 15;
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            Form5 f = new Form5();
          
            this.Hide();
            
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select room as room_no,teacher_name,operate.book_id as subject_id,book_name as subject_name,t,p,c, day,start_time,end_time from operate,book ,teacher where teacher.teacher_id=operate.teacher_id and operate.book_id=book.book_id and semester_no='" + textBox3.Text + "' and course_id='" + textBox1.Text + "' and day='" + comboBox4.Text + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            DataGridViewColumn column1 = dataGridView1.Columns[4];
            column1.Width = 15;

            DataGridViewColumn column2 = dataGridView1.Columns[5];
            column2.Width = 15;

            DataGridViewColumn column = dataGridView1.Columns[6];
            column.Width = 15;
        }

        private void S_routine_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false; this.ControlBox = false;
            button1.PerformClick();
        }
    }
}

