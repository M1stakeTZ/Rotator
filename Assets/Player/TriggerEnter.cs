using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerEnter : MonoBehaviour
{
    public GameObject win;
    bool canTeleport = true;
    GameObject[] OnOffs;
    bool isMain = false;
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (Static.isStopPlayer && Static.isStopBlocks) return;

        string Tag = c.gameObject.tag;

        switch (Tag)
        {
            case "Untagged":
            case "BlockOnOff":
                GameObject lose = GameObject.FindGameObjectWithTag("Lose");
                if (lose != null) lose.GetComponent<AudioSource>().Play();
                Static.tries++;

                Static.timePlayed += Static.time;
                Static.time = 0f;
                Static.isStopPlayer = false;
                Static.isStopBlocks = false;

                if (Static.timePlayed > Static.timeToAd)
                                    GameObject.FindGameObjectWithTag("MusicNAd").GetComponent<Music>().showAd();
                else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;

            case "Finish":
                if (isMain)
                {
                    Static.isStopPlayer = true;
                    Static.isStopBlocks = true;
                    Static.timePlayed += Static.time;

                    win.SetActive(true);
                    win.GetComponent<Win>().setStats();
                }
                break;

            case "StopRotation":
                Static.isStopPlayer = true;
                break;

            case "StopBlocks":
                Static.isStopBlocks = true;
                break;

            case "Resume":
                Static.isStopBlocks = false;
                Static.isStopPlayer = false;
                break;

            case "Slower":
                GameObject.FindGameObjectWithTag("Player").GetComponent<RotateAndMove>().rotateSpeed = 25;
                break;

            case "Faster":
                GameObject.FindGameObjectWithTag("Player").GetComponent<RotateAndMove>().movementSpeed = 0.7f;
                break;

            case "Respawn":
                GameObject.FindGameObjectWithTag("Faster").GetComponent<Timer2>().tp();
                break;

            case "AddPoint":
                if (GameObject.FindGameObjectsWithTag("AddPoint").Length > 1) return;
                GameObject.FindGameObjectWithTag("Faster").GetComponent<Timer4>().addPoint();
                Destroy(c.gameObject);
                break;

            case "On":
                OnOff(true);
                break;

            case "Off":
                OnOff(false);
                break;

            case "Activate":
                float t = c.gameObject.GetComponent<Activate>().time;
                if (t > 0)
                {
                    Static.isStopBlocks = false;
                    c.gameObject.GetComponent<Activate>().time = 0;
                    Invoke("stopBlocks", t);
                }
                break;

            case "Tp":
                if (!canTeleport) return;
                if (!isMain) return;
                canTeleport = false;
                int v = c.gameObject.GetComponent<TpValue>().value;

                foreach(GameObject tp in GameObject.FindGameObjectsWithTag("Tp"))
                {
                    if (tp != c.gameObject && v == tp.GetComponent<TpValue>().value)
                    {
                        GameObject.FindGameObjectWithTag("Player").transform.position = tp.transform.position;
                        break;
                    }
                }

                Invoke("canTp", 0.1f);
                break;

            case "Car":
                if (!isMain) return;
                c.gameObject.GetComponent<Car>().beginMove();
                break;
        }
    }

    private void Update()
    {
       if (isMain) Static.time += Time.deltaTime;
    }

    void OnOff(bool isOn)
    {
        if (Static.lastBool == isOn) return;
        Static.lastBool = isOn;
        Color c;  

        if (OnOffs.Length != 0) c = OnOffs[0].GetComponent<Renderer>().material.color;
        else c = new Color();
        for (int i = 0; i < OnOffs.Length; i++)
        {
            isOn = !OnOffs[i].GetComponent<BoxCollider2D>().enabled;
            OnOffs[i].GetComponent<BoxCollider2D>().enabled = isOn;

            OnOffs[i].GetComponent<Renderer>().material.color = new Color(1, 1, 1, isOn ? 1f : 0.5f);
        }
    }

    private void Start()
    {
        if (win != null) isMain = true;
        OnOffs = GameObject.FindGameObjectsWithTag("BlockOnOff");
        for (int i = 0; i < OnOffs.Length; i++)
        {
            if (!OnOffs[i].GetComponent<BoxCollider2D>().enabled) OnOffs[i].GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0.5f);
        }
        if (GameObject.FindGameObjectWithTag("Activate") != null) Static.isStopBlocks = true;
    }

    void stopBlocks() { Static.isStopBlocks = true; }
    void canTp() { canTeleport = true; }
}
