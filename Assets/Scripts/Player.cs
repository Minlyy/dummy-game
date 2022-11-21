using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid;
    public int speed = 20;
    public float horizontal;
    public float vertical;
    Animator anim;
    public bool isRunning = false;
    public GameObject hand;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal") * speed;
        vertical = Input.GetAxis("Vertical") * speed;
        if (horizontal != 0 || vertical != 0)
        {
            isRunning = true;
            hand.SetActive(false);
        }
        else
        {
            isRunning = false;
            hand.SetActive(true);
        }

        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = 0;
        Vector3 aimDir = (worldPos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        if(worldPos.x > transform.position.x)
            transform.eulerAngles = new Vector3(0, 180, -angle);
        else
            transform.eulerAngles = new Vector3(180, 180, angle);
        anim.SetBool("isRunning", isRunning);
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(horizontal, vertical);
    }
}
