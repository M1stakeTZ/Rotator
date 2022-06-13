using UnityEngine;
using UnityEngine.UI;

public class Timer3 : MonoBehaviour
{
    public Text timer;
    public GameObject win;
    public GameObject movingPlatform;
    public GameObject[] tickers;

    public int count = 60;
    public float speed = 1f;

    int timeToNext = 0;
    int next = 120;

    int some = 0;
    int local = 0;
    GameObject[] goes = new GameObject[210];

    private void Start()
    {
        timer.text = count.ToString();
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
            timer.text = count.ToString();
            some = 0;
        }
        timeToNext++;
        if (timeToNext == next)
        {
            timeToNext = 0;
            next -= 1;
            goes[local] = Instantiate(movingPlatform, new Vector3(-2, 6, 0), new Quaternion());
            goes[local].GetComponent<MovingPl>().target = new Vector2(-2, -8);
            goes[local].GetComponent<MovingPl>().speed = speed;
            local++;
            goes[local] = Instantiate(movingPlatform, new Vector3(0, 6, 0), new Quaternion());
            goes[local].GetComponent<MovingPl>().target = new Vector2(0, -8);
            goes[local].GetComponent<MovingPl>().speed = speed;
            local++;
            goes[local] = Instantiate(movingPlatform, new Vector3(2, 6, 0), new Quaternion());
            goes[local].GetComponent<MovingPl>().target = new Vector2(2, -8);
            goes[local].GetComponent<MovingPl>().speed = speed;
            local++;
        }

        for (int i = 0; i < local; i++)
        {
            if (goes[i] == null) continue;

            float y = goes[i].transform.position.y;
            if (y > 2.7f && y < 3.3f)
            {
                if (tickers[(int)goes[i].transform.position.x / 2 + 1].GetComponent<BoxCollider2D>().enabled)
                    Destroy(goes[i]);
            }

            else if (y < -6)
            {
                Destroy(goes[i]);
            }
        }
    }
}
