using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RestoranKyrs
{
    public partial class Sklad_change : Form
    {
        public Sklad_change()
        {
            InitializeComponent();
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
                    SqlCommand sqlCommand = new SqlCommand("Zakaz_Prod_Update", sqlConnect)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@Nazv_Prod", textBox1.Text);
                    sqlCommand.Parameters.AddWithValue("@Kolvo_neob_prod", textBox2.Text);
                    sqlCommand.Parameters.AddWithValue("@SotrD_id", Convert.ToInt32(textBox3.Text));
                    sqlCommand.Parameters.AddWithValue("@Id_Prod", Convert.ToInt32(textBox4.Text));
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Заказ добавлен");
                }
                catch
                {
                    MessageBox.Show("Какие либо данные введены не корректно!");
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}
