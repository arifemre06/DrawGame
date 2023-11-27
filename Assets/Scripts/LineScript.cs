using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    [SerializeField] private LineRenderer _renderer;
    [SerializeField] private EdgeCollider2D _collider;
    private readonly List<Vector2> _colliderPoints = new List<Vector2>(); 
    void Start()
    {
        _collider.transform.position -= transform.position;
    }

    
    void Update()
    {
        
    }

    public void SetPointForRenderer(Vector2 pos)
    {
        if (!CanAddNewPoint(pos))
        {
            return;
        }
        else
        {   
            _colliderPoints.Add(pos);
            _renderer.positionCount++;
            _renderer.SetPosition(_renderer.positionCount -1,pos);
            
            _collider.points = _colliderPoints.ToArray();
        }
    }

    private bool CanAddNewPoint(Vector2 pos)
    {
        if (_renderer.positionCount == 0)
        {
            return true;
        }
        else
        {
            return Vector2.Distance(_renderer.GetPosition(_renderer.positionCount - 1), pos) >
                   DrawManagerScript.RESOLUTION;
        }
    }
}
