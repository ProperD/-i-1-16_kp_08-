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

namespace RestoranKyrs
{
    public partial class Add_Zak : Form
    {
        public Add_Zak()
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
                    SqlCommand sqlCommand = new SqlCommand("Zakaz_Insert", sqlConnect)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@TableNomer", textBox1.Text);
                    sqlCommand.Parameters.AddWithValue("@DataTime", maskedTextBox1.Text);
                    sqlCommand.Parameters.AddWithValue("@Client_Id", Convert.ToInt32(textBox2.Text));
                    sqlCommand.Parameters.AddWithValue("@Sotr_Id", Convert.ToInt32(textBox3.Text));
                    //sqlCommand.Parameters.AddWithValue("@Id_Zakaz", Convert.ToInt32(textBox4.Text));
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
            Zakaz z = new Zakaz();
            z.Show();
            this.Hide();
        }
    }
}
