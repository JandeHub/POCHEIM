using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;


public class CustomTools : MonoBehaviour
{


    [MenuItem("CustomTools/Añadir Monedas", false, 1)]
    public static void AddCoins()
    {
        int numCoins = 10;
        var Coin = Resources.Load("Coin");
        var Coins = new GameObject("Coins");
        if (numCoins != 0)
        {   
            
            for (int i = 0; i < numCoins; i++)
            {
                Quaternion spawnRotation = Quaternion.identity;
                Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(25, -25), 5, 0);
                Instantiate(Coin, spawnPosition, spawnRotation);
                
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "No hay monedas ", "Ok");
        }
       
    }

 


}
