using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Collider    player;
    public GameObject  silly;
    public bool        isInfinite;
    public float       spawnRate;
    private float      enemyType;

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
                Instantiate(silly, transform.position, transform.rotation);
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
                Instantiate(silly, transform.position, transform.rotation);
                spawnRate = Random.Range(5, 8);
            }
        }
        
    }

}
