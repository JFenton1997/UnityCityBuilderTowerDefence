using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour {

    public static BuildingManager Instance {get; private set;}

    public event EventHandler<OnActiveBuildingTypeChangeEventArgs> OnActiveBuildingTypeChange;
    
    public  class  OnActiveBuildingTypeChangeEventArgs :EventArgs
    {
        public BuildingTypeSO ActiveBuildingType;
    };
    
    private BuildingTypeListSO buildingTypeList;
    private BuildingTypeSO activeBuildingType;

    
    private void Awake(){
        Instance = this;
        buildingTypeList = Resources.Load<BuildingTypeListSO>(nameof(BuildingTypeListSO));
        activeBuildingType = null;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()){
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            Instantiate(activeBuildingType.prefab,UtilsClass.GetMouseWorldPosition(), Quaternion.identity);
        }
    }

    [ContextMenu("changeActiveSelection")]
    public void SetActiveBuildingType(BuildingTypeSO buildingType){
        activeBuildingType = buildingType;
        OnActiveBuildingTypeChange?.Invoke(this, new OnActiveBuildingTypeChangeEventArgs {ActiveBuildingType = activeBuildingType} );

    }

    public BuildingTypeSO GetActiveBuildingType()
    {
        return activeBuildingType;
    }
}
