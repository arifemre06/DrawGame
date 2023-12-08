using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class DrawManagerScript : MonoBehaviour
{
    private Camera _mainCamera;
    [SerializeField] private LineScript _linePrefab;
    private LineScript _currentLine;
    private GameManager _gameManager;
    private List<LineScript> _lines;
    

    public const float RESOLUTION = 0.1f;
    public const float UPPERBORDER = 8.52f;
    public const float LOWERBORDER = -8.52f;
    public const float RIGHTBORDER = 16.2f;
    public const float LEFTBORDER = -16.2f;
    
    private void Awake()
    {
        _lines = new List<LineScript>();
    }

    void Start()
    {   
      
        _mainCamera = Camera.main;
        
    }

    void Update()
    {
        Vector2 mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && GameManager.gameState == GameState.DrawPhase)
        {
            if (mousePos.y is < UPPERBORDER and > LOWERBORDER && mousePos.x is < RIGHTBORDER and > LEFTBORDER)
            {
                _currentLine = Instantiate(_linePrefab, mousePos, Quaternion.identity);
                _lines.Add(_currentLine);
                
            }

        }

        if (Input.GetMouseButton(0) && GameManager.gameState == GameState.DrawPhase)
        {   
            if (mousePos.y is < UPPERBORDER and > LOWERBORDER && mousePos.x is < RIGHTBORDER and > LEFTBORDER)
            {
                if (_currentLine != null)
                {
                    _currentLine.SetPointForRenderer(mousePos);
                }
               
            }
            
            
        }    
        
    }

    public void DestroyAllLines()
    {
        //GameObject[] lineScripts = GameObject.FindGameObjectsWithTag("Line");
        
        
          
        for (int i = 0; i < _lines.Count; i++)
        { 
            Destroy(_lines[i].gameObject);
        }
        
        _lines.Clear();
           
        
        
        /*
        for (int i = 0; i < lineScripts.Length; i++)
        {
            Destroy(lineScripts[i].gameObject);
        }
        */
        
    }
}
