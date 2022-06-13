using UnityEngine;
using UnityEngine.UI;

public class Open : MonoBehaviour
{
    RectMask2D mask;
    float speed;
    public bool canDo = true;
    void Start()
    {
        mask = GetComponent<RectMask2D>();
        mask.padding = new Vector4(Screen.width * 0.9375f, 0, 0, 0);
        speed = Screen.width * 3 / 4;
    }

    void Update()
    {
        if (canDo)
        {
            float x = mask.padding.x;
            mask.padding -= new Vector4(speed * Time.deltaTime, 0, 0, 0);

            if (x <= 0)
            {
                mask.padding = new Vector4(0, 0, 0);
                canDo = false;
            }
        }
    }
}
