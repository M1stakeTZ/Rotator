using UnityEngine;

public class RotateAndMove : MonoBehaviour
{
    public float rotateSpeed = 1f;
    public float movementSpeed = 1f;
    public Vector2 speed = Vector2.zero;
    bool isGameBegin = false;

    public Sprite[] circles;
    public Sprite[] rombs;

    void Update()
    {
        if (Static.isStopPlayer)
        {
            if (Static.isStopBlocks) return;
            transform.position = transform.position + (Vector3)(speed * movementSpeed * Time.deltaTime / Static.size);
        }
        else
        {
            if (!isGameBegin) if (speed != Vector2.zero)
            {
                Static.isGameBegin = true;
                isGameBegin = true;
            }
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
            transform.position = transform.position + (Vector3)(speed * movementSpeed * Time.deltaTime / Static.size);
        }
    }

    private void Start()
    {
        int skin = Static.skin;
        Static.lastBool = true;
        SpriteRenderer[] sr = new SpriteRenderer[3]
        {
            transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>(),
            transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>(),
            transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>()
        };
        sr[0].sprite = circles[skin];
        sr[1].sprite = rombs[skin];
        sr[2].sprite = rombs[skin];
        if (skin == 5)
        {
            sr[1].color = new Color(45f / 255f, 119f / 255f, 183f / 255f);
            sr[2].color = new Color(45f / 255f, 119f / 255f, 183f / 255f);
        }
        else if (skin == 0)
        {
            sr[0].color = new Color(0.42f, 0.48f, 0.66f);
            sr[1].color = new Color(0, 0.38f, 1);
            sr[2].color = new Color(0, 0.38f, 1);
        }
    }
}
