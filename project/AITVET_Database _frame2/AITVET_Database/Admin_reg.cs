using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
namespace AITVET_Database
{
    public partial class Admin_reg : Form
    {
        string imgloc = "";
        public Admin_reg()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 l = new Form1();
            l.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.ImageLocation==""||textBox1.Text == "" || textBox12.Text == "" || textBox11.Text == "" || textBox6.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox15.Text == "") { MessageBox.Show("Fill ip all field"); } else { 
            textBox16.Text = DateTime.Now.ToString("MMM dd ,dddd, yyyy hh:mm:ss tt");
            textBox12.Text = textBox1.Text;
            if (textBox6.Text == textBox11.Text)
            { }
            else
            {

                MessageBox.Show("Password not match");
            }

            if (textBox11.Text.Length > 0 && textBox12.Text.Length > 4 && textBox6.Text == textBox11.Text)
            {
                Class1 dbaccess = new Class1();
                dbaccess.Login_id = textBox12.Text;
                dbaccess.Login_password = textBox11.Text;
                dbaccess.Log_type = textBox10.Text;
                if (dbaccess.DataSaveInTable())
                {
                    button4.Text = "s";
                }
                else
                {
                    button4.Text = "f";
                    MessageBox.Show("admin ID already use");
                }

            }
            else if (textBox1.Text.Length == 0) { MessageBox.Show("check admin ID length"); }
            else if (textBox6.Text.Length < 4) { MessageBox.Show("check all password filed length"); }

            else { }


            if (button4.Text == "s" && textBox9.Text != "" && pictureBox1.ImageLocation != "")
            {


                Class1 dbaccess = new Class1();
                dbaccess.Admin_id = textBox1.Text;
                dbaccess.Admin_name = textBox2.Text;
                dbaccess.Picture = textBox20.Text;


                dbaccess.Phone = textBox3.Text;
                dbaccess.Email = textBox4.Text;
                dbaccess.Current_Address = textBox5.Text;
                dbaccess.S = textBox15.Text;
                dbaccess.Insert_By = textBox16.Text;
                dbaccess.Update_Time = "";

                if (textBox9.Text == "") { MessageBox.Show("image not insert"); }

                if (dbaccess.DataSaveInAdmin())
                {
                    button14.PerformClick();
                    MessageBox.Show("submit successful");

                    SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                    SqlDataAdapter sda = new SqlDataAdapter("select admin_id,admin_name,image,phone,email,current_address,picture,s,Insert_by as Insert_time from administrator where admin_id='" + textBox1.Text + "' ", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    DataGridViewImageColumn image = new DataGridViewImageColumn();
                    image = (DataGridViewImageColumn)dataGridView1.Columns[2];
                    image.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    button13.PerformClick();
                    textBox13.Text = textBox1.Text;
                    button9.PerformClick();
                    pictureBox1.ImageLocation = "";
                    textBox1.Clear();
                    textBox12.Clear();
                    textBox11.Clear();
                    textBox6.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox1.Focus();
                    textBox9.Clear();
                    textBox15.Clear();

                    textBox13.Clear();
                   





                }
                else
                {
                    MessageBox.Show(" submit fail");
                    SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                    SqlDataAdapter sda = new SqlDataAdapter("delete from login_id where login_id='" + textBox1.Text + "' delete from administrator where admin_id='" + textBox1.Text + "'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    //dataGridView1.DataSource = dt;
                }
            }
            else if (textBox9.Text == "") { /*MessageBox.Show("insert image");*/ }
            else
            {


            }
        }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1 dbaccess = new Class1();
            dbaccess.Department_id = "";
            if (dbaccess.DataSaveInfilen()) { }
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select max(Serial_no) from filen ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView22.DataSource = dt;
            int art;
            DataGridViewRow row = this.dataGridView22.Rows[0];
            art =int.Parse( row.Cells[0].Value.ToString());
            /*  +art + "__"  */


            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG Files(*.jpg)|*.jpg";
                dlg.Title = "select emp pic";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgloc = dlg.FileName.ToString();
                    pictureBox1.ImageLocation = imgloc;
                    textBox17.Text = imgloc;
                    textBox18.Text = @"\\\\JISANRAHMAN-PC\New folder\"+art+"__"+dlg.SafeFileName.ToString();
                    textBox19.Text = @"C:\New folder\"+art + "__"+ dlg.SafeFileName.ToString();
                    textBox20.Text= art + "__" + dlg.SafeFileName.ToString();
                    File.Copy(textBox17.Text, textBox18.Text);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            textBox9.Text = @"\\JISANRAHMAN - PC\New folder\not insert.jpg";
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void Admin_reg_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aITVETDataSet69.administrator' table. You can move, or remove it, as needed.
            this.administratorTableAdapter.Fill(this.aITVETDataSet69.administrator);
            this.MaximizeBox = false;

            // TODO: This line of code loads data into the 'aITVETDataSet34.administrator' table. You can move, or remove it, as needed.
         
            this.ControlBox = false;
            textBox1.Focus();
            button10.PerformClick();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox12.Text = textBox1.Text;
               
                textBox11.Focus();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox6.Focus();
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox2.Focus();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.PerformClick();
                textBox3.Focus();
            }
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

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox12.Clear();
            textBox11.Clear();
            textBox6.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            pictureBox1.ImageLocation = "";
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                textBox15.Focus();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\AITVET\WindowsFormsApplication3.exe");
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select admin_id,admin_name,image,phone,email,current_address,picture,s,Insert_by as Insert_time,Update_Time from administrator", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            DataGridViewImageColumn image = new DataGridViewImageColumn();
            image = (DataGridViewImageColumn)dataGridView1.Columns[2];
            image.ImageLayout = DataGridViewImageCellLayout.Stretch;
            Process[] p = Process.GetProcesses();
            foreach (Process ps in p)
            {
                string s = ps.ProcessName;
                s = s.ToLower();
                if (s.CompareTo("windowsformsapplication3") == 0) { ps.Kill(); }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select admin_id,admin_name,image,phone,email,current_address,picture,s,Insert_by as Insert_time,Update_Time from administrator where admin_id='" + textBox13.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            DataGridViewImageColumn image = new DataGridViewImageColumn();
            image = (DataGridViewImageColumn)dataGridView1.Columns[2];
            image.ImageLayout = DataGridViewImageCellLayout.Stretch;
            textBox13.Clear();
            int v, a;
            textBox13.Text = dataGridView1.RowCount.ToString();
            v = int.Parse(textBox13.Text);
            a = v - 1;

            textBox13.Text = a.ToString();
            if (textBox13.Text == "1")
            {
                DataGridViewRow row = this.dataGridView1.Rows[0];

                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
                textBox4.Text = row.Cells[4].Value.ToString();
                textBox5.Text = row.Cells[5].Value.ToString();
                textBox15.Text = row.Cells[7].Value.ToString();

                pictureBox1.ImageLocation = row.Cells[6].Value.ToString();
                textBox13.Clear();
            }
            else
            {
                textBox1.Clear();
                textBox12.Clear();
                textBox11.Clear();
                textBox6.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox15.Clear();
                pictureBox1.ImageLocation = "";
            }
            textBox13.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
                textBox4.Text = row.Cells[4].Value.ToString();
                textBox5.Text = row.Cells[5].Value.ToString();
                textBox15.Text = row.Cells[7].Value.ToString();
                textBox9.Text = row.Cells[6].Value.ToString();
              textBox20.Text= row.Cells[6].Value.ToString();
                pictureBox1.ImageLocation = @"\\\\JISANRAHMAN-PC\New folder\" + textBox20.Text;
                textBox19.Text = @"C:\New folder\" + textBox20.Text;
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox16.Text = DateTime.Now.ToString("MMM dd ,dddd, yyyy hh:mm:ss tt");
            if (textBox1.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to update this item", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                    SqlDataAdapter sda = new SqlDataAdapter("update administrator set s='"+textBox15.Text+"',admin_name='" + textBox2.Text + "', phone='" + textBox3.Text + "', email='" + textBox4.Text + "', current_address='" + textBox5.Text + "', picture='" + textBox20.Text + "',Update_Time='"+textBox16.Text+"' where admin_id='" + textBox1.Text + "'", con);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    SqlConnection conx = new SqlConnection(Properties.Settings.Default._ConnectionString);
                    SqlDataAdapter sdax = new SqlDataAdapter("update appoint set salary='" + textBox15.Text + "' where teacher_id1='" + textBox1.Text + "'", conx);
                    DataTable dtx = new DataTable();
                    sdax.Fill(dtx);
                    dataGridView1.DataSource = dt;
                    button13.PerformClick();
                    textBox13.Text = textBox1.Text;
                    button9.PerformClick();
                    textBox13.Clear();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox15.Clear();
                    pictureBox1.ImageLocation = "";

                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            else { MessageBox.Show("select item for update"); }
           

        }

        private void button12_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("One email send to your admin if you show this password. Are you want? ", "warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Email en = new Email();
                en.textBox7.Text = "admin";
                en.textBox9.Text = "ID " + textBox13.Text + "'s password show";
                en.textBox8.Text = textBox14.Text;
                en.Show();
                en.button22.PerformClick();
                en.Hide();

                Class1 dbaccess = new Class1();
                dbaccess.Login_id = textBox13.Text;


                if (dbaccess.QueryInTable1())
                {


                    MessageBox.Show(dbaccess.Login_password);

                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
           

          
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button9.PerformClick();
        }

        private void textBox15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("update administrator set image=BulkColumn FROM Openrowset( Bulk '" +textBox19.Text+ "', Single_Blob) as blob where admin_id='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox13.Text = comboBox2.Text;
            button9.PerformClick();
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox13.Text = comboBox2.Text;
                button9.PerformClick();
            }
        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {

            System.Diagnostics.Process.Start(@"C:\AITVET\WindowsFormsApplication3.exe");


            

            SqlConnection con = new SqlConnection(Properties.Settings.Default._ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter("select admin_id,admin_name,image,phone,email,current_address,picture,s,Insert_by as Insert_time,Update_Time from administrator where admin_name like '"+comboBox3.Text+ "%' or admin_name like '%" + comboBox3.Text + "%' or admin_name like '%" + comboBox3.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                DataGridViewImageColumn image = new DataGridViewImageColumn();
                image = (DataGridViewImageColumn)dataGridView1.Columns[2];
                image.ImageLayout = DataGridViewImageCellLayout.Stretch;
            Process[] p = Process.GetProcesses();
            foreach (Process ps in p)
            {
                string s = ps.ProcessName;
                s = s.ToLower();
                if (s.CompareTo("windowsformsapplication3") == 0) { ps.Kill(); }
            }

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "";
            textBox1.Clear();
            textBox12.Clear();
            textBox11.Clear();
            textBox6.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox1.Focus();
            textBox9.Clear();
            textBox15.Clear();

            textBox13.Clear();
          
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Class1 dbaccess = new Class1();
            dbaccess.Department_id = "ADMIN";
            dbaccess.Teacher_id1 = textBox1.Text;



            dbaccess.Appoint_date = DateTime.Now.ToString(" MMM dd ,dddd, yyyy ");

            dbaccess.Salary = textBox15.Text;



            if (dbaccess.DataSaveInAppoint()) { }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            
        }
    }
}
