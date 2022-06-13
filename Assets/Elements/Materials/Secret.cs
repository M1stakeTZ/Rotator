using UnityEngine;

public class Secret : MonoBehaviour
{
    public SpriteRenderer[] sr;
    void Start()
    {
        Invoke("Off", 0.5f);
    }

    void Off()
    {
        for (int i = 0; i < 4; i++)
        {
            sr[i].enabled = false;
        }
    }
}
