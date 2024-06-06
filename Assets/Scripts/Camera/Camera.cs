using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Camera : MonoBehaviour

{
    [SerializeField] float cameraSize = 10;
    [SerializeField] float maxCameraSize = 17f;



    void Start()
    {
        UnityEngine.Camera.main.orthographicSize = cameraSize;
    }

    void Update()
    {

        if (cameraSize > 1 && cameraSize < maxCameraSize)
        {
            UnityEngine.Camera.main.orthographicSize -= Input.mouseScrollDelta.y;
        }
        
        if(cameraSize >= maxCameraSize)
        {
            UnityEngine.Camera.main.orthographicSize = maxCameraSize - 0.0001f;
            cameraSize = 14.0000009f;
        }
        if(cameraSize <= 1)
        {
            UnityEngine.Camera.main.orthographicSize = 1.0000001f;
            cameraSize = 1.0000001f;
        }

        cameraSize = UnityEngine.Camera.main.orthographicSize;
    }
}
