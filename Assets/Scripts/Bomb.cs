using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public int damage;
    public float fieldOfImpact;
    public float force;
    public LayerMask layerToHit;
    public GameObject explosion;
    bool exploded = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!exploded)
            Explode();
    }

    void Explode()
    {
        Invoke("Explosion", .5f);
        Destroy(gameObject, 0.5f);
        exploded = true;
    }
    
    void Explosion()
    {
        GameObject explode = Instantiate(explosion, transform.position, Quaternion.identity);
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, layerToHit);
        foreach (Collider2D obj in objects)
        {
            Vector2 dir = obj.transform.position - transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce(dir * force);
            obj.GetComponent<Enemy>().health -= damage;
        }
        Destroy(explode, 1f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldOfImpact);
    }
}
