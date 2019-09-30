using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public delegate void ObstacleCollision();
    public static event ObstacleCollision OnObstacleCollision;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Collided with Obstacle");
            OnObstacleCollision?.Invoke();
        }
    }
}
