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
    public partial class Course_has : Form
    {
        public Course_has()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 n = new Form1();
            n.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.Text;
            textBox2.Text = comboBox2.Text;
            textBox3.Text = comboBox3.Text;
            button5.PerformClick();
            if (textBox5.Text == "0")
            {
                Class1 dbaccess = new Class1();
                dbaccess.Course_id = textBox1.Text;
                dbaccess.Semester_no = textBox2.Text;
                dbaccess.Book_id = textBox3.Text;



                if (dbaccess.DataSaveIncourse_has())
                {

                    MessageBox.Show("save successfull");
                    textBox4.Text = textBox1.Text;

                    button4.PerformClick();
                   
                    textBox3.Clear();
                    textBox3.Focus();

                    textBox4.Clear();
                    comboBox3.Focus();




                }
                else
                {
                    MessageBox.Show("save fail");
                }
            }
            else
                MessageBox.Show("already insert");
        }

        private void Course_has_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aITVETDataSet53.book' table. You can move, or remove it, as needed.
            this.bookTableAdapter2.Fill(this.aITVETDataSet53.book);
            // TODO: This line of code loads data into the 'aITVETDataSet52.semester' table. You can move, or remove it, as needed.
            this.semesterTableAdapter2.Fill(this.aITVETDataSet52.semester);
            // TODO: This line of code loads data into the 'aITVETDataSet51.course' table. You can move, or remove it, as needed.
            this.courseTableAdapter2.Fill(this.aITVETDataSet51.course);
            // TODO: This line of code loads data into the 'aITVETDataSet48.semester' table. You can move, or remove it, as needed.
            this.semesterTableAdapter1.Fill(this.aITVETDataSet48.semester);
            // TODO: This line of code loads data into the 'aITVETDataSet47.course_has' table. You can move, or remove it, as needed.
            this.course_hasTableAdapter.Fill(this.aITVETDataSet47.course_has);
            this.MaximizeBox = false;// TODO: This line of code loads data into the 'aITVETDataSet39.book' table. You can move, or remove it, as needed.
            this.bookTableAdapter1.Fill(this.aITVETDataSet39.book);
            // TODO: This line of code loads data into the 'aITVETDataSet37.course' table. You can move, or remove it, as needed.
            this.courseTableAdapter1.Fill(this.aITVETDataSet37.course);
            // TODO: This line of code loads data into the 'aITVETDataSet28.book' table. You can move, or remove it, as needed.
            this.bookTableAdapter.Fill(this.aITVETDataSet28.book);
            // TODO: This line of code loads data into the 'aITVETDataSet27.semester' table. You can move, or remove it, as needed.
            this.semesterTableAdapter.Fill(this.aITVETDataSet27.semester);
            // TODO: This line of code loads data into the 'aITVETDataSet26.course' table. You can move, or remove it, as needed.
            this.courseTableAdapter.Fill(this.aITVETDataSet26.course);
            this.ControlBox = false;
            button3.PerformClick();
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select course_id as technology_id,semester_no,course_has.book_id as subject_id,book_name as Subject_name,t,p,c from course_has,book where course_has.book_id=book.book_id", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select course_id as technology_id,semester_no,course_has.book_id as subject_id,book_name as Subject_name,t,p,c from course_has,book where course_has.book_id=book.book_id and course_id='"+textBox4.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            textBox4.Clear();
           
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

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button2.PerformClick();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select course_id as technology_id,semester_no,course_has.book_id as subject_id,book_name as Subject_name from course_has,book where course_has.book_id=book.book_id and  course_id='" + textBox1.Text+ "' and course_has.book_id='" + textBox3.Text+"' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            int v, a;
            textBox5.Text = dataGridView1.RowCount.ToString();
            v = int.Parse(textBox5.Text);
            a = v - 1;

            textBox5.Text = a.ToString();
        }

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                comboBox1.Text = textBox1.Text;
                comboBox2.Text = textBox2.Text;
                comboBox3.Text = textBox3.Text;
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            comboBox1.Text=textBox1.Text;
             comboBox2.Text=textBox2.Text;
            comboBox3.Text=textBox3.Text;
            if (textBox1.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("delete this item", "warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                    SqlDataAdapter sda = new SqlDataAdapter("delete from course_has  where course_id='" + textBox1.Text + "' and semester_no='" + textBox2.Text + "' and book_id='" + textBox3.Text + "' ", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    button3.PerformClick();
                    textBox4.Clear();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }

            }
            else { MessageBox.Show("select item first"); }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("update  course_has set course_id='" + textBox3.Text + "' , semester_no='" + textBox3.Text + "' , book_id='" + textBox3.Text + "'  where course_id='" + textBox3.Text + "' and semester_no='" + textBox3.Text + "' and book_id='" + textBox3.Text + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            textBox4.Text = textBox1.Text;
            button4.PerformClick();
            textBox4.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();


        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button4.PerformClick();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                comboBox2.Focus();
        }
        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void comboBox2_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                comboBox3.Focus();
        }

        private void comboBox3_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button2.PerformClick();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4.Text = comboBox4.Text;
            button4.PerformClick();
        }

        private void comboBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                textBox4.Text = comboBox4.Text;
                button4.PerformClick();
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select course_id as technology_id,semester_no,course_has.book_id as subject_id,book_name as Subject_name,t,p,c from course_has,book where course_has.book_id=book.book_id and course_id='" + comboBox4.Text + "' and semester_no='"+comboBox5.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            textBox4.Clear();
        }

        private void comboBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("select course_id as technology_id,semester_no,course_has.book_id as subject_id,book_name as Subject_name,t,p,c from course_has,book where course_has.book_id=book.book_id and course_id='" + comboBox4.Text + "' and semester_no='" + comboBox5.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                textBox4.Clear();
            }
        }
    }
}
