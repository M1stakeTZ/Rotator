using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class Music : MonoBehaviour
{
    InterstitialAd ia;
    RewardedAd ra;

    readonly string initID = "ca-app-pub-3098171792778485/9439679315";
    readonly string rewID = "ca-app-pub-3098171792778485/6566582892";

    AdRequest ar = new AdRequest.Builder().Build();
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        MobileAds.Initialize(initStatus => { });
    }

    private void OnEnable()
    {
        ia = new InterstitialAd(initID);
        ra = new RewardedAd(rewID);
    }

    public void showAd()
    {
        ia.LoadAd(ar);
        if (ia.IsLoaded()) ia.Show();
        Static.timePlayed = 0;
        Invoke("loadScene", 0.05f);
    }

    public void showRewAd()
    {
        ra.LoadAd(ar);
        ra.OnUserEarnedReward += HandleUserEarnerReward;
        if (ra.IsLoaded()) ra.Show();
        else
        {
            GameObject.FindGameObjectWithTag("Activate").GetComponent<RectTransform>().localScale = new Vector3(1, 1);
            Invoke("off", 3f);
        }
    }

    void loadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void HandleUserEarnerReward(object sender, Reward e)
    {
        Static.skins[8] = true;
        PlayerPrefs.SetInt("skin8", 1);
        Static.isSkinGet = true;
        loadScene();
    }

    void off()
    {
        GameObject.FindGameObjectWithTag("Activate").GetComponent<RectTransform>().localScale = new Vector3(1, 0);
    }
}
