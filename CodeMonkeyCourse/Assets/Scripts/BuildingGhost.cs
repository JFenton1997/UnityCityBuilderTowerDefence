using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGhost : MonoBehaviour
{
    private GameObject spriteGameObject;
    private void Awake()
    {
        spriteGameObject = transform.Find("sprite").gameObject;
        Hide();

    }

    private void Start()
    {
        BuildingManager.Instance.OnActiveBuildingTypeChange += InstanceOnOnActiveBuildingTypeChange;
    }

    private void InstanceOnOnActiveBuildingTypeChange(object sender, BuildingManager.OnActiveBuildingTypeChangeEventArgs e)
    {
        BuildingTypeSO buildingType = e.ActiveBuildingType;
        if(buildingType == null)
            Hide();
        else
        {
            Show(buildingType.sprite);
        }
    }

    private void Update()
    {
        transform.position = UtilsClass.GetMouseWorldPosition();
    }

    private void Hide()
    {
        spriteGameObject.SetActive(false);
    }

    private void Show(Sprite ghostSprite)
    {
        spriteGameObject.SetActive(true);
        spriteGameObject.GetComponent<SpriteRenderer>().sprite = ghostSprite;
    }
}
