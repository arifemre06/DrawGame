using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using DefaultNamespace;
using UnityEngine;

public class CollectableScripts : MonoBehaviour
{
    [SerializeField] private CollectableType collectableType;
    [SerializeField] private CollectableData collectableData;
    private SpriteRenderer _renderer;
    private int _money;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {   
        
        CollectableMeta collectableMeta = collectableData.GetCollectableMeta(collectableType);
        _money = collectableMeta.Value;
        _renderer.sprite = collectableMeta.Sprite;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {   
        Debug.Log(col.tag);
        if (col.CompareTag("Player"))
        {
            EventManager.RaiseOnCollectablesCollected(_money);
            Destroy(gameObject);
        }    
    }
}
