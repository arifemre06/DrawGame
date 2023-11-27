using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawmZoneScript : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    void Awake()
    {
        EventManager.StartHeistButtonClicked += OnStartHeist;
    }

    private void OnDestroy()
    {
        EventManager.StartHeistButtonClicked -= OnStartHeist;
    }

    private void OnStartHeist()
    {
        Instantiate(ballPrefab,transform.position, quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
