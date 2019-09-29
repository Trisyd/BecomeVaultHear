using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    public delegate void Detected();
    public static event Detected OnDetected;
    public Transform target;


    private void Update()
    {
        transform.LookAt(target);
        ShootRaycast();
    }


    //invisible cone shaped object and do collision testing on that.
    //Then if any collisions come up positive do a ray from the enemy to the player
    //to make sure its an actual line-of-sight.
    void DrawColoredRay(Color col)
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, col);
    }

    

    public void ShootRaycast()
    {
        Debug.Log("Shooting Raycast");
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.transform.gameObject.tag == "Player")
            {
                DrawColoredRay(Color.red);
                //Make use of event system
                //OnDetected();
                Debug.Log("Found Player");
            }

            else { Debug.Log("Hit wall"); DrawColoredRay(Color.black); }

            
        }

        else
        {
            DrawColoredRay(Color.blue);
        }
    }



}
