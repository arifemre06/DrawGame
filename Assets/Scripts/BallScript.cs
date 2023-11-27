using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    
    void Awake()
    {
        EventManager.GameStateChanged += DestroyBallOnGameStateChanged;
    }

    private void OnDestroy()
    {
        EventManager.GameStateChanged -= DestroyBallOnGameStateChanged;
    }

    private void DestroyBallOnGameStateChanged(GameState oldState, GameState newState)
    {
        if (newState != GameState.InGameMenu)
        {
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
                
        }    
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Finish"))
        {
            EventManager.RaiseBallArrivedToFinish();
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
    }
    
    
    void Update()
    {
        
    }
    
    
}
