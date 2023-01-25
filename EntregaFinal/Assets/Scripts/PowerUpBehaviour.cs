using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehaviour : MonoBehaviour
{
    private int powerindex = 0;
    private new Renderer renderer;

    public AudioSource pickupfx;

    void Start()
    {
        
    }

    private void Awake() // Se genera un número aleatorio y se aplica el color
    {
        powerindex = Random.Range(0, 2);
        renderer = GetComponent<Renderer>();
        setColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other) // Al colisionar con el player, se activa dependiendo del numero que salga la función correspondiente
    {

        if (other.tag == "Player")
        {
            PlayerController player = other.GetComponent<PlayerController>();

            switch (powerindex)
            {
                case 0:

                    player.useMedkit();


                    break;

                case 1:

                    player.setUltraRof();

                    break;
            }
            pickupfx.Play();

            Object.Destroy(gameObject);
        }

    }

    public void setColor()
    {
        switch (powerindex) //Se le aplica un color dependiendo de el valor que salga al ser creado
        {
            case 0:
                renderer.material.color = Color.red;

                break;

            case 1:
                renderer.material.color = Color.green;

                break;

        }
    }
}
