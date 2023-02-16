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
    public partial class Book : Form
    {
        public Book()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form a = new Form1();
            a.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a, b;
            a = int.Parse(textBox3.Text);
            b = int.Parse(textBox4.Text);
            textBox5.Text = (a + b).ToString();

            Class1 dbaccess = new Class1();
            dbaccess.Book_id = textBox6.Text;
            dbaccess.Book_name = textBox2.Text;



            dbaccess.T = textBox3.Text;
            dbaccess.P = textBox4.Text;
            dbaccess.C = textBox5.Text;
            dbaccess.Cn = textBox7.Text;



            if (dbaccess.DataSaveInBook())
            {

               MessageBox.Show("save successfull");
                textBox6.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
               
                textBox6.Focus();
                
                dataGridView1.Visible = true;
                dataGridView2.Visible = false;
                SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("select book_id as subject_id,book_name as Subject_name,t,p,c ,cn as per_credit_number from book", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                this.dataGridView1.Sort(this.dataGridView1.Columns["subject_id"], ListSortDirection.Descending);


            }
            else
            {
                MessageBox.Show("fail");
            }
        }

        private void Book_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;// TODO: This line of code loads data into the 'aITVETDataSet36.book' table. You can move, or remove it, as needed.
            this.bookTableAdapter.Fill(this.aITVETDataSet36.book);
            this.ControlBox = false;
            button3.PerformClick();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select book_id as subject_id,book_name as Subject_name,t,p,c,cn as per_credit_number from book", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
            dataGridView1.Visible = true;
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select book_id as subject_id,book_name as Subject_name,t,p,c,cn as per_credit_number  from book where book_id='" + textBox1.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            int v, a;
            textBox1.Text = dataGridView1.RowCount.ToString();
            v = int.Parse(textBox1.Text);
            a = v - 1;

            textBox1.Text = a.ToString();


            if (textBox1.Text == "1")
            {
                DataGridViewRow row = this.dataGridView1.Rows[0];

                textBox6.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
                
            }
            else
            {
                textBox6.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Focus();
            }
            textBox1.Clear();
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
            {
                int a, b;
                a = int.Parse(textBox3.Text);
                b = int.Parse(textBox4.Text);
                textBox5.Text = (a + b).ToString();
                textBox7.Focus();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select course_id as technology_id,semester_no,course_has.book_id as subject_id,book_name as Subject_name from course_has,book where course_has.book_id=book.book_id and (course_has.book_id='" + comboBox1.Text + "' )", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox2.Focus();
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button2.PerformClick();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int a, b;
            a = int.Parse(textBox3.Text);
            b = int.Parse(textBox4.Text);
            textBox5.Text = (a + b).ToString();
            if (textBox6.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("update this item", "warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dataGridView1.Visible = false;
                    dataGridView2.Visible = true;
                    SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                    SqlDataAdapter sda = new SqlDataAdapter("update book set book_name='" + textBox2.Text + "',t='" + textBox3.Text + "',p='" + textBox4.Text + "',c='" + textBox5.Text + "',cn='"+textBox7.Text+"' where book_id='" + textBox6.Text + "'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView2.DataSource = dt;
                    textBox1.Text = textBox6.Text;
                    button4.PerformClick();
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

                textBox6.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("delete this item", "warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Class1 dbaccess = new Class1();
                    dbaccess.Book_id = textBox6.Text;




                    if (dbaccess.DataSaveInBook1())
                    {

                        MessageBox.Show("successfull");
                        textBox6.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Focus();




                    }
                    else
                    {
                        MessageBox.Show("this item use as relational data");
                    }
                    button3.PerformClick();
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

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button4.PerformClick();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.Text;
            button4.PerformClick();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                textBox1.Text = comboBox1.Text;
                button4.PerformClick();
            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select book_id as subject_id,book_name as Subject_name,t,p,c,cn as per_credit_number  from book where book_name like'" + comboBox2.Text+ "%' or book_name like'%" + comboBox2.Text + "%' or book_name like'%" + comboBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            textBox6.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Focus();
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button2.PerformClick();
        }
    }
}
