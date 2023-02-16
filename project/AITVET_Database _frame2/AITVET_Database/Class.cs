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
    public partial class Class : Form
    {
        public Class()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox6.Text = comboBox2.Text;
            textBox4.Text = comboBox1.Text;
          

            Class1 dbaccess = new Class1();
            dbaccess.Building = textBox1.Text;
            dbaccess.Floor = textBox2.Text;
            dbaccess.Room_name = textBox6.Text;


            dbaccess.Room_type = textBox4.Text;
            dbaccess.Sit = textBox5.Text;
            dbaccess.Room = textBox3.Text;



            if (dbaccess.DataSaveInClass())
            {

                MessageBox.Show("sucessfull");
                textBox1.Clear();
                comboBox1.Text = "";
                comboBox2.Text = "";
                textBox5.Clear();
                textBox2.Clear();
                textBox3.Clear();
                button3.PerformClick();


            }
            else
            {
                MessageBox.Show("fail");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select building,floor,room as room_no,room_name,room_type,sit as capacity from class", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select building,floor,room as room_no,room_name,room_type,sit as capacity from class where room_name='"+comboBox3.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select COUNT(room_name)as Total from class where room_name='"+comboBox3.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select building,floor,room as room_no,room_name,room_type,sit as capacity from class where room_type='"+comboBox4.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select COUNT(room_type) as Total from class where room_type='"+comboBox4.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select max(floor) Total_floor ,COUNT(room) as Total_room from class where building='"+textBox7.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select COUNT(room_type) as Total from class where building='"+textBox7.Text+"' and room_name='"+comboBox5.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select COUNT(room_type) as Total from class where building='" + textBox7.Text + "' and room_type='" + comboBox6.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Class_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false; this.ControlBox = false;
            button3.PerformClick();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                comboBox1.Focus();

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox1.Focus();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox2.Focus();
            
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                comboBox2.Focus();
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox5.Focus();
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button2.PerformClick();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int v, a;
            textBox8.Text = dataGridView1.ColumnCount.ToString();
            v = int.Parse(textBox8.Text);
            a = v - 1;

            textBox8.Text = a.ToString();
            if (e.RowIndex >= 0 && textBox8.Text=="5")
                
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                comboBox2.Text = row.Cells[3].Value.ToString();
                comboBox1.Text = row.Cells[4].Value.ToString();
                textBox5.Text = row.Cells[5].Value.ToString();
            }
            textBox8.Clear();


        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("delete this item", "warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                   


                    Class1 dbaccess = new Class1();
                    
                    dbaccess.Room = textBox3.Text;



                    if (dbaccess.DataSaveInClass1())
                    {

                        MessageBox.Show("sucessfull");
                      

                    }
                    else
                    {
                        MessageBox.Show("this item use as relational data");
                    }
                    button3.PerformClick();
                    textBox1.Clear();
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    textBox5.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
              
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select building,floor,room as room_no,room_name,room_type,sit as capacity from class where room='" + textBox8.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            int v, a;
            textBox8.Text = dataGridView1.RowCount.ToString();
            v = int.Parse(textBox8.Text);
            a = v - 1;

            textBox8.Text = a.ToString();


            if (textBox8.Text == "1")
            {
                DataGridViewRow row = this.dataGridView1.Rows[0];

                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                comboBox2.Text = row.Cells[3].Value.ToString();
                comboBox1.Text = row.Cells[4].Value.ToString();
                textBox5.Text = row.Cells[5].Value.ToString();
            }
            else
            {
                textBox1.Clear();
                comboBox1.Text = "";
                comboBox2.Text = "";
                textBox5.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
            textBox8.Clear();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("update this item", "warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                    SqlDataAdapter sda = new SqlDataAdapter("update class set building='" + textBox1.Text + "',floor='" + textBox2.Text + "',room='" + textBox3.Text + "',room_type='" + comboBox1.Text + "',sit='" + textBox5.Text + "',room_name='" + comboBox2.Text + "' where room='" + textBox3.Text + "'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    textBox8.Text = textBox3.Text;
                    button13.PerformClick();
                    textBox1.Clear();
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    textBox5.Clear();
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

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button13.PerformClick();
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox5.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}
