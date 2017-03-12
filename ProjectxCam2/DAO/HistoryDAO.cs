using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectxCam2.Model;
using System.Data.SqlClient;
using System.Data;

namespace ProjectxCam2.DAO
{
    class HistoryDAO
    {
        SqlConnection con = null;
        string sql;
        DataTable dt;

        public HistoryDAO()
        {
            con = SqlDataHelper.Connect(SqlDataHelper.strConnectionString);
        }
        public int addHistory(Historys _obj)
        {
            int iResult = -1;
            try
            {
                if (con != null)
                {
                    string sql = "INSERT INTO CapturedHistory(CameraID,PeopleID,FaceCaptured,DateCaptured,TimeIn,TimeOut,FrameCaptured,isDeleted) values(";
                    sql += "" + _obj.CameraID + "";
                    sql += "," + _obj.PeopleID + "";
                    sql += ",N'" + _obj.FaceCaptured + "'";
                    sql += ",'" + DateTime.Now.ToString() + "'";
                    if (_obj.TimeIn >= DateTime.Now)
                        sql += ",'" + _obj.TimeIn + "'";
                    else
                        sql += ",''";
                    if (_obj.TimeOut >= DateTime.Now)
                        sql += ",'" + _obj.TimeOut+ "'";
                    else
                        sql += ",''";
                    sql += ",'" + _obj.FrameCaptured + "'";                
                    sql += ",'" + _obj.isDeleted.ToString() + "')";
                   
                    iResult = SqlDataHelper.ExecuteNonQuery(sql, con);
                    if (iResult == 1)
                    {
                        sql = "SELECT MAX(ID) FROM CapturedHistory";
                        iResult = SqlDataHelper.GetMaxID(sql, con);
                        iResult = int.Parse(_obj.ID.ToString());
                    }
                    Console.WriteLine(sql);
                }
            }
            catch { }
            return iResult;
        }

        public int getMaxID()
        {
            int  iResult = -1;
            sql = "SELECT MAX(ID) FROM CapturedHistory";
            iResult = SqlDataHelper.GetMaxID(sql, con);
            return iResult;
        }

        public List<Historys> getTopHistorys()
        {
            List<Historys> listResult = new List<Historys>();
            try
            {
                sql = "Select a.CameraID, a.DateCaptured,a.FrameCaptured,b.PeopleID,b.FirstName,b.LastName,b.Position from CapturedHistory a left join Peoples b on a.PeopleID = b.ID";
                dt = SqlDataHelper.GetDataToStringSQL(sql, con);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow Row in dt.Rows)
                    {
                        Historys obj = new Historys();
                    
                        obj.PeopleID = int.Parse(Row["PeopleID"].ToString());
                        obj.CameraID = int.Parse(Row["CameraID"].ToString());

                        obj.DateCaptured = DateTime.Parse(Row["DateCaptured"].ToString());
                        obj.FirstName = Row["FirstName"].ToString();
                        obj.LastName = Row["LastName"].ToString();
                        obj.Position = Row["Position"].ToString();
                        obj.FrameCaptured = Row["FrameCaptured"].ToString();
                        // obj.isDeleted = bool.Parse(Row["isDeleted"].ToString());
                        listResult.Add(obj);

                        Console.WriteLine(obj.PeopleID);
                   
                    }
                }
            }
            catch { }
            return listResult;
        }

        public List<Historys> getTopHistorys(int _id)
        {
            List<Historys> listResult = new List<Historys>();
            try
            {
                sql = "Select a.CameraID, a.DateCaptured,a.FrameCaptured,b.PeopleID,b.FirstName,b.LastName,b.Position from CapturedHistory a left join Peoples b on a.PeopleID = b.ID and b.PeopleID=0";
                dt = SqlDataHelper.GetDataToStringSQL(sql, con);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow Row in dt.Rows)
                    {
                        Historys obj = new Historys();

                        //obj.PeopleID = int.Parse(Row["PeopleID"].ToString());
                        obj.CameraID = int.Parse(Row["CameraID"].ToString());

                        obj.DateCaptured = DateTime.Parse(Row["DateCaptured"].ToString());
                       /* obj.FirstName = Row["FirstName"].ToString();
                        obj.LastName = Row["LastName"].ToString();
                        obj.Position = Row["Position"].ToString();
                        obj.FrameCaptured = Row["FrameCaptured"].ToString();*/
                        // obj.isDeleted = bool.Parse(Row["isDeleted"].ToString());
                        listResult.Add(obj);

                        Console.WriteLine(obj.PeopleID);

                    }
                }
            }
            catch { }
            return listResult;
        }
        public Historys getLatestHistorybyPeopleID(int _id)
        {
            Historys obj = new Historys();
            //sql = "Select top(1) * from CapturedHistory where PeopleID="+ _id +" order by _dectionID desc;";
            sql = "Select top(1) * from CapturedHistory  where PeopleID="+_id+" order by ID desc";
            dt = SqlDataHelper.GetDataToStringSQL(sql, con);
            if (dt.Rows.Count == 1)
            {
                obj.ID = int.Parse(dt.Rows[0]["ID"].ToString());
               obj.PeopleID = int.Parse(dt.Rows[0]["PeopleID"].ToString());
              // obj.FirstName = dt.Rows[0]["FirstName"].ToString();
                //obj.LastName = dt.Rows[0]["LastName"].ToString();
                obj.DateCaptured = DateTime.Parse(dt.Rows[0]["DateCaptured"].ToString());
                Console.WriteLine(obj.DateCaptured.ToString()+ "ID: "+_id);
            }
            return obj;           
        }

        public int getMinuteDiff(string _daytime,string _datetimenow)
        {
            sql = "select DATEDIFF(MINUTE,'"+ _daytime +"','"+_datetimenow+"')";
            Console.WriteLine(sql);
            int minute = SqlDataHelper.GetMaxID(sql, con);
            return minute;
        }
    }
}
