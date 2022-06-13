using UnityEngine;

public class GoToPlayer : MonoBehaviour
{
    Transform player;
    public float speed = 1f;
    public bool isActive = false;
    RaycastHit2D hit;
    float width;
    float height;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        width = transform.localScale.x / 2;
        height = transform.localScale.y / 2;
    }

    void Update()
    {
        if (Static.isStopBlocks) return;
        if (isActive) transform.Translate((player.position - transform.position).normalized * speed * Time.deltaTime);
        else
        {
            Vector3 pos = transform.position + Vector3.right * width * znak(player.position.x - transform.position.x) + Vector3.up * height * znak(player.position.y - transform.position.y);
            hit = Physics2D.Raycast(pos, player.position.normalized, speed * Time.deltaTime);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("Player") || hit.collider.gameObject.CompareTag("AlsoPlayer"))
                {
                    transform.Translate((player.position - transform.position).normalized * speed * Time.deltaTime);
                }
            }
            else transform.Translate((player.position - transform.position).normalized * speed * Time.deltaTime);
        }
    }

    float znak(float f)
    {
        if (f > 0) return 1.01f;
        else if (f == 0) return 0;
        else return -1.01f;
    }
}
