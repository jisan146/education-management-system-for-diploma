using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AITVET_Database
{
    public partial class Form7 : Form
    {
        int a, b;
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aITVETDataSet68.book' table. You can move, or remove it, as needed.
            this.bookTableAdapter.Fill(this.aITVETDataSet68.book);
            // TODO: This line of code loads data into the 'aITVETDataSet67.student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.aITVETDataSet67.student);
            button1.PerformClick();
            this.ControlBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select student_id,book_id,s as Present,teacher_id from percent1", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Class1 dbaccess = new Class1();
            dbaccess.Student_id = comboBox1.Text;


            if (dbaccess.QueryInOp())
            {
                textBox2.Text = dbaccess.Semester_no;
                textBox3.Text = dbaccess.Course_id;

                //MessageBox.Show("sucess");
            }
            else
            {
                //MessageBox.Show("fail");
                // textBox4.Text = comboBox1.Text; 
            }
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select * from course_has where course_id='"+textBox3.Text+"' and semester_no='"+textBox2.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            b = int.Parse(dataGridView2.RowCount.ToString());
            b = b - 1;
            textBox4.Text = b.ToString();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("select student_id,book_id,s as Present,teacher_id from percent1 where student_id='" + comboBox1.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                button3.PerformClick();
                button4.PerformClick();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select student_id,book_id,s as Present,teacher_id from percent1 where student_id='" + comboBox1.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            button3.PerformClick();
            button4.PerformClick();
        }

    

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select student_id,book_id,s as Present,teacher_id from percent1 where student_id='" + comboBox1.Text + "' and book_id='"+comboBox2.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select student_id,book_id,s as Present,teacher_id from percent1 where student_id='" + comboBox1.Text + "' and book_id='" + comboBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select  sum(s)from percent1 where student_id='"+comboBox1.Text+ "' and semester_no='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView3.DataSource = dt;
            DataGridViewRow row = this.dataGridView3.Rows[0];
            textBox5.Text = row.Cells[0].Value.ToString();
            if (textBox5.Text != "")
            {
                a = int.Parse(textBox5.Text);
                a = a / b;
                textBox6.Text = a.ToString()+"%";
            }
            else { textBox6.Clear(); }

        }
    }
}
