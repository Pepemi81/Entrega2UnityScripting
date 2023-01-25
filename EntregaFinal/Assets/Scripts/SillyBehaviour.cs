using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SillyBehaviour : MonoBehaviour
{
    Rigidbody body;

    public float      speed     = 200;
    public float      hp        = 5;
    public float      movetimer = 5;
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
            Debug.Log(direction);
        }
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.takeDamage();
            Destroy(gameObject);
        }
    }

    public void takeDamage()
    {
        hp -= 1;

        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
