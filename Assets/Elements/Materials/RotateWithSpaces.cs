using UnityEngine;

public class RotateWithSpaces : Rotate
{
    public float[] times;
    public float[] speeds;
    int i = 0;
    void Start()
    {
        speed = speeds[0];
        Invoke("Next", times[0]);
    }
    void Next()
    {
        i++;
        if (i == times.Length) i = 0;
        speed = speeds[i];
        Invoke("Next", times[i]);
    }
}
