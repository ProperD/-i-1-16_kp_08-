using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace RestoranKyrs
{
    public partial class Authoriz : Form
    {
        private string dataSource = @"DESKTOP-QGKOCIM\ILYA";
        private string initialCatalog = "Restoran";
        private string userID = "sa";
        private string password = "1234";
        private bool checkSecurity = true;
        public Authoriz()
        {          
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string loginCheck = textBox1.Text;
            string passwordCheck = GetHash(textBox2.Text);
           // MessageBox.Show(GetHash(textBox2.Text));
            string checkCmd = $"Select Login, Password from Authorization_ where Login ='{loginCheck}' and Password ='{passwordCheck}'";
            ConnectBD connectBD = new ConnectBD();
            SqlConnection sqlConnection = connectBD.GetSqlConnection(dataSource, initialCatalog, userID, password, checkSecurity);
            SqlCommand sqlCommand = new SqlCommand(checkCmd, sqlConnection);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Prepare();
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show((string)sqlCommand.ExecuteScalar());
                    if (loginCheck == (string)sqlCommand.ExecuteScalar())
                    {
                        this.Hide();
                        MainForm mf = new MainForm();
                        mf.Show();
                    }
                    else
                    {
                        MessageBox.Show("Логин или пароль ведены не верно");
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }

        private string GetHash(string input) //Хэширование пароля в БД
        {
            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Register R = new Register();
            R.Show();
            this.Hide();
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }
    }
}
