using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Manager : MonoBehaviour
{
    public string[] levelList;
    public int level = 1;


    private void OnEnable()
    {
        EventManager.StartListening("SwitchLevel", SwitchLevel);
    }

    private void OnDisable()
    {
        EventManager.StopListening("KillPlayer", SwitchLevel);
    }



    // Start is called before the first frame update
    void Start()
    {
        levelList = GetAllLevel();
        foreach(string level in levelList)
        {
            Debug.Log(level);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string[] GetAllLevel()
    {
        int sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
        string[] scenes = new string[sceneCount];
        for (int i = 0; i < sceneCount; i++)
        {
            scenes[i] = System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i));
        }
        return scenes;
    }

    private void SwitchLevel(float obj)
    {
        string currentScene = SceneManager.GetActiveScene().name;
        Debug.Log(currentScene.Substring(0, 5));
        //On prend les 6 premiers charactère 
        if (currentScene.Substring(0, 6) == "Level_")
        {
            Debug.Log("Changement de niveau");
            SceneManager.LoadScene("Level_" + level.ToString());
        }
        else if(currentScene == "SampleScene")
        {
            SceneManager.LoadScene("Level_" + level.ToString());
        }
    }
}
