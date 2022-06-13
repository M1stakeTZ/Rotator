using UnityEngine;

public class MovingPl : MonoBehaviour
{
    public Vector2 target;
    Vector2[] targets = new Vector2[2];
    public float speed;

    int local = 1;
    Vector2 dir;

    void Start()
    {
        targets[0] = (Vector2)transform.position;
        targets[1] = target;
        dir = (targets[1] - targets[0]).normalized;
    }

    void Update()
    {
        if (Static.isStopBlocks) return;
        if (dir == Vector2.zero) return;
        Vector2 d = dir * speed * Time.deltaTime;
        float x = transform.position.x;
        float xTarg = targets[local].x;
        float y = transform.position.y;
        float yTarg = targets[local].y;

        if (znak(x - xTarg) == znak(d.x + x - xTarg) && znak(y - yTarg) == znak(d.y + y - yTarg))
        {
            transform.Translate(d);
        }
        else
        {
            d -= targets[local] - new Vector2(x, y);
            dir *= -1;
            transform.position = targets[local];
            transform.Translate(-d);
            local = local == 0 ? 1 : 0;
        }
    }

    int znak(float f)
    {
        if (f > 0) return 1;
        else if (f == 0) return 0;
        else return -1;
    }
}
