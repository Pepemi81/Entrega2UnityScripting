using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;

    public float lerp = 0.05f;

    public Vector3 posoffset;

    public Quaternion rotoffset;


    void Start()
    {
        transform.rotation = target.transform.rotation * rotoffset;
    }

    
    void FixedUpdate()
    {

        Vector3 lagpos = target.transform.position + posoffset;
        Vector3 smoothpos = Vector3.Lerp(transform.position, lagpos, lerp);

        transform.position = smoothpos;
        transform.LookAt(target.transform.position);
               
    }
}
