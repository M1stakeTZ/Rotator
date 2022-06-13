using UnityEngine;
using UnityEngine.UI;

public class SetSkin : MonoBehaviour
{
    public int num;
    public Transform light_;
    float speed;

    public Text text;
    public GameObject locked;

    bool isDoWhite = false;
    bool is9 = false;
    void Start()
    {
        speed = Random.Range(200, 400) * (Random.Range(0, 2) * 2 - 1);
        if (Static.skin == num) light_.position = transform.position;
        if (Static.skins[num]) locked.SetActive(false);
        text.fontSize = (int)Screen.width / 30;
    }
    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * speed);
    }

    private void FixedUpdate()
    {
        if (isDoWhite)
        {
            text.color = new Color(0, 0, 0, text.color.a - 0.05f);

            if (text.color.a == 0) isDoWhite = false;
        }
    }

    public void setSkin()
    {
        if (!Static.skins[num]) return;
        Static.skin = num;
        PlayerPrefs.SetInt("skin", num);
        light_.position = transform.position;
    }

    public void showQuest()
    {
        if (Static.skins[num]) return;

        Invoke("unshowQuest", 2f);
    }

    public void enter()
    {
        if (Static.skins[num]) return;

        CancelInvoke();
        if (num == 8 && !is9) is9 = true;
        if (num == 8 && is9)
        {
            GameObject.FindGameObjectWithTag("MusicNAd").GetComponent<Music>().showRewAd();
            return;
        }
        isDoWhite = false;
        text.color = new Color(0, 0, 0, 1);
    }

    void unshowQuest()
    {
        isDoWhite = true;
    }
}
