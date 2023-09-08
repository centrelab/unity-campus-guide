using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceUser : MonoBehaviour
{
    public bool reverseDirection;
    public bool lockXAxis;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        if (reverseDirection) {
            transform.Rotate( 0, 180, 0 ) ;
        }
        if (lockXAxis) {
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }

    }
}
