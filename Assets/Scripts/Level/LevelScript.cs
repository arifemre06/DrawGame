using Unity.Burst.CompilerServices;
using UnityEngine;

namespace DefaultNamespace
{   
    
    public class LevelScript : MonoBehaviour
    {
        [SerializeField] private int requiredMoneyForWin;

        public int GetRequiredMoneyForWin()
        {
            return requiredMoneyForWin;
        }
    }
}
