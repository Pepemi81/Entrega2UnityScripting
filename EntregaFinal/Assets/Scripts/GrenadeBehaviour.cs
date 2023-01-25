using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GrenadeBehaviour : MonoBehaviour
{
    Rigidbody       body;
    public ParticleSystem explodefx;
    public AudioSource explodeSound;

    public float    axisforce    = 0;
    public float    launchforce  = 10;
    public int      bouncecount = 0;

    private void Awake()
    {
        bouncecount = 4;

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

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Surface")
        {
            bouncecount--;

            if (bouncecount <= 0)
            {
                explodeNade();
            }
        }

        if (other.gameObject.tag == "SillyEnemy")
        {
            explodeNade();
        }
    }

    public void explodeNade()
    {
        Collider[] enemyHits = Physics.OverlapSphere(transform.position, 100);

        foreach(Collider col in enemyHits)
        {
            Rigidbody rgbd = col.GetComponent<Rigidbody>();

            if (rgbd != null)
            {
                rgbd.AddExplosionForce(10 , transform.position, 10);
            }

            SillyBehaviour sillyenemy = col.GetComponent<SillyBehaviour>();
            GameObject sillybody      = col.GetComponent<GameObject>();

            Object.Destroy(sillybody);
        }

        explodeSound.Play();

        Instantiate(explodefx, transform.position, Quaternion.identity); 

        Destroy(gameObject);
    }
}
