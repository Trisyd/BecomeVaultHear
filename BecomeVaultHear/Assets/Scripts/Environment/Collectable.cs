using UnityEngine;

public enum Collectables
{
    First,
    Second,
    Third
}

public class Collectable : MonoBehaviour
{
    //Can I just have one event with a parameter
    public delegate void Collection();
    public static event Collection OnFirstCollection;
    public static event Collection OnSecondCollection;
    public static event Collection OnThirdCollection;


    public Collectables Type;
    public Material baseMaterial;
    public Material ghostMaterial;

    [HideInInspector] public SaveData data;

    private bool alreadyCollected;
    private string currentScene;

    void Start()
    {
        /*
        data = SaveMangement.Instance.data;
        currentScene = new SceneManagement().CurrentScene().ToString();


        if (!data.obtainedCollectables.ContainsKey(currentScene))
        {
            alreadyCollected = false;
        }
        else
        {
            alreadyCollected = data.obtainedCollectables[currentScene].Contains(Type);
        }
        */

        //Spawn a cosmetic ghost material variant of the ornament
        if (alreadyCollected) GetComponent<Renderer>().material = ghostMaterial;
        else GetComponent<Renderer>().material = baseMaterial;
        Debug.Log(GetComponent<Renderer>().material.name);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Player"))
        {

            switch (Type)
            {
                case Collectables.First:
                    OnFirstCollection?.Invoke();
                    Destroy(this.gameObject);
                    return;

                case Collectables.Second:
                    OnSecondCollection?.Invoke();
                    Destroy(this.gameObject);
                    return;

                case Collectables.Third:
                    OnThirdCollection?.Invoke();
                    Destroy(this.gameObject);
                    return;
            }

            //Trigger some despawn effect here. Instantiate some prefab//

        }

    }

    //What exists in the save binary?

}
