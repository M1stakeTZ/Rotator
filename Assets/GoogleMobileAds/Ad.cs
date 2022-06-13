using UnityEngine;
using GoogleMobileAds.Api;

public class Ad : MonoBehaviour
{
    void Awake()
    {
        MobileAds.Initialize(initStatus => { });
    }
}
