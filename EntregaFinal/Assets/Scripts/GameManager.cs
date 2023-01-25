using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float      restartTimer = 3;
    private bool      startTimer   = false;
    private bool      victory      = false;
    
    void Start()
    {
        restartTimer = 3;
    }

    
    void Update()
    {
        if(startTimer == true)
        {
            restartTimer -= Time.deltaTime;

            if(restartTimer <= 0 && victory == false)
            {
                
            }
            else if (restartTimer <= 0 && victory == true)
            {

            }
        }
    }

    public void gameOver()
    {
        victory = false;
        startTimer = true;

    }

    public void youWin()
    {
        victory = true;
        startTimer = true;
        
    }
}
