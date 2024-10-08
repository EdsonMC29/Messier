using System;
using UnityEngine;

class CameraControl: MonoBehaviour
{
    public Camera mainCamera;
    // Variable which makes move faster if zoomed too much
    private double doubleZoomLevel;
    public int intZoomLevel;

    void Start()
    {
        mainCamera = Camera.main;
        doubleZoomLevel = 100;
        intZoomLevel = 100;
    }

    void Update()
    {
        moveCamera();
        zoomCamera();
        rotateCamera();
    }

    void moveCamera() {
        // Forward
        if(Input.GetKey(KeyCode.W)) {
            mainCamera.transform.position += mainCamera.transform.forward * Time.deltaTime * intZoomLevel;
        }
        // Backward
        if(Input.GetKey(KeyCode.S)) {
            mainCamera.transform.position -= mainCamera.transform.forward * Time.deltaTime * intZoomLevel;
        }
        // Left
        if(Input.GetKey(KeyCode.A)) {
            mainCamera.transform.position -= mainCamera.transform.right * Time.deltaTime * intZoomLevel;
        }
        // Right
        if(Input.GetKey(KeyCode.D)) {
            mainCamera.transform.position += mainCamera.transform.right * Time.deltaTime * intZoomLevel;
        }
        // Up
        if(Input.GetKey(KeyCode.Space)) {
            mainCamera.transform.position += mainCamera.transform.up * Time.deltaTime * intZoomLevel;
        }
        // Down
        if(Input.GetKey(KeyCode.LeftShift)) {
            mainCamera.transform.position -= mainCamera.transform.up * Time.deltaTime * intZoomLevel;
        }
    }

    void zoomCamera() {
        if(doubleZoomLevel > 1.01) {
            // Zoom in
            if(Input.GetKey(KeyCode.Q)) {
                mainCamera.transform.position += mainCamera.transform.forward * Time.deltaTime * intZoomLevel;
                doubleZoomLevel = doubleZoomLevel * doubleZoomLevel / 2;
            }
        }else doubleZoomLevel = 1.01;
            // Zoom out
            if(Input.GetKey(KeyCode.E)) {
                mainCamera.transform.position -= mainCamera.transform.forward * Time.deltaTime * intZoomLevel;
                doubleZoomLevel = Math.Sqrt(doubleZoomLevel * 2);
            }
        intZoomLevel = (int)doubleZoomLevel;
    }

    void rotateCamera() {
        // Rotate left
        if(Input.GetKey(KeyCode.LeftArrow)) {
            mainCamera.transform.Rotate(Vector3.up, -1);
        }
        // Rotate right
        if(Input.GetKey(KeyCode.RightArrow)) {
            mainCamera.transform.Rotate(Vector3.up, 1);
        }
        // Rotate up
        if(Input.GetKey(KeyCode.UpArrow)) {
            mainCamera.transform.Rotate(Vector3.right, -1);
        }
        // Rotate down
        if(Input.GetKey(KeyCode.DownArrow)) {
            mainCamera.transform.Rotate(Vector3.right, 1);
        }

    }
    
}