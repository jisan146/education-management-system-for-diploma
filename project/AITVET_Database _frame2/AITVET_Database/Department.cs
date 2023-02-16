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
    public partial class Department : Form
    {
        public Department()
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

           

            Class1 dbaccess = new Class1();
            dbaccess.Department_id = textBox1.Text;
            dbaccess.Department_name = textBox2.Text;





            if (dbaccess.DataSaveInDepartment())
            {

                MessageBox.Show("save suceessfull");
                textBox1.Clear();
                textBox2.Clear();
                button3.PerformClick();
                textBox1.Focus();
             

            }
            else
            {
                MessageBox.Show("save fail");
            }
        }

        private void Department_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false; this.ControlBox = false;
            button3.PerformClick();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select department_id,department_name from department", con);
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
                button2.PerformClick();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("update this item", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                    SqlDataAdapter sda = new SqlDataAdapter("update department set department_id='" + textBox1.Text + "', department_name='" + textBox2.Text + "' where department_id='" + textBox1.Text + "' ", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    button3.PerformClick();
                    textBox1.Clear();
                    textBox2.Clear();


                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            else { MessageBox.Show("Please select item for update"); }



           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) { 
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
        }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("Delete this item", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    Class1 dbaccess = new Class1();
                    dbaccess.Department_id = textBox1.Text;






                    if (dbaccess.DataSaveInDepartment1())
                    {

                        MessageBox.Show("suceessfull");
                        textBox1.Clear();
                        textBox2.Clear();
                        button3.PerformClick();
                        textBox1.Focus();


                    }
                    else
                    {
                        MessageBox.Show("Not possible because this item is use as relational data");
                    }
                
               
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            else { MessageBox.Show("Please select item for delete"); }


            button3.PerformClick();
            textBox1.Clear();
            textBox2.Clear();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
