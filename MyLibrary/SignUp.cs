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

namespace MyLibrary
{
    public partial class SignUp : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyLibrary;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
      
        public SignUp()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username, userPassword;
            username = textBox1.Text;
            userPassword = textBox2.Text;

            try
            {
                String querry2 = "Select * FROM Login where username='"+textBox1.Text+"' ";

                SqlDataAdapter adapter2 = new SqlDataAdapter(querry2, conn);
                DataTable dataTable2 = new DataTable();
                adapter2.Fill(dataTable2);

                if (textBox1.Text=="" || textBox2.Text=="")
                { MessageBox.Show("Missing informations !"); }

                else if (dataTable2.Rows.Count > 0)
                {
                    MessageBox.Show("User Email already exists !");
                    textBox1.Clear();
                    textBox2.Clear();
                }
                else
                {
                    SqlCommand com = new SqlCommand("insert into Login values('"+textBox1.Text+"','"+textBox2.Text +"')", conn);
                    conn.Open();
                    com.ExecuteNonQuery();
                    MessageBox.Show("User added successfully! ");
                    conn.Close();

                    Login next = new Login();
                    next.Show();
                    this.Hide();
                }
            }
            catch { MessageBox.Show("Error!"); }

            finally { conn.Close(); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
