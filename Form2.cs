using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.Diagnostics.Internal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StudentRegistration
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            
            string connectionString = "server=hp15s;Database=master;Trusted_connection=True";
            SqlConnection connection = new SqlConnection(connectionString);
            string labe = dep.Text; string label = dep.Text; string label2 = comboBox1.Text;
            string label1 = comboBox2.Text;
            SqlCommand cmd = new SqlCommand("select*from student4", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.ReportPath = @"C:\Users\ADMIN\source\repos\WindowsFormsApp2\WindowsFormsApp2\Report1.rdlc";
            reportViewer1.LocalReport.DataSources.Add(source);
            reportViewer1.RefreshReport();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "name";
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember =  "course";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            dep.SelectedIndex = -1;
            label5.Text = "select";
            label4.Text = "select";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
            
        }

        string connectionString = "server=hp15s;Database=master;Trusted_connection=True";
        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "server=hp15s;Database=master;Trusted_connection=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string label1 = comboBox2.Text;
            string label = comboBox1.Text;
            string label2 = dep.Text;
            SqlCommand cmd = new SqlCommand("select*from student4 where name LIKE '" + label + "'+'%' and course LIKE'" + label1 + "'+'%' and dept LIKE'" + label2 + "' +'%' ", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.ReportPath = @"C:\Users\ADMIN\source\repos\WindowsFormsApp2\WindowsFormsApp2\Report1.rdlc";
            reportViewer1.LocalReport.DataSources.Add(source);
            reportViewer1.RefreshReport();
            connection.Close();
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {



        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = "server=hp15s;Database=master;Trusted_connection=True";
            SqlConnection connection = new SqlConnection(connectionString);
            string labe = comboBox1.Text; string label = dep.Text; string label2 = comboBox1.Text;
            string label1 = comboBox2.Text;
            SqlCommand cmd = new SqlCommand("select*from student4", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.ReportPath = @"C:\Users\ADMIN\source\repos\WindowsFormsApp2\WindowsFormsApp2\Report1.rdlc";
            reportViewer1.LocalReport.DataSources.Add(source);
            reportViewer1.RefreshReport();
            comboBox1.Text = "";
            dep.Text = "";
            comboBox2.Text = "";
            ll.Text = "select";
            label5.Text = "select";
            label4.Text = "select";


        }

        private void dep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dep.SelectedIndex == -1)
            {

            }
            else
            {
                ll.Text = "";
            }


        }

        private void dep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dep.SelectedIndex == 0)
            {

            }
            else
            {
                ll.Text = "";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox2.SelectedIndex == -1)
            {

            }
            else
            {
                label4.Text = "";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == -1)
            {

            }
            else
            {
                label5.Text = "";
            }
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (comboBox2.SelectedIndex == 0)
            {

            }
            else
            {
                label4.Text = "";
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (comboBox1.SelectedIndex == 0)
            {

            }
            else
            {
                label5.Text = "";
            }
        }
    }
}
