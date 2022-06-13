using UnityEngine;

public class TicTac : MonoBehaviour
{
    public float period = 2f;

    float canChange = 0f;
    BoxCollider2D bc;
    EdgeCollider2D ec;
    Renderer rend;
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        ec = GetComponent<EdgeCollider2D>();
        rend = GetComponent<Renderer>();

        if (!bc.enabled)
        {
            rend.material.color = new Color(1, 1, 1, 0.5f);
        }
    }

    void Update()
    {
        if (Static.isStopPlayer && Static.isStopBlocks) return;
        canChange += Time.deltaTime;

        if (canChange > period)
        {
            canChange -= period;

            if (bc != null)
            {
                if (bc.enabled)
                {
                    bc.enabled = false;
                    rend.material.color = new Color(1, 1, 1, 0.5f);
                }
                else
                {
                    bc.enabled = true;
                    rend.material.color = new Color(1, 1, 1, 1);
                }
            }
            else
            {
                if (ec.enabled)
                {
                    ec.enabled = false;
                    rend.material.color = new Color(1, 1, 1, 0.5f);
                }
                else
                {
                    ec.enabled = true;
                    rend.material.color = new Color(1, 1, 1, 1);
                }
            }
        }
    }
}
