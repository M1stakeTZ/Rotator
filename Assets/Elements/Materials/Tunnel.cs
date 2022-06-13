using UnityEngine;

public class Tunnel : MonoBehaviour
{
    bool isDo = false;
    void Update()
    {
        if (isDo) return;
        if (Static.isGameBegin)
        {
            Static.isGameBegin = false;
            GetComponent<Renderer>().material.color = new Color(1, 1, 1, 2);
        }
    }
}
