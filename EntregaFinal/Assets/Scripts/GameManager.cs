using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float      restartTimer = 3;
    private bool      startTimer   = false;
    private bool      victory      = false;

    public AudioSource menuMusic;
    
    void Start()
    {
        menuMusic.Play();

        restartTimer = 3;
    }

    
    void Update()
    {
        if(startTimer == true)
        {
            restartTimer -= Time.deltaTime;

            if(restartTimer <= 0 && victory == false)
            {
                SceneManager.LoadScene("DeathMenu");
            }
            else if (restartTimer <= 0 && victory == true)
            {
                SceneManager.LoadScene("WinMenu");
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

    public void startGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void loadMenu()
    {
        menuMusic.Play();
        SceneManager.LoadScene("MainMenu");
    }
}
