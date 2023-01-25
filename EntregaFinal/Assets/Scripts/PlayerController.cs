using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody            cuerpo;
    public GameManager   manager;
    public CanvasManager canvas;
    public GameObject    shootPoint;
    public GameObject    bullet;
    public GameObject    grenade;

    private Vector3   turn;

    private bool ultraRof        = false;
    private int  weaponmode      = 1;
    public int   hp              = 5;
    public int   maxhp           = 5;
    public float speed           = 10;
    public float turnsens        = 1;
    public float shootrate       = 0.5f;
    public float shootref        = 0.5f;
    public float shootreset      = 0;
    public float grenaderate     = 2f;
    public float grenaderef      = 2f;
    public float grenadereset    = 0;

    public float powerupduration = 5;
    public float powerupreset    = 5;

    public AudioSource shootfx;
    public AudioSource rayfx;
    public AudioSource grenadefx;
    public AudioSource hurtfx;






    private void Awake() //Setea las variables al ser instanciado
    {
        hp           = maxhp;
        weaponmode   = 1;
        shootref     = shootrate;
        grenaderef   = grenaderate;
        powerupreset = powerupduration;

    }

    void Start()
    {
        //Accedemos al rigidbody del player para poder usarlo luego
        cuerpo = GetComponent<Rigidbody>();
        
    }


    void Update()
    {
        //Input para cambiar de armas

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

        canvas.PlayerLifeBar(hp, maxhp);
        playermove();
        useRof();
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
                shootfx.Play();
                Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
                shootreset = Time.time + shootrate;
            }
            
        }
        if (firemode == 2 && Input.GetKey(KeyCode.Space))
        {
            if(shootreset <= Time.time)
            {
                if (Physics.Raycast(shootPoint.transform.position, shootPoint.transform.up, out RaycastHit hitinfo, Mathf.Infinity, LayerMask.NameToLayer("SillyEnemy")))
                {
                    rayfx.Play();
                    Debug.DrawRay(shootPoint.transform.position, shootPoint.transform.up, Color.green, Mathf.Infinity);
                    shootreset = Time.time + shootrate;

                    if (hitinfo.rigidbody.gameObject.tag == "SillyEnemy")
                    {
                        SillyBehaviour enemy = hitinfo.rigidbody.GetComponent<SillyBehaviour>();

                        enemy.takeDamage();
                    }
                }
            }

                
        }
        if (firemode == 3 && Input.GetKeyUp(KeyCode.Space))
        {
            if (grenadereset <= Time.time)
            {
                grenadefx.Play();
                Instantiate(grenade, shootPoint.transform.position, shootPoint.transform.rotation);
                grenadereset = Time.time + grenaderate;
            }
        }
    }

    public void takeDamage()
    {
        hp -= 1;
        hurtfx.Play();

        if(hp <= 0)
        {
            manager.gameOver();
            Destroy(gameObject);
        }
    }

    public void useMedkit()
    {
        hp = 5;
    }

    public void useRof()
    {
        if(ultraRof == true)
        {
            shootrate = 0.1f;
            grenaderate = 0.5f;

            powerupduration -= Time.deltaTime;

            if (powerupduration <= 0)
            {
                shootrate       = 0.5f;
                grenaderate     = 2;
                powerupduration = powerupreset;
                ultraRof        = false;
            }

        }
    }

    public void setUltraRof()
    {
        ultraRof = true;
    }
    
}
