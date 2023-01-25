using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Collider    player;
    public GameObject  silly;
    public bool        isInfinite;
    public float       spawnRate;
    public float       offsetX;
    public float       offsetZ;


    void Start()
    {
        spawnRate = Random.Range(5, 8);
    }


    void Update()
    {
        if (isInfinite == true)
        {
            spawnRate -= Time.deltaTime;

            if(spawnRate <= 0 )
            {
                offsetX = Random.Range(-10, 11);
                offsetZ = Random.Range(-10, 11);
                Instantiate(silly, new Vector3(offsetX, 0.6f, offsetZ), transform.rotation);
                spawnRate = Random.Range(5, 8);
            }
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && isInfinite == false)
        {
            spawnRate -= Time.deltaTime;

            if (spawnRate <= 0)
            {
                offsetX = Random.Range(-10, 11);
                offsetZ = Random.Range(-10, 11);
                Instantiate(silly, new Vector3(offsetX, 0.6f, offsetZ), transform.rotation);
                spawnRate = Random.Range(5, 8);
            }
        }
        
    }

}
