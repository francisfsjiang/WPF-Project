using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MyProject
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            //this.DialogResult = true;
            string username = this.tbUserName.Text;
            string password = this.tbPassword.Password;

            DataTable dtTable = new DataTable();
            string sqlstr = "SELECT password FROM Teacher WHERE account='"+username+"'";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TeacherDb"].ConnectionString);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sqlstr;
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            sda.Fill(dtTable);

            try
            {
                if(dtTable.Rows[0]["password"].ToString() == password)
                {
                    this.DialogResult = true;
                }
            }
            catch
            {
                this.WarningBox.Visibility = Visibility.Visible;
                this.tbUserName.Text = "";
                this.tbPassword.Password = "";
            }


        }

        private void CancleClick(object sender, RoutedEventArgs e)
        {
            this.tbUserName.Text = "";
            this.tbPassword.Password = "";
        }

                
    }
}
