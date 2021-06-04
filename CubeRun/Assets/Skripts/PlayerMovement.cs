using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce;
    public float sidewaysForce;
    private Touch theTouch;
    public Material gold;

    private void Start()
    {
        rb = FindObjectOfType<PlayerCollision>().gameObject.GetComponent<Rigidbody>();

        int l = 0;
        while (PlayerPrefs.GetInt("complete" + (l + 1), 0) == 1)
        {
            l++;
        }
        if (l == 15)
        {
            GetComponent<MeshRenderer>().material = gold;
        }
    }
    // Update is called once per frame
    void Update()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        if ( Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); // VelocityChange 50  Acceleration 2000  Force 2000 Impulse 70
        }
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            if (theTouch.position.x < Screen.width / 2)
            {
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            else
            {
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
        }
        if (rb.position.y < 0.85f)
        {
            enabled = false;
            FindObjectOfType<GameManager>().EndGame();
            return;
        }
    }
}
