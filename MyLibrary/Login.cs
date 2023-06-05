using System.Data;
using System.Data.SqlClient;
namespace MyLibrary
{
    public partial class Login : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyLibrary;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public Login()
        {
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username, userPassword;
            username = textBox1.Text;
            userPassword = textBox2.Text;
            try
            {
                String querry="Select * FROM Login WHERE password='"+ textBox2.Text+"' AND username='"+textBox1.Text+"' ";
                SqlCommand commande = new SqlCommand(querry, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(querry,conn);
                DataTable dataTable= new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {

                    /*while (dataReader.Read())
                    {
                        string role = dataReader["role"].ToString();
                        if (role == "Admin")
                        {
                            username = textBox1.Text;
                            userPassword = textBox2.Text;

                            LibraryForm nextForm = new LibraryForm();
                            nextForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            username = textBox1.Text;
                            userPassword = textBox2.Text;
                            UserInterface nextForm = new UserInterface();
                            nextForm.Show();
                            this.Hide();
                        }
                    }*/

                    username = textBox1.Text;
                    userPassword = textBox2.Text;
                    LibraryForm nextForm = new LibraryForm();
                    nextForm.Show();
                    this.Hide();
                }
                else {
                    MessageBox.Show("Invalid login details ","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox2.Clear();
                    
                }
            }
            catch { MessageBox.Show("Error"); }
            finally { conn.Close(); }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
       SignUp next = new SignUp();
            next.Show();
            this.Hide();
        }
    }
}