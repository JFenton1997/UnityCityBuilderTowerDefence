using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour{

    private BuildingTypeSO buildingType;
    private float timer;
    private float timerMax;
    [SerializeField] private float generatorRadius = 5f;
    

    private void Awake() {
        buildingType = GetComponent<BuildingTypeHolder>().buildingType;
        timerMax = buildingType.resourceGeneratorData.timerMax;
    }

    private void Start()
    {
        //Physics2D.OverlapCircleAll(transform.position, generatorRadius);
    }

    private void Update() {
        timer -= Time.deltaTime;
        if(timer <= 0f){
            timer+= timerMax;
            ResourceManager.Instance.AddResource(buildingType.resourceGeneratorData.resourceType,1);

        }
        
    }

}
