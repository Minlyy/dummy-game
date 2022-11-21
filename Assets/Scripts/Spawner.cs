using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    public int maxSpawn;
    public float spawnTime;
    float timer = 0;
    int spawned = 0;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Enemy, transform.position, transform.rotation);
        spawned += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawned >= maxSpawn)
        {
            Destroy(this.gameObject);
        }
        timer += Time.deltaTime;
        Spawn();
    }

    void Spawn()
    {
        if(timer > spawnTime)
        {
            Instantiate(Enemy, transform.position, transform.rotation);
            spawned += 1;
            timer = 0;
        }
    }
}
