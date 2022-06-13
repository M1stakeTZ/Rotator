using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed = 1f;
    Vector2 dir;
    public Vector2 target;
    bool isCanGo = false;
    Transform player;
    bool toX;
    bool toY;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        dir = ((Vector3)target - transform.position).normalized;
        toX = dir.x > 0;
        toY = dir.y > 0;
    }

    void Update()
    {
        if (!isCanGo) return;

        dir = ((Vector3)target - transform.position).normalized;
        Vector3 to = dir * speed * Time.deltaTime;

        if (toX != to.x > 0 || toY != to.y > 0)
        {
            player.position = target;
            Destroy(gameObject);
        }

        transform.Translate(to);
        player.position = transform.position;
    }

    public void beginMove()
    {
        isCanGo = true;
        player.position = transform.position;
    }
}
