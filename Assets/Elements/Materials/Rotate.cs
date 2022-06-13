using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 1f;

    void Update()
    {
        if (Static.isStopBlocks) return;
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
