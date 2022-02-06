using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine.UI;

public class DBManager : MonoBehaviour
{
    public static DBManager _instance;
    public Text CoinsList;
    private string dbName = "URI=file:Inventory.db";

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != null)
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        //crea la tabla de base de datos
        CreateDB();

        DisplayCoins();

        DontDestroyOnLoad(gameObject);


    }

    public void CreateDB()
    {
        //crear la conexion con la base de datos
        using (var dbconn = new SqliteConnection(dbName))
        {
            dbconn.Open();

            using (var command = dbconn.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS coins (quantityCoins INT);";
                command.ExecuteNonQuery();
            }

            dbconn.Close();
        }

    }

    public void AddCoins(int quantityCoins)
    {
        using (var dbconn = new SqliteConnection(dbName))
        {
            dbconn.Open();

            using (var command = dbconn.CreateCommand())
            {
                command.CommandText = "INSERT INTO coins (quantityCoins) VALUES (" + quantityCoins + ");";
                command.ExecuteNonQuery();

                Debug.Log("AÑADIDO MONEDA");
            }

            dbconn.Close();
        }
    }

    public void DisplayCoins()
    {
        using (var dbconn = new SqliteConnection(dbName))
        {
            dbconn.Open();

            using (var command = dbconn.CreateCommand())
            {
                command.CommandText = "SELECT * FROM coins;";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        GameObject.Find("GameManager").GetComponent<CoinAmount>().amount = (int)reader["quantityCoins"];


                    }
                    reader.Close();

                }

            }

            dbconn.Close();


        }
    }

}
