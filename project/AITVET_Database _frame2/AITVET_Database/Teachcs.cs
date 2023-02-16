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
    public partial class Teachcs : Form
    {
        public Teachcs()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = comboBox2.Text;
            textBox3.Text = comboBox1.Text;
            label9.Visible = true;

            Class1 dbaccess = new Class1();
            dbaccess.Teacher_id = textBox1.Text;
            dbaccess.Semester_no = textBox2.Text;



            dbaccess.Course_id = textBox3.Text;

            dbaccess.Book_id = textBox4.Text;



            if (dbaccess.DataSaveInTeach())
            {

                label9.Text = "submit suceessfull ";
             

            }
            else
            {
                label9.Text = "submit fail ";
            }
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select teacher_id,book_id,semester_no,course_id from teach  where teacher_id='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 n = new Form1();
            n.Show();
            this.Hide();
        }

        private void Teachcs_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false; this.ControlBox = false;
            // TODO: This line of code loads data into the 'aITVETDataSet10.course' table. You can move, or remove it, as needed.
            this.courseTableAdapter.Fill(this.aITVETDataSet10.course);
            // TODO: This line of code loads data into the 'aITVETDataSet9.semester' table. You can move, or remove it, as needed.
            this.semesterTableAdapter.Fill(this.aITVETDataSet9.semester);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select teacher_id,book_id,semester_no,course_id from teach", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select teacher_id,book_id,semester_no,course_id from teach  where teacher_id='"+textBox5.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
