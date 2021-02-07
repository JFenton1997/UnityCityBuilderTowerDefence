using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTypeSelectUI : MonoBehaviour
{
        [SerializeField]
        private float offsetAmount = 160f;

    private void Awake() {
        Transform btnTemplate = transform.Find("btnTemplate");
        btnTemplate.gameObject.SetActive(false);


        BuildingTypeListSO buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
        int index = 0;
        foreach (BuildingTypeSO buildingType in buildingTypeList.list){
            Transform bntTranform = Instantiate(btnTemplate, transform);
            bntTranform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);
            bntTranform.gameObject.SetActive(true);
            bntTranform.Find("image").GetComponent<Image>().sprite = buildingType.sprite;

            bntTranform.GetComponent<Button>().onClick.AddListener(() => {
                Debug.Log("Selected: " + buildingType.nameString);
                BuildingManager.Instance.SetActiveBuildingType(buildingType);
            });

            index++;


        }
    }
}
