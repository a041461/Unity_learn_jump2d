using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    float dampTime = 0.5f;
    public Transform targer;
    Vector3 velocity = Vector3.zero;


   
    // Update is called once per frame
    void Update()
    {
        if (targer!=null)
        {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(targer.position);
            Vector3 delta = targer.position - Camera.main.ViewportToWorldPoint(new Vector3(0f,0f,point.z));
            Vector3 destination = transform.position + delta;
            destination.x = 0f;
            if (destination.y != transform.position.y)
            {
                transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
            }
        }
        
    }
}
