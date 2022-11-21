using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    float timer = 0;
    public float fireSpeed = .25f;
    public Animator anim;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ShootBullet();
        timer += Time.deltaTime;
    }

    void ShootBullet()
    {
        if (Input.GetMouseButton(0) && timer > fireSpeed)
        {
            audio.Play();
            timer = 0;
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.z = -1;
            Instantiate(bullet, worldPos, transform.rotation);
            anim.SetBool("isFiring", true);
        }
        else
            anim.SetBool("isFiring", false);
    }
    
}
