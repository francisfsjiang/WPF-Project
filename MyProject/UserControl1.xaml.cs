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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.ObjectModel;

namespace MyProject
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>

    public enum SexType { male = 0, famale = 1 };
    
    public partial class UserControl1 : UserControl
    {
        ObservableCollection<TeacherType> ListofTeachers = new ObservableCollection<TeacherType>();
        HashSet<TeacherType> OriginData = new HashSet<TeacherType>();
        public UserControl1()
        {
            InitializeComponent();
            dg.ItemsSource = ListofTeachers;
        }

        private void LoadTeacherData()
        {
            LoadTeacherData(new object(),new RoutedEventArgs());
        }

        private void LoadTeacherData(object sender, RoutedEventArgs e)
        {
            DataTable dtTable=new DataTable();
            string sqlstr = "SELECT [ID],[teachername],[account],[password],[sex] FROM [TeacherDB].[dbo].[Teacher]";
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
            ListofTeachers.Clear();
            foreach (DataRow dr in dtTable.Rows)
            {
                TeacherType en = new TeacherType(
                    Convert.ToInt32(dr["ID"]),
                    dr["teachername"].ToString(),
                    dr["account"].ToString(),
                    dr["password"].ToString(),
                    (SexType)Enum.Parse(typeof(SexType), dr["sex"].ToString()),
                    false
                    );
                ListofTeachers.Add(en);
                OriginData.Add(en);
               
            }
            conn.Close();
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            string sqlstr = "DELETE FROM [dbo].[Teacher] WHERE ID={0}";
            
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TeacherDb"].ConnectionString);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            foreach (TeacherType t in ListofTeachers)
            {
                if (t.checkd == true)
                {
                    string sql_to_excute = string.Format(sqlstr, t.teacher_id);
                    cmd.CommandText = sql_to_excute;
                    cmd.ExecuteNonQuery();

                }
            }
            conn.Close();
            LoadTeacherData();
        }

        private void SelectAll(object sender, RoutedEventArgs e)
        {
            foreach (TeacherType i in ListofTeachers)
            {
                i.checkd = true;
            }
            
        }

        private void UnSelectAll(object sender, RoutedEventArgs e)
        {
            foreach (TeacherType i in ListofTeachers)
            {
                i.checkd = false;
            }
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            DropData();
            string sqlstr = "INSERT INTO [dbo].[Teacher]([teachername],[account],[password],[sex]) VALUES('{0}','{1}','{2}','{3}')";
            
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TeacherDb"].ConnectionString);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            foreach (TeacherType t in ListofTeachers)
            {
                string sql_to_excute = string.Format(sqlstr, t.teacher_name, t.account, t.password, t.sex.ToString());
                cmd.CommandText = sql_to_excute;
                cmd.ExecuteNonQuery();
            }
            conn.Close();
            LoadTeacherData();
        }

        public void DropData()
        {
            string sqlstr = "DELETE FROM　Teacher";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TeacherDb"].ConnectionString);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sqlstr;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            TeacherType en = new TeacherType(
                    -1,
                    "",
                    "",
                    "",
                    (SexType)Enum.Parse(typeof(SexType), "male"),
                    false
                    );
            ListofTeachers.Add(en);
        }


        
    }
}
