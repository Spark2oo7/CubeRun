using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<PlayerMovement>().gameObject.GetComponent<PlayerMovement>().enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
