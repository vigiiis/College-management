using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.VisualBasic.Devices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data;
using System.Runtime.Intrinsics.Arm;
using System.Collections;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.Entity.Infrastructure;
using System.Drawing.Text;
using Microsoft.ReportingServices.Diagnostics.Internal;
using System.Reflection.PortableExecutable;
namespace StudentRegistration
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void

        label8_Click(object sender, EventArgs e)
        {

        }

        private void linklabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


        }
        string pattern = "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$";
        private void t5_Leave(object sender, EventArgs e)
        {

        }
        private void t12_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Choose a Photo",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tiff",
                Multiselect = false
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                pictureBox1.ImageLocation = openFileDialog.FileName;

                string filename = Path.GetFileName(openFileDialog.FileName);
                string photoPath = openFileDialog.FileName;
                label8.Text = photoPath;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cString = "Server=hp15s;Database=master;Trusted_connection=True";

            textBox1.Text = string.Empty;
            t1.Text = string.Empty;
            t2.Text = string.Empty;
            t3.Text = string.Empty;
            t4.Text = string.Empty;
            t5.Text = string.Empty;
            t7.Text = string.Empty;
            t10.Text = string.Empty;
            t6.Checked = false;
            r2.Checked = false;
            r3.Checked = false;
            r5.Checked = false;
            r6.Checked = false;
            t9.Checked = false;
            t11.Checked = false;
            c2.Checked = false;
            c1.Checked = false;
            c4.Checked = false;
            t8.Text = " select";
            pictureBox1.Image = null;
            label8.Text = "";
            string newId = GetNextId(cString);
            textBox1.Text = newId;
        }

        private void t4_TextChanged(object sender, EventArgs e)
        {
            if (t4.Text.Length > 10)
            {
                t4.Text = t4.Text.Substring(0, 10);
                t4.SelectionStart = t4.Text.Length;
            }


        }

        private void t4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter student id ");
                return;
            }
            string enteredIdText = textBox1.Text;
            if (int.TryParse(enteredIdText, out int enteredId))
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["ID"].Value != null) // Replace "ID" with your actual column name
                    {
                        int existingId = Convert.ToInt32(row.Cells["ID"].Value);
                        if (existingId == enteredId)
                        {
                            MessageBox.Show("The ID already exists in the table. Please enter a unique ID.",
                                            "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
            if (t1.Text == "")
            {
                MessageBox.Show("Enter name");
                t1.Focus();
                return;
            }
            /*if (t2.Text == "")
            {
                MessageBox.Show("Enter Father's name");
                t2.Focus();
                return;
            }
            if (t3.Text == "")
            {
                MessageBox.Show("Enter Mother's name");
                t3.Focus();
                return;
            }*/
            if (t4.Text == "")
            {
                MessageBox.Show("Enter Phone Number");
                t4.Focus();
                return;
            }
            if (t5.Text == "")
            {
                MessageBox.Show("Enter Email");
                t5.Focus();
                return;


            }
            if (Regex.IsMatch(t5.Text, pattern) == false)
            {
                t5.Focus();
                errorProvider1.SetError(this.t5, "email invalid");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (((t6.Checked) || (r2.Checked) || (r3.Checked)))
            {

            }
            else
            {
                MessageBox.Show("select gender");
                gb3.Focus();
                return;
            }
            if (t7.Text == "")
            {
                MessageBox.Show("Enter address");
                t7.Focus();
                return;
            }
            if (t8.Text == " select")
            {
                MessageBox.Show("Select blood group");
                t8.Focus();
                return;
            }

            if (((t9.Checked) || (r5.Checked) || (r6.Checked)))
            {

            }
            else
            {
                MessageBox.Show("select department");
                groupBox1.Focus();
                return;
            }
            if (DateTime.Today.AddYears(-3) < t10.Value.Date && t10.Value.Date > DateTime.Today.AddYears(-100))
            {
                MessageBox.Show("student is at least of 3 years old ");
                t10.Focus();
                return;
            }
            if ((t11.Checked) || (c2.Checked) || (c4.Checked) || (c1.Checked))
            {

            }
            else
            {
                MessageBox.Show("Please select course");
                gb4.Focus();
                return;
            }
            if (label8.Text == "")
            {
                MessageBox.Show("Please upload photo");
                t12.Focus();
                return;
            }

            string connectionString = "Server=hp15s;Database=master;Trusted_connection=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string id = textBox1.Text;
            string name = t1.Text;
            string fname = t2.Text;
            string mname = t3.Text;
            string pn = t4.Text;
            string eml = t5.Text;
            string dob = t10.Text;
            string gndr = t6.Checked ? "male" :
                r2.Checked ? "female" :
                "other";
            string adr = t7.Text;
            string bg = t8.Text;
            string dept = t9.Checked ? "CSE" :
                r5.Checked ? "EEE" :
                "BBA";
            string crse = "";
            if (c1.Checked)
                crse += "python";
            if (c2.Checked)
                crse += "c++";
            if (t11.Checked)
                crse += " C";
            if (c4.Checked)
                crse += "java";
            string phto = label8.Text;
            string Query = " insert into student4( ID , name, FatherName, MotherName, phoneNo, email, gender, DOB, Addr, bloodGroup, dept, course, photo) values( '" + id + "','" + name + "', '" + fname + "', '" + mname + "', '" + pn + "', '" + eml + "', '" + gndr + "', '" + dob + "','" + adr + "', '" + bg + "', '" + dept + "', '" + crse + "', '" + phto + "' )";

            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();

            if (Regex.IsMatch(t5.Text, pattern) == false)
            {
                t5.Focus();
                errorProvider1.SetError(this.t5, "email invalid");
            }
            else
            {
                errorProvider1.Clear();
            }
            getData();
            con.Close();
            MessageBox.Show("data submitted");
            textBox1.Text = string.Empty;
            t1.Text = string.Empty;
            t2.Text = string.Empty;
            t3.Text = string.Empty;
            t4.Text = string.Empty;
            t5.Text = string.Empty;
            t5.Text = string.Empty;
            t7.Text = string.Empty;
            t10.Text = string.Empty;
            t8.Text = string.Empty;
            t6.Checked = false;
            r2.Checked = false;
            r3.Checked = false;
            r5.Checked = false;
            r6.Checked = false;
            t9.Checked = false;
            t11.Checked = false;
            c2.Checked = false;
            c1.Checked = false;
            c4.Checked = false;
            pictureBox1.Image = null;
            label8.Text = "";
            string cString = "Server=hp15s;Database=master;Trusted_connection=True";
            string newId = GetNextId(cString);
            textBox1.Text = newId;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            getData();
            datatab1();
            teacherload();
            subload();
            classload();
            suboptions();
            classoption();


        }
        private void classoption()
        {
            string connectionString = "Server=hp15s;Database=master;Trusted_connection=True";
            string newId = GetNextId(connectionString);
            textBox1.Text = newId;
            //
            string conforteacher = "Server=hp15s;Database=master;Trusted_connection=True";
            string nId = NextId(conforteacher);
            textBox5.Text = nId;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select*from classInfo", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "ClassName";
            //comboBox2.DataSource = dt;
            //comboBox2.DisplayMember = "course";

            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            //dep.SelectedIndex = -1;
            classlabel.Text = "select class";
            subjectlabel.Text = "select subject";
        }
        private void suboptions()
        {
            string connectionString = "Server=hp15s;Database=master;Trusted_connection=True";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select*from subjectInfo", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Subject_Name";
        }
        private string NextId(string connectionString)
        {
            int maxId = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT MAX(teacherId) FROM teacherDetail ";
                    SqlCommand cmd = new SqlCommand(query, conn);


                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        maxId = Convert.ToInt32(result);
                    }

                    int nId = maxId + 1;
                    return nId.ToString("D3");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving ID from database: " + ex.Message);
                    return string.Empty;
                }
            }

        }

        private string GetNextId(string connectionString)
        {
            int maxId = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT MAX(ID) FROM student4 ";
                    SqlCommand cmd = new SqlCommand(query, conn);


                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        maxId = Convert.ToInt32(result);
                    }

                    int newId = maxId + 1;
                    return newId.ToString("D4");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving ID from database: " + ex.Message);
                    return string.Empty;
                }
            }

        }

        private void sudentId()
        {

        }

        private void first()
        {
            string connectionString = "Server=hp15s;Database=master;Trusted_connection=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            string Query = "select*from student4";
            SqlCommand cmd = new SqlCommand(Query, con);
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void getData()
        {
            string connectionString = "Server=hp15s;Database=master;Trusted_connection=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            string Query = "select*from student4";
            SqlCommand cmd = new SqlCommand(Query, con);
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;

            con.Close();

        }

        private void t10_ValueChanged(object sender, EventArgs e)
        {
        }

        private void t1_Leave(object sender, EventArgs e)
        {

        }

        private void t2_Leave(object sender, EventArgs e)
        {

        }

        private void t3_Leave(object sender, EventArgs e)
        {

        }

        private void t4_Leave(object sender, EventArgs e)
        {

        }

        private void t7_Leave(object sender, EventArgs e)
        {

        }

        private void t8_Leave(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[14].Value.ToString();
                t1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                t2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                t3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                t4.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                t5.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                string gender = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();

                if (gender == "male")
                {
                    t6.Checked = true;
                }
                else if (gender == "female")
                {
                    r2.Checked = true;
                }
                else if (gender == "transgender")
                {
                    r3.Checked = true;
                }
                t7.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                t8.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();

                string dept = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                if (dept == "CSE")
                {
                    t9.Checked = true;
                }
                else if (dept == "BBA")
                {
                    r6.Checked = true;
                }
                else if (dept == "EEE")
                {
                    r5.Checked = true;
                }
                string dateValue = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();

                if (DateTime.TryParse(dateValue, out DateTime dob))
                {
                    t10.Value = dob;
                }
                string photoPath = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();

                if (!string.IsNullOrEmpty(photoPath) && System.IO.File.Exists(photoPath))
                {
                    pictureBox1.Image = Image.FromFile(photoPath);
                    label8.Text = photoPath;
                }
                string course = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
                t11.Checked = course.Contains(" C");
                c1.Checked = course.Contains("python");
                c2.Checked = course.Contains("c++");
                c4.Checked = course.Contains("java");
                if (!isEditMode)
                {
                    EnableFormFields(true);
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button4.Enabled = true;

                    isEditMode = true;
                    isViewMode = false;


                }
                else
                {
                    EnableFormFields(true);

                }
            }
            if (e.ColumnIndex == 1 && e.RowIndex > -1)
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[14].Value.ToString();
                t1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                t2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                t3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                t4.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                t5.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                string gender = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();

                if (gender == "male")
                {
                    t6.Checked = true;
                }
                else if (gender == "female")
                {
                    r2.Checked = true;
                }
                else if (gender == "transgender")
                {
                    r3.Checked = true;
                }
                t7.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                t8.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();

                string dept = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                if (dept == "CSE")
                {
                    t9.Checked = true;
                }
                else if (dept == "BBA")
                {
                    r6.Checked = true;
                }
                else if (dept == "EEE")
                {
                    r5.Checked = true;
                }
                string dateValue = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();

                if (DateTime.TryParse(dateValue, out DateTime dob))
                {
                    t10.Value = dob;
                }
                string photoPath = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();

                if (!string.IsNullOrEmpty(photoPath) && System.IO.File.Exists(photoPath))
                {
                    pictureBox1.Image = Image.FromFile(photoPath);
                    label8.Text = photoPath;
                }
                string course = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
                t11.Checked = course.Contains(" C");
                c1.Checked = course.Contains("python");
                c2.Checked = course.Contains("c++");
                c4.Checked = course.Contains("java");
                if (!isViewMode)
                {
                    EnableFormFields(false);
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button4.Enabled = false;

                    isEditMode = false;
                    isViewMode = false;


                }
                else
                {
                    EnableFormFields(false);

                }
            }

        }

        private void t1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(t1.Text, "^[a-zA-Z -']+$"))
            {

            }
            else
            {

                t1.Clear();
                t1.Text.Remove(t1.Text.Length - 0);
                t1.Clear();
                t1.Focus();
            }
        }

        private void t1_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void t1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void t2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(t2.Text, "^[a-zA-Z -']+$"))
            {

            }
            else
            {

                t2.Text.Remove(t2.Text.Length - 0);

                t2.Focus();
            }
        }

        private void t3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(t1.Text, "^[a-zA-Z -']+$"))
            {

            }
            else
            {

                t3.Text.Remove(t3.Text.Length - 0);

                t3.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string cString = "Server=hp15s;Database=master;Trusted_connection=True";

            string connectionString = "Server=hp15s;Database=master;Trusted_connection=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string id = textBox1.Text;
            string name = t1.Text;
            string fname = t2.Text;
            string mname = t3.Text;
            string pn = t4.Text;
            string eml = t5.Text;
            string dob = t10.Text;
            string gndr = t6.Checked ? "male" :
                r2.Checked ? "female" :
                "other";
            string adr = t7.Text;
            string bg = t8.Text;
            string dept = t9.Checked ? "CSE" :
                r5.Checked ? "EEE" :
                "BBA";
            string crse = "";
            if (c1.Checked)
                crse += "python";
            if (c2.Checked)
                crse += "c++";
            if (t11.Checked)
                crse += "c";
            if (c4.Checked)
                crse += "java";
            string phto = label2.Text;
            string query = "delete from student4 where ID ='" + id + "' ";
            SqlCommand cmd = new SqlCommand(query, con);

            //cmd.Parameters.AddWithValue("name", name);
            cmd.ExecuteNonQuery();



            con.Close();
            getData();
            textBox1.Text = string.Empty;
            t1.Text = string.Empty;
            t2.Text = string.Empty;
            t3.Text = string.Empty;
            t4.Text = string.Empty;
            t5.Text = string.Empty;
            t5.Text = string.Empty;
            t7.Text = string.Empty;
            t10.Text = string.Empty;
            t8.Text = " select";
            t6.Checked = false;
            r2.Checked = false;
            r3.Checked = false;
            r5.Checked = false;
            r6.Checked = false;
            t9.Checked = false;
            t11.Checked = false;
            c2.Checked = false;
            c1.Checked = false;
            c4.Checked = false;
            pictureBox1.Image = null;
            label8.Text = "";
            string newId = GetNextId(cString);
            textBox1.Text = newId;

        }

        private void gb3_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = string.Empty;
            t1.Text = string.Empty;
            t2.Text = string.Empty;
            t3.Text = string.Empty;
            t4.Text = string.Empty;
            t5.Text = string.Empty;
            t7.Text = string.Empty;
            t10.Text = string.Empty;
            t6.Checked = false;
            r2.Checked = false;
            r3.Checked = false;
            r5.Checked = false;
            r6.Checked = false;
            t9.Checked = false;
            t11.Checked = false;
            c2.Checked = false;
            c1.Checked = false;
            c4.Checked = false;
            t8.Text = " select";
            pictureBox1.Image = null;
            label8.Text = "";
        }
        bool isEditMode = false;
        bool isViewMode = true;
        private void EnableFormFields(bool enable)
        {
            textBox1.Enabled = enable;
            t1.Enabled = enable;
            t1.Enabled = enable;
            t2.Enabled = enable;
            t3.Enabled = enable;
            t4.Enabled = enable;
            t5.Enabled = enable;
            t6.Enabled = enable;
            r2.Enabled = enable;
            r3.Enabled = enable;
            t7.Enabled = enable;
            t8.Enabled = enable;
            r5.Enabled = enable;
            r6.Enabled = enable;
            t7.Enabled = enable;
            t9.Enabled = enable;
            t12.Enabled = enable;
            t10.Enabled = enable;
            t11.Enabled = enable;
            c1.Enabled = enable;
            c2.Enabled = enable;
            c4.Enabled = enable;
        }



        private void edit_Click(object sender, EventArgs e)
        {

        }

        private void view_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string cString = "Server=hp15s;Database=master;Trusted_connection=True";

            textBox1.Text = string.Empty;
            t1.Text = string.Empty;
            t2.Text = string.Empty;
            t3.Text = string.Empty;
            t4.Text = string.Empty;
            t5.Text = string.Empty;
            t7.Text = string.Empty;
            t10.Text = string.Empty;
            t6.Checked = false;
            r2.Checked = false;
            r3.Checked = false;
            r5.Checked = false;
            r6.Checked = false;
            t9.Checked = false;
            t11.Checked = false;
            c2.Checked = false;
            c1.Checked = false;
            c4.Checked = false;
            t8.Text = " select";
            pictureBox1.Image = null;
            label8.Text = "";
            if (!isEditMode)
            {
                EnableFormFields(true);
                button1.Enabled = true;
                button2.Enabled = true;
                button4.Enabled = true;

                isEditMode = true;
                isViewMode = false;


            }
            else
            {
                EnableFormFields(true);

            }
            string newId = GetNextId(cString);
            textBox1.Text = newId;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {   
            //this.Hide();
            Form2 form2 = new Form2();
            this.Hide();
            //form2.MdiParent = this;
            //this.Hide();
            
            // Show the child form
            form2.Show();
           // form2.BringToFront();
            //tabControl1.Hide();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void eml_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (textBox3.Text == "")
            {
                MessageBox.Show("all fields are necessary");
                t8.Focus();
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("all fields are necessary");
                t8.Focus();
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("all fields are necessary");
                t8.Focus();
                return;
            }
            if (textBox3.Text == textBox4.Text)
            {

            }
            else
            {
                MessageBox.Show("password and confirm password are not same");
                return;
            }
            string connectionString = "Server=hp15s;Database=master;Trusted_connection=True";
            SqlConnection con = new SqlConnection(connectionString);
            string label9 = textBox2.Text;
            string label11 = textBox4.Text;
            string label10 = textBox3.Text;
            con.Open();
            string query = "insert into userD( userID, password, cpass) values ('" + label9 + "' , '" + label11 + "' , '" + label10 + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            datatab1();
            MessageBox.Show(" registered successfully");
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            con.Close();
            tabPage2.Focus();

        }

        private void datatab1()
        {
            string connectionString = "Server=hp15s;Database=master;Trusted_connection=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            string Query = "select*from userD";
            SqlCommand cmd = new SqlCommand(Query, con);
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView2.DataSource = dt;


            con.Close();
        }

        public class User
        {
            public int UserID { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }
        private User GetUserById(int userID)
        {
            string connectionString = "Server=hp15s;Database=master;Trusted_connection=True";
            SqlConnection con = new SqlConnection(connectionString);
            string userId = label9.Text;
            string query = "SELECT * FROM userD WHERE Uername='" + userId + "'";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {

                con.Open();
                var reader = cmd.ExecuteReader();

                User user = null;
                if (reader.Read())
                {
                    user = new User
                    {
                        UserID = (int)reader["UserID"],
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"].ToString()
                    };
                }
                con.Close();
                return user;
            }


        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("please select user");
                t8.Focus();
                return;

            }

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string userID = textBox2.Text.Trim();
            string confirmPassword = textBox3.Text.Trim();
            string password = textBox4.Text.Trim();
            if (textBox3.Text == "")
            {
                MessageBox.Show("all fields are necessary");
                t8.Focus();
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("all fields are necessary");
                t8.Focus();
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("all fields are necessary");
                t8.Focus();
                return;
            }
            if (textBox3.Text == textBox4.Text)
            {

            }
            else
            {
                MessageBox.Show("password and confirm password are not same");
                return;
            }
            bool userExits = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value?.ToString() == userID)
                {

                    userExits = true;

                    row.Cells[1].Value = password;
                    row.Cells[2].Value = confirmPassword;
                    string connectionString = "Server=hp15s;Database=master;Trusted_connection=True";
                    SqlConnection con = new SqlConnection(connectionString);
                    string query = " UPDATE userD SET password = '" + password + "', cpass='" + confirmPassword + "'WHERE userID ='" + userID + "'; ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("user updated");
                    return;

                }

            }

            if (!userExits)
            {
                string connectionString = "Server=hp15s;Database=master;Trusted_connection=True";
                SqlConnection con = new SqlConnection(connectionString);
                string label9 = textBox2.Text;
                string label11 = textBox4.Text;
                string label10 = textBox3.Text;
                con.Open();
                string query = "insert into userD( userID, password, cpass) values ('" + label9 + "' , '" + label11 + "' , '" + label10 + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
                con.Close();
                tabPage2.Focus();
                datatab1();
                MessageBox.Show("New user saved successfully!");
            }





        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=hp15s;Database=master;Trusted_connection=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string label9 = textBox2.Text;
            string query = "delete from userD where userID ='" + label9 + "' ";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.ExecuteNonQuery();
            datatab1();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {



            DataGridViewRow selectedRow = dataGridView2.Rows[e.RowIndex];
            if (selectedRow != null && selectedRow.Cells.Count > 1)
            {
                textBox2.Text = selectedRow.Cells[0].Value.ToString();
                textBox3.Text = selectedRow.Cells[1].Value.ToString();
                textBox4.Text = selectedRow.Cells[2].Value.ToString();
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

            if (textBox5.Text == "")
            {
                MessageBox.Show("Enter student id ");
                return;
            }
            string enteredIdText = textBox5.Text;
            if (int.TryParse(enteredIdText, out int enteredId))
            {
                foreach (DataGridViewRow row in dvt.Rows)
                {
                    if (row.Cells["teacherId"].Value != null)
                    {
                        int existingId = Convert.ToInt32(row.Cells["teacherId"].Value);
                        if (existingId == enteredId)
                        {
                            MessageBox.Show("The ID already exists in the table. Please enter a unique ID.",
                                            "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
            if (textBox7.Text == "")
            {
                MessageBox.Show("Enter your name");
                textBox7.Focus();
                return;
            }
            if (textBox6.Text == "")
            {
                MessageBox.Show("Contact number required");
                textBox6.Focus();
                return;
            }
            if ((rb1.Checked) || (rb2.Checked))
            {

            }
            else
            {
                MessageBox.Show("select gender");
                gb3.Focus();
                return;
            }
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Enter Subject Name");
                comboBox1.Focus();
                return;
            }
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Enter Class");
                comboBox2.Focus();
                return;
            }
            if (emailbox.Text == "")
            {

            }
            else
            {
                string pattern = "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$";
                if (Regex.IsMatch(emailbox.Text, pattern) == false)
                {
                    emailbox.Focus();
                    errorProvider2.SetError(this.emailbox, "email invalid");
                    return;
                }
                else
                {
                    errorProvider2.Clear();
                }

            }

            if (DateTime.Today.AddYears(-25) < dateTimePicker2.Value.Date && dateTimePicker2.Value.Date > DateTime.Today.AddYears(-100))
            {
                MessageBox.Show(" Teacher should be 25 years old ");
                dateTimePicker2.Focus();
                return;
            }

            string connectionString = "Server=hp15s;Database=master;Trusted_connection=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string tid = textBox5.Text;
            string nam = textBox7.Text;
            string cn = textBox6.Text;
            string emlT = emailbox.Text;
            string dateB = dateTimePicker2.Text;
            string adrs = textBox9.Text;
            string doj = dateTimePicker1.Text;
            string gendr = rb1.Checked ? "Male" :
                "Female";
            string sub = comboBox2.Text;
            string classs = comboBox1.Text;


            string Query = " insert into teacherDetail( teacherId ,Name, ContactNo, Email, Dob, DateOfJoining, Address, Gender, Subject, Class) values( '" + tid + "','" + nam + "', '" + cn + "', '" + emlT + "', '" + dateB + "', '" + doj + "', '" + adrs + "', '" + gendr + "','" + sub + "', '" + classs + "')";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();
            teacherload();
            con.Close();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            emailbox.Clear();
            dateTimePicker1.Text = string.Empty;
            dateTimePicker2.Text = string.Empty;
            textBox9.Text = string.Empty;
            rb1.Checked = false;
            rb2.Checked = false;
            string conforteacher = "Server=hp15s;Database=master;Trusted_connection=True";
            string nId = NextId(conforteacher);
            textBox5.Text = nId;
            classlabel.Text = "select class";
            subjectlabel.Text = "select subject";
        }
        private void teacherload()
        {
            string connectionString = "Server=hp15s;Database=master;Trusted_connection=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string Query = "select*from teacherDetail order by teacherId";
            SqlCommand cmd = new SqlCommand(Query, con);
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dvt.DataSource = dt;
        }
        private void tabPage3_Click(object sender, EventArgs e)
        {
            textBox5.Focus();
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox5.Focus();
        }

        private void button12_Click(object sender, EventArgs e)
        {

            teacherload();

            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            emailbox.Clear();
            dateTimePicker1.Text = string.Empty;
            dateTimePicker2.Text = string.Empty;
            textBox9.Text = string.Empty;
            rb1.Checked = false;
            rb2.Checked = false;
            string conforteacher = "Server=hp15s;Database=master;Trusted_connection=True";
            string nId = NextId(conforteacher);
            textBox5.Text = nId;
            classlabel.Text = "select class";
            subjectlabel.Text = "select subject";
        }

        private void dvt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dvt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dvt.Rows[e.RowIndex];
            if (selectedRow != null && selectedRow.Cells.Count > 1)
            {
                textBox5.Text = selectedRow.Cells[0].Value.ToString();
                textBox7.Text = selectedRow.Cells[1].Value.ToString();
                textBox6.Text = selectedRow.Cells[2].Value.ToString();
                dateTimePicker1.Text = selectedRow.Cells[5].Value.ToString();
                dateTimePicker2.Text = selectedRow.Cells[4].Value.ToString();
                comboBox2.Text = selectedRow.Cells[8].Value.ToString();
                comboBox1.Text = selectedRow.Cells[9].Value.ToString();
                textBox9.Text = selectedRow.Cells[6].Value.ToString();
                emailbox.Text = selectedRow.Cells[3].Value.ToString();
                string gend = selectedRow.Cells[7].Value.ToString();
                if (gend == "Male")
                {
                    rb1.Checked = true;
                }
                else if (gend == "Female")
                {
                    rb2.Checked = true;
                }
                classlabel.Text = "";
                subjectlabel.Text = "";
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=hp15s;Database=master;Trusted_connection=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string lab = textBox5.Text;
            string query = "delete teacherDetail where teacherId = '" + lab + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            reasignid();
            teacherload();
            //con.Close();
            string conforteacher = "Server=hp15s;Database=master;Trusted_connection=True";
            string nId = NextId(conforteacher);
            textBox5.Text = nId;

            teacherload();
            con.Close();

            comboBox1.Text = string.Empty;
            comboBox2.Text = string.Empty;
            //dataGridView_UserDeletingRow(sender);
            teacherload();

            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            emailbox.Clear();
            dateTimePicker1.Text = string.Empty;
            dateTimePicker2.Text = string.Empty;
            textBox9.Text = string.Empty;
            rb1.Checked = false;
            rb2.Checked = false;

            textBox5.Text = nId;
            classlabel.Text = "select class";
            subjectlabel.Text = "select subject";

        }


        private void button13_Click(object sender, EventArgs e)
        {
            string tid = textBox5.Text;
            string nam = textBox7.Text;
            string cn = textBox6.Text;
            string emlT = emailbox.Text;
            string dateB = dateTimePicker2.Text;
            string adrs = textBox9.Text;
            string doj = dateTimePicker1.Text;
            string gendr = rb1.Checked ? "Male" :
                "Female";
            string sub = comboBox1.Text;
            string classs = comboBox2.Text;

            string query = "update  teacherDetail set teacherId='" + tid + "' , Name='" + nam + "', ContactNo='" + cn + "' , Email='" + emlT + "' , Dob ='" + dateB + "' , DateOfJoining='" + doj + "' , Address='" + adrs + "' , Gender = '" + gendr + "' , Subject='" + sub + "' , Class='" + classs + "'   where teacherId='" + tid + "'  ";
            string connectionString = "Server=hp15s;Database=master;Trusted_connection=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            teacherload();
            con.Close();
            teacherload();
            string conforteacher = "Server=hp15s;Database=master;Trusted_connection=True";
            string nId = NextId(conforteacher);
            textBox5.Text = nId;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string connectionString = "server=hp15s;Database=master;Trusted_connection=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string tid = textBox5.Text;
            string nam = textBox7.Text;
            string cn = textBox6.Text;
            string emlT = emailbox.Text;
            string dateB = dateTimePicker2.Text;
            string adrs = textBox9.Text;
            string doj = dateTimePicker1.Text;
            string gendr = rb1.Checked ? "Male" :
                "Female";
            string sub = comboBox2.Text;
            string classs = comboBox2.Text;
            SqlCommand cmd = new SqlCommand("select*from teacherDetail where teacherId LIKE '" + tid + "'+'%' or Name LIKE'" + nam + "'+'%' ", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            // teacherload();
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dvt.DataSource = dt;
            connection.Close();
            // teacherload();

        }
        private void subload()
        {
            string connectionString = "Server=hp15s;Database=master;Trusted_connection=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string Query = "select*from subjectInfo";
            SqlCommand cmd = new SqlCommand(Query, con);
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView4.DataSource = dt;
        }
        private void classload()
        {
            string connectionString = "Server=hp15s;Database=master;Trusted_connection=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string Query = "select * from classInfo";
            SqlCommand cmd = new SqlCommand(Query, con);
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView3.DataSource = dt;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (textBox12.Text == "" && textBox8.Text == "")
            {
                MessageBox.Show("enter all the fields ");
                return;
            }
            string connectionString = "server=hp15s;Database=master;Trusted_connection=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string sun = textBox8.Text;
            string suc = textBox12.Text;
            string query = "insert into subjectInfo (Subject_Name , Sub_code) values ( '" + sun + "', '" + suc + "')";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            // cmd.ExecuteNonQuery();
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView4.DataSource = dt;
            connection.Close();
            subload();
            MessageBox.Show("data submitted");
            suboptions();
            classoption();
            textBox8.Text = string.Empty;
            textBox12.Text = string.Empty;

        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "" && textBox11.Text == "")
            {
                MessageBox.Show("enter all the fields ");
                return;
            }
            string connectionString = "server=hp15s;Database=master;Trusted_connection=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string classN = textBox10.Text;
            string classI = textBox11.Text;
            string query = "insert into classInfo (ClassName ,ClassId) values('" + classN + "', '" + classI + "')";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            // cmd.ExecuteNonQuery();
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView3.DataSource = dt;
            connection.Close();
            classload();
            MessageBox.Show("data submitted");
            suboptions();
            classoption();
            textBox10.Text = string.Empty;
            textBox11.Text = string.Empty;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
            {
                MessageBox.Show("enter class name ");
                return;
            }
            using (SqlConnection connection = new SqlConnection("server=hp15s;Database=master;Trusted_connection=True"))
            {
                connection.Open();
                string labe = textBox10.Text;
                string query = "SELECT 1 FROM teacherDetail WHERE Class = '" + labe + "'";
                SqlCommand command = new SqlCommand(query, connection);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    MessageBox.Show("The class is selected by teacher master.");
                }
                else
                {

                    string connectionString = "server=hp15s;Database=master;Trusted_connection=True";
                    SqlConnection connectio = new SqlConnection(connectionString);
                    connectio.Open();
                    string classN = textBox10.Text;
                    string classI = textBox11.Text;
                    string Query = "delete from classInfo where ClassName='" + classN + "';";
                    SqlCommand cmd = new SqlCommand(Query, connectio);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    // cmd.ExecuteNonQuery();
                    var reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dataGridView3.DataSource = dt;
                    connectio.Close();
                    classload();
                    dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    MessageBox.Show("data deleted");
                    suboptions();
                    classoption();
                    textBox10.Text = string.Empty;
                    textBox11.Text = string.Empty;
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                MessageBox.Show("enter subject name ");
                return;
            }
            using (SqlConnection connection = new SqlConnection("server=hp15s;Database=master;Trusted_connection=True"))
            {
                connection.Open();
                string labe = textBox8.Text;
                string query = "SELECT 1 FROM teacherDetail WHERE Subject = '" + labe + "'";
                SqlCommand command = new SqlCommand(query, connection);


                object result = command.ExecuteScalar();

                if (result != null)
                {
                    MessageBox.Show("The subject is selected by teacher master.");
                }
                else
                {
                    string connectionString = "server=hp15s;Database=master;Trusted_connection=True";
                    SqlConnection connectio = new SqlConnection(connectionString);
                    connectio.Open();
                    string sun = textBox8.Text;

                    string Query = "delete from subjectInfo where Subject_Name='" + sun + "';";
                    SqlCommand cmd = new SqlCommand(Query, connectio);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    // cmd.ExecuteNonQuery();
                    var reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dataGridView4.DataSource = dt;
                    subload();
                    connectio.Close();
                    dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    //classload();
                    MessageBox.Show("data deleted");
                    suboptions();
                    classoption();
                    textBox8.Text = string.Empty;
                    textBox12.Text = string.Empty;
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {

            }
            else
            {
                classlabel.Text = "";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox2.SelectedIndex == -1)
            {

            }
            else
            {
                subjectlabel.Text = "";
            }
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (comboBox2.SelectedIndex == 0)
            {

            }
            else
            {
                subjectlabel.Text = "";
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (comboBox1.SelectedIndex == 0)
            {

            }
            else
            {
                classlabel.Text = "";
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox10.Text = string.Empty;
            textBox11.Text = string.Empty;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox8.Text = string.Empty;
            textBox12.Text = string.Empty;
        }
        private void reasignid()
        {
            string query = "WITH CTE AS (\r\n    SELECT \r\n        TeacherId, \r\n        ROW_NUMBER() OVER (ORDER BY TeacherId) AS NewID\r\n    FROM teacherDetail\r\n)\r\nUPDATE teacherDetail\r\nSET TeacherID = CTE.NewID\r\nFROM teacherDetail\r\nINNER JOIN CTE ON teacherDetail.TeacherID = CTE.TeacherID;";
            string connectionString = "server=hp15s;Database=master;Trusted_connection=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            string Query = " SELECT * FROM teacherDetail ORDER BY teacherId; ";
            SqlCommand md = new SqlCommand(Query, connection);
            md.ExecuteNonQuery();
            connection.Close();
            teacherload();
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView4.Rows[e.RowIndex];
            if (selectedRow != null && selectedRow.Cells.Count > 1)
            {
                textBox8.Text = selectedRow.Cells[0].Value.ToString();
                textBox12.Text = selectedRow.Cells[1].Value.ToString();

            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView3.Rows[e.RowIndex];
            if (selectedRow != null && selectedRow.Cells.Count > 1)
            {
                textBox10.Text = selectedRow.Cells[0].Value.ToString();
                textBox11.Text = selectedRow.Cells[1].Value.ToString();
                
            }
        }
    }
}




