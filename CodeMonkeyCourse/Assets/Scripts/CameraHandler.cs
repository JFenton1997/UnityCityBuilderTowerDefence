using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Vector2 zoomClamp = new Vector2(10,30); 
    [SerializeField] private float zoomAmount = 2f;
    [SerializeField] private float zoomSpeed = 5f;
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

    private float orthographicSize;
    private float targetOrthographicSize;

    private void Start() {
        orthographicSize = cinemachineVirtualCamera.m_Lens.OrthographicSize;
        targetOrthographicSize = orthographicSize;
    }

   private void Update() {
       HandleMovement();
       HandleZoom();

   }

    private void HandleMovement(){
        float x = (float)Input.GetAxisRaw("Horizontal");
        float y = (float)Input.GetAxisRaw("Vertical");
        Vector3 movdir = new Vector3(x,y).normalized;
        transform.position += movdir * moveSpeed * Time.deltaTime;
    }


    private void HandleZoom(){
        targetOrthographicSize += -Input.mouseScrollDelta.y * zoomAmount;
        targetOrthographicSize = Mathf.Clamp(targetOrthographicSize,zoomClamp.x,zoomClamp.y);
        orthographicSize = Mathf.Lerp(orthographicSize, targetOrthographicSize, Time.deltaTime*zoomSpeed);
        cinemachineVirtualCamera.m_Lens.OrthographicSize = orthographicSize;

    }




}
