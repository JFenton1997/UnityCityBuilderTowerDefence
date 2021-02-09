using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePositionSortingOrder : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    
    [SerializeField]
    private const float PrecisionMultiplier = 5f;

    [SerializeField] private float positionOffset;

    [SerializeField] private bool runOnce = true;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {

        spriteRenderer.sortingOrder = -(int) (transform.position.y + positionOffset * PrecisionMultiplier);

        if (runOnce)
        {
            Destroy(this);
        }
    }
}
