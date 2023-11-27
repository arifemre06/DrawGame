using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class CollectableScripts : MonoBehaviour
{

    [SerializeField]
    private int money;

    private void OnTriggerEnter2D(Collider2D col)
    {   
        Debug.Log(col.tag);
        if (col.CompareTag("Player"))
        {
            EventManager.RaiseOnCollectablesCollected(money);
            Destroy(gameObject);
        }    
    }
}
