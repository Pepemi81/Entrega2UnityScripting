using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public Image playerHp;


    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void PlayerLifeBar(int amount, int maxLife)
    {
        Debug.Log("Life");
        playerHp.fillAmount = (float)amount / maxLife;
    }
}
