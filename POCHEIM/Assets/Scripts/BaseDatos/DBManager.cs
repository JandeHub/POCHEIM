using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class DBManager : MonoBehaviour
{
    void Start()
    {

        string conn = "URI=file:" + Application.dataPath + "/Plugins/BaseDatos.db";
        IDbConnection dbconn;

        //void OpenConnection()
        //{

        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();

        //}

        /*void CloseConnection()
        {

            dbconn.Close();
        }*/

        //void Insert()
        //{
        IDbCommand dbcmd = dbconn.CreateCommand();
        string query = "INSERT INTO SCORES(name, score) VALUES('pedro', 300)";

        dbcmd.CommandText = query;
        dbcmd.ExecuteNonQuery();
        //}


        /*void Select()
        {
        IDbCommand dbcmd = dbconn.CreateCommand();
        string query = "SELECT * FROM BaseDatos";

            dbcmd.CommandText = query;
            IDataReader reader = dbcmd.ExecuteReader();

            while (reader.Read())
            {
                int ids = reader.GetInt32(0);
                string n = reader.GetString(1);
                int sc = reader.GetInt32(2);

                Debug.Log("Id: " + ids + " Name: " + n + " Score: " + sc);
            }
        }

        /*void Delete()
        {
            IDbCommand dbcmd = dbconn.CreateCommand();
            string query = "DELETE FROM BaseDatos WHERE id = 3";

            dbcmd.CommandText = query;
            dbcmd.ExecuteNonQuery();
        }*/
    }


}
