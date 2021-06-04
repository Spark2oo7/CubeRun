using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public Transform end;
    public float percent;

    // Update is called once per frame
    void Update()
    {
        percent = player.position.z / end.position.z * 100;
        if (percent >= 100)
        {
            scoreText.text = "100%";
        }
        else
        {
            scoreText.text = percent.ToString("0") + "%";
        }
    }
}
