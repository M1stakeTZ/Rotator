using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer4 : MonoBehaviour
{
    public Text score;
    public Text time;
    public GameObject point;
    public GameObject win;

    int points = -1;
    int localPos = -1;
    int some = 0;

    public int count = 60;
    public int maxPoints = 60;
    void Start()
    {
        addPoint();
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
                GameObject lose = GameObject.FindGameObjectWithTag("Lose");
                if (lose != null) lose.GetComponent<AudioSource>().Play();
                Static.tries++;
                Static.time = 0f;
                Static.isStopPlayer = false;
                Static.isStopBlocks = false;

                Static.timePlayed += 60f;
                if (Static.timePlayed > Static.timeToAd)
                    GameObject.FindGameObjectWithTag("MusicNAd").GetComponent<Music>().showAd();
                else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }
            time.text = count.ToString();
            some = 0;
        }
    }

    public void addPoint()
    {
        points++;
        score.text = points.ToString() + "/" + maxPoints.ToString();

        if (points == maxPoints)
        {
            Static.isStopPlayer = true;
            Static.isStopBlocks = true;
            Static.timePlayed += Static.time;
            win.SetActive(true);
            win.GetComponent<Win>().setStats();
        }

        int r = Random.Range(0, 2);
        if (r == localPos) r = -1;
        localPos = r;

        Instantiate(point, new Vector3(0, localPos * 3, 0), new Quaternion());
    }
}
