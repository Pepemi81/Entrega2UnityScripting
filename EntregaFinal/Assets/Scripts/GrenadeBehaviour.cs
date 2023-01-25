using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBehaviour : MonoBehaviour
{
    Rigidbody       body;
    public Collider collision;
    public float    axisforce    = 0;
    public float    launchforce  = 10;
    public int      bouncecount = 0;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();

        Vector3 launchvector = new Vector3(0, 1, -1);
        Vector3 rotatevector = new Vector3(0, 1, -1);

        body.AddRelativeForce(launchvector * launchforce * Time.deltaTime);

        body.AddRelativeTorque(rotatevector * axisforce * Time.deltaTime);

    }

    void Start()
    {
        
    }

    void Update()
    {

        
    }
}
