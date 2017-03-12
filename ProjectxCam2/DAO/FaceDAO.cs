using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectxCam2.DAO;
using System.Data.SqlClient;
using System.Data;
using ProjectxCam2.Model;

namespace ProjectxCam2.DAO
{

    class FaceDAO
    {
        SqlConnection con = null;
        string sql;
        DataTable dt;
        public FaceDAO()
        {
            con = SqlDataHelper.Connect(SqlDataHelper.strConnectionString);
        }

        public int addTrainFace(Face _obj)
        {
            int iResult = -1;
            try
            {
                if (con != null)
                {
                    sql = "INSERT INTO TrainedFace(CameraID,PeopleID,FaceCaptured,FaceTrainedPath,DateCaptured,Comment,isDeleted) values(";
                    sql += "N'" + _obj.CameraID + "'";
                    sql += ",'" + _obj.PeopleID + "'";
                    sql += ",'" + _obj.FaceCaptured + "'";
                    sql += ",'" + _obj.FaceTrainedPath + "'";
                    sql += ",'" + _obj.DateCaptured.ToString() + "'";                                    
                    sql += ",'" + _obj.Comment + "'";                    
                    sql += ",'" + _obj.isDeleted.ToString() + "')";
                   
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

        public List<Face> getAllFace()
        {
            List<Face> listResult = new List<Face>();
            try
            {
                sql = "Select * from TrainedFace;";
                dt = SqlDataHelper.GetDataToStringSQL(sql, con);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow Row in dt.Rows)
                    {
                        Face obj = new Face();
                        obj.ID = int.Parse(Row["ID"].ToString());
                        obj.PeopleID = Row["PeopleID"].ToString();
                        obj.CameraID = int.Parse(Row["CameraID"].ToString());

                        //obj.FaceCaptured = int.Parse(Row["FaceCaptured"].ToString());
                        obj.DateCaptured = DateTime.Parse(Row["DateCaptured"].ToString());
                        obj.Comment = Row["Comment"].ToString();
                        obj.FaceTrainedPath = Row["FaceTrainedPath"].ToString();
                       
                        obj.isDeleted = bool.Parse(Row["isDeleted"].ToString());
                        listResult.Add(obj);                       
                    }
                }
            }
            catch { }
            return listResult;
        }


        public List<Face> getAllUnKnowFace()
        {
            List<Face> listResult = new List<Face>();
            try
            {
                sql = "Select * from TrainedFace where PeopleID='';";
                dt = SqlDataHelper.GetDataToStringSQL(sql, con);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow Row in dt.Rows)
                    {
                        Face obj = new Face();
                        obj.ID = int.Parse(Row["ID"].ToString());
                        obj.PeopleID = Row["PeopleID"].ToString();
                        obj.CameraID = int.Parse(Row["CameraID"].ToString());

                        //obj.FaceCaptured = int.Parse(Row["FaceCaptured"].ToString());
                        obj.DateCaptured = DateTime.Parse(Row["DateCaptured"].ToString());
                        obj.Comment = Row["Comment"].ToString();
                        obj.FaceTrainedPath = Row["FaceTrainedPath"].ToString();

                        obj.isDeleted = bool.Parse(Row["isDeleted"].ToString());
                        listResult.Add(obj);
                    }
                }
            }
            catch { }
            return listResult;
        }

    }
}
