using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    public GameObject achievment;
    public void back()
    {
        SceneManager.LoadScene(0);
    }

    private void Start()
    {
        if (Static.isSkinGet)
        {
            Static.isSkinGet = false;
            achievment.SetActive(true);
            achievment.GetComponent<AudioSource>().Play();
            Invoke("off", 3f);
        } 
    }

    void off() { achievment.SetActive(false); }
}
