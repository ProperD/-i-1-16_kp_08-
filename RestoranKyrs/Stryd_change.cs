using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RestoranKyrs
{
    public partial class Stryd_change : Form
    {
        public Stryd_change()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            OtdelKadrov ot = new OtdelKadrov();
            ot.Show();
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            BD databae = new BD();
            SqlConnection sqlConnect = databae.DatabaseSQL();
            using (sqlConnect)
            {
                try
                {
                    sqlConnect.Open();
                    SqlCommand sqlCommand = new SqlCommand("Sotrydnik_Update", sqlConnect)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@Name", textBox1.Text);
                    sqlCommand.Parameters.AddWithValue("@Familia", textBox2.Text);
                    sqlCommand.Parameters.AddWithValue("@Otchestvo", textBox3.Text);
                    sqlCommand.Parameters.AddWithValue("@Passport_Dannie", textBox4.Text);
                    sqlCommand.Parameters.AddWithValue("@Dolznost", textBox5.Text);
                    sqlCommand.Parameters.AddWithValue("@ID_Sotrydnik", Convert.ToInt32(textBox6.Text));
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Сотрудник Изменен!");
                }
                catch
                {
                    MessageBox.Show("Какие либо данные введены не корректно!");
                }
            }

        }
    }
}
