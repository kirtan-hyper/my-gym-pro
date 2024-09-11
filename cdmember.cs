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
using System.Data.Sql;

namespace GYM_Management
{
    public partial class cdmember : Form
    {
 
        SqlConnection con;
        SqlCommand cmd;
        SqlCommand fitcmd;

        String cs = "Data Source = LAPTOP-JOVFRCUT\\SQLEXPRESS; database =  GYM_mng; integrated security = true";

        public cdmember()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cdmember_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(0, 0, 0, 0);
            panel2.BackColor = Color.FromArgb(110, 0, 0, 0);
            panel4.BackColor = Color.FromArgb(0, 255, 255, 255);
            button4.BackColor = Color.FromArgb(110, 0, 0, 0);
            button1.BackColor = Color.FromArgb(200, 255, 255, 255);
            button2.BackColor = Color.FromArgb(200, 255, 255, 255);
            button3.BackColor = Color.FromArgb(200, 255, 255, 255);
            panel3.BackColor = Color.FromArgb(110, 0, 0, 0);

        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (txtfit.SelectedItem != null) {

                using (con = new SqlConnection(cs))
                {
                    string specs = txtfit.SelectedItem.ToString();
                    String query1 = "select Trainer_ID from trainers where Specilization = @specs";

                    cmd = new SqlCommand(query1, con);
                    cmd.Parameters.AddWithValue("@specs", specs);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int trainer_id = (int)reader["Trainer_ID"];
                        textBox1.Text = trainer_id.ToString();
                        MessageBox.Show("Trainer_ID found");
                    }
                    else
                    {
                        MessageBox.Show("No trainer found with this fitness goal.");
                    }
                }
        }
            else
            {
                MessageBox.Show("First Select Fitness goal");
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            String query = "Insert into Client_table values(@name,@email,@mobile_no,@address,@Gender,@Training,@BMI,@fitness_goal,@membership_plan,@date_lastfee,@classes,@Fee_expiring_date,@trainer_ID)";
            

            int trainer_id = int.Parse(textBox1.Text);
            String client_name = txt_name.Text;
            String email = textemail.Text;
            String gnd;
            Int64 mb = Int64.Parse(txt_mobile.Text);
            String adrs = txtaddress.Text;
            String trn = txttrain.Text;
            float bmi = float.Parse(txtbmi.Text);
            String fitg = txtfit.SelectedItem.ToString();
            int member = int.Parse(txtplan.Text);
            DateTime date_join = Convert.ToDateTime(dateTimePicker1.Text);
            String classes = txtclasses.Text;


            DateTime mt = date_join.AddMonths(member);

            



            if (radioBtn_m.Checked)
            {
                gnd = radioBtn_m.Text;

            }
            else
            {
                gnd = radioBtn_f.Text;
            }

           

           
            using(con = new SqlConnection(cs))
            {
                cmd = new SqlCommand(query, con);
           

                cmd.Parameters.AddWithValue("@name", client_name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@mobile_no", mb);
                cmd.Parameters.AddWithValue("@address", adrs);
                cmd.Parameters.AddWithValue("@Gender", gnd);
                cmd.Parameters.AddWithValue("@Training", trn);
                cmd.Parameters.AddWithValue("@BMI", bmi);
                cmd.Parameters.AddWithValue("@fitness_goal", fitg);
                cmd.Parameters.AddWithValue("@membership_plan", member);
                cmd.Parameters.AddWithValue("@date_lastfee", date_join);
                cmd.Parameters.AddWithValue("@classes", classes);
                cmd.Parameters.AddWithValue("@Fee_expiring_date", mt);
                cmd.Parameters.AddWithValue("@Trainer_ID", trainer_id);
              
                con.Open();

                int rows = cmd.ExecuteNonQuery();


                if(rows > 0)
                {
                    MessageBox.Show("Record inserted");
                }
                else
                {
                    MessageBox.Show("Fail to insert");
                }
                con.Close();
            }
        }

        private void radioBtn_m_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Home hm = new Home();
            hm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txt_name.Clear();
            txt_mobile.Clear();
            txtbmi.Clear();
            txtaddress.Clear();
            dateTimePicker1.Value = DateTime.Now;
            radioBtn_m.Checked = false;
            radioBtn_f.Checked = false;
            textemail.Clear();
            textBox1.Clear();
            txttrain.ResetText();
            txtfit.ResetText();
            txtplan.ResetText();
            txtclasses.ResetText();
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String query = "delete from Client_table where Client_ID = @Client_table";
            int id = Int32.Parse(textBox2.Text);

            using (con = new SqlConnection(cs))
            {
                cmd =  new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Client_table", id);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Client deleted successfully");
                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }
                con.Close();
            }
        }
    }
}
