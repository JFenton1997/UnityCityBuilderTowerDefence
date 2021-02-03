using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour{

    public static ResourceManager Instance {get; private set;}


    public event EventHandler OnResourceAmountChanged;
    private Dictionary<ResourceTypeSO, int> resourceAmountDictionary;

    private void Awake(){
        Instance = this;
        resourceAmountDictionary = new Dictionary<ResourceTypeSO, int>();
        ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);

        foreach(ResourceTypeSO resourceType in resourceTypeList.list){
            resourceAmountDictionary[resourceType] = 0;
        }
        TestLogResourceAmountDictionary();
    }

    private void TestLogResourceAmountDictionary(){
        foreach (ResourceTypeSO resourceType in resourceAmountDictionary.Keys){
            Debug.Log(resourceType.nameString + ":" + resourceAmountDictionary[resourceType]);

        }
    }

    public void AddResource (ResourceTypeSO resourceType, int amount){
        resourceAmountDictionary[resourceType] += amount;
        // ? means if not null, so if object isnt null, then run (is null if no listerners to event)
        OnResourceAmountChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetResouceAmount(ResourceTypeSO resourceType){
        return resourceAmountDictionary[resourceType];
    }
}
