using System;
using UnityEngine;

namespace DefaultNamespace
{   
    [Serializable]
    public class CollectableMeta
    {
        
        [SerializeField] private Sprite sprite;

        [SerializeField] private int value;
        

        public Sprite Sprite => sprite;

        public int Value => value;
        
        
    }
}