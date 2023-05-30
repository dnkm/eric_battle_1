using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrthographicZoom : MonoBehaviour
{
    public Camera cam;
    public float maxZoom =5;
    public float minZoom =20;
    public float sensitivity = 1;
    public float speed =30;
    float targetZoom;
    
    Vector2 mouseClickPos;
    Vector2 mouseCurrentPos;
    bool panning = false;

    public float dragSpeed = 50;
    private Vector3 dragOrigin;
    void Start()
    {
        targetZoom = cam.orthographicSize;
    }
    void Update()
    {
        
        MoveCamera();
        
        targetZoom -= Input.mouseScrollDelta.y * sensitivity;
        targetZoom = Mathf.Clamp(targetZoom, maxZoom, minZoom);
        float newSize = Mathf.MoveTowards(cam.orthographicSize, targetZoom, speed * Time.deltaTime);
        cam.orthographicSize = newSize;
    }
    
    void MoveCamera()
    {
        
        /*if (Input.GetMouseButton(1))
        {
            float speed = dragSpeed * Time.deltaTime;
            cam.transform.position += new Vector3(Input.GetAxis("Mouse X") * speed, Input.GetAxis("Mouse Y") * speed, 0);
        }*/
        
        // When LMB clicked get mouse click position and set panning to true
        if (Input.GetKeyDown(KeyCode.Mouse0) && !panning)
        {
            mouseClickPos = cam.ScreenToWorldPoint(Input.mousePosition);
            panning = true;
        }
        // If LMB is already clicked, move the camera following the mouse position update
        if (panning)
        {
            mouseCurrentPos = cam.ScreenToWorldPoint(Input.mousePosition);
            var distance = mouseCurrentPos - mouseClickPos;
            transform.position += new Vector3(-distance.x,-distance.y,0);
        }
 
        // If LMB is released, stop moving the camera
        if (Input.GetKeyUp(KeyCode.Mouse0))
            panning = false;
    }
}