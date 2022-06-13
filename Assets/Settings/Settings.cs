using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Sprite[] micro;
    public Image mic;

    public RectTransform joystick;
    public RectTransform hammer;
    public AnimationCurve size;
    public AnimationCurve volume;

    public Slider slide;
    public Slider joy;
    public Toggle rezh;

    public AudioMixer mixer;
    public Transform inter;
    void Start()
    {
        joy.value = Static.animationTime;
        slide.value = Static.soundTime;
        rezh.isOn = Static.rezhim;

        joystick.anchorMin = new Vector2(rezh.isOn ? 1 : 0, 0);
        joystick.anchorMax = new Vector2(rezh.isOn ? 1 : 0, 0);
        joystick.anchoredPosition = new Vector2((rezh.isOn ? -1 : 1) * (450 * Static.size), 450 * Static.size);
        inter.position = new Vector2((rezh.isOn ? -1 : 1) * 3, -5);
    }
    public void changeMusic()
    {
        mixer.SetFloat("Master", volume.Evaluate(slide.value));
        Static.soundTime = slide.value;
        mic.color = new Color(slide.value * 0.5f, 0, 0, 1);
        if (slide.value == 0f) mic.sprite = micro[0];
        else if (slide.value < 0.5f) mic.sprite = micro[1];
        else mic.sprite = micro[2];
        PlayerPrefs.SetFloat("soundTime", slide.value);
    }

    public void changeRezhim()
    {
        Static.rezhim = rezh.isOn;
        PlayerPrefs.SetInt("rezhim", rezh.isOn ? 1 : 0);
        joystick.anchorMin = new Vector2(rezh.isOn ? 1 : 0, 0);
        joystick.anchorMax = new Vector2(rezh.isOn ? 1 : 0, 0);
        joystick.anchoredPosition = new Vector2((rezh.isOn ? -1 : 1) * 450 * Static.size, 450 * Static.size);
        inter.position = new Vector2((rezh.isOn ? -1 : 1) * 3, -5);
    }

    public void changeJoystick()
    {
        Static.animationTime = joy.value;
        float value = size.Evaluate(joy.value);
        Static.size = value;
        PlayerPrefs.SetFloat("size", value);
        PlayerPrefs.SetFloat("animationTime", joy.value);

        joystick.anchoredPosition = new Vector2((rezh.isOn ? -1 : 1) * (450 * value), 450 * value); 
        joystick.sizeDelta = new Vector2(680 * value, 680 * value);
        hammer.sizeDelta = new Vector2(320 * value, 320 * value);
    }

    public void back() { SceneManager.LoadScene(0); }
}
