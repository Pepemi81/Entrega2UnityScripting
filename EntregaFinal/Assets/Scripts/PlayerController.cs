using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody cuerpo;

    public float speed = 10;
    public float sens = 1;
    public Vector2 turn;

    // Start is called before the first frame update
    void Start()
    {
        cuerpo = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //Movement

        float finput = Input.GetAxis("Vertical");

        Vector3 inputvert = new Vector3(0, 0, finput);

        cuerpo.AddRelativeForce(inputvert * Time.deltaTime * speed);


           
        float sinput = Input.GetAxis("Horizontal");

        Vector3 inputhor = new Vector3(sinput, 0, 0);

        cuerpo.AddRelativeForce(inputhor * Time.deltaTime * speed);

        //Rotation

        turn.y = Input.GetAxis("Horizontal 2");
        transform.Rotate(turn * Time.deltaTime * sens, Space.Self);

        Debug.Log("Turn" + turn);

    }
}
