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
    public partial class Course : Form
    {
        public Course()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 n = new Form1();
            n.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            Class1 dbaccess = new Class1();
            dbaccess.Course_id = textBox1.Text;
            dbaccess.Course_name = textBox2.Text;



            dbaccess.Course_credit = textBox3.Text;
            dbaccess.Course_fees = textBox4.Text;
            dbaccess.Sit = textBox5.Text;



            if (dbaccess.DataSaveInCourse())
            {

                MessageBox.Show("submit successfull");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();

                textBox1.Focus();
                button3.PerformClick();


            }
            else
            {
                MessageBox.Show("submit fail");
            }
        }

        private void Course_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;// TODO: This line of code loads data into the 'aITVETDataSet35.course' table. You can move, or remove it, as needed.
            this.courseTableAdapter.Fill(this.aITVETDataSet35.course);
            this.ControlBox = false;
            textBox1.Focus();
            button3.PerformClick();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select *from course", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
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
                textBox4.Focus();
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox5.Focus();
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("delete this item", "warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Class1 dbaccess = new Class1();
                    dbaccess.Course_id = textBox1.Text;




                    if (dbaccess.DataSaveInCourse1())
                    {

                        MessageBox.Show(" successfull");



                    }
                    else
                    {
                        MessageBox.Show("this item use as relationnal data");
                    }
                    button3.PerformClick();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            else { MessageBox.Show("select item first"); }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select *from course where course_id='" + textBox6.Text + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            int v, a;
            textBox6.Text = dataGridView1.RowCount.ToString();
            v = int.Parse(textBox6.Text);
            a = v - 1;

            textBox6.Text = a.ToString();
            if (textBox6.Text == "1")
            {
                DataGridViewRow row = this.dataGridView1.Rows[0];

                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
            }
            else
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }
            textBox6.Clear();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("update this item", "warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    textBox6.Text = textBox1.Text;
                    SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                    SqlDataAdapter sda = new SqlDataAdapter("update  course set course_name='" + textBox2.Text + "', course_credit='" + textBox3.Text + "',course_fees='" + textBox4.Text + "', sit='" + textBox5.Text + "' where course_id='" + textBox6.Text + "' ", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    button6.PerformClick();
                    textBox6.Clear();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }

            else { MessageBox.Show("select item first"); }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
            }

        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button6.PerformClick();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
                textBox6.Text = comboBox1.Text;
                button6.PerformClick();
            
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox6.Text = comboBox1.Text;
                button6.PerformClick();
                
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

        }
    }
}
