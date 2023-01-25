using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SillyBehaviour : MonoBehaviour
{
    Rigidbody body;
    public GameObject powerUp;

    public float      speed      = 200;
    public float      hp         = 5;
    public float      movetimer  = 5;
    private float     dropChance = 3;
    private Vector3   direction;
    
    
   
    
    void Start()
    {
        movetimer = Random.Range(3, 5);
        body = GetComponent<Rigidbody>();

        //Movimiento inicial

        direction = Random.insideUnitSphere;
        direction.y = 0;
    }

    
    void Update()
    {
        //Movemos al tonto

        body.AddForce(direction * speed * Time.deltaTime);
        movetimer -= Time.deltaTime;

        // Si se acaba el contador, cogemos un vector nuevo y reseteamos el timer con un numero random entre 3 y 5

        if (movetimer <= 0)
        {
            direction = Random.insideUnitSphere;
            direction.y = 0;

            movetimer = Random.Range(3, 6);
        }
        
    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            player.takeDamage();
            Destroy(gameObject);
        }
    }

    public void takeDamage()
    {
        hp -= 1;

        if(hp <= 0)
        {
            dropChance = Random.Range(1, 4);

            if(dropChance == 1)
            {
                Instantiate(powerUp, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}
