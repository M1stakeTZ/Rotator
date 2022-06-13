using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text time;
    public GameObject win;
    public int count = 60;
    int some = 0;

    private void Start()
    {
        time.text = count.ToString();
    }

    void FixedUpdate()
    {
        if (Static.isStopPlayer && Static.isStopBlocks) return;
        some++;
        if (some == 60)
        {
            count--;
            if (count == 0)
            {
                Static.isStopPlayer = true;
                Static.isStopBlocks = true;
                Static.timePlayed += Static.time;
                win.SetActive(true);
                win.GetComponent<Win>().setStats();
            }
            time.text = count.ToString();
            some = 0;
        }
    }
}
