using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GYM_Management
{
    public partial class Home : Form
    {

        cdmember cm = new cdmember();
        Trainers tn = new Trainers();
        Update_plan up = new Update_plan();
        SqlConnection con;
        SqlDataAdapter sdr;
        String cs = "Data Source = LAPTOP-JOVFRCUT\\SQLEXPRESS; database =  GYM_mng; integrated security = true";
        public Home()
        {
            InitializeComponent();
        }





        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void aDDMEMBERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cm.Show();
            this.Hide();

        }

        private void dELETEMEMBERToolStripMenuItem_Click(object sender, EventArgs e)
        {

            cm.Show();
            this.Hide();
        }

        private void aDDMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tn.Show();
            this.Hide();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            menuStrip1.BackColor = Color.FromArgb(200, 255, 255, 255);

            dataGridView1.Visible = false;


        }

        private void uPDATEPLANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            up.Show();
            this.Hide();
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }

        private void aLLCLIENTSToolStripMenuItem_Click(object sender, EventArgs e)
        {

            String query = "Select * from Client_table";
            dataGridView1.Visible = true;

            using (con = new SqlConnection(cs))
            {
                sdr = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                con.Open();
                sdr.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

            }
        }

        private void fEEPENDINGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String query = "select * from Client_table where month(fee_expiring_date) = month(getdate()) and year(fee_expiring_date) = month(getdate())";
            dataGridView1.Visible = true;

            using (con = new SqlConnection(cs))
            {
                sdr = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                con.Open();
                sdr.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }

        }

        private void sEARCHTRAINERSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aLLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String query = "select * from Trainers";
            dataGridView1.Visible = true;

            using (con = new SqlConnection(cs))
            {
                sdr = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                con.Open();
                sdr.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
        }

        private void sALARYPENDINGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String query = "select * from Trainers where month(Date_join) = month(getdate()) and year(Date_join) = month(getdate())";
            dataGridView1.Visible = true;

            using (con = new SqlConnection(cs))
            {
                sdr = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                con.Open();
                sdr.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
        }

        private void cLASSESOVERSIGHTToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aMToolStripMenuItem_Click(object sender, EventArgs e)
        {

            dataGridView1.Visible = true;

            // SQL query to retrieve combined data from client and trainer tables where classes are in the morning
            string query = @"
            SELECT 
                c.Client_ID,
                c.Full_name,
                c.Classes,
                t.Trainer_ID,
                t.Full_name
            FROM 
                Client_table c
            INNER JOIN 
                Trainers t ON c.Trainer_ID = t.Trainer_ID
            WHERE 
                c.Classes = 'Morning';";

            // Using SqlConnection and SqlDataAdapter to fill a DataTable
            using (SqlConnection conn = new SqlConnection(cs))
            {
                sdr= new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                sdr.Fill(dt);

                // Bind the DataTable to the DataGridView
                dataGridView1.DataSource = dt;
            }
            }
        }
    }



