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


namespace MyProject
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public class TeacherEn
    {
        public int? TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        //public int? SexId { get; set; }
        public string SexName { get; set; }
    }
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl_Load(object sender, RoutedEventArgs e)
        {
            DataTable dtTable=new DataTable();
            //string sqlstr="select ID, teachername,account,password,sex as sexid,CASE sex WHEN '1' THEN '男' WHEN '0' THEN '女' ELSE '其他' END as sexname from Teacher where 1=1";
            string sqlstr = "SELECT ID, teachername,account,password,sex FROM Teacher";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TeacherDb"].ConnectionString);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection=conn;
            cmd.CommandText = sqlstr;
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand=cmd;
            sda.Fill(dtTable);

            List<TeacherEn> lstTeach = new List<TeacherEn>();

            foreach (DataRow dr in dtTable.Rows)
            {
                TeacherEn en = new TeacherEn();
                en.TeacherId = Convert.ToInt32(dr["ID"]);
                en.TeacherName = dr["teachername"].ToString();
                en.Password = dr["password"].ToString();
                en.Account = dr["account"].ToString();
                //en.SexId = Convert.ToInt32(dr["sex"]);
                en.SexName = Convert.ToString(dr["sex"]);
                lstTeach.Add(en);
            }
            dg.ItemsSource = lstTeach;
        }
    }
}
