using System;
using System.Collections.Generic;
using UnityEngine;

//What data do we want to save?
//I'm thinking hwat levels you've finished and what collectables you have
//As well as what score you have for a given level. (This can be represented as time remaining)
//The actual value will be interpreted prior to display, but we can just store its float value rather than a whole ass string
//This class should follow the singleton pattern
[Serializable]
public class SaveData : MonoBehaviour
{
    private static SaveData _instance;
    public static SaveData Instance { get { return _instance; } }

    private void Awake()
    {
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }
    }

    public HashSet<Scenes> clearedLevels = new HashSet<Scenes>();
    public Dictionary<Scenes, HashSet<Collectables>> obtainedCollectables = new Dictionary<Scenes, HashSet<Collectables>>(); 
    //The Collectables set should ensure that I only ever have as many collectables found for a level as I do in the enum. Genius, I hope.
    public Dictionary<Scenes, float> times = new Dictionary<Scenes, float>();
    public string test; //This is used to validate proper save/load use

    private void EraseData()
    {
        clearedLevels.Clear();
        obtainedCollectables.Clear();
        times.Clear();
        test = "Cleared All Data";
    }
}
