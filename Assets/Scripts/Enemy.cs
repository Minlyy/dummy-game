using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 5;
    public int speed = 1;
    private GameObject player;
    SpriteRenderer rend;
    Color originalColor;
    bool triggered = false;
    Collider2D other;
    // Start is called before the first frame update

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rend = GetComponent<SpriteRenderer>();
        originalColor = rend.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
        float dis = Vector2.Distance(transform.position, player.transform.position);
        Vector2 dir = player.transform.position - transform.position;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        Vector3 aimDir = (player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);

        if(triggered && !other)
        {
            rend.color = originalColor;
            triggered = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            health -= collision.gameObject.GetComponent<Bullet>().damage;
            rend.color = Color.red;
        }
        if (collision.CompareTag("Bomb"))
        {
            rend.color = Color.red;
        }
        triggered = true;
        other = collision;
    }

}
