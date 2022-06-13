using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pause;
    bool player;
    bool blocks;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause_();
        }
    }

    public void pause_()
    {
        if (pause.activeSelf)
        {
            Static.isStopPlayer = player;
            Static.isStopBlocks = blocks;
            pause.SetActive(false);
        }
        else
        {
            player = Static.isStopPlayer;
            Static.isStopPlayer = true;
            blocks = Static.isStopBlocks;
            Static.isStopBlocks = true;
            pause.SetActive(true);
        }
    }

    public void loadScene(int scene)
    {

        switch (scene)
        {
            case -1:
                Static.isStopPlayer = false;
                Static.isStopBlocks = false;
                Static.time = 0f;
                Static.tries = 0;
                SceneManager.LoadScene(0);
                break;
            case 0:
                Static.isStopPlayer = false;
                Static.isStopBlocks = false;
                Static.time = 0f;
                Static.tries = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            case 1:
                pause_();
                break;
        }
    }
}
