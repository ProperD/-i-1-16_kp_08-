using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RestoranKyrs
{
    public partial class Zak_change : Form
    {
        public Zak_change()
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
                    sqlCommand.Parameters.AddWithValue("@Client_Id", Convert.ToInt32(textBox2.Text));
                    sqlCommand.Parameters.AddWithValue("@SotrD_id", Convert.ToInt32(textBox3.Text));
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Заказ Изменен!");
                }
                catch
                {
                    MessageBox.Show("Какие либо данные введены не корректно!");
                }
            }
            Sklad sk = new Sklad();
            sk.Show();
            this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Zakaz z = new Zakaz();
            z.Show();
            this.Hide();
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            Sklad sk = new Sklad();
            sk.Show();
            this.Hide();
        }
    }
}
