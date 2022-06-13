using UnityEngine;

public class MenuMovement : MonoBehaviour
{
    public float target;
    public float speed;
    public float rotateSpeed;
    public bool canMove = false;

    void Update()
    {
        if (isActiveAndEnabled)
        {
            if (canMove) if (target - transform.position.x <= 0)
                {
                    transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
                }
                else
                {
                    canMove = false;
                    transform.position = new Vector3(target, transform.position.y, 0);
                }
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }
    }
}
