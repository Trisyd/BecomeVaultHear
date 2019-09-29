using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveMangement : MonoBehaviour
{

    private SaveData data;
    private Scenes currentScene;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        data = new SaveData();
        LoadGame();
    }



    public void SaveGame()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite); //Might need OpenOrCreate

        data.clearedLevels.Add(currentScene);
        data.test = "Saved";
        //Save current time in Scene Dcitionary

        formatter.Serialize(file, data);
        file.Close();
        PrintSaveData();
    }

    public void LoadGame()
    {
        if(File.Exists(Application.persistentDataPath + "/save.dat"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite); //I hope this works. Wasn't in the tutorial, but the function needs a filemode
            SaveData data = (SaveData)formatter.Deserialize(file);
            file.Close();
            PrintSaveData();
        }
        else Debug.LogError("Failed to load save data. Check directory information");
    }

    private void OnEnable()
    {
        Goal.OnClearLevel += SaveGame;
    }

    private void OnDisable()
    {
        Goal.OnClearLevel -= SaveGame;
    }

    //Debugging script for monitoring what data is currently saved
    public void PrintSaveData()
    {
        Debug.Log(data.test);
        Debug.Log("Printing Save Data");
        //Print Cleared Levels
        if (data.clearedLevels.Count == 0) Debug.Log("No Cleared Levels");
        foreach(Scenes level in data.clearedLevels)
        {
            Debug.Log("Level Cleared: " + level.ToString());
        }
        if (data.obtainedCollectables.Keys.Count == 0) Debug.Log("No Obtained Collectables");
        foreach(Scenes level in data.obtainedCollectables.Keys)
        {
            Debug.Log("Items collected in: " + level.ToString());
            foreach(Collectables coll in data.obtainedCollectables[level])
            {
                Debug.Log("Collected Type: " + coll.ToString());
            }
        }
    }

}

