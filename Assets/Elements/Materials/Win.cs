using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public Text tries;
    public Text time;

    int index;

    public void setStats()
    {
        GetComponent<AudioSource>().Play();
        tries.text = "Попытки: " + (Static.tries + 1);
        Static.tries = 0;

        index = SceneManager.GetActiveScene().buildIndex;

        switch (index)
        {
            case 4:
                on(1);                
                break;

            case 44:
                on(5);
                break;

            case 13:
                on(2);
                break;

            case 23:
                on(3);
                break;

            case 33:
                on(6);
                break;

            case 43:
                on(7);
                break;
        }

        if (Static.time < 60)
        {
            if (Static.time < 10)
            {
                time.text = "Время: 0:0" + (int)Static.time;
                if (index == 9 && (int)Static.time <= 9 && !Static.skins[4]) on(4);
            }
            else time.text = "Время: 0:" + (int)Static.time;
        }
        else
        {
            if (Static.time % 60 < 10) time.text = "Время: " + (int)Static.time / 60 + ":0" + (int)Static.time % 60;
            else time.text = "Время: " + (int)Static.time / 60 + ":" + (int)Static.time % 60;
        }
        Static.time = 0f;
    }

    public void loadScene(int scene)
    {
        Static.isStopPlayer = false;
        Static.isStopBlocks = false;

        if (index - 3 == Static.level && index < Static.count) { Static.level++; PlayerPrefs.SetInt("level", Static.level); }

        switch (scene)
        {
            case -1:
                SceneManager.LoadScene(0);
                break;
            case 0:
                SceneManager.LoadScene(index);
                break;
            case 1:
                if (index < Static.count) SceneManager.LoadScene(index + 1);
                else SceneManager.LoadScene(0);
                break;
        }
    }

    void off() { GameObject.FindGameObjectWithTag("Car").SetActive(false); }
    void on(int ind)
    {
        if (Static.skins[ind]) return;
        Static.skins[ind] = true;
        PlayerPrefs.SetInt("skin" + ind.ToString(), 1);
        GameObject achievment = GameObject.FindGameObjectWithTag("Car");
        achievment.GetComponent<RectTransform>().localScale = new Vector3(1, 1);
        //achievment.GetComponent<AudioSource>().Play();
        Invoke("off", 3f);
    }
}
