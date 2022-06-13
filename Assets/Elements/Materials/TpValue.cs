using UnityEngine;

public class TpValue : MonoBehaviour
{
    public float period = 1f;
    public bool notChanged = true;
    public int valueCount = 0;

    float time = 0f;
    Renderer rend;
    public int value = 0;

    private void Update()
    {
        if (notChanged) return;
        if (Static.isStopBlocks) return;
        time += Time.deltaTime;

        if (time > period)
        {
            time -= period;

            value++;
            if (value == valueCount) value = 0;

            setColor();
        }
    }

    private void Start()
    {
        rend = GetComponent<Renderer>();

        setColor();
    }

    void setColor()
    {
        Color c = new Color();
        switch (value)
        {
            case 0:
                c = Color.blue;
                break;
            case 1:
                c = Color.green;
                break;
            case 2:
                c = Color.yellow;
                break;
            case 3:
                c = Color.red;
                break;
            case 4:
                c = Color.cyan;
                break;
            case 5:
                c = Color.magenta;
                break;
        }
        rend.material.color = c;
    }
}
