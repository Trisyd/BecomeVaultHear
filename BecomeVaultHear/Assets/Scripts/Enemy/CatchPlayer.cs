using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Behavior for when the Father enemy induces game over
public class CatchPlayer : MonoBehaviour
{
    public delegate void Detected();
    public static event Detected OnDetected;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //Send detect player signal
            OnDetected?.Invoke();
            
        }
    }
}
