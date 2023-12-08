using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "CollectableData", menuName = "Game/CollactableData", order = 0)]
    public class CollectableData : ScriptableObject
    {
        [SerializeField] private List<CollectableType> keys;
        [SerializeField] private List<CollectableMeta> values;


        public CollectableMeta GetCollectableMeta(CollectableType type)
        {
            for (int i = 0; i < keys.Count; i++)
            {
                if (keys[i].Equals(type))
                {
                    return values[i];
                }
            }
            return null;
        }
        
    }
    
   
}