using UnityEngine;

public class MenuCube : MonoBehaviour
{
    public float speed;
    public Transform tr;
    public Material gold;

    void Start()
    {
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
        tr.Rotate(new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, 0));
    }
}
