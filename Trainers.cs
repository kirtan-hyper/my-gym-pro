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
    public partial class Trainers : Form
    {
        SqlConnection con;
        SqlCommand cmd;

  

        public Trainers()
        {
            InitializeComponent();
        }

        private void Trainers_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(0, 0, 0, 0);
            panel2.BackColor = Color.FromArgb(110, 0, 0, 0);
            panel3.BackColor = Color.FromArgb(0, 0, 0, 0);
            txtinsert.BackColor = Color.FromArgb(200, 255, 255, 255);
            txtdelete.BackColor = Color.FromArgb(200, 255, 255, 255);
            txtreset.BackColor = Color.FromArgb(200, 255, 255, 255);
        }

        private void txtinsert_Click(object sender, EventArgs e)
        {
            String cs = "Data Source = LAPTOP-JOVFRCUT\\SQLEXPRESS; database =  GYM_mng; integrated security = true";
            String query = "Insert into Trainers values(@name,@email,@Mobile_no,@Gender,@Address,@salary,@specilization,@Date_join,@Contract_schedule,@Trainer_type)";
            String name = textBox1.Text;
            String email = textBox2.Text;
            String Mobile_no = textBox3.Text;
            String Gender;
            String Address = textBox4.Text;
            String salary = textBox5.Text;
            String Spec = comboBox3.SelectedItem.ToString();
            DateTime date_join = Convert.ToDateTime(dateTimePicker1.Text);
            String Contract = comboBox1.Text;
            String Trainer_T = comboBox2.Text;

            if (radioButton1.Checked) { 
                Gender = radioButton1.Text;

            }
            else
            {
                Gender= radioButton2.Text;
            }
            using(con = new SqlConnection(cs))
            {
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@Mobile_no", Mobile_no);
                cmd.Parameters.AddWithValue("@Gender", Gender);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@salary", salary);
                cmd.Parameters.AddWithValue("@specilization", Spec);
                cmd.Parameters.AddWithValue("@Date_join", date_join);
                cmd.Parameters.AddWithValue("@Contract_schedule", Contract);
                cmd.Parameters.AddWithValue("@Trainer_type", Trainer_T);

                con.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0) {
                    MessageBox.Show("One record inserted");
                }

                else
                {
                    MessageBox.Show("Fail to insert");
                }
                con.Close();

            }

        }

        private void txtreset_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();  
            
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            dateTimePicker1.Value = DateTime.Now;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.Show();
            this.Hide();
        }

        private void txtdelete_Click(object sender, EventArgs e)
        {
            
        }
    }
}
