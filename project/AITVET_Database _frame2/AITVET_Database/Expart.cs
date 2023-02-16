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
    public partial class Expart : Form
    {
        public Expart()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (groupBox1.Visible != false)
            { SqlConnection con1 = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda1 = new SqlDataAdapter("select expart.teacher_id,expart.book_id as Suject_id,teacher_name,book_name,t,p,c from expart,book,teacher where expart.book_id=book.book_id and teacher.teacher_id=expart.teacher_id and expart.teacher_id='" + comboBox1.Text + "' and expart.book_id='" + comboBox2.Text + "'", con1);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            }
            else {
                SqlConnection con1 = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda1 = new SqlDataAdapter("select expart.teacher_id,expart.book_id as Suject_id,teacher_name,book_name,t,p,c from expart,book,teacher where expart.book_id=book.book_id and teacher.teacher_id=expart.teacher_id and expart.teacher_id='" + textBox1.Text + "' and expart.book_id='" + comboBox2.Text + "'", con1);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                dataGridView1.DataSource = dt1;
            }
            int v, a;
            textBox4.Text = dataGridView1.RowCount.ToString();
            v = int.Parse(textBox4.Text);
            a = v - 1;

            textBox4.Text = a.ToString();
            if (groupBox1.Visible != false)
            {
                textBox1.Text = comboBox1.Text;

            }
            textBox2.Text = comboBox2.Text;
            //label1.Visible = true;
            if (textBox4.Text != "1")
            {
                textBox3.Clear();
                Class1 dbaccess = new Class1();
                dbaccess.Teacher_id = textBox1.Text;
                dbaccess.Book_id = textBox2.Text;







                if (dbaccess.DataSaveInExpart())
                {
                    textBox3.Clear();
                    MessageBox.Show("Success");
                    SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                    SqlDataAdapter sda = new SqlDataAdapter("select expart.teacher_id,expart.book_id as Suject_id,teacher_name,book_name,t,p,c from expart,book,teacher where expart.book_id=book.book_id and teacher.teacher_id=expart.teacher_id and expart.teacher_id='" + comboBox1.Text + "'and expart.book_id='" + comboBox2.Text + "' ", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    comboBox1.Focus();


                }
                else
                {
                    comboBox1.Focus();
                    textBox3.Clear();
                    MessageBox.Show("Fail");
                    // label1.Text = "submit fail ";
                }
            }else { comboBox1.Focus(); MessageBox.Show("Already insert"); }
            textBox3.Clear();
            button7.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Form1 a = new Form1();
           // a.Show();
            this.Hide();

        }

        private void Expart_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aITVETDataSet55.teacher' table. You can move, or remove it, as needed.
            this.teacherTableAdapter3.Fill(this.aITVETDataSet55.teacher);
            // TODO: This line of code loads data into the 'aITVETDataSet54.book' table. You can move, or remove it, as needed.
            this.bookTableAdapter3.Fill(this.aITVETDataSet54.book);
            // TODO: This line of code loads data into the 'aITVETDataSet45.book' table. You can move, or remove it, as needed.
            this.bookTableAdapter2.Fill(this.aITVETDataSet45.book);
            // TODO: This line of code loads data into the 'aITVETDataSet44.teacher' table. You can move, or remove it, as needed.
            this.teacherTableAdapter2.Fill(this.aITVETDataSet44.teacher);

            this.MaximizeBox = false;// TODO: This line of code loads data into the 'aITVETDataSet40.teacher' table. You can move, or remove it, as needed.
           //*** this.teacherTableAdapter1.Fill(this.aITVETDataSet40.teacher);

            // TODO: This line of code loads data into the 'aITVETDataSet31.book' table. You can move, or remove it, as needed.
            this.bookTableAdapter1.Fill(this.aITVETDataSet31.book);
            // TODO: This line of code loads data into the 'aITVETDataSet30.book' table. You can move, or remove it, as needed.
            this.bookTableAdapter.Fill(this.aITVETDataSet30.book);
            // TODO: This line of code loads data into the 'aITVETDataSet29.teacher' table. You can move, or remove it, as needed.
            this.teacherTableAdapter.Fill(this.aITVETDataSet29.teacher);
            this.ControlBox = false;
           
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                comboBox4.Focus();
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                comboBox3.Focus();
        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select expart.teacher_id,expart.book_id as Suject_id,teacher_name,book_name,t,p,c from expart,book,teacher where expart.book_id=book.book_id and teacher.teacher_id=expart.teacher_id", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select expart.teacher_id,expart.book_id as Suject_id,teacher_name,book_name,t,p,c from expart,book,teacher where expart.book_id=book.book_id and teacher.teacher_id=expart.teacher_id and expart.teacher_id='"+textBox3.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button4.PerformClick();
                textBox3.Clear();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string com,bok;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                // comboBox1.Text = row.Cells[0].Value.ToString();
                 com = row.Cells[0].Value.ToString();
                // textBox1.Text = row.Cells[0].Value.ToString();
               bok= row.Cells[1].Value.ToString();
             
                DialogResult dialogResult = MessageBox.Show("Delete this item", "Waring", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                    SqlDataAdapter sda = new SqlDataAdapter("delete from expart where teacher_id='" + com+ "' and book_id='" + bok+ "'", con);
                   DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    button6.PerformClick();
                    
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
               
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select expart.teacher_id,expart.book_id as Suject_id,teacher_name,book_name,t,p,c from expart,book,teacher where expart.book_id=book.book_id and teacher.teacher_id=expart.teacher_id and expart.teacher_id='" + comboBox5.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void comboBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("select expart.teacher_id,expart.book_id as Suject_id,teacher_name,book_name,t,p,c from expart,book,teacher where expart.book_id=book.book_id and teacher.teacher_id=expart.teacher_id and expart.teacher_id='" + comboBox5.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select expart.teacher_id,expart.book_id as Suject_id,teacher_name,book_name,t,p,c from expart,book,teacher where expart.book_id=book.book_id and teacher.teacher_id=expart.teacher_id and expart.book_id='" + comboBox6.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void comboBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("select expart.teacher_id,expart.book_id as Suject_id,teacher_name,book_name,t,p,c from expart,book,teacher where expart.book_id=book.book_id and teacher.teacher_id=expart.teacher_id and expart.book_id='" + comboBox6.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void comboBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                comboBox2.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select expart.teacher_id,expart.book_id as Suject_id,teacher_name,book_name,t,p,c from expart,book,teacher where expart.book_id=book.book_id and teacher.teacher_id=expart.teacher_id and expart.teacher_id='" + textBox1.Text + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select expart.teacher_id,expart.book_id as Suject_id,teacher_name,book_name,t,p,c from expart,book,teacher where expart.book_id=book.book_id and teacher.teacher_id=expart.teacher_id and expart.teacher_id='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select expart.teacher_id,expart.book_id as Suject_id,teacher_name,book_name,t,p,c from expart,book,teacher where expart.book_id=book.book_id and teacher.teacher_id=expart.teacher_id and expart.teacher_id='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
