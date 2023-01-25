using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField]
    private int speed = 5;
    private float dietime = 3;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime, Space.Self);

        dietime -= Time.deltaTime;

        if (dietime <= 0)
        {
            Object.Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "SillyEnemy")
        {
            SillyBehaviour sillyenemy = other.GetComponent<SillyBehaviour>();

            if (sillyenemy != null)
            {
                sillyenemy.takeDamage();
            }

            Object.Destroy(gameObject);
        }

        if (other.tag == "Surface")
        {
            Object.Destroy(gameObject);
        }
        
    }
}
