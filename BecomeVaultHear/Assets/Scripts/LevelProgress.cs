using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgress : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Transform playerPos, goalPos;
    public 

    //Reference some sprite on a canvas
    //Two y positions: Start and Destination
    //Have transform of Goal and Player at all times
    //Clamp the distance between Player and Goal between 0 and 1 (maybe normalize the vector)
    //Starting y is -5, end is 5
    //Get the normalized value * 10 will give us what we want
    //YES! We know the cane is 10 units tall

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
