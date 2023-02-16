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
    public partial class semester : Form
    {
        public semester()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a;
            
             a = int.Parse(textBox1.Text); 
            if (a < 9) { 

            Class1 dbaccess = new Class1();
            dbaccess.Semester_no = textBox1.Text;



            if (dbaccess.DataSaveInSemester())
            {

                MessageBox.Show("sucessfull");
                textBox1.Clear();
                button3.PerformClick();

            }
            else
            {
                MessageBox.Show("fail");
            }
        }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 n = new Form1();
            n.Show();
            this.Hide();
        }

        private void semester_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false; this.ControlBox = false;
            button3.PerformClick();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select *from semester", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("do you want to delete this item ?", "warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {


                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                    textBox1.Text = row.Cells[0].Value.ToString();

                    Class1 dbaccess = new Class1();
                    dbaccess.Semester_no = textBox1.Text;



                    if (dbaccess.DataSaveInSemester1())
                    {

                        MessageBox.Show("sucessfull");
                        textBox1.Clear();
                        button3.PerformClick();

                    }
                    else
                    {
                        MessageBox.Show("this item use as relational data");
                    }
                    button3.PerformClick();
                    textBox1.Clear();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
           
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }
    }
}
