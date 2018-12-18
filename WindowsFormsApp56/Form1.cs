using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp56
{
    public partial class Form1 : Form
    {
        private string connectionString;
        private MySqlConnection connection;
        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            connectionString = "server=localhost; database=hosteldb; Uid=root; password=mbabazi@2018";
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var UsernameText = textBox1.Text;
            var passwordText = textBox2.Text;


            var selectCommand = new MySqlCommand();
            selectCommand.CommandText = "select * from users where username=@username and password=@password";
            selectCommand.Parameters.AddWithValue("@username", UsernameText);
            selectCommand.Parameters.AddWithValue("@password", passwordText);

            selectCommand.Connection = connection;
            MySqlDataReader dataReader = selectCommand.ExecuteReader();

            if(dataReader.Read())
            {
                MessageBox.Show("login successful");
            }
            else
            {
                MessageBox.Show("Invalid username or Password");
            }
        }
    }
}
