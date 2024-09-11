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


    
    public partial class Update_plan : Form
    {
        SqlConnection con;



        public Update_plan()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {   
            String name = textBox1.Text;
            int Client_ID = Convert.ToInt32(textBox2.Text);
            DateTime dt = Convert.ToDateTime(dateTimePicker1.Text);
            int months = int.Parse(comboBox1.Text);

            DateTime mt = dt.AddMonths(months);

            String cs = "Data Source = LAPTOP-JOVFRCUT\\SQLEXPRESS; database =  GYM_mng; integrated security = true";
            String query = "update Client_table set Last_fee_submitted = @Last_fee, Membership_plan_months = @Membership, Fee_expiring_date = @Fee_expiring where Client_ID = @Client_ID";

            using (con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Client_ID", Client_ID);
                cmd.Parameters.AddWithValue("@Last_fee", dt);
                cmd.Parameters.AddWithValue("@Membership", months);
                cmd.Parameters.AddWithValue("@Fee_expiring", mt);

                con.Open();

                int rows = cmd.ExecuteNonQuery();


                if (rows > 0)
                {
                    MessageBox.Show("Record updated");
                }
                else
                {
                    MessageBox.Show("Fail to update");
                }
                con.Close();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.Show();
            this.Hide();
        }

        private void Update_plan_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(150, 0, 0, 0);
            panel2.BackColor = Color.FromArgb(150, 255, 255, 255);
            panel3.BackColor = Color.FromArgb(150, 0, 0, 0);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
    }
}
