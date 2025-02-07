using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float frustumWidth;
    Camera mainCamera;
    float distanceToCanvas;
    float fov;
    // Start is called before the first frame update
    void Start()
    {
        fov = Camera.main.fieldOfView;
        mainCamera = Camera.main;
        distanceToCanvas = Mathf.Abs(transform.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        frustumWidth = 2.0f * distanceToCanvas * Mathf.Tan(fov * 0.5f * Mathf.Deg2Rad);
    }
}
