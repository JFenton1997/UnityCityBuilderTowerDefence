using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour {

    public static BuildingManager Instance {get; private set;}
    private BuildingTypeListSO buildingTypeList;
    private BuildingTypeSO activeBuildingType;

    private Camera mainCamera;
    
    private void Awake(){
        Instance = this;
        buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
        activeBuildingType = buildingTypeList.list[0];
    }

    
    private void Start(){
        mainCamera = Camera.main;

    }

    private void Update() {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()){
            Instantiate(activeBuildingType.prefab,GetMouseWorldPosition(), Quaternion.identity);
        }
    }

    private Vector3 GetMouseWorldPosition(){
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);        
        mouseWorldPos.z = 0f;
        return mouseWorldPos;
    }

    public void SetActiveBuildingType(BuildingTypeSO buildingType){
        activeBuildingType = buildingType;

    }
}
