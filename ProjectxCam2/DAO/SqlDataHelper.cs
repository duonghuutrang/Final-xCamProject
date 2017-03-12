using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace ProjectxCam2.DAO
{
    public class SqlDataHelper
    {
        public static string strConnectionString = Properties.Settings.Default.DatabaseConectionString.ToString();
        public static SqlConnection Connect(string _strSqlConnectionString)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(_strSqlConnectionString);
                cn.Open();
            }
            catch { }
            return cn;

        }
        public static SqlConnection OpenConnection(SqlConnection _cn)
        {
            SqlConnection cn = null;
            try
            {
                if (_cn.State == ConnectionState.Open)
                    _cn.Close();

                _cn.Open();
                cn = _cn;
            }
            catch { }
            return cn;
        }
        public static SqlConnection CloseConnection(SqlConnection _cn)
        {
            SqlConnection cn = null;
            try
            {
                if (_cn.State == ConnectionState.Open)
                    cn = _cn;
                cn.Close();
            }
            catch { }
            return cn;
        }

        /// <summary>
        /// Lấy danh sách các dòng trong 1 bảng từ câu truy vấn
        /// </summary>
        /// <param savedEmployeeID="_strSql">câu truy vấn sql</param>
        /// <param savedEmployeeID="_cn">đối tượng SQLConnection</param>
        /// <returns></returns>
        public static DataTable GetDataToStringSQL(string _strSql, SqlConnection _cn)
        {
            DataTable dtResult = null;
            try
            {
                dtResult = new DataTable();
                _cn = OpenConnection(_cn);
                if (_cn.State == ConnectionState.Open)
                {
                    SqlDataAdapter da = new SqlDataAdapter(_strSql, _cn);
                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dtResult);
                }
            }
            catch { }
            return dtResult;
        }

        //thực hiện câu truy vấn Insert
        public static int ExecuteNonQuery(string _strSql, SqlConnection _cn)
        {
            int IDResult = -1;
            try
            {
                SqlCommand cmd = new SqlCommand(_strSql, _cn);
                cmd.CommandType = CommandType.Text;
                OpenConnection(_cn);
                IDResult = cmd.ExecuteNonQuery();
                CloseConnection(_cn);
            }
            catch { }
            return IDResult;
        }
        public static int GetMaxID(string _strSql, SqlConnection _cn)
        {
            int IDResult = -1;
            try
            {
                SqlCommand cmd = new SqlCommand(_strSql, _cn);
                cmd.CommandType = CommandType.Text;
                OpenConnection(_cn);
                IDResult = int.Parse(cmd.ExecuteScalar().ToString());
                CloseConnection(_cn);
            }
            catch { }
            return IDResult;
        }
    }
}
