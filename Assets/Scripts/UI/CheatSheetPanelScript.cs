using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
namespace DefaultNamespace.UI
{
    public class CheatSheetPanelScript : UIPanel
    {
        [SerializeField] private CollectableData collectableData;
        [SerializeField] private Transform collectableUITemplate;
        [SerializeField] private Button closeButton;
        
        private List<CollectableMeta> _collectableMetaList;

        private void Start()
        {
            closeButton.onClick.AddListener(OnCloseButtonClicked);
            
            _collectableMetaList = collectableData.GetAllCollectablesMeta();
            collectableUITemplate.gameObject.SetActive(false);
            
            int index = 0;
            foreach (CollectableMeta collectableMeta in _collectableMetaList)
            {   
                Transform collectableUITransform =Instantiate(collectableUITemplate, transform);
                collectableUITransform.gameObject.SetActive(true);
                float offset = -80f;
                float xoffset = 180f;
                int xindex = 0;
                if (index % 5 == 0 && index != 0)
                {
                    xindex += 1;
                    index = 0;
                }
                collectableUITransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(xindex * xoffset, index * offset);
                collectableUITransform.Find("Image").GetComponent<Image>().sprite = collectableMeta.Sprite;
                collectableUITransform.Find("Valuetext").GetComponent<TextMeshProUGUI>().text=collectableMeta.Value.ToString() + "$";
                index++;
                Debug.Log(index+" evet bakalim");

            }
        }

        private void OnCloseButtonClicked()
        {
            EventManager.RaiseCheatSheetClosed();
        }
    
    }
}
