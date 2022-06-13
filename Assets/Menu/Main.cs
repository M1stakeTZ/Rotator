using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public GameObject[] models;
    public AudioMixer mixer;
    public AnimationCurve volume;

    private void Start()
    {
        menu();
        if (!PlayerPrefs.HasKey("level"))
        {
            PlayerPrefs.SetInt("level", 1);
            PlayerPrefs.SetInt("rezhim", 1);
            PlayerPrefs.SetInt("skin", 0);
            PlayerPrefs.SetFloat("size", 0.364f);
            PlayerPrefs.SetFloat("animationTime", 0.6f);
            PlayerPrefs.SetFloat("soundTime", 0.5f);

            PlayerPrefs.SetInt("skin1", 0);
            PlayerPrefs.SetInt("skin2", 0);
            PlayerPrefs.SetInt("skin3", 0);
            PlayerPrefs.SetInt("skin4", 0);
            PlayerPrefs.SetInt("skin5", 0);
            PlayerPrefs.SetInt("skin6", 0);
            PlayerPrefs.SetInt("skin7", 0);
            PlayerPrefs.SetInt("skin8", 0);
        }
        else 
        {
            Static.level = PlayerPrefs.GetInt("level");
            Static.skin = PlayerPrefs.GetInt("skin");
            Static.size = PlayerPrefs.GetFloat("size");
            Static.animationTime = PlayerPrefs.GetFloat("animationTime");
            Static.soundTime = PlayerPrefs.GetFloat("soundTime");
            Static.rezhim = PlayerPrefs.GetInt("rezhim") == 1;

            Static.skins[1] = PlayerPrefs.GetInt("skin1") == 1;
            Static.skins[2] = PlayerPrefs.GetInt("skin2") == 1;
            Static.skins[3] = PlayerPrefs.GetInt("skin3") == 1;
            Static.skins[4] = PlayerPrefs.GetInt("skin4") == 1;
            Static.skins[5] = PlayerPrefs.GetInt("skin5") == 1;
            Static.skins[6] = PlayerPrefs.GetInt("skin6") == 1;
            Static.skins[7] = PlayerPrefs.GetInt("skin7") == 1;
            Static.skins[8] = PlayerPrefs.GetInt("skin8") == 1;
        }

        mixer.SetFloat("Master", volume.Evaluate(Static.soundTime));
    }

    void menu()
    {
        for (int i = 0; i < 4; i++)
        {
            models[i].GetComponent<MenuMovement>().canMove = true;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        if (Static.level != 21) SceneManager.LoadScene(Static.level + 3);
    }

    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
