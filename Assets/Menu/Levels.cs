using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public GameObject[] levels;
    public RectTransform secret;
    void Start()
    {
        for (int i = 0; i < Static.level; i++)
        {
            levels[i].SetActive(false);
        }
        secret.anchoredPosition = new Vector2(0, Screen.height / 6);
    }

    public void openLevel(int level)
    {
        if (level <= Static.level || level == 21) SceneManager.LoadScene(level + 3);
    }
}
