using UnityEngine;

public class MoveOstacle : MonoBehaviour
{
    public bool move = true;
    public Rigidbody rb;
    public bool target1;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            if (rb.position.x <= -7f)
            {
                target1 = false;
            }
            if (rb.position.x >= 7f)
            {
                target1 = true;
            }
            if (target1)
            {
                rb.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            }
            else
            {
                rb.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }
        }
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Obstacle" || collisionInfo.gameObject.tag == "Player")
        {
            move = false;
        }
    }
}
