using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class LevelManagerScript : MonoBehaviour
    {
        [SerializeField] private LevelScript[] levelPrefabs;
        
        public Action LevelDestroyed;
        private LevelScript currentLevel;
        private int currentLevelIndex;

        public void PrepareCurrentLevel()
        {
            if (currentLevel != null)
            {
                DestroyLevel();
            }

            if (levelPrefabs[currentLevelIndex] != null)
            {
                CreateLevel(currentLevelIndex);
            }
            else
            {
                CreateLevel(0);
            }
            
        }

        private void CreateLevel(int levelIndex)
        {   
            Debug.Log($"levelIndex {levelIndex}");
            
            currentLevel = Instantiate(levelPrefabs[levelIndex], Vector3.zero ,Quaternion.identity);
            EventManager.RaiseLevelCreated(GetRequiredGoldForWin());
            EventManager.RaiseOnCollectablesCollected(0);
        }

        private void DestroyLevel()
        {
            Destroy(currentLevel.gameObject);
            LevelDestroyed?.Invoke();
        }
        /*
        public PlayerManager GetPlayerManager()
        {
            return currentLevel.GetPlayerManager();
        }
        */
        public void SetLevelIndexToNextLevel()
        {   
            Debug.Log($"currentLevelIndex {currentLevelIndex}");
            currentLevelIndex += 1;
            
        }

        private int GetRequiredGoldForWin()
        {
            return levelPrefabs[currentLevelIndex].GetRequiredMoneyForWin();
        }
    }
}
