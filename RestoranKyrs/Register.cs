using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace RestoranKyrs
{
    public partial class Register : Form
    {
        private BD database = new BD();      
        public Register()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {
                try
                {
                    SqlConnection sqlConnection = database.DatabaseSQL();
                    string passwordHash = GetHash(textBox2.Text);
                    ConnectBD connectBD = new ConnectBD();
                    ConnectBD sqlBD = new ConnectBD();
                    using (sqlConnection)
                    {
                        sqlConnection.Open();
                        SqlCommand sqlCommand = new SqlCommand("Authorization_Insert", sqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        sqlCommand.Parameters.AddWithValue("@Login", textBox1.Text);
                        sqlCommand.Parameters.AddWithValue("@Password", passwordHash);
                        sqlCommand.Parameters.AddWithValue("@Dolzn_Id", Convert.ToInt32(comboBox1.Text));
                        sqlCommand.ExecuteNonQuery();
                    }
                    MessageBox.Show("Пользователь зарегистрирован");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка, проверьте правильность введенных данных" + ex.ToString());
                }
            }
            else { MessageBox.Show("Пароли не совпадают!!!"); }
        }

        private string GetHash(string input) //Хэширование пароля в БД
        {
            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            Authoriz a = new Authoriz();
            a.Show();
            this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Sotryd so = new Sotryd();
            so.Show();
            this.Hide();
        }
    }
}
