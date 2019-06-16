using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DataAccess
{
    //Property to acces data
    public PlayerData PlayerData
    {
        get
        {
            return playerData;
        }
    }
    PlayerData playerData;


    public void Load()
    {
        //At first call load from scriptable object
        playerData = AssetDatabase.LoadAssetAtPath(
            "Assets/Scripte/Test.asset", typeof(PlayerData)
            ) as PlayerData;
        Debug.Log("Player data is loaded");
    }

    //Singleton 
    private DataAccess() // constructeur privé donc peut pas être détruit de l'exterieur
    {
        Debug.Log("Data are loading");
        Load(); // load data 
    }

    private static DataAccess instance;
    public static DataAccess Instance
    {
        get
        {
            if (instance == null) instance = new DataAccess();
            Debug.Log("new data access instance");
            return instance;
        }
    }


}
