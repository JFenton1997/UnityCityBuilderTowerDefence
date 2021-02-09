using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTypeSelectUI : MonoBehaviour
{
    [SerializeField] private Sprite arrowSprite;
    [SerializeField] private float offsetAmount = 110f;

    private Dictionary<BuildingTypeSO, Transform> btnTransformDictionary;
    private Transform arrowBtn;

    private void Awake()
    {
        var index = 0;
        btnTransformDictionary = new Dictionary<BuildingTypeSO, Transform>();
        Transform btnTemplate = transform.Find("btnTemplate");
        btnTemplate.gameObject.SetActive(false);
        arrowBtn = Instantiate(btnTemplate, transform);
        arrowBtn.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);
        arrowBtn.gameObject.SetActive(true);
        arrowBtn.Find("image").GetComponent<Image>().sprite = arrowSprite;
        arrowBtn.Find("image").GetComponent<RectTransform>().sizeDelta = new Vector2(0, -30);


        arrowBtn.GetComponent<Button>().onClick.AddListener(() =>
        {
            Debug.Log("Selected: Arrow Button [NULL]");
            BuildingManager.Instance.SetActiveBuildingType(null);
            UpdateActiveBuildingTypeButton();
        });
        index++;

        BuildingTypeListSO buildingTypeList = Resources.Load<BuildingTypeListSO>(nameof(BuildingTypeListSO));
        foreach (BuildingTypeSO buildingType in buildingTypeList.list)
        {
            Transform bntTranform = Instantiate(btnTemplate, transform);
            bntTranform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);
            bntTranform.gameObject.SetActive(true);
            bntTranform.Find("image").GetComponent<Image>().sprite = buildingType.sprite;
            bntTranform.GetComponent<Button>().onClick.AddListener(() =>
            {
                Debug.Log("Selected: " + buildingType.nameString);
                BuildingManager.Instance.SetActiveBuildingType(buildingType);

            });

            btnTransformDictionary[buildingType] = bntTranform;

            index++;
        }
        
    }

    private void Start()
    {
        UpdateActiveBuildingTypeButton();
        BuildingManager.Instance.OnActiveBuildingTypeChange += OnActiveBuildingTypeChange;
    }

    private void OnActiveBuildingTypeChange(object sender, BuildingManager.OnActiveBuildingTypeChangeEventArgs e)
    {
        UpdateActiveBuildingTypeButton();
    }


    private void UpdateActiveBuildingTypeButton()
    {
        arrowBtn.Find("selected").gameObject.SetActive(false);
        foreach (Transform button in btnTransformDictionary.Values) button.Find("selected").gameObject.SetActive(false);
        BuildingTypeSO activeBuildingType = BuildingManager.Instance.GetActiveBuildingType();
        if (activeBuildingType)
            btnTransformDictionary[activeBuildingType].Find("selected").gameObject.SetActive(true);
        else
            arrowBtn.Find("selected").gameObject.SetActive(true);
    }
}