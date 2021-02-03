using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour {

    private BuildingTypeListSO buildingTypeList;
    private BuildingTypeSO buildingType;

    private Camera mainCamera;
    
    private void Awake(){
        buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
        buildingType = buildingTypeList.list[0];
    }

    
    private void Start(){
        mainCamera = Camera.main;

    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)){
            Instantiate(buildingType.prefab,getMouseWorldPosition(), Quaternion.identity);
        }

        if(Input.GetKeyDown(KeyCode.T)){
            buildingType = buildingTypeList.list[0];
        }

        if(Input.GetKeyDown(KeyCode.Y)){
            buildingType = buildingTypeList.list[1];
        }

    }

    private Vector3 getMouseWorldPosition(){
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);        
        mouseWorldPos.z = 0f;
        return mouseWorldPos;
    }
}
