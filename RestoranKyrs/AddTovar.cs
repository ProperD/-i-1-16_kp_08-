using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RestoranKyrs
{
    public partial class AddTovar : Form
    {
        public AddTovar()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Sklad at = new Sklad();
            at.Show();
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
                    SqlCommand sqlCommand = new SqlCommand("Zakaz_Prod_Insert", sqlConnect)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@Nazv_Prod", textBox1.Text);
                    sqlCommand.Parameters.AddWithValue("@Kolvo_neob_prod", textBox2.Text);
                    sqlCommand.Parameters.AddWithValue("@SotrD_id", Convert.ToInt32(textBox3.Text));
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Заказ добавлен");
                }
                catch
                {
                    MessageBox.Show("Какие либо данные введены не корректно!");
                }
            }
        }
    }
}
