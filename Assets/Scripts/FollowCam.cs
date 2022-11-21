using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    Vector3 offset = new Vector3(0f, 0f, -10f);
    float smoothTime = 0.25f;
    Vector3 velocity = Vector3.zero;

    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothTime);
        transform.position = smoothPosition;

    }
}
