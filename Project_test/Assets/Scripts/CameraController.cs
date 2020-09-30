using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float pitch = 2f;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    public float zoomSpeed = 4f;
    public float yawSpeed = 100f;
    
    private float currentYaw = 0f;
    private float currentZoom = 10f;
    

    // Update is called once per frame
    void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;

        if (Input.GetMouseButton(2))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            currentYaw -= Input.GetAxis("Mouse Y") * yawSpeed/10;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        
    }
    
    private void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);
        
        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }
}
