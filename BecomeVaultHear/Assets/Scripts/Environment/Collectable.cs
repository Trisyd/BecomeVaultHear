using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Collectables
{
    First,
    Second,
    Third
}

public class Collectable : MonoBehaviour
{

    public Collectables Type;
    public Material baseMaterial;
    public Material ghostMaterial;

    private bool alreadyCollected;
    private SceneManagement sceneManagement;
    private SaveData data;
    private Scenes curr;

    void Start()
    {
        data = new SaveData();
        sceneManagement = new SceneManagement();
        curr = sceneManagement.CurrentScene();

        if (!data.obtainedCollectables.ContainsKey(curr))
        {
            alreadyCollected = false;
        }
        else
        {
            alreadyCollected = data.obtainedCollectables[curr].Contains(Type);
        }
        
        //Has the player already collected this and cleared the level? [Check current data class]
        //In other words, is the collectable saved in the binary file?
        //If so, spawn a ghost prefab of the ornament
        if (alreadyCollected) GetComponent<Renderer>().material = ghostMaterial;
        
        else GetComponent<Renderer>().material = baseMaterial;
        //The only difference will be in the loaded material
        //This ghost will trigger collection effects, but not do much else
        Debug.Log(GetComponent<Renderer>().material.name);
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //Check type and pass it to save data
            if (!alreadyCollected) {

                if (data.obtainedCollectables.ContainsKey(curr))
                {
                    Debug.Log("Collectalble not first collected in Scene");
                    data.obtainedCollectables[curr].Add(Type);
                }
                //Add the scene to the dictionary if nonexitent
                else {
                    Debug.Log("First collectable of scene");
                    data.obtainedCollectables.Add(curr, new HashSet<Collectables> { Type });
                }
                    
            }
            
            //Trigger some despawn effect here. Instantiate some prefab//

        }
        Destroy(this.gameObject);
    }

    //What exists in the save binary?
    
}
