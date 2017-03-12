using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectxCam2.Model;

namespace ProjectxCam2.DAO
{   
    class CameraDAO
    {
        SqlConnection con = null;
        string sql;
        DataTable dt;
        public CameraDAO()
        {
            con = SqlDataHelper.Connect(SqlDataHelper.strConnectionString);
        }
        public List<Camera> getAllCamera()
        {
            List<Camera> listResult = new List<Camera>();
            try
            {                
                sql = "Select * from Cameras;";
                dt = SqlDataHelper.GetDataToStringSQL(sql, con);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow Row in dt.Rows)
                    {
                        Camera obj = new Camera();
                        obj.ID = int.Parse(Row["ID"].ToString());
                        obj.CamName = Row["CamName"].ToString();
                        obj.Comment = Row["Comment"].ToString();

                        obj.UserAdded = int.Parse(Row["UserAdded"].ToString());
                        obj.UserModded = int.Parse(Row["UserModded"].ToString());
                        obj.DateAdded = DateTime.Parse(Row["DateAdded"].ToString());
                        obj.DateModded = DateTime.Parse(Row["DateModified"].ToString());

                        obj.CamAddress = Row["CamAddress"].ToString();
                        obj.isDeleted = bool.Parse(Row["isDeleted"].ToString());
                        listResult.Add(obj);

                        Console.WriteLine(obj.CamName);
                    }
                }
            }
            catch { }
            return listResult;
        }

        public int addCamera(Camera _obj)
        {
            int iResult = -1;
            try
            {
                if (con != null)
                {
                    string sql = "INSERT INTO Cameras(CamName,CamAddress,Comment,DateAdded,DateModified,UserAdded,UserModded,isDeleted) values(";
                    sql += "N'" + _obj.CamName + "'";
                    sql += ",'" + _obj.CamAddress + "'";
                    sql += ",N'" + _obj.Comment + "'";
                    if (_obj.DateAdded >= DateTime.Now)
                        sql += ",'" + _obj.DateAdded + "'";
                    else
                        sql += ",''";
                    if(_obj.DateModded>=DateTime.Now)
                        sql += ",'" + _obj.DateModded + "'";
                    else
                        sql += ",''";
                    sql += ",'" + _obj.UserAdded + "'";
                    sql += ",'" + _obj.UserModded + "'";
                    sql += ",'" + _obj.isDeleted.ToString()+ "')";
                    Console.WriteLine("Sql add employee: " + sql);
                    iResult = SqlDataHelper.ExecuteNonQuery(sql, con);
                    if (iResult == 1)
                    {
                        sql = "SELECT MAX(ID) FROM Cameras";
                        iResult = SqlDataHelper.GetMaxID(sql, con);
                        iResult = int.Parse(_obj.ID.ToString());

                    }
                    Console.WriteLine(sql);
                }
            }
            catch { }
            return iResult;
        }
        
    }
}
