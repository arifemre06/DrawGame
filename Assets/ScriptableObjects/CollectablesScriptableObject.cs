using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CollectablesScriptableObject", order = 1)]
public class CollectablesScriptableObject : ScriptableObject
{
    public int MoneyAmount;
    public Sprite sprite;
}
