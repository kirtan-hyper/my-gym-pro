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
    public partial class Login_form : Form
    {



        public Login_form()
        {
            InitializeComponent();
            label3.Visible = false;
        }

        private void Login_form_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(0, 0, 0, 0);
            panel2.BackColor = Color.FromArgb(0, 0, 0, 0);
            panel3.BackColor = Color.FromArgb(150, 255, 255, 255);
            btn_login.BackColor = Color.FromArgb(0, 0, 0, 0);
            btn_reset.BackColor = Color.FromArgb(0, 0, 0, 0);


        }

        private void btn_login_Click(object sender, EventArgs e)
        {
        
                String cs = "data source = LAPTOP-JOVFRCUT\\SQLEXPRESS; database = GYM_mng; integrated Security = SSPI";
                SqlConnection con = new SqlConnection(cs);
                String query = "select * from owne where username=@username and pwd=@pwd";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr;



                cmd.Parameters.AddWithValue("@username", textname.Text);
                cmd.Parameters.AddWithValue("@pwd", textpasd.Text);


                con.Open();
                sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    Home f2 = new Home();
                    f2.Show();
                    this.Hide();
                }
                else
                {
                    label3.Visible = true;
                }
                con.Close();


            

        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            textname.Clear();
            textpasd.Clear();
            label3.Visible = false;
        }

        private void textname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textname_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textpasd_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void textname_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textname.Text)) {
            
                textname.Focus();
                errorProvider1.SetError(this.textname, "username can't be left blank");
            }
            else
            {
                errorProvider1.Clear();
            }

        }

        private void textpasd_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textpasd.Text))
            {
                textpasd.Focus();
                errorProvider2.SetError(this.textpasd, "password can't be left blank");

            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void textname_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textpasd_KeyPress(object sender, KeyPressEventArgs e)
        {
            //char c = e.KeyChar;
            //if (char.IsLetter(c))
            //{
            //    e.Handled = true;

            //}
            //else
            //{
            //    e.Handled = false;
            //}
        }
    }
}

