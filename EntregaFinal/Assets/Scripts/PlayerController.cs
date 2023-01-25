using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody         cuerpo;
    public GameObject shootPoint;
    public GameObject bullet;
    public GameObject grenade;

    private Vector3   turn;

    
    private int  weaponmode   = 1;
    public float hp           = 5;
    public float maxhp        = 5;
    public float speed        = 10;
    public float turnsens     = 1;
    public float shootrate    = 0.5f;
    public float shootreset   = 0;
    public float grenaderate  = 2f;
    public float grenadereset = 0;

    private bool canShoot = true;



    private void Awake() //Setea las variables al ser instanciado
    {
        hp = maxhp;
        weaponmode = 1;
    }

    void Start()
    {
        //Accedemos al rigidbody del player para poder usarlo luego
        cuerpo = GetComponent<Rigidbody>();
        
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponmode = 1;
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponmode = 2;
            
        }        
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weaponmode = 3;
        }

        playermove();
        playershoot(weaponmode);

    }

    private void playermove ()
    {
        //FWDMovement

        float finput = Input.GetAxis("Vertical");

        Vector3 inputvert = new Vector3(0, 0, finput);

        cuerpo.AddRelativeForce(inputvert * Time.deltaTime * speed);


        //SWMovement

        float sinput = Input.GetAxis("Horizontal");

        Vector3 inputhor = new Vector3(sinput, 0, 0);

        cuerpo.AddRelativeForce(inputhor * Time.deltaTime * speed);


        if(Input.GetKey(KeyCode.LeftArrow)) 
        {
            cuerpo.AddRelativeTorque(new Vector3(0, -turnsens, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            cuerpo.AddRelativeTorque(new Vector3(0, turnsens, 0));
        }

    }

    private void playershoot (int firemode)
    {
        //Modos de fuego y accion

        if (firemode == 1 && Input.GetKey(KeyCode.Space))
        {
            if(shootreset <= Time.time)
            {
                Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
                shootreset = Time.time + shootrate;
            }
            
        }
        if (firemode == 2 && Input.GetKey(KeyCode.Space))
        {
            if(Physics.Raycast(shootPoint.transform.position,shootPoint.transform.forward,500))
            {

            }
        }
        if (firemode == 3 && Input.GetKeyUp(KeyCode.Space))
        {
            if (grenadereset <= Time.time)
            {
                Instantiate(grenade, shootPoint.transform.position, shootPoint.transform.rotation);
                grenadereset = Time.time + grenaderate;
            }
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

    public void useMedkit()
    {
        hp = 5;
    }
    
}
