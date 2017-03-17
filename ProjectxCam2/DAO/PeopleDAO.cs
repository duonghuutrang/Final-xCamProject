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
    class PeopleDAO
    {
        SqlConnection con = null;
        string sql;
        DataTable dt;
        public PeopleDAO()
        {
            con = SqlDataHelper.Connect(SqlDataHelper.strConnectionString);
        }

        public List<People> getAllPeoples()
        {
            List<People> listResult = new List<People>();
            try
            {
                sql = "Select * from Peoples;";
                dt = SqlDataHelper.GetDataToStringSQL(sql, con);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow Row in dt.Rows)
                    {
                        People obj = new People();
                        obj.ID = int.Parse(Row["ID"].ToString());
                        obj.PeopleID = Row["PeopleID"].ToString();
                        obj.FirstName = Row["FirstName"].ToString();
                        obj.LastName = Row["LastName"].ToString();
                        obj.Position = Row["Position"].ToString();
                        obj.Sex = bool.Parse(Row["Sex"].ToString());
                        obj.Phone = Row["Phone"].ToString();
                        obj.Address = Row["Address"].ToString();
                        obj.Comment = Row["Comment"].ToString();
                        obj.BirthDay = DateTime.Parse(Row["BirthDay"].ToString());
                        obj.DateAdded = DateTime.Parse(Row["DateAdded"].ToString());
                        obj.isDeleted = bool.Parse(Row["isDeleted"].ToString());
                        listResult.Add(obj);
                    }
                }
            }
            catch { }
            return listResult;
        }

        public int addPeople(People _obj)
        {
            int iResult = -1;
            try
            {
                if (con != null)
                {
                    string sql = "INSERT INTO Peoples(PeopleID,FirstName,LastName,Position,Sex,Phone,Address,Comment,BirthDay,DateAdded,isDeleted) values(";
                    sql += "'" + _obj.PeopleID + "'";
                    sql += ",N'" + _obj.FirstName + "'";
                    sql += ",N'" + _obj.LastName + "'";

                    sql += ",N'" + _obj.Position + "'";
                    sql += ",'" + _obj.Sex + "'";
                    sql += ",'" + _obj.Phone + "'";
                    sql += ",N'" + _obj.Address + "'";
                    sql += ",N'" + _obj.Comment + "'";
                    if (_obj.BirthDay >= DateTime.Now)
                        sql += ",'" + _obj.BirthDay + "'";
                    else
                        sql += ",''";
                    if (_obj.DateAdded >= DateTime.Now)
                        sql += ",'" + _obj.DateAdded + "'";
                    else
                        sql += ",''";
                    sql += ",'" + _obj.isDeleted.ToString() + "')";
                    Console.WriteLine("Sql add employee: " + sql);
                    iResult = SqlDataHelper.ExecuteNonQuery(sql, con);
                    if (iResult == 1)
                    {
                        sql = "SELECT MAX(ID) FROM Peoples";
                        iResult = SqlDataHelper.GetMaxID(sql, con);
                        iResult = int.Parse(_obj.ID.ToString());

                    }
                    Console.WriteLine(sql);
                }
            }
            catch { }
            return iResult;
        }

        #region [Get People By ID To Show Info]
        public People getPeopleByID(int _id)
        {
            People obj = new People();

            //sql = "Select * from Peoples a left join TrainedFace b on a.PeopleID = b.PeopleID where b.ID=" + _id;
            sql = "Select a.ID,a.FirstName,a.LastName,a.Position,a.Phone,a.Address,a.BirthDay,a.PeopleID,a.Sex from Peoples a left join TrainedFace b on a.ID = b.PeopleID where b.ID ="+_id;
            dt = SqlDataHelper.GetDataToStringSQL(sql, con);
            if (dt.Rows.Count == 1)
            {
                obj.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                obj.PeopleID = dt.Rows[0]["PeopleID"].ToString();
                obj.FirstName = dt.Rows[0]["FirstName"].ToString();
                obj.LastName = dt.Rows[0]["LastName"].ToString();
                if (dt.Rows[0]["Sex"].ToString() == "1")
                    obj.Sex = true;
                else
                    obj.Sex = false;
                obj.Phone = dt.Rows[0]["Phone"].ToString();
                obj.Position = dt.Rows[0]["Position"].ToString();
                obj.Address = dt.Rows[0]["Address"].ToString();
                obj.BirthDay = DateTime.Parse(dt.Rows[0]["BirthDay"].ToString());

            }
            return obj;
        }
        #endregion
        public bool updatePeople(People _obj)
        {
            bool isResult = false;
            try
            {
                if (con != null)
                {

                    string sql = "UPDATE Peoples SET ";
                    sql += " PeopleID = '" + _obj.PeopleID + "'";
                    sql += " ,FirstName = N'" + _obj.FirstName + "'";
                    sql += " ,LastName = N'" + _obj.LastName + "'";
                    sql += " ,Position = N'" + _obj.Position + "'";
                    sql += " ,Sex = '" + _obj.Sex.ToString() + "'";
                    sql += " ,Phone = N'" + _obj.Phone + "'";
                    sql += " ,Address = N'" + _obj.Address + "'";
                    sql += " ,Comment = N'" + _obj.Comment + "'";
                    sql += " ,BirthDay = '" + _obj.BirthDay.ToString() + "'";
                    sql += " ,DateAdded = '" + _obj.DateAdded.ToString() + "'";
                    sql += " ,isDeleted = '" + _obj.isDeleted.ToString() + "'";
                    sql += " Where ID = " + _obj.ID;

                    Console.WriteLine(sql);

                    int Result = SqlDataHelper.ExecuteNonQuery(sql, con);
                    if (Result > 0)
                        isResult = true;

                }
            }
            catch { }
            return isResult;
        }

    }
}
  