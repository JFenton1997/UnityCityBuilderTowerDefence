using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceUI : MonoBehaviour{

    [SerializeField]
    private float offsetAmount = -40;

    private ResourceTypeListSO resourceTypeList;
    private Dictionary<ResourceTypeSO,Transform> resourceTypeTransformDictionary;

    private void Awake(){
        resourceTypeTransformDictionary = new Dictionary<ResourceTypeSO, Transform>();
        resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);

        Transform resourceTemplate = transform.Find("resourceTemplate");
        resourceTemplate.gameObject.SetActive(false);
        int index = 0;
        foreach (ResourceTypeSO resourceType in resourceTypeList.list){
            Transform resourceTransform = Instantiate(resourceTemplate, transform);
            resourceTransform.gameObject.SetActive(true);
            resourceTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);
            resourceTransform.Find("image").GetComponent<Image>().sprite = resourceType.sprite;
            resourceTypeTransformDictionary[resourceType] = resourceTransform;
            index++;
        }
    }

    private void Start() {
        ResourceManager.Instance.OnResourceAmountChanged += ResouceManager_OnResourceAmountChanged;
        UpdateResourceAmount();
        
    }

    private void ResouceManager_OnResourceAmountChanged(object sender, System.EventArgs e)
    {
        UpdateResourceAmount();
    }

    private void UpdateResourceAmount(){
           foreach (ResourceTypeSO resourceType in resourceTypeList.list){
                Transform resourceTransform = resourceTypeTransformDictionary[resourceType];
                int resourceAmount = ResourceManager.Instance.GetResouceAmount(resourceType);              
                resourceTransform.Find("text").GetComponent<TextMeshProUGUI>().SetText(resourceAmount.ToString());
           }
    }
}
