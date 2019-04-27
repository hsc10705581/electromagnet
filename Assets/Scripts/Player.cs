using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    const int maxInt = 255;

    public float smoothing = 1;
    public float restTime = 1;
    public float restTimer = 0;

    [HideInInspector] public Vector2 targetPos = new Vector2(1, 1); //player在每一关的起点
    private Rigidbody2D rigidbody2D;
    private BoxCollider2D collider2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        rigidbody2D.MovePosition(Vector2.Lerp(transform.position, targetPos, smoothing * Time.deltaTime));
        restTimer += Time.deltaTime;
        if (restTimer < restTime) return;

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        RaycastHit2D hitHorizontal, hitVertical;
        //两个方向的都要检测，会往距离更近的吸，如果距离相同，就往起始方向吸
        if (h > 0)
        {
            collider2D.enabled = false;
            hitHorizontal = Physics2D.Linecast(targetPos, targetPos + new Vector2(maxInt, 0));
            collider2D.enabled = true;
        }
        else if(h < 0)
        {
            collider2D.enabled = false;
            hitHorizontal = Physics2D.Linecast(targetPos, targetPos + new Vector2(-maxInt, 0));
            collider2D.enabled = true;
        }
        if(v > 0)
        {
            collider2D.enabled = false;
            hitVertical = Physics2D.Linecast(targetPos, targetPos + new Vector2(0, maxInt));
            collider2D.enabled = true;
        }
        else if(v < 0)
        {
            collider2D.enabled = false;
            hitVertical = Physics2D.Linecast(targetPos, targetPos + new Vector2(0, -maxInt));
            collider2D.enabled = true;
        }
    }
}
